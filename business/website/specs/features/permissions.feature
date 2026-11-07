# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Permission groups and granular permissions
  As an installation owner
  I want to control exactly what each member can do
  So that access is least-privilege and scoped per installation

  Background:
    Given a signed-in exporter owner
    And an active installation

  Scenario: List system templates and custom groups
    When the owner opens permission groups
    Then the system templates "Owner", "Member", "Consultant" and "Verifier" are listed
    And custom groups for this installation are listed

  Scenario: Create a custom group
    When the owner creates a group "Upload only" with "document.read" and "document.upload"
    Then the group is created for this installation
    And it is not visible in another installation

  Scenario: Assign a group to a member
    Given a member without a permission group
    When the owner assigns "Upload only" to the member
    Then the member's effective permissions are "document.read" and "document.upload"

  Scenario: Add a DENY override
    Given a member in the "Member" group
    When the owner denies "report.download" for that member
    Then the member's effective permissions exclude "report.download"

  Scenario: Add an ALLOW override
    Given a member in the "Consultant" group
    When the owner allows "report.create" for that member
    Then the member can create a draft report

  Scenario: Verifier is read-only
    Given a member in the "Verifier" group
    When the member attempts upload, delete or publish
    Then every request is rejected with "forbidden"

  Scenario: Only permitted users manage groups
    Given a member without "permission_group.manage"
    When the member tries to create a group
    Then the request is rejected with "forbidden"

  Scenario: A group cannot cross installations
    Given a custom group created in installation A
    When the owner of installation B tries to assign it
    Then the request is rejected with "validation_error"

  Scenario: Every group change is audited
    When the owner changes a member's permission group
    Then an audit event records the change
