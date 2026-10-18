Feature: Pillar 2 — Validation intelligence (verifier-survival)
  As a CBAM practitioner
  I want the platform to produce numbers that survive an accredited verifier
  So that my declared values are accepted, not challenged

  # --- Phase 1 (MVP) ---

  @ignore @stub @p1
  Scenario: Calculate SEE correctly for each production route
    Given an installation on a specific production route
    When the embedded emissions are calculated
    Then the result matches the route-specific methodology

  @ignore @stub @p1
  Scenario: Normalise mass and volume streams via NCV
    Given a source stream captured in tonnes or Nm3
    When the stream is harmonised
    Then it is converted to energy via its NCV

  @ignore @stub @p1
  Scenario: Default a missing oxidation factor to one
    Given a source stream has no oxidation factor
    When the stream is harmonised
    Then the oxidation factor is treated as 1.0

  @ignore @stub @p1
  Scenario: Pass through only covered precursors
    Given a complex good with mixed inputs
    When the precursor contribution is calculated
    Then only CBAM-covered inputs contribute

  @ignore @stub @p1
  Scenario: Set the actual-versus-default determination
    Given a product line
    When the declaration is assembled
    Then the line is marked actual or default

  # --- Phase 2 ---

  @ignore @stub @p2
  Scenario: Flag an implausible emission value
    Given a source stream reports an impossible intensity
    When the platform checks plausibility
    Then the value is flagged for review

  @ignore @stub @p2
  Scenario: Check boundary completeness
    Given an installation's system boundary
    When the platform checks completeness
    Then any omitted stream is flagged

  @ignore @stub @p2
  Scenario: Flag a non-CBAM methodology
    Given a supplier used a non-CBAM method
    When the platform validates the methodology
    Then the deviation is flagged before submission

  # --- Phase 3 ---

  @ignore @stub @p3
  Scenario: Recalculate a sample at verifier grade
    Given a declaration using verified actuals
    When the platform recalculation checks a sample
    Then the recalculated values match the methodology

  @ignore @stub @p3
  Scenario: Check mass-balance consistency
    Given a plant's input and output streams
    When the platform checks the carbon balance
    Then inconsistencies are flagged

  @ignore @stub @p3
  Scenario: Apply the aluminium PFC slope method
    Given a primary aluminium installation with anode-effect data
    When the PFC emissions are calculated
    Then the CF4 and C2F6 values follow the slope method
