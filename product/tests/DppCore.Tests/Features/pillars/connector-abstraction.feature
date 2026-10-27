Feature: Capture adapter / plugin seam
  As a platform engineer
  I want every customer system to be converted to the same canonical JSON
  So that the core works on one shape regardless of the source

  @ignore @stub @p1
  Scenario: Convert a CSV export to the canonical JSON
    Given a CSV of source streams
    When the CSV adapter runs
    Then the output conforms to the canonical JSON model

  @ignore @stub @p1
  Scenario: Convert an Excel export to the canonical JSON
    Given an XLSX of source streams
    When the Excel adapter runs
    Then the output conforms to the canonical JSON model

  @ignore @stub @p1
  Scenario: Add a new adapter without changing the core
    Given a new customer format
    When I add an adapter for it
    Then the core pipeline is unchanged

  @ignore @stub @p2
  Scenario: Connect an ERP and map it to JSON
    Given an ERP with CBAM-relevant tables
    When the ERP connector runs
    Then it maps the tables to the canonical JSON model

  @ignore @stub @p3
  Scenario: Convert a MTC or CoA PDF to JSON
    Given a mill test certificate or certificate of analysis PDF
    When the PDF adapter runs
    Then grade, chemistry and factors are extracted into JSON
