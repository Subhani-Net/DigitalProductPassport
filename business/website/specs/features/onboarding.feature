# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Installation onboarding and tenancy
  As an exporter
  I want an installation (tenant) that holds my documents and reports
  So that my data is separated from every other company

  Scenario: Create an installation during registration
    When the user registers with company "Coimbatore Castings" and sector "IRON_STEEL"
    Then an installation is created with country "IN"
    And the user is its "EXPORTER_OWNER"

  Scenario Outline: Reject an unsupported sector
    When the user creates an installation with sector "<sector>"
    Then the request is rejected with "validation_error"

    Examples:
      | sector    |
      | CEMENT    |
      | CHEMICALS |
      |           |

  Scenario: Owner invites an exporter member
    Given an installation owned by the user
    When the owner invites "colleague@example.com" as "EXPORTER_MEMBER"
    Then an invitation is created with a single-use token
    And the invitation expires in 7 days

  Scenario: Consultant can be assigned to multiple installations
    Given a consultant membership on installation A
    And a consultant membership on installation B
    When the consultant lists their installations
    Then both installations are returned

  Scenario: Verifier gets read-only access
    Given a verifier membership on an installation
    When the verifier opens the evidence room
    Then the report and evidence are visible
    And upload, delete and publish actions are not available

  Scenario: User with no membership sees an empty state
    Given a signed-in user with no active membership
    When the user opens the app
    Then the dashboard shows "Ask your administrator for an invitation"
