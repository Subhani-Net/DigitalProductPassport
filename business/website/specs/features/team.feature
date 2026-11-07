# Application shell — separate from the CBAM engine BDDs in product/tests/.
@app @ui @ignore @stub
Feature: Team and invitations
  As an installation owner
  I want to invite the right people with the right roles
  So that only authorised people can act

  Background:
    Given a signed-in installation owner

  Scenario: Invite a consultant
    When the owner invites "consultant@example.com" with the "Consultant" permission group
    Then an invitation is created
    And the consultant can view, but not publish, reports after accepting

  Scenario: Invite a verifier
    When the owner invites "verifier@example.com" with the "Verifier" permission group
    Then the invitation is created
    And the verifier gets read-only access after accepting

  Scenario: Accept an invitation
    Given a valid invitation for "new@example.com"
    When the invitee accepts it
    Then a membership is activated with the invited permission group

  Scenario: Expired invitation is rejected
    Given an invitation older than 7 days
    When the invitee accepts it
    Then the request is rejected with "gone"

  Scenario: Only a member with member.manage can change groups
    Given an exporter member without "member.manage"
    When the member tries to change another member's permission group
    Then the request is rejected with "forbidden"

  Scenario: Revoke a member
    When the owner revokes a member
    Then the member's access ends
    And an audit event is written
