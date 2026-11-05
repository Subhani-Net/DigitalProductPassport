# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Security controls
  As the platform
  I must protect accounts, files and tenant data
  So that the shell is safe to expose to customers

  Scenario: Rate-limit repeated login attempts
    Given more than the allowed login attempts in a minute
    When the user tries again
    Then the request is rejected with "too_many_requests"
    And the response includes "Retry-After"

  Scenario: Idempotent upload intent
    Given an upload intent request with an idempotency key
    When the same request is retried with the same key
    Then no duplicate document is created
    And the same intent is returned

  Scenario: Audit event on a state change
    When the owner deletes a document
    Then an audit event records the actor, installation, action and entity
    And the event contains no secret or file content

  Scenario: Reject malformed input
    When a request sends an unknown enum value or an oversized field
    Then the request is rejected with "validation_error"

  Scenario: Reject cross-origin state changes
    Given a request from an origin that is not allowlisted
    When it attempts a state-changing call
    Then the request is rejected

  Scenario: Revoke a session
    Given an active session
    When the user revokes it from settings
    Then the access token no longer works

  Scenario: File is served safely
    Given a clean document
    When the user downloads it
    Then the response is an attachment
    And the content type is the stored safe type

  Scenario: Quarantined file is not downloadable
    Given a document in "QUARANTINED"
    When the user requests a download
    Then the request is rejected with "forbidden"
