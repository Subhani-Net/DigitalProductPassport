using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DppCore;

/// <summary>
/// Minimal client for a DPP metadata registry (CIRPASS-2 mock, or the EC test/live env):
/// OIDC client-credentials token → register metadata → fetch Proof of Registration.
/// </summary>
public sealed class RegistryClient
{
    private readonly HttpClient _http;

    public RegistryClient(HttpClient http) => _http = http;

    public async Task<string> GetTokenAsync(string tokenUrl, string clientId, string clientSecret, CancellationToken ct = default)
    {
        var form = new Dictionary<string, string>
        {
            ["client_id"] = clientId,
            ["client_secret"] = clientSecret,
            ["grant_type"] = "client_credentials"
        };

        using var resp = await _http.PostAsync(tokenUrl, new FormUrlEncodedContent(form), ct);
        var body = await resp.Content.ReadAsStringAsync(ct);
        resp.EnsureSuccessStatusCode();

        using var doc = JsonDocument.Parse(body);
        return doc.RootElement.GetProperty("access_token").GetString()
            ?? throw new InvalidOperationException("access_token missing in token response");
    }

    public async Task<(int StatusCode, string Body)> RegisterAsync(string registryUrl, string payload, string token, CancellationToken ct = default)
    {
        using var req = new HttpRequestMessage(HttpMethod.Post, $"{registryUrl.TrimEnd('/')}/metadata/v1/registerDPP")
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        using var resp = await _http.SendAsync(req, ct);
        return ((int)resp.StatusCode, await resp.Content.ReadAsStringAsync(ct));
    }

    public async Task<(int StatusCode, string Body)> GetProofAsync(string registryUrl, string registryId, string token, CancellationToken ct = default)
    {
        using var req = new HttpRequestMessage(HttpMethod.Get, $"{registryUrl.TrimEnd('/')}/metadata/v1/{registryId}/proof");
        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        using var resp = await _http.SendAsync(req, ct);
        return ((int)resp.StatusCode, await resp.Content.ReadAsStringAsync(ct));
    }
}
