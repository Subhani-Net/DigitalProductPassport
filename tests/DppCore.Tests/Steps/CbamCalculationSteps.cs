using DppCore;
using DppCore.Models;
using Reqnroll;
using Xunit;

namespace DppCore.Tests.Steps;

[Binding]
public sealed class CbamCalculationSteps
{
    private readonly ScenarioContext _ctx;

    public CbamCalculationSteps(ScenarioContext ctx) => _ctx = ctx;

    private CalcInputs Inputs() => _ctx.Get<CalcInputs>("inputs");

    [Given(@"a steel installation on the ""(.*)"" production route")]
    public void GivenRoute(string route)
    {
        _ctx.Set(route, "route");
        _ctx.Set(new CalcInputs
        {
            Installation = new Installation { ProductionRoute = route },
            Production = new Production()
        }, "inputs");
    }

    [Given(@"an installation on the ""(.*)"" production route")]
    public void GivenInstallationRoute(string route) => GivenRoute(route);

    [Given(@"the installation produced (\d+) tonnes of product")]
    public void GivenProduced(int tonnes) => Inputs().Production!.ActivityLevelTonnes = tonnes;

    [Given(@"source stream ""(.*)"" consumed (\d+) t with NCV (.*) TJ per unit and emission factor (.*) tCO2 per TJ and oxidation factor (.*)")]
    public void GivenMassStream(string name, int activityData, double ncv, double ef, double of)
    {
        Inputs().SourceStreams.Add(new SourceStream
        {
            Name = name, ActivityData = activityData, Unit = "t",
            NcvTJPerUnit = ncv, EmissionFactorTCO2PerTJ = ef, OxidationFactor = of
        });
    }

    [Given(@"source stream ""(.*)"" consumed (\d+) TJ with emission factor (.*) tCO2 per TJ and oxidation factor (.*)")]
    public void GivenEnergyStream(string name, int activityData, double ef, double of)
    {
        Inputs().SourceStreams.Add(new SourceStream
        {
            Name = name, ActivityData = activityData, Unit = "TJ",
            EmissionFactorTCO2PerTJ = ef, OxidationFactor = of
        });
    }

    [Given(@"source stream ""(.*)"" consumed (\d+) Nm3 with NCV (.*) TJ per unit and emission factor (.*) tCO2 per TJ and oxidation factor (.*)")]
    public void GivenVolumeStream(string name, int activityData, double ncv, double ef, double of)
    {
        Inputs().SourceStreams.Add(new SourceStream
        {
            Name = name, ActivityData = activityData, Unit = "Nm3",
            NcvTJPerUnit = ncv, EmissionFactorTCO2PerTJ = ef, OxidationFactor = of
        });
    }

    [Given(@"purchased electricity of (\d+) MWh at (.*) tCO2 per MWh")]
    public void GivenElectricity(int mwh, double factor)
        => Inputs().Electricity = new Electricity { Mwh = mwh, EmissionFactorTCO2PerMWh = factor };

    [Given(@"a precursor ""(.*)"" of (\d+) tonnes at (.*) tCO2 per tonne")]
    public void GivenPrecursor(string name, int tonnes, double see)
        => Inputs().Precursors.Add(new Precursor { Name = name, MassTonnes = tonnes, SeeTCO2PerTonne = see });

    [When(@"the embedded emissions are calculated")]
    public void WhenCalculated()
    {
        try
        {
            _ctx.Set(CbamCalculator.Calculate(Inputs()), "result");
            _ctx.Set<Exception?>(null, "exception");
        }
        catch (Exception ex)
        {
            _ctx.Set(ex, "exception");
        }
    }

    [Then(@"the direct emissions equal (\d+) tCO2")]
    public void ThenDirect(int expected) => Assert.Equal(expected, _ctx.Get<CbamResult>("result").DirectTCO2, precision: 0);

    [Then(@"the indirect emissions equal (\d+) tCO2")]
    public void ThenIndirect(int expected) => Assert.Equal(expected, _ctx.Get<CbamResult>("result").IndirectTCO2, precision: 0);

    [Then(@"the precursor emissions equal (\d+) tCO2")]
    public void ThenPrecursor(int expected) => Assert.Equal(expected, _ctx.Get<CbamResult>("result").PrecursorTCO2, precision: 0);

    [Then(@"the SEE equals (.*) tCO2e per tonne")]
    public void ThenSee(double expected) => Assert.Equal(expected, _ctx.Get<CbamResult>("result").SeeTCO2PerTonne, precision: 5);

    [Then(@"the calculation is rejected")]
    public void ThenRejected() => Assert.IsType<ArgumentException>(_ctx.Get<Exception?>("exception"));

    // --- economics ---

    [Given(@"the certificate price is (.*) euros per tonne")]
    public void GivenPrice(double price) => _ctx.Set(price, "price");

    [Given(@"the installation reports actual SEE of (.*) tCO2e per tonne for (\d+) tonnes")]
    public void GivenActualSee(double see, int tonnes)
    {
        _ctx.Set(see, "actualSee");
        _ctx.Set((double)tonnes, "activity");
    }

    [When(@"I compare the actual SEE against the route default")]
    public void WhenCompare()
    {
        var route = _ctx.Get<string>("route");
        var saving = CbamEconomics.CostDelta(
            _ctx.Get<double>("actualSee"),
            CbamEconomics.DefaultSee(route),
            _ctx.Get<double>("activity"),
            _ctx.Get<double>("price"));
        _ctx.Set(saving, "saving");
    }

    [Then(@"the cost saving equals (\d+) euros")]
    public void ThenSaving(double expected) => Assert.Equal(expected, _ctx.Get<double>("saving"), precision: 0);
}
