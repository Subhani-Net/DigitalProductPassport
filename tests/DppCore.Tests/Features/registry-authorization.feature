Feature: CBAM registry authorization
  As an economic operator
  I want to authenticate with my operator credentials
  So that I can submit passport data securely

Scenario: Economic operator obtains a token with the eo role
  Given the CBAM registry is running
  And the economic operator credentials are available
  When I request an OIDC token
  Then I receive an access token with the eo role

Scenario: Unauthenticated registration is rejected
  Given the CBAM registry is running
  When I register a passport without a token
  Then the response status is 401 or 403
