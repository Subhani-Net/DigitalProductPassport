Feature: CBAM accredited verifier
  As an accredited verifier
  I want to review operator data efficiently
  So that I can issue verification reports with confidence

  @ignore @stub
  Scenario: Review operator emissions and evidence
    Given an installation operator has uploaded data and evidence
    When I open the read-only audit room
    Then I can drill down from the SEE figure to the raw invoices and meter logs

  @ignore @stub
  Scenario: Recalculate a sample that matches the methodology
    Given I select a data sample
    When I recalculate the embedded emissions
    Then the recalculated values match the declared methodology

  @ignore @stub
  Scenario: Recalculate a sample that finds a mismatch
    Given I select a data sample
    When I recalculate the embedded emissions
    Then any deviation from the declared methodology is flagged

  @ignore @stub
  Scenario: Issue a verification report
    Given the data passes my assurance review
    When I issue the verification report
    Then the report enables declarants to use verified actual values

  @ignore @stub
  Scenario: Flag non-conformity
    Given the data does not pass my assurance review
    When I issue my findings
    Then the non-conformity is recorded and the actual value cannot be used

  @ignore @stub
  Scenario: Self-review of own affiliate is blocked
    Given the data was produced by my own affiliated company
    When I attempt to verify it
    Then verification is blocked for independence reasons
