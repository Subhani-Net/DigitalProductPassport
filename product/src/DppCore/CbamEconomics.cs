namespace DppCore;

/// <summary>
/// Indicative CBAM default values and cost comparison. Defaults are country/CN-specific in
/// the real regime (IR (EU) 2025/2621); these reference figures are for business scenarios
/// and must be replaced by the EC-published table in C5. [verify against IR 2025/2621]
/// </summary>
public static class CbamEconomics
{
    private static readonly Dictionary<string, double> ReferenceDefaults = new(StringComparer.OrdinalIgnoreCase)
    {
        ["BF-BOF"] = 2.10,        // steel, blast furnace-basic oxygen (tCO2/t)
        ["EAF"] = 0.45,           // steel, electric arc furnace
        ["DRI"] = 1.0,            // steel, direct reduced iron [verify]
        ["PrimaryAluminium"] = 16.50 // primary aluminium
    };

    public static double DefaultSee(string route)
        => ReferenceDefaults.TryGetValue(route, out var v)
            ? v
            : throw new ArgumentOutOfRangeException(nameof(route), $"No reference default for route '{route}'");

    /// <summary>
    /// Money saved by using verified actual values instead of the default:
    ///   saving = (default SEE - actual SEE) × activity(t) × certificate price (€/t).
    /// Positive = saving; negative = actual is worse than default.
    /// </summary>
    public static double CostDelta(double actualSee, double defaultSee, double activityTonnes, double pricePerTonne)
        => (defaultSee - actualSee) * activityTonnes * pricePerTonne;
}
