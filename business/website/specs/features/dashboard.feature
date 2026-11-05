# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Dashboard and report display
  As an exporter
  I want to see the status of my documents and the engine's report
  So that I know what is ready and what is pending

  Background:
    Given a signed-in member of an installation

  Scenario: Empty dashboard before any documents
    Given the installation has no documents
    When the member opens the dashboard
    Then the dashboard shows "Upload your first document to start"

  Scenario: Show document counts
    Given 14 documents, 2 of them pending
    When the member opens the dashboard
    Then the dashboard shows 14 documents
    And it shows 2 pending

  Scenario: Show the latest engine snapshot
    Given a published report for "CY 2026" with calculated SEE 2.04 and default 2.10
    When the member opens the dashboard
    Then the dashboard shows the calculated SEE 2.04
    And it shows the default 2.10
    And it shows the illustrative saving with its assumptions

  Scenario: Do not fake a calculation while the engine is pending
    Given a draft report with no engine output yet
    When the member opens the report
    Then the status reads "Pending engine review"
    And no SEE is displayed as final

  Scenario: Report detail shows goods and determination flags
    Given a report with an actual line and a default line
    When the member opens the report
    Then each goods line shows "ACTUAL" or "DEFAULT"
    And every figure links to its evidence

  Scenario: Label the boundary
    Given any report view
    Then the page shows "Verifier-ready, not verified"

  Scenario: Non-member cannot see the dashboard
    Given a signed-in user with no membership on the installation
    When the user requests the dashboard
    Then the request is rejected with "forbidden"

  Scenario: Download the report dossier
    Given a published report
    When the member requests a download
    Then a short-lived download URL is returned
