# Security Spec — Application Shell

Security is a **specification**, not a later hardening task. Every endpoint, upload path and
screen in `openapi.yaml` / `ui-flows.md` must satisfy this document.

## 1. Principles

1. **Deny by default.** No endpoint is public unless explicitly marked.
2. **Server-side enforcement.** The UI may hide actions; the API checks role + tenant on every call.
3. **Tenant isolation.** Every tenant-owned query is scoped by `installationId`.
4. **Least privilege.** Roles are per installation (`Membership`), never global.
5. **No secrets in the repo.** Use environment/Key Vault; rotate.
6. **Least data.** Collect only what the flow needs; hash identifiers in logs.

## 2. Authentication

- Passwords: **Argon2id** (preferred) or bcrypt with a strong work factor; never plain text.
- Password policy: minimum 12 characters; check against a breached-password list.
- **Email verification** before full access; tokens are single-use and expire.
- **Password reset**: single-use token, short expiry, always returns 204 (no account enumeration);
  reset revokes all sessions.
- **Sessions**: short-lived access token + rotating refresh token. Refresh rotation revokes the
  old token. Logout revokes the session.
- **Lockout / rate limit** on login and reset (per account + per IP).
- **MFA** (TOTP) recommended before paid scale; design the UI now, enable later.
- Optional managed auth (Entra External ID / Auth0 / Clerk) is allowed; the contract stays the same.

## 3. Authorization and tenant isolation

- Every tenant path includes `installationId`; the server **must** verify an `ACTIVE` membership
  for `(currentUser, installationId)` before any read/write.
- Role matrix is in `ui-flows.md` §1; enforce it in middleware/handlers, not the client.
- **IDOR tests** are mandatory: a user from tenant A must get **404/403** for tenant B's
  installation, document, or report — never data.
- Database: enable **row-level security** (or equivalent enforced query scoping) on all tenant tables.
- Never accept `userId`/`installationId` from the body where the path already defines it.
- Verifier role is **read-only**; it cannot upload, delete, create, or publish.

## 4. Input validation

- Validate every request against the OpenAPI schema (types, enums, lengths, formats).
- Reject unknown fields (or ignore them explicitly); no mass assignment.
- Parameterised queries only (no string-built SQL).
- Output encoding for all user-supplied text; no `innerHTML` with user data.
- Bound arrays/pagination (`pageSize ≤ 100`); cap request body size.
- Validate dates (period start < end) and UUIDs.

## 5. File upload and management security

- **Pre-signed upload only.** The server never proxies the file bytes.
- **Allowlist**: `application/pdf`, `image/jpeg`, `image/png`, `text/csv`,
  `application/vnd.openxmlformats-officedocument.spreadsheetml.sheet`.
- **Size cap**: 25 MB (enforced client and server; signed policy enforces it too).
- **Short-lived URL** (e.g. 5–15 min), single use where supported, scoped to the exact key.
- **Per-tenant prefix**: `installations/{installationId}/documents/{documentId}/{filename}`.
- **Private container/bucket**; no public URLs; downloads via short-lived signed URLs.
- **Hash** (`sha256`) stored for integrity/dedupe; verify on complete.
- **Malware scan** on upload (`PENDING → CLEAN | INFECTED | FAILED`); infected files go to
  `QUARANTINED` and are never served.
- **No execution**: serve with `Content-Disposition: attachment` and a safe content type.
- Strip risky metadata where feasible (PDF scripts/JS, image EXIF).
- Reject path traversal and double extensions; sanitise the display filename.
- Retention: soft-delete; purge according to the retention policy.

## 6. Transport and headers

- HTTPS only; HSTS.
- `Content-Security-Policy` (no inline scripts; `connect-src` limited to the API origin).
- `X-Content-Type-Options: nosniff`, `Referrer-Policy: strict-origin-when-cross-origin`,
  `Permissions-Policy` minimal, `frame-ancestors 'none'`.
- **CORS**: allowlist the app origin(s) only; no `*` with credentials.
- If cookies are used: `Secure`, `HttpOnly`, `SameSite`, and **CSRF** tokens for state-changing
  requests. If bearer tokens are used, keep them out of `localStorage` where possible.

## 7. Rate limiting and abuse

- Per-IP and per-account limits on auth, upload-intent, and report creation.
- Return `429` with `Retry-After`.
- Idempotency keys on create/upload-intent to make retries safe.
- Monitor for enumeration, credential stuffing, and bulk uploads.

## 8. Logging and audit

- **Audit events** for: login, logout, invite, accept, role change, upload-intent, upload-complete,
  document delete, report create/publish/download, settings change.
- Store `actorUserId`, `installationId`, action, entity, timestamp; **hash** IP/user-agent.
- Never log passwords, tokens, full file contents, or unnecessary PII.
- Tamper-evident storage (append-only or WORM where possible).

## 9. Privacy and data protection

- Minimise data; state the purpose in `privacy.html`.
- UK GDPR / EU GDPR and India DPDP considerations: lawful basis, rights (access, rectification,
  erasure, portability), retention, subprocessors, international transfers.
- **Zero-exposure intent**: the importer/verifier sees the figure and evidence, not the
  supplier's recipe or commercial energy terms, by default.
- Data deletion request flow; backups purged on the retention schedule.
- DPAs with storage/email/auth subprocessors.

## 10. Secure development and operations

- Dependency scanning + secret scanning + SAST in CI.
- Pin and update dependencies; review advisories.
- Separate environments; no production data in dev/test.
- Least-privilege cloud identities; no long-lived keys where managed identity works.
- Penetration test before paid scale; remediate high findings.
- Incident response: detect, contain, notify (regulatory timelines), post-mortem.

## 11. Endpoint checklist (apply to every path)

- [ ] Public? Explicitly marked `security: []` and justified.
- [ ] Authenticated? Bearer/session validated.
- [ ] Tenant membership checked for `installationId`.
- [ ] Role checked against the matrix.
- [ ] Request validated against the schema; size/array caps.
- [ ] Response filtered to the tenant; no cross-tenant leakage.
- [ ] Errors are generic (no stack traces / internals).
- [ ] Rate limited where abusable.
- [ ] Audit event written for state changes.

## 12. Boundary statement

The shell is **verifier-ready, not verified**. It must never present an in-app badge or copy that
implies an accreditation or verification opinion. The accredited partner issues the verification.
