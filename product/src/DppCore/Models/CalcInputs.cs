using System.Text.Json.Serialization;

namespace DppCore.Models;

/// <summary>Top-level CBAM calculation inputs (mirrors src/model/calc-inputs.schema.json stub).</summary>
public sealed class CalcInputs
{
    [JsonPropertyName("installation")]
    public Installation? Installation { get; set; }

    [JsonPropertyName("reportingPeriod")]
    public int ReportingPeriod { get; set; }

    [JsonPropertyName("production")]
    public Production? Production { get; set; }

    [JsonPropertyName("sourceStreams")]
    public List<SourceStream> SourceStreams { get; set; } = new();

    [JsonPropertyName("electricity")]
    public Electricity? Electricity { get; set; }

    [JsonPropertyName("precursors")]
    public List<Precursor> Precursors { get; set; } = new();

    [JsonPropertyName("result")]
    public Result? Result { get; set; }
}

public sealed class Installation
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("country")] public string? Country { get; set; }
    [JsonPropertyName("unLocode")] public string? UnLocode { get; set; }
    [JsonPropertyName("productionRoute")] public string? ProductionRoute { get; set; }
}

public sealed class Production
{
    [JsonPropertyName("cnCode")] public string? CnCode { get; set; }
    [JsonPropertyName("activityLevelTonnes")] public double ActivityLevelTonnes { get; set; }
}

public sealed class SourceStream
{
    [JsonPropertyName("name")] public string? Name { get; set; }

    /// <summary>Quantity consumed. Unit is given by <see cref="Unit"/>.</summary>
    [JsonPropertyName("activityData")] public double ActivityData { get; set; }

    /// <summary>t, TJ, Nm3, or MWh.</summary>
    [JsonPropertyName("unit")] public string? Unit { get; set; }

    /// <summary>Net calorific value in TJ per activity-data unit (only for mass/volume streams).</summary>
    [JsonPropertyName("ncvTJPerUnit")] public double? NcvTJPerUnit { get; set; }

    [JsonPropertyName("emissionFactorTCO2PerTJ")] public double EmissionFactorTCO2PerTJ { get; set; }

    [JsonPropertyName("oxidationFactor")] public double? OxidationFactor { get; set; }
}

public sealed class Electricity
{
    [JsonPropertyName("mwh")] public double Mwh { get; set; }
    [JsonPropertyName("emissionFactorTCO2PerMWh")] public double EmissionFactorTCO2PerMWh { get; set; }
    [JsonPropertyName("contractualFactor")] public bool? ContractualFactor { get; set; }
}

public sealed class Precursor
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("massTonnes")] public double MassTonnes { get; set; }
    [JsonPropertyName("seeTCO2PerTonne")] public double SeeTCO2PerTonne { get; set; }
}

public sealed class Result
{
    [JsonPropertyName("directTCO2")] public double DirectTCO2 { get; set; }
    [JsonPropertyName("indirectTCO2")] public double IndirectTCO2 { get; set; }
    [JsonPropertyName("seeTCO2PerTonne")] public double SeeTCO2PerTonne { get; set; }
    [JsonPropertyName("determination")] public string? Determination { get; set; }
}
