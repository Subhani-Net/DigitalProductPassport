using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;
using Xunit;

namespace DppCore.Tests;

/// <summary>
/// Validates the calc-input schema and sample against JSON Schema draft 2020-12 — the same
/// validation vocabulary the CBAM Registry uses.
/// </summary>
public class CalcInputSchemaTests
{
    private static string SchemaText() => File.ReadAllText(Repo.Path("product/src/model/calc-inputs.schema.json"));
    private static string SampleText() => File.ReadAllText(Repo.Path("product/src/fixtures/steel-calc-inputs.sample.json"));

    // Build once — JsonSchema.Net registers by $id and refuses re-registration.
    private static readonly JsonSchema Schema = JsonSchema.FromText(SchemaText());

    private static JsonElement Element(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.Clone();
    }

    [Fact]
    public void Schema_is_valid_json_schema_2020_12()
    {
        var node = JsonNode.Parse(SchemaText())!.AsObject();
        Assert.Equal("https://json-schema.org/draft/2020-12/schema", node["$schema"]?.GetValue<string>());
        Assert.NotNull(Schema);
    }

    [Fact]
    public void Sample_fixture_is_valid_against_the_schema()
    {
        var result = Schema.Evaluate(Element(SampleText()));
        Assert.True(result.IsValid, "sample fixture must validate against the calc-input schema");
    }

    [Fact]
    public void Invalid_payload_is_rejected()
    {
        var node = JsonNode.Parse(SampleText())!.AsObject();
        node.Remove("electricity"); // electricity is required

        var result = Schema.Evaluate(Element(node.ToJsonString()));
        Assert.False(result.IsValid);
    }
}
