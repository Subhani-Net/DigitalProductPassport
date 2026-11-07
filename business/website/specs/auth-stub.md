# Auth Stub — Interface & Dev Behaviour

**Purpose:** unblock the application shell while production authentication is designed as a
**separate story**. The stub implements the same interface the real provider will implement, so
the API contract and UI do not change when we swap it.

## Interface (C#)

```csharp
public interface IAuthProvider
{
    Task<AuthResult> RegisterAsync(RegisterRequest request, CancellationToken ct);
    Task<AuthResult> LoginAsync(LoginRequest request, CancellationToken ct);
    Task<AuthResult> RefreshAsync(string refreshToken, CancellationToken ct);
    Task LogoutAsync(string sessionId, CancellationToken ct);
    Task VerifyEmailAsync(string token, CancellationToken ct);
    Task RequestPasswordResetAsync(string email, CancellationToken ct);
    Task ResetPasswordAsync(string token, string newPassword, CancellationToken ct);
}

public sealed record AuthResult(
    Guid UserId,
    string AccessToken,
    string RefreshToken,
    DateTimeOffset AccessExpiresAt,
    DateTimeOffset RefreshExpiresAt);
```

- The API depends on `IAuthProvider`, never on the stub type.
- The stub is registered only when `Auth:Mode = "Stub"`; startup **fails** in Production if
  `Auth:Mode = "Stub"`.
- No secrets are committed; dev signing keys live in user-secrets/local settings.

## Dev stub behaviour

- In-memory users; seeds one owner + one installation.
- Fixed, clearly marked dev tokens (short-lived) — **never** for real data.
- "Email verification" and "password reset" are logged to the console, not sent.
- Refresh rotation and logout are simulated in memory.
- No MFA, no external identity provider.

## Acceptance criteria (stub story)

- [ ] API starts with `Auth:Mode=Stub`; refuses to start with it in Production.
- [ ] Register/login/refresh/logout/verify/reset endpoints return the contract shapes.
- [ ] A dev owner can reach the app shell; a wrong password returns 401.
- [ ] No real PII or production data is used in the stub.
- [ ] The UI works against the stub without changes when auth is swapped.

## Production auth — separate story (not now)

- Choose provider (ASP.NET Core Identity + OpenIddict/Duende, or managed: Entra External ID /
  Auth0 / Clerk).
- MFA, email delivery, password reset, token rotation, lockout, rate limits.
- Security review and penetration test.
- Update `security.md` and the OpenAPI contract if the flow changes.
