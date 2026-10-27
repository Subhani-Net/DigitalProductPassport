namespace DppCore;

/// <summary>
/// CBAM phase-in factor — the share of embedded emissions actually payable each year,
/// rising in step with the EU ETS free-allowance phase-out. Endpoints are published
/// (2.5% in 2026 → 100% in 2034); intermediate years [verify] against the ETS Directive.
/// </summary>
public static class CbamFactor
{
    public static double ForYear(int year) => year switch
    {
        2026 => 0.025,
        2034 => 1.0,
        _ => throw new ArgumentOutOfRangeException(nameof(year),
            $"CBAM phase-in factor for {year} is not specified — verify against the ETS Directive phase-out")
    };
}

/// <summary>
/// An importer's annual declaration and certificate settlement (Art. 35 Reg 2023/956).
/// </summary>
public sealed record CbamDeclaration(
    double TotalEmbeddedEmissionsTCO2e,
    int Year,
    double ForeignCarbonPricePaid = 0,
    bool UsesDefaults = false)
{
    /// <summary>Share of embedded emissions payable in this declaration year.</summary>
    public double Factor => CbamFactor.ForYear(Year);

    /// <summary>Certificate obligation = embedded emissions × CBAM factor.</summary>
    public double ObligationTCO2e => TotalEmbeddedEmissionsTCO2e * Factor;

    /// <summary>Certificates to surrender, after deducting the (capped) foreign carbon price.</summary>
    public double CertificatesToSurrender =>
        Math.Max(0, ObligationTCO2e - Math.Min(ForeignCarbonPricePaid, ObligationTCO2e));

    public static CbamDeclaration FromActuals(double quantityTonnes, double seeTCO2PerTonne, int year, double foreignCarbonPricePaid = 0)
        => new(quantityTonnes * seeTCO2PerTonne, year, foreignCarbonPricePaid);

    public static CbamDeclaration FromDefaults(double quantityTonnes, double defaultSeeTCO2PerTonne, int year, double foreignCarbonPricePaid = 0)
        => new(quantityTonnes * defaultSeeTCO2PerTonne, year, foreignCarbonPricePaid, UsesDefaults: true);

    public CbamDeclaration WithForeignCarbonPrice(double paid) => this with { ForeignCarbonPricePaid = paid };
}
