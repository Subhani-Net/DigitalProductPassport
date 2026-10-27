using System.Text.Json;
using DppCore;
using Xunit;
using Xunit.Abstractions;

namespace DppCore.Tests;

/// <summary>
/// End-to-end registry round-trip. Requires the CIRPASS-2 test environment + credentials
/// (CLIENT_ID / CLIENT_SECRET env vars). When the environment is unavailable the test is
/// skipped gracefully (not a failure).
/// </summary>
[Trait("Category", "Integration")]
public class RegistryClientIntegrationTests
{
    private readonly ITestOutputHelper _out;

    public RegistryClientIntegrationTests(ITestOutputHelper output) => _out = output;

    private static bool TryEnv(string name, out string value)
    {
        value = Environment.GetEnvironmentVariable(name) ?? "";
        return !string.IsNullOrWhiteSpace(value);
    }

    [Fact]
    public async Task Register_and_fetch_proof_roundtrip()
    {
        var registryUrl = Environment.GetEnvironmentVariable("REGISTRY_URL") ?? "http://localhost:8082";
        var tokenUrl = Environment.GetEnvironmentVariable("TOKEN_URL") ?? "http://localhost:8180/realms/cirpass-2/protocol/openid-connect/token";

        if (!TryEnv("CLIENT_ID", out var clientId) || !TryEnv("CLIENT_SECRET", out var clientSecret))
        {
            _out.WriteLine("SKIP: CLIENT_ID / CLIENT_SECRET env vars not set.");
            return;
        }

        using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(8) };
        if (!await Reachable(http, $"{registryUrl.TrimEnd('/')}/q/openapi"))
        {
            _out.WriteLine($"SKIP: registry not reachable at {registryUrl}.");
            return;
        }

        var client = new RegistryClient(http);
        var token = await client.GetTokenAsync(tokenUrl, clientId, clientSecret);

        var entry = File.ReadAllText(Repo.Path("product/src/fixtures/registry-entry.model.sample.json"));
        var (regStatus, regBody) = await client.RegisterAsync(registryUrl, entry, token);
        Assert.Equal(201, regStatus);

        using var doc = JsonDocument.Parse(regBody);
        var registryId = doc.RootElement.GetProperty("registryId").GetString();
        Assert.False(string.IsNullOrWhiteSpace(registryId));

        var (proofStatus, proof) = await client.GetProofAsync(registryUrl, registryId!, token);
        Assert.Equal(200, proofStatus);
        Assert.Contains('.', proof); // compact JWS has two dots
        _out.WriteLine($"OK: registered {registryId}, proof retrieved.");
    }

    private static async Task<bool> Reachable(HttpClient http, string url)
    {
        try
        {
            using var resp = await http.GetAsync(url);
            return (int)resp.StatusCode is >= 200 and < 500;
        }
        catch
        {
            return false;
        }
    }
}
