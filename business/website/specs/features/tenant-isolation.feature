# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Tenant isolation
  As the platform
  I must never expose one installation's data to another
  So that exporters can trust the evidence room

  Background:
    Given user A is an owner of installation A
    And user B is an owner of installation B

  Scenario: Cannot read another installation
    When user A requests installation B
    Then the request is rejected with "forbidden" or "not_found"
    And no installation B data is returned

  Scenario: Cannot read another installation's document
    Given a document in installation B
    When user A requests it using its id
    Then the request is rejected with "not_found"
    And no document metadata is returned

  Scenario: Cannot read another installation's report
    Given a report in installation B
    When user A requests it using its id
    Then the request is rejected with "not_found"
    And no report or goods data is returned

  Scenario: Cannot list another installation's documents
    When user A lists documents with installation B's id
    Then the request is rejected with "forbidden"

  Scenario: A consultant sees only assigned installations
    Given a consultant assigned to installation A only
    When the consultant lists installations
    Then only installation A is returned

  Scenario: A verifier cannot mutate
    Given a verifier assigned to installation A
    When the verifier attempts to upload, delete or publish
    Then every request is rejected with "forbidden"

  Scenario: Server ignores a client-supplied tenant id in the body
    When user A posts a document intent with installation B's id in the body
    Then the path's installation A is used
    And the document is created in installation A
