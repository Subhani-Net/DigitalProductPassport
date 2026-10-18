using DppCore.Models;

namespace DppCore;

/// <summary>Outcome of an embedded-emissions calculation.</summary>
public sealed class CbamResult
{
    public double DirectTCO2 { get; init; }
    public double IndirectTCO2 { get; init; }
    public double PrecursorTCO2 { get; init; }
    public double TotalTCO2 => DirectTCO2 + IndirectTCO2 + PrecursorTCO2;

    /// <summary>Specific Embedded Emissions (tCO2e per tonne of product).</summary>
    public double SeeTCO2PerTonne { get; init; }
}

/// <summary>
/// CBAM embedded-emissions calculation (direct + indirect + precursors), per Reg (EU) 2023/956
/// Annex IV and IR (EU) 2025/2547. This encodes the L1 learning as code.
/// </summary>
public static class CbamCalculator
{
    /// <summary>
    /// Direct emissions from source streams:
    ///   emissions = Σ ( energy(TJ) × emissionFactor(tCO2/TJ) × oxidationFactor )
    /// where energy = activityData (if unit == TJ) else activityData × ncv(TJ/unit).
    /// </summary>
    public static double CalculateDirect(IEnumerable<SourceStream> streams)
    {
        double total = 0;
        foreach (var s in streams)
        {
            if (s.EmissionFactorTCO2PerTJ <= 0) continue;

            double energy;
            if (string.Equals(s.Unit, "TJ", StringComparison.OrdinalIgnoreCase))
            {
                energy = s.ActivityData;
            }
            else
            {
                energy = s.ActivityData * (s.NcvTJPerUnit ?? 0);
            }

            var of = s.OxidationFactor ?? 1.0;
            total += energy * s.EmissionFactorTCO2PerTJ * of;
        }
        return total;
    }

    /// <summary>Indirect emissions from purchased electricity: MWh × tCO2/MWh.</summary>
    public static double CalculateIndirect(Electricity? electricity)
    {
        if (electricity is null) return 0;
        return electricity.Mwh * electricity.EmissionFactorTCO2PerMWh;
    }

    /// <summary>Precursor contribution: Σ ( mass × SEE ).</summary>
    public static double CalculatePrecursors(IEnumerable<Precursor> precursors)
    {
        double total = 0;
        foreach (var p in precursors) total += p.MassTonnes * p.SeeTCO2PerTonne;
        return total;
    }

    /// <summary>Full SEE result for an installation's production.</summary>
    public static CbamResult Calculate(CalcInputs inputs)
    {
        if (inputs.Production is null || inputs.Production.ActivityLevelTonnes <= 0)
            throw new ArgumentException("production.activityLevelTonnes must be > 0");

        var direct = CalculateDirect(inputs.SourceStreams);
        var indirect = CalculateIndirect(inputs.Electricity);
        var precursor = CalculatePrecursors(inputs.Precursors);

        return new CbamResult
        {
            DirectTCO2 = direct,
            IndirectTCO2 = indirect,
            PrecursorTCO2 = precursor,
            SeeTCO2PerTonne = (direct + indirect + precursor) / inputs.Production.ActivityLevelTonnes
        };
    }
}
