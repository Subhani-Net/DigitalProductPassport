using System.Text.Json;
using DppCore;

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
var client = new RegistryClient(http);

string token;
try
{
    token = await client.GetTokenAsync(tokenUrl, clientId!, clientSecret!);
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Token failed: {ex.Message}");
    return 1;
}
Console.WriteLine("Token obtained.");

var payload = await File.ReadAllTextAsync(entryFile);
var (regStatus, regBody) = await client.RegisterAsync(registryUrl, payload, token);
Console.WriteLine($"Register: {regStatus}");
if (regStatus is < 200 or >= 300)
{
    Console.Error.WriteLine(regBody);
    return 1;
}

using var regDoc = JsonDocument.Parse(regBody);
var registryId = regDoc.RootElement.GetProperty("registryId").GetString()!;
Console.WriteLine($"registryId: {registryId}");
if (regDoc.RootElement.TryGetProperty("dppHash", out var dppHash)) Console.WriteLine($"dppHash: {dppHash}");
if (regDoc.RootElement.TryGetProperty("contentType", out var ctype)) Console.WriteLine($"contentType: {ctype}");

var (proofStatus, proof) = await client.GetProofAsync(registryUrl, registryId, token);
Console.WriteLine($"Proof: {proofStatus}");
Console.WriteLine(proof);
return 0;
