# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Authentication and sessions
  As an exporter
  I want to sign in securely
  So that only authorised people can see my installation

  Scenario: Register an exporter owner and create the first installation
    Given no account exists for "owner@example.com"
    When the user registers with company "Rajkot Steel" and sector "IRON_STEEL"
    Then the account is created with status "ACTIVE"
    And the user is the "EXPORTER_OWNER" of the installation
    And an email verification is sent

  Scenario: Reject a weak password
    When the user registers with password "short"
    Then the request is rejected with "validation_error"
    And the response names the password field

  Scenario: Reject a duplicate email
    Given an account exists for "owner@example.com"
    When the user registers with the same email
    Then the request is rejected with "conflict"

  Scenario: Verify an email address
    Given an unverified account with a valid verification token
    When the user submits the token
    Then the email is marked verified
    And the token cannot be reused

  Scenario: Log in with valid credentials
    Given a verified account with a valid password
    When the user logs in
    Then an access token and a refresh token are returned

  Scenario: Lock out after repeated failures
    Given 5 failed login attempts for the account
    When the user tries again
    Then the request is rejected with "too_many_requests"

  Scenario: Rotate a refresh token
    Given a valid refresh token
    When the user refreshes the session
    Then a new access token and refresh token are returned
    And the previous refresh token is revoked

  Scenario: Reset a password and revoke sessions
    Given a valid password-reset token
    When the user sets a new password
    Then the password is updated
    And all existing sessions are revoked

  Scenario: Log out
    Given a signed-in user
    When the user logs out
    Then the session is revoked
