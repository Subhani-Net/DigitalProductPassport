Feature: CBAM cross-cutting data rules
  As a CBAM practitioner
  I want the platform to enforce data integrity across every role
  So that every declaration is verifiable and defensible

  @ignore @stub
  Scenario: Every figure is anchored to its source document
    Given a declared emission figure
    When a verifier inspects the figure
    Then the figure links back to its source document with an immutable audit trail

  @ignore @stub
  Scenario: Non-CBAM methodology is flagged
    Given a supplier calculated emissions using a non-CBAM method
    When the platform validates the methodology
    Then the deviation is flagged before submission

  @ignore @stub
  Scenario: A determination flag is set on every product line
    Given a product line in a declaration
    When the declaration is assembled
    Then the line is marked as actual or default

  @ignore @stub
  Scenario: Same inputs produce the same result
    Given the same installation data is calculated twice
    When the calculation is repeated
    Then the embedded emissions result is identical

  @ignore @stub
  Scenario: A payload is read by its schema version
    Given a payload produced against an older schema version
    When the platform ingests it
    Then it is read using its schema version and validated accordingly

  @ignore @stub
  Scenario: Ingestion is idempotent
    Given the same installation data is ingested twice
    When the second ingest runs
    Then no duplicate record is created

  @ignore @stub
  Scenario: Data is bound to its identifiers
    Given an installation with UN/LOCODE, LEI, EORI and mill ID
    When the data is stored
    Then it is bound to those identifiers
