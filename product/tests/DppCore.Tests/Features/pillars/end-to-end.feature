Feature: CBAM end-to-end journey (demo)
  As a demo operator
  I want to seed the demo data pack and drive the whole CBAM process end to end
  So that I can show capture, validation, transfer, declaration, assurance and the wedge saving

  # --- Stage 1: capture ---

  @ignore @stub @p1
  Scenario: Seed the demo exporters
    Given the demo data pack is loaded
    When I seed the exporters
    Then each installation is registered with its identity, source streams and electricity

  # --- Stage 2: validation ---

  @ignore @stub @p1
  Scenario: Compute SEE for every demo installation
    Given the demo exporters are seeded
    When the embedded emissions are calculated
    Then each installation yields the SEE in expected-outputs.json

  # --- Stage 3: transfer ---

  @ignore @stub @p1
  Scenario: Upload each installation once
    Given the demo exporters have calculated SEE
    When each installation uploads its data
    Then the data is stored once for reuse by all linked declarants

  # --- Stage 4: consume ---

  @ignore @stub @p1
  Scenario: Importer assembles and settles the declaration
    Given the demo importer links to the suppliers via EORI
    When the importer assembles and settles the declaration
    Then the total embedded emissions and certificates match expected-outputs.json

  # --- Stage 5: assure ---

  @ignore @stub @p2
  Scenario: Verifier drills down and reports
    Given a demo declaration using verified actuals
    When the verifier opens the read-only audit room and drills down
    Then the verifier can trace the SEE to its source documents and issue a report

  # --- Stage 6: sell-twice ---

  @ignore @stub @p3
  Scenario: Reuse the steel data for the DPP
    Given a demo steel dataset already used for CBAM
    When the DPP obligation applies
    Then the same dataset produces the steel passport

  # --- Stage 7: the wedge ---

  @ignore @stub @p1
  Scenario: Show the actual-versus-default saving
    Given a demo installation with verified actuals
    When I compare against the route default
    Then the saving matches expected-outputs.json and tells the commercial story
