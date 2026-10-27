Feature: CBAM registry connectivity
  As an integration engineer
  I want to confirm the DPP registry is reachable
  So that submission flows can run reliably

Scenario: Registry API responds to a health check
  Given the CBAM registry is running
  When I call the registry health endpoint
  Then the response status is 200
