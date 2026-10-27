Feature: CBAM importer declaration and settlement
  As an EU importer (authorised CBAM declarant)
  I want to assemble my annual declaration and settle certificates
  So that I surrender the correct amount and pay no more than required

  Scenario Outline: Assemble a declaration from verified actuals
    Given I import <quantity> tonnes with a SEE of <see> tCO2e per tonne
    And the declaration year is <year>
    When I assemble the declaration
    Then the total embedded emissions equal <total> tCO2e
    And the obligation equals <obligation> tCO2e

    Examples:
      | quantity | see  | year | total | obligation |
      | 1000     | 1.9  | 2026 | 1900  | 47.5       |
      | 5000     | 2.44 | 2034 | 12200 | 12200      |

  Scenario: Fall back to defaults when no verified data is available
    Given I import 1000 tonnes with no verified actual emissions
    And the route default for "BF-BOF" applies
    And the declaration year is 2026
    When I assemble the declaration
    Then the total embedded emissions equal 2100 tCO2e
    And the declaration is flagged as using defaults

  Scenario: Deduct the foreign carbon price when settling
    Given a declaration with total embedded emissions of 1900 tCO2e for year 2034
    And a foreign carbon price covering 200 tCO2e was already paid
    When I settle the declaration
    Then the certificates to surrender equal 1700

  Scenario: Deduction cannot exceed the obligation
    Given a declaration with total embedded emissions of 100 tCO2e for year 2034
    And a foreign carbon price covering 150 tCO2e was already paid
    When I settle the declaration
    Then the certificates to surrender equal 0
