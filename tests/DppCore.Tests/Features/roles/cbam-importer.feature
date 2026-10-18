Feature: CBAM importer / authorised declarant
  As an EU importer (authorised CBAM declarant)
  I want to manage my CBAM declarations
  So that I comply and minimise my certificate cost

  @ignore @stub
  Scenario: Apply for authorised declarant status
    Given I am an EU importer with an EORI number
    When I apply for authorised CBAM declarant status
    Then my application is submitted to the national competent authority
    And I receive a decision within 120 days

  @ignore @stub
  Scenario: Retrieve verified supplier emissions via EORI link
    Given my supplier has shared its EORI-linked installation data
    When I search the third-country installations registry
    Then I retrieve the verified embedded emissions for my imported goods

  @ignore @stub
  Scenario: Fall back to defaults when no verified data is available
    Given my supplier has not provided verified actual emissions
    When I assemble my declaration
    Then the default value is used and flagged as default
    And I am shown the additional cost of using the default

  @ignore @stub
  Scenario: Assemble the annual declaration
    Given I have imported CBAM goods with verified actual emissions
    When I assemble my annual declaration
    Then the declaration contains quantity, embedded emissions, carbon price paid and certificates

  @ignore @stub
  Scenario: Flag missing data during declaration assembly
    Given my declaration is incomplete
    When I assemble the annual declaration
    Then I am shown the missing fields before submission

  @ignore @stub
  Scenario: Settle certificates and deduct the foreign carbon price
    Given my annual declaration has a certificate obligation
    And a carbon price was already paid in the country of origin
    When I settle the declaration
    Then I surrender the required certificates
    And the foreign carbon price is deducted

  @ignore @stub
  Scenario: Meet the quarterly minimum holding
    Given I have accrued embedded emissions this year
    When the quarter ends
    Then I hold certificates covering at least half of my accrued emissions

  @ignore @stub
  Scenario: Share a read-only audit room with my verifier
    Given my declaration uses verified actual values
    When my accredited verifier requests evidence
    Then I can share a read-only evidence room with drill-down to source documents
