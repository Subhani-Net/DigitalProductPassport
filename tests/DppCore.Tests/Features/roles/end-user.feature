Feature: End user browsing (DPP)
  As an end user
  I want to read a product's passport
  So that I can verify its sustainability claims

  @ignore @stub
  Scenario: Scan a QR code and read the passport
    Given a product has a registered passport
    When I scan its GS1 Digital Link
    Then I can view the passport information permitted for my access level
