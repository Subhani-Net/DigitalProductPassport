using DppCore;
using Reqnroll;
using Xunit;

namespace DppCore.Tests.Steps;

[Binding]
public sealed class DeclarationSteps
{
    private double _qty;
    private double _see;
    private double? _defaultSee;
    private int _year;
    private bool _actuals;
    private CbamDeclaration _decl = null!;
    private double _deduction;

    [Given(@"I import (.*) tonnes with a SEE of (.*) tCO2e per tonne")]
    public void GivenActuals(double qty, double see) { _qty = qty; _see = see; _actuals = true; }

    [Given(@"I import (.*) tonnes with no verified actual emissions")]
    public void GivenNoActuals(double qty) { _qty = qty; _actuals = false; }

    [Given(@"the route default for ""(.*)"" applies")]
    public void GivenRouteDefault(string route) => _defaultSee = CbamEconomics.DefaultSee(route);

    [Given(@"the declaration year is (.*)")]
    public void GivenYear(int year) => _year = year;

    [When(@"I assemble the declaration")]
    public void WhenAssemble()
        => _decl = _actuals
            ? CbamDeclaration.FromActuals(_qty, _see, _year)
            : CbamDeclaration.FromDefaults(_qty, _defaultSee ?? 0, _year);

    [Then(@"the total embedded emissions equal (.*) tCO2e")]
    public void ThenTotal(double expected) => Assert.Equal(expected, _decl.TotalEmbeddedEmissionsTCO2e, precision: 4);

    [Then(@"the obligation equals (.*) tCO2e")]
    public void ThenObligation(double expected) => Assert.Equal(expected, _decl.ObligationTCO2e, precision: 4);

    [Then(@"the declaration is flagged as using defaults")]
    public void ThenDefaults() => Assert.True(_decl.UsesDefaults);

    [Given(@"a declaration with total embedded emissions of (.*) tCO2e for year (.*)")]
    public void GivenDeclaration(double total, int year) => _decl = new CbamDeclaration(total, year);

    [Given(@"a foreign carbon price covering (.*) tCO2e was already paid")]
    public void GivenDeduction(double deduction) => _deduction = deduction;

    [When(@"I settle the declaration")]
    public void WhenSettle() => _decl = _decl.WithForeignCarbonPrice(_deduction);

    [Then(@"the certificates to surrender equal (.*)")]
    public void ThenSurrender(double expected) => Assert.Equal(expected, _decl.CertificatesToSurrender, precision: 4);
}
