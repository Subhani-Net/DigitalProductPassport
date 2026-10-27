Feature: CBAM embedded emissions calculation
  As a CBAM practitioner
  I want to compute and validate specific embedded emissions from source streams
  So that verified actual values can be declared instead of costly defaults

  # Rule 1 — source-stream calculation (three physical input forms)

  Scenario Outline: Calculate SEE from a mass-based source stream
    Given an installation on the "<route>" production route
    And the installation produced <activity> tonnes of product
    And source stream "<fuel>" consumed <amount> t with NCV <ncv> TJ per unit and emission factor <ef> tCO2 per TJ and oxidation factor <of>
    And purchased electricity of <mwh> MWh at <elecef> tCO2 per MWh
    When the embedded emissions are calculated
    Then the direct emissions equal <direct> tCO2
    And the indirect emissions equal <indirect> tCO2
    And the SEE equals <see> tCO2e per tonne

    Examples:
      | route            | fuel                | amount | ncv   | ef  | of   | mwh     | elecef | activity | direct  | indirect | see     |
      | BF-BOF           | Metallurgical coal  | 550000 | 0.028 | 95  | 0.99 | 250000  | 0.71   | 1000000  | 1448370 | 177500   | 1.62587 |
      | EAF              | Graphite electrodes | 5000   | 0.033 | 93  | 1.0  | 400000  | 0.45   | 400000   | 15345   | 180000   | 0.48836 |
      | PrimaryAluminium | Carbon anodes       | 1000   | 0.031 | 93  | 1.0  | 1400000 | 0.40   | 100000   | 2883    | 560000   | 5.62883 |

  Scenario Outline: Calculate SEE from an energy (TJ) source stream
    Given an installation on the "<route>" production route
    And the installation produced <activity> tonnes of product
    And source stream "<fuel>" consumed <amount> TJ with emission factor <ef> tCO2 per TJ and oxidation factor <of>
    And purchased electricity of <mwh> MWh at <elecef> tCO2 per MWh
    When the embedded emissions are calculated
    Then the direct emissions equal <direct> tCO2
    And the indirect emissions equal <indirect> tCO2
    And the SEE equals <see> tCO2e per tonne

    Examples:
      | route  | fuel              | amount | ef  | of  | mwh    | elecef | activity | direct | indirect | see     |
      | DRI    | Natural gas       | 8000   | 56  | 1.0 | 100000 | 0.40   | 200000   | 448000 | 40000    | 2.44000 |
      | BF-BOF | Blast furnace gas | 2000   | 55  | 1.0 | 50000  | 0.40   | 100000   | 110000 | 20000    | 1.30000 |
      | BF-BOF | Coke oven gas     | 1500   | 44  | 1.0 | 30000  | 0.40   | 50000    | 66000  | 12000    | 1.56000 |

  Scenario Outline: Calculate SEE from a volumetric (Nm3) source stream
    Given an installation on the "<route>" production route
    And the installation produced <activity> tonnes of product
    And source stream "<fuel>" consumed <amount> Nm3 with NCV <ncv> TJ per unit and emission factor <ef> tCO2 per TJ and oxidation factor <of>
    And purchased electricity of <mwh> MWh at <elecef> tCO2 per MWh
    When the embedded emissions are calculated
    Then the direct emissions equal <direct> tCO2
    And the indirect emissions equal <indirect> tCO2
    And the SEE equals <see> tCO2e per tonne

    Examples:
      | route | fuel                    | amount  | ncv       | ef  | of  | mwh   | elecef | activity | direct | indirect | see     |
      | DRI   | Natural gas             | 2000000 | 0.0000355 | 56  | 1.0 | 50000 | 0.50   | 100000   | 3976   | 25000    | 0.28976 |
      | DRI   | Natural gas (2nd batch) | 1000000 | 0.0000355 | 56  | 1.0 | 30000 | 0.50   | 50000    | 1988   | 15000    | 0.33976 |

  # Rule 2 — complex goods (precursor roll-up)

  Scenario: Roll precursor emissions into a complex good
    Given an installation on the "EAF" production route
    And the installation produced 500000 tonnes of product
    And source stream "Graphite electrodes" consumed 3000 t with NCV 0.033 TJ per unit and emission factor 93 tCO2 per TJ and oxidation factor 1.0
    And purchased electricity of 200000 MWh at 0.45 tCO2 per MWh
    And a precursor "pig iron" of 100000 tonnes at 1.5 tCO2 per tonne
    When the embedded emissions are calculated
    Then the direct emissions equal 9207 tCO2
    And the indirect emissions equal 90000 tCO2
    And the precursor emissions equal 150000 tCO2
    And the SEE equals 0.49841 tCO2e per tonne

  # Rule 3 — validation

  Scenario: Reject an installation with no production
    Given an installation on the "BF-BOF" production route
    And the installation produced 0 tonnes of product
    When the embedded emissions are calculated
    Then the calculation is rejected

  # Rule 4 — economics

  Scenario Outline: Cost saving of verified actuals versus the default
    Given an installation on the "<route>" production route
    And the certificate price is <price> euros per tonne
    And the installation reports actual SEE of <actualSee> tCO2e per tonne for <activity> tonnes
    When I compare the actual SEE against the route default
    Then the cost saving equals <saving> euros

    Examples:
      | route            | price | actualSee | activity | saving   |
      | BF-BOF           | 75.0  | 2.00      | 1000000  | 7500000  |
      | EAF              | 75.36 | 0.30      | 500000   | 5652000  |
      | PrimaryAluminium | 75.36 | 12.0      | 100000   | 33912000 |
