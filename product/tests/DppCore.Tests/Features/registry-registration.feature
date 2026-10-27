Feature: DPP passport registration
  As an economic operator
  I want to register passport metadata and obtain proof of registration
  So that my product is compliant in the registry

Scenario: Register metadata and fetch proof of registration
  Given the CBAM registry is running
  And the economic operator credentials are available
  When I request an OIDC token
  And I register the sample passport metadata
  Then the response status is 201
  And I receive a registry identifier
  When I fetch the proof of registration
  Then the proof response status is 200
  And the proof is a signed JWT
