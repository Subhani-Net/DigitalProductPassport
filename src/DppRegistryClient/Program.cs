using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

const string DefaultRegistry = "http://localhost:8082";
const string DefaultToken = "http://localhost:8180/realms/cirpass-2/protocol/openid-connect/token";

var registryUrl = Environment.GetEnvironmentVariable("REGISTRY_URL") ?? DefaultRegistry;
var tokenUrl = Environment.GetEnvironmentVariable("TOKEN_URL") ?? DefaultToken;
var clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
var clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
var entryFile = Environment.GetEnvironmentVariable("ENTRY_FILE") ?? "fixtures/registry-entry.model.sample.json";

if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
{
    Console.Error.WriteLine("Missing CLIENT_ID / CLIENT_SECRET environment variables.");
    return 2;
}
if (!File.Exists(entryFile))
{
    Console.Error.WriteLine($"Entry file not found: {entryFile}");
    return 2;
}

using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };

// 1) OIDC client-credentials token
var form = new Dictionary<string, string>
{
    ["client_id"] = clientId!,
    ["client_secret"] = clientSecret!,
    ["grant_type"] = "client_credentials"
};
using var tokenResp = await http.PostAsync(tokenUrl, new FormUrlEncodedContent(form));
var tokenBody = await tokenResp.Content.ReadAsStringAsync();
if (!tokenResp.IsSuccessStatusCode)
{
    Console.Error.WriteLine($"Token failed: {(int)tokenResp.StatusCode} {tokenResp.StatusCode}\n{tokenBody}");
    return 1;
}
using var tokenDoc = JsonDocument.Parse(tokenBody);
var token = tokenDoc.RootElement.GetProperty("access_token").GetString()!;
Console.WriteLine("Token obtained.");
http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

// 2) Register DPP metadata
var payload = await File.ReadAllTextAsync(entryFile);
using var content = new StringContent(payload, Encoding.UTF8, "application/json");
var regUrl = $"{registryUrl.TrimEnd('/')}/metadata/v1/registerDPP";
using var regResp = await http.PostAsync(regUrl, content);
var regBody = await regResp.Content.ReadAsStringAsync();
Console.WriteLine($"Register: {(int)regResp.StatusCode} {regResp.StatusCode}");
if (!regResp.IsSuccessStatusCode)
{
    Console.Error.WriteLine(regBody);
    return 1;
}

using var regDoc = JsonDocument.Parse(regBody);
var registryId = regDoc.RootElement.GetProperty("registryId").GetString()!;
Console.WriteLine($"registryId: {registryId}");
if (regDoc.RootElement.TryGetProperty("dppHash", out var dppHash)) Console.WriteLine($"dppHash: {dppHash}");
if (regDoc.RootElement.TryGetProperty("contentType", out var ctype)) Console.WriteLine($"contentType: {ctype}");

// 3) Proof of registration
var proofUrl = $"{registryUrl.TrimEnd('/')}/metadata/v1/{registryId}/proof";
using var proofResp = await http.GetAsync(proofUrl);
var proof = await proofResp.Content.ReadAsStringAsync();
Console.WriteLine($"Proof: {(int)proofResp.StatusCode} {proofResp.StatusCode}");
Console.WriteLine(proof);
return 0;
