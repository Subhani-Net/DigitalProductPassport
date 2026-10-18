Feature: Pillar 4 — Trust & hand-off (two-sided coordination)
  As an importer and exporter
  I want to share data safely and reuse it across many declarants
  So that the importer is compliant and the exporter retains EU business

  # --- Phase 1 (MVP) ---

  @ignore @stub @p1
  Scenario: Store exporter data once for reuse by many importers
    Given an exporter uploads installation and emissions data
    When the data is stored
    Then it is stored once and reused by all linked declarants

  @ignore @stub @p1
  Scenario: Link an importer to a supplier via EORI
    Given an importer shares its EORI with a supplier
    When the supplier links it
    Then the importer retrieves the supplier's verified data

  @ignore @stub @p1
  Scenario: Enforce role-based access
    Given supplier, importer and verifier roles
    When each signs in
    Then each sees only the data permitted for their role

  # --- Phase 2 ---

  @ignore @stub @p2
  Scenario: Share without exposing supplier data
    Given a supplier shares verified emissions with an importer
    When the importer consumes it
    Then the supplier's proprietary recipe and energy mix are not exposed

  # --- Phase 3 ---

  @ignore @stub @p3
  Scenario: Prove a claim with zero-knowledge attestation
    Given a supplier attests to a carbon claim
    When an importer verifies it
    Then the claim is proven without revealing the underlying data

  @ignore @stub @p3
  Scenario: Reuse the same data for the DPP
    Given a steel dataset used for CBAM
    When the DPP obligation applies
    Then the same dataset produces the steel passport (sell-twice)
