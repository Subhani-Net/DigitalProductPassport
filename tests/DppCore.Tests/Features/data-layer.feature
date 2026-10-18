Feature: CBAM data layer — capture, transfer, transform
  As a CBAM practitioner
  I want to capture exporter data once and transform it into declaration-ready data
  So that the importer receives clean, verifiable, correctly-normalised inputs

  # --- capture ---

  @ignore @stub
  Scenario: Ingest a CSV export and map its columns automatically
    Given an exporter uploads a CSV of source streams
    When the platform ingests the file
    Then the columns are mapped to the canonical fields automatically
    And unmapped columns are surfaced for review

  @ignore @stub
  Scenario: Normalise units from mass, energy and volume
    Given a source stream is captured in tonnes with an NCV
    And another is captured in TJ
    And another in Nm3 with an NCV
    When the streams are harmonised
    Then all energy values are expressed in TJ
    And each mass or volume stream is converted via its NCV

  @ignore @stub
  Scenario: Reject a row missing required fields
    Given a source-stream row is missing its quantity or unit
    When the platform ingests the row
    Then the row is rejected and reported to the exporter

  @ignore @stub
  Scenario: Default a missing oxidation factor to one
    Given a source stream has no oxidation factor
    When the stream is harmonised
    Then the oxidation factor is treated as 1.0

  # --- transfer ---

  @ignore @stub
  Scenario: Exporter uploads installation data once
    Given an exporter has uploaded installation and emissions data
    When the data is stored in the registry
    Then the data is stored once for reuse by all linked declarants
    And business-sensitive data is treated confidentially

  @ignore @stub
  Scenario: Importer retrieves verified data via EORI link
    Given a supplier has linked an importer via EORI
    When the importer retrieves the data
    Then the importer receives the verified embedded emissions from the registry

  # --- transform ---

  @ignore @stub
  Scenario: Transform raw source streams into the canonical model
    Given raw exporter data with identity, source streams, electricity and precursors
    When the data is transformed
    Then the result conforms to the canonical model

  @ignore @stub
  Scenario: Pass through only covered precursors
    Given a complex good with mixed inputs
    When the precursor contribution is calculated
    Then only CBAM-covered inputs contribute to the embedded emissions

  @ignore @stub
  Scenario: Flag a determination for every product line
    Given a declaration with multiple product lines
    When the declaration is assembled
    Then each line is marked actual or default

  @ignore @stub
  Scenario: Fall back to defaults and show the cost delta
    Given a product line has no verified actual emissions
    When the declaration is assembled
    Then the default value is used and flagged
    And the cost difference versus the default is shown

  @ignore @stub
  Scenario: Flag a non-CBAM methodology
    Given a supplier calculated emissions with a non-CBAM method
    When the platform validates the methodology
    Then the deviation is flagged before submission
