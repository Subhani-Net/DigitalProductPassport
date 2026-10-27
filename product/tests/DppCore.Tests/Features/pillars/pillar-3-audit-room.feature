Feature: Pillar 3 — Audit room (evidence provenance)
  As an accredited verifier
  I want to verify a declaration quickly through a read-only evidence room
  So that audits take hours, not weeks

  # --- Phase 1 (MVP) ---

  @ignore @stub @p1
  Scenario: Anchor every figure to its source document
    Given a declared emission figure
    When a verifier inspects it
    Then the figure links to its source document with an immutable trail

  @ignore @stub @p1
  Scenario: Record a determination flag per line
    Given a declaration with multiple product lines
    When the declaration is assembled
    Then each line carries its actual-or-default determination

  # --- Phase 2 ---

  @ignore @stub @p2
  Scenario: Give the verifier a read-only login
    Given an accredited verifier is engaged
    When the verifier signs in
    Then they get read-only access to the evidence room

  @ignore @stub @p2
  Scenario: Drill down from SEE to the raw source
    Given a verifier opens a declared SEE figure
    When the verifier drills down
    Then they see the raw invoices, meter logs and factors behind it

  # --- Phase 3 ---

  @ignore @stub @p3
  Scenario: Auto-assemble the evidence dossier
    Given a declaration using verified actuals
    When the platform prepares the evidence
    Then a complete dossier is assembled from the source records

  @ignore @stub @p3
  Scenario: Hand off cleanly to a partner verifier
    Given a declaration needs a verification report
    When the importer hands off to a partner verifier
    Then the verifier receives a complete, structured evidence pack
