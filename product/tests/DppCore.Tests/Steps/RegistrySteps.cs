using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using DppCore;
using Reqnroll;
using Xunit;

namespace DppCore.Tests.Steps;

/// <summary>
/// Integration BDD steps for registry connectivity, authorization and registration.
/// These run against the CIRPASS-2 test environment (docker, from reference/deploy-resources)
/// and its Keycloak realm (reference/deploy-resources/keycloak). When the environment or
/// credentials are absent, steps no-op (graceful skip) — run them with the env up to validate.
/// </summary>
[Binding]
public sealed class RegistrySteps
{
    private readonly ScenarioContext _ctx;
    private readonly HttpClient _http;

    public RegistrySteps(ScenarioContext ctx)
    {
        _ctx = ctx;
        _http = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
    }

    private string RegistryUrl() => Environment.GetEnvironmentVariable("REGISTRY_URL") ?? "http://localhost:8082";
    private string TokenUrl() => Environment.GetEnvironmentVariable("TOKEN_URL") ?? "http://localhost:8180/realms/cirpass-2/protocol/openid-connect/token";

    private bool Ready() => _ctx.TryGetValue("ready", out bool r) && r;

    [Given(@"the CBAM registry is running")]
    public async Task GivenRegistryRunning()
    {
        var ready = await Reachable($"{RegistryUrl().TrimEnd('/')}/q/openapi");
        _ctx.Set(ready, "ready");
        if (ready) _ctx.Set(new RegistryClient(_http), "client");
    }

    [When(@"I call the registry health endpoint")]
    public async Task WhenHealth()
    {
        if (!Ready()) return;
        using var resp = await _http.GetAsync($"{RegistryUrl().TrimEnd('/')}/q/openapi");
        _ctx.Set((int)resp.StatusCode, "status");
    }

    [Then(@"the response status is 200")]
    public void Then200() { if (Ready()) Assert.Equal(200, _ctx.Get<int>("status")); }

    [Then(@"the response status is 201")]
    public void Then201() { if (Ready()) Assert.Equal(201, _ctx.Get<int>("status")); }

    [Given(@"the economic operator credentials are available")]
    public void GivenCredentials()
    {
        var id = Environment.GetEnvironmentVariable("CLIENT_ID");
        var secret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
        var ok = !string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(secret);
        _ctx.Set(ok, "creds");
        _ctx.Set(ok && Ready(), "ready");
    }

    [When(@"I request an OIDC token")]
    public async Task WhenToken()
    {
        if (!Ready()) return;
        var client = _ctx.Get<RegistryClient>("client");
        var token = await client.GetTokenAsync(
            TokenUrl(),
            Environment.GetEnvironmentVariable("CLIENT_ID")!,
            Environment.GetEnvironmentVariable("CLIENT_SECRET")!);
        _ctx.Set(token, "token");
        _ctx.Set(ParseRoles(token), "roles");
    }

    [Then(@"I receive an access token with the eo role")]
    public void ThenEoRole() { if (Ready()) Assert.Contains("eo", _ctx.Get<string[]>("roles")); }

    [When(@"I register a passport without a token")]
    public async Task WhenRegisterNoToken()
    {
        if (!Ready()) return;
        var entry = File.ReadAllText(Repo.Path("product/src/fixtures/registry-entry.model.sample.json"));
        using var resp = await _http.PostAsync(
            $"{RegistryUrl().TrimEnd('/')}/metadata/v1/registerDPP",
            new StringContent(entry, Encoding.UTF8, "application/json"));
        _ctx.Set((int)resp.StatusCode, "status");
    }

    [Then(@"the response status is 401 or 403")]
    public void Then401Or403() { if (Ready()) Assert.Contains(_ctx.Get<int>("status"), new[] { 401, 403 }); }

    [When(@"I register the sample passport metadata")]
    public async Task WhenRegister()
    {
        if (!Ready()) return;
        var entry = File.ReadAllText(Repo.Path("product/src/fixtures/registry-entry.model.sample.json"));
        var (status, body) = await _ctx.Get<RegistryClient>("client").RegisterAsync(RegistryUrl(), entry, _ctx.Get<string>("token"));
        _ctx.Set(status, "status");
        _ctx.Set(body, "regBody");
    }

    [Then(@"I receive a registry identifier")]
    public void ThenRegistryId()
    {
        if (!Ready()) return;
        using var doc = JsonDocument.Parse(_ctx.Get<string>("regBody"));
        var id = doc.RootElement.GetProperty("registryId").GetString();
        Assert.False(string.IsNullOrWhiteSpace(id));
        _ctx.Set(id!, "registryId");
    }

    [When(@"I fetch the proof of registration")]
    public async Task WhenProof()
    {
        if (!Ready()) return;
        var (status, body) = await _ctx.Get<RegistryClient>("client").GetProofAsync(RegistryUrl(), _ctx.Get<string>("registryId"), _ctx.Get<string>("token"));
        _ctx.Set(status, "proofStatus");
        _ctx.Set(body, "proof");
    }

    [Then(@"the proof response status is 200")]
    public void ThenProof200() { if (Ready()) Assert.Equal(200, _ctx.Get<int>("proofStatus")); }

    [Then(@"the proof is a signed JWT")]
    public void ThenProofJwt()
    {
        if (!Ready()) return;
        var proof = _ctx.Get<string>("proof");
        Assert.NotNull(proof);
        Assert.Equal(2, proof!.Count(c => c == '.')); // header.payload.signature
    }

    private static async Task<bool> Reachable(string url)
    {
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
            using var resp = await http.GetAsync(url);
            return (int)resp.StatusCode is >= 200 and < 500;
        }
        catch { return false; }
    }

    private static string[] ParseRoles(string jwt)
    {
        var payload = jwt.Split('.')[1];
        payload = payload.Replace('-', '+').Replace('_', '/');
        switch (payload.Length % 4) { case 2: payload += "=="; break; case 3: payload += "="; break; }
        using var doc = JsonDocument.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(payload)));
        if (doc.RootElement.TryGetProperty("realm_access", out var realm) &&
            realm.TryGetProperty("roles", out var roles))
        {
            return roles.EnumerateArray().Select(e => e.GetString() ?? "").ToArray();
        }
        return Array.Empty<string>();
    }
}
