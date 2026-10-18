Feature: CBAM exporter / installation operator
  As a non-EU installation operator
  I want to provide verifier-ready emissions data once
  So that multiple EU importers can reuse my verified values

  @ignore @stub
  Scenario: Register an installation in O3CI
    Given I operate a steel installation outside the EU
    When I register my installation in the O3CI portal
    Then my installation is registered with confidential treatment of my data

  @ignore @stub
  Scenario: Upload installation and emissions data
    Given I have activity data, source streams and energy records
    When I upload my installation and emissions data
    Then the data is stored once for reuse by linked declarants

  @ignore @stub
  Scenario: Produce verifier-ready evidence
    Given my emissions are calculated from primary data
    When I prepare my evidence pack
    Then I get an evidence dossier with source records, factors and an audit trail

  @ignore @stub
  Scenario: Share data with an importer via EORI link
    Given an EU importer shares its EORI number with me
    When I link the importer to my installation
    Then the importer can retrieve my verified emissions from the registry

  @ignore @stub
  Scenario: Receive validation feedback before the verifier sees it
    Given I have uploaded emissions data
    When the platform validates my data
    Then anomalies are flagged to me before submission to the verifier
