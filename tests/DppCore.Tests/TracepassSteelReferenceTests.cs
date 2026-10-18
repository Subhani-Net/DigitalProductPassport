using System.Text.Json.Nodes;
using Xunit;

namespace DppCore.Tests;

/// <summary>
/// Uses the EU reference dump (reference/tracepass-dpp-schemas) to validate that our data
/// model direction covers the CBAM/steel fields the EU actually mandates. This is the
/// "reference folder as test oracle" pattern.
/// </summary>
public class TracepassSteelReferenceTests
{
    private static JsonArray? Fields()
    {
        var path = Repo.Path("reference/tracepass-dpp-schemas/templates/steel.json");
        if (!File.Exists(path)) return null; // reference clone absent -> test no-ops
        return JsonNode.Parse(File.ReadAllText(path))!["fields"]!.AsArray();
    }

    private static HashSet<string> Keys()
    {
        var fields = Fields();
        if (fields is null) return new HashSet<string>();
        return fields.Select(f => f!["key"]!.GetValue<string>()).ToHashSet();
    }

    [Fact]
    public void Steel_template_defines_the_core_carbon_fields_our_model_must_serve()
    {
        var keys = Keys();
        if (keys.Count == 0) return; // reference absent

        Assert.All(new[]
        {
            "scope1DirectEmissions",
            "precursorEmissions",
            "calculationMethodology",
            "thirdPartyVerification",
            "dataQuality",
            "totalSpecificEmbeddedEmissions",
            "cbamGoodsType",
            "productionRoute",
            "heatNumber",
            "reductionAgent",
            "cnCode"
        }, key => Assert.True(keys.Contains(key), $"TracePass steel template is missing required field '{key}'"));
    }

    [Fact]
    public void Steel_template_field_count_matches_the_documented_inventory()
    {
        var fields = Fields();
        if (fields is null) return;
        Assert.Equal(84, fields.Count);
    }
}
