Feature: Platform administration (DPP registry)
  As a platform administrator (public authority)
  I want to manage schemas and roles
  So that the platform stays conformant and secure

  @ignore @stub
  Scenario: Publish a metadata schema version
    Given I am authorised as public authority
    When I submit a new DPP metadata JSON schema
    Then the schema becomes the active validation schema

  @ignore @stub
  Scenario: Manage role access
    Given I am authorised as public authority
    When I change a user's role mapping
    Then the user's permissions change accordingly
