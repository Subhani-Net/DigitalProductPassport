Feature: Pillar 1 — Capture (friction-reducing data entry)
  As a non-EU exporter
  I want to get my messy plant data into the platform with minimal effort
  So that I can provide verifier-ready data without a consultant

  # --- Phase 1 (MVP) ---

  @ignore @stub @p1
  Scenario: Upload a CSV/XLSX file and auto-map its columns
    Given an exporter uploads a source-stream file
    When the platform ingests it
    Then the columns are mapped to the canonical fields automatically
    And unmapped columns are surfaced for review

  @ignore @stub @p1
  Scenario: Auto-detect units on upload
    Given an exporter uploads values without explicit units
    When the platform ingests them
    Then mass, energy, volume and electricity units are detected automatically

  @ignore @stub @p1
  Scenario: Reject a row missing required fields
    Given a source-stream row is missing its quantity or unit
    When the platform ingests the row
    Then the row is rejected and reported to the exporter

  @ignore @stub @p1
  Scenario: Give immediate validation feedback to the exporter
    Given an exporter has submitted a file with issues
    When the platform validates it
    Then the exporter sees the issues before submission to the verifier

  # --- Phase 2 ---

  @ignore @stub @p2
  Scenario: Connect an ERP, MES or LIMS via an adapter
    Given an exporter has an ERP, MES or LIMS
    When the platform connects to it via an adapter
    Then source data flows into the canonical model automatically

  @ignore @stub @p2
  Scenario: Provide a multi-tenant supplier portal
    Given multiple suppliers are onboarded
    When each supplier signs in
    Then each sees only their own installations and data

  # --- Phase 3 ---

  @ignore @stub @p3
  Scenario: Ingest real-time telemetry from plant devices
    Given a plant has OPC UA, historian or CEMS devices
    When the platform connects to them
    Then activity data is captured in near real time

  @ignore @stub @p3
  Scenario: Extract data automatically from MTC and CoA documents
    Given an exporter uploads mill test certificates and certificates of analysis
    When the platform processes the documents
    Then grade, chemistry and factors are extracted automatically
