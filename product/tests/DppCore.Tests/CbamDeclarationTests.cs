using DppCore;
using Xunit;

namespace DppCore.Tests;

public class CbamDeclarationTests
{
    [Theory]
    [InlineData(2026, 0.025)]
    [InlineData(2034, 1.0)]
    public void Phase_in_factor_endpoints(int year, double expected)
        => Assert.Equal(expected, CbamFactor.ForYear(year), precision: 6);

    [Fact]
    public void Unspecified_year_throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => CbamFactor.ForYear(2027));

    [Fact]
    public void From_actuals_computes_total_embedded_emissions()
        => Assert.Equal(1900.0, CbamDeclaration.FromActuals(1000, 1.9, 2026).TotalEmbeddedEmissionsTCO2e, precision: 6);

    [Fact]
    public void Obligation_applies_the_phase_in_factor()
        => Assert.Equal(47.5, CbamDeclaration.FromActuals(1000, 1.9, 2026).ObligationTCO2e, precision: 6);

    [Fact]
    public void From_defaults_marks_the_declaration()
        => Assert.True(CbamDeclaration.FromDefaults(1000, 2.10, 2026).UsesDefaults);

    [Fact]
    public void Foreign_carbon_price_is_deducted_from_the_obligation()
    {
        var d = new CbamDeclaration(1900, 2034).WithForeignCarbonPrice(200);
        Assert.Equal(1700.0, d.CertificatesToSurrender, precision: 6);
    }

    [Fact]
    public void Deduction_cannot_exceed_the_obligation()
    {
        var d = new CbamDeclaration(100, 2034).WithForeignCarbonPrice(150);
        Assert.Equal(0.0, d.CertificatesToSurrender, precision: 6);
    }
}
