using System.Text.Json;
using DppCore;
using DppCore.Models;
using Xunit;

namespace DppCore.Tests;

/// <summary>
/// Unit tests that encode (and therefore document) the CBAM calculation rules from L1.
/// Expected values are the hand-computed figures stored in the sample fixture.
/// </summary>
public class CbamCalculatorTests
{
    private static CalcInputs LoadSample()
    {
        var json = File.ReadAllText(Repo.Path("product/src/fixtures/steel-calc-inputs.sample.json"));
        return JsonSerializer.Deserialize<CalcInputs>(json)!;
    }

    [Fact]
    public void Direct_emissions_match_hand_computed_fixture_value()
    {
        var result = CbamCalculator.Calculate(LoadSample());
        // coal: 550,000 t × 0.028 TJ/t × 95 tCO2/TJ × 0.99 = 1,448,370
        // gas:  5,000 TJ × 56 tCO2/TJ × 1.0           =   280,000
        // total                                        = 1,728,370
        Assert.Equal(1_728_370.0, result.DirectTCO2, precision: 0);
    }

    [Fact]
    public void Indirect_emissions_match_fixture_value()
    {
        var result = CbamCalculator.Calculate(LoadSample());
        // 250,000 MWh × 0.71 tCO2/MWh = 177,500
        Assert.Equal(177_500.0, result.IndirectTCO2, precision: 0);
    }

    [Fact]
    public void See_matches_fixture_value()
    {
        var result = CbamCalculator.Calculate(LoadSample());
        // (1,728,370 + 177,500 + 0) / 1,000,000 t = 1.90587 tCO2e/t
        Assert.Equal(1.90587, result.SeeTCO2PerTonne, precision: 5);
    }

    [Fact]
    public void Stated_fixture_result_is_consistent_with_calculation()
    {
        var inputs = LoadSample();
        var result = CbamCalculator.Calculate(inputs);

        Assert.Equal(inputs.Result!.DirectTCO2, result.DirectTCO2, precision: 0);
        Assert.Equal(inputs.Result!.IndirectTCO2, result.IndirectTCO2, precision: 0);
        Assert.Equal(inputs.Result!.SeeTCO2PerTonne, result.SeeTCO2PerTonne, precision: 5);
    }

    [Fact]
    public void Tj_unit_stream_needs_no_ncv()
    {
        // A TJ-denominated stream contributes activityData × EF × OF directly.
        var streams = new[]
        {
            new SourceStream { ActivityData = 5_000, Unit = "TJ", EmissionFactorTCO2PerTJ = 56, OxidationFactor = 1.0 }
        };
        Assert.Equal(280_000.0, CbamCalculator.CalculateDirect(streams), precision: 0);
    }

    [Fact]
    public void Precursors_are_added_to_the_total()
    {
        var inputs = LoadSample();
        inputs.Precursors.Add(new Precursor { Name = "pig iron", MassTonnes = 1_000, SeeTCO2PerTonne = 1.5 });

        var result = CbamCalculator.Calculate(inputs);

        Assert.Equal(1_500.0, result.PrecursorTCO2, precision: 0);
        Assert.Equal(1_905_870.0 + 1_500.0, result.TotalTCO2, precision: 0);
    }

    [Fact]
    public void Missing_oxidation_factor_defaults_to_one()
    {
        var streams = new[]
        {
            new SourceStream { ActivityData = 1_000, Unit = "TJ", EmissionFactorTCO2PerTJ = 10, OxidationFactor = null }
        };
        Assert.Equal(10_000.0, CbamCalculator.CalculateDirect(streams), precision: 0);
    }

    [Fact]
    public void Zero_activity_level_throws()
    {
        var inputs = LoadSample();
        inputs.Production!.ActivityLevelTonnes = 0;

        Assert.Throws<ArgumentException>(() => CbamCalculator.Calculate(inputs));
    }
}
