# Implementation Stories — Application Shell

Plan for the customer-facing shell. **Auth and the engine are stubs**; production versions are
separate stories. The CBAM engine BDDs in `product/tests/` are untouched.

## Accepted decisions

| Decision | Choice |
|---|---|
| Stack | **C#/.NET + EF Core** |
| Database | **Single DB + PostgreSQL row-level security** |
| Storage | **Azure Blob + SAS** |
| Auth | **Stub now**; production is a separate story |
| Engine | **Stub now**; production is a separate, manual, phased story |
| Permissions | **Permission groups + per-installation, per-member granular permissions** |
| Verifier | **Read-only for now**; capabilities deferred |

## Definition of Done (every story)

- OpenAPI updated (if the contract changes) and the spec validates.
- EF Core migration + RLS policy where tenant data is added.
- Unit + integration tests; Gherkin promoted from `@ignore @stub` when implemented.
- Permission check enforced server-side; audit event for state changes.
- No secrets in the repo; config via app settings/user-secrets.
- UI states: empty, loading, error, permission-denied; accessibility checked.
- `README`/spec traceability updated.

---

## E0 — Spec baseline (done)

| ID | Story | Status |
|---|---|---|
| APP-001 | Data model, OpenAPI, UI flows, security, Gherkin, ADR-001 | ✅ |

## E1 — Platform foundation

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-101 | ASP.NET Core API skeleton + EF Core + PostgreSQL | `/health` returns 200; OpenAPI served; config validated | — | M |
| APP-102 | Migrations baseline + RLS session middleware | tenant tables have policies; session variable set per request | APP-101 | M |
| APP-103 | CI: build, tests, OpenAPI lint, migration check | pipeline green; PR gate | APP-101 | S |
| APP-104 | Observability: structured logs, request IDs | correlation id in logs; no PII | APP-101 | S |

## E2 — Auth stub (production separate)

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-201 | `IAuthProvider` + dev stub + startup guard | `Auth:Mode=Stub` works; refuses in Production | APP-101 | M |
| APP-202 | Sessions + refresh rotation (stub) | refresh rotates; logout revokes | APP-201 | S |
| APP-203 | Auth endpoints wired to the contract | register/login/refresh/logout/verify/reset | APP-201 | M |
| APP-204 | Auth Gherkin + tests | scenarios green; no real email sent | APP-203 | S |

## E3 — Permissions & tenancy

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-301 | Permission catalog + seed system groups | 18 keys seeded; Owner/Member/Consultant/Verifier templates | APP-101 | M |
| APP-302 | Custom permission groups (per installation) | CRUD; cannot cross installations | APP-301 | M |
| APP-303 | Membership group + overrides + effective permissions | `group ∪ ALLOW − DENY`; unit-tested | APP-302 | M |
| APP-304 | Permission policies/middleware + RLS backstop | every tenant endpoint checks a permission key | APP-303 | M |
| APP-305 | Permissions Gherkin + IDOR tests | `permissions.feature` + `tenant-isolation.feature` green | APP-304 | M |

## E4 — Installations & team

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-401 | Create/list/get installation | scoped to membership | APP-102 | M |
| APP-402 | Invitations create/accept/revoke | single-use token; 7-day expiry | APP-401 | M |
| APP-403 | Members list/revoke/change group | `member.manage`; audit event | APP-303 | M |
| APP-404 | Team Gherkin + tests | `team.feature` green | APP-403 | S |

## E5 — Documents (Azure Blob + SAS)

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-501 | Blob container + SAS provider | private container; short-lived; per-tenant prefix | APP-101 | M |
| APP-502 | Upload intent + complete | allowlist, 25 MB, hash, idempotency | APP-501 | M |
| APP-503 | Document list/detail/soft delete | pagination; `document.delete`; soft delete | APP-502 | M |
| APP-504 | Scan stub + status transitions | `PROCESSING → READY_FOR_AUDIT / QUARANTINED` | APP-502 | S |
| APP-505 | Documents Gherkin + upload security tests | `documents.feature` + `security.feature` green | APP-503 | M |

## E6 — Reports, dashboard, engine stub

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-601 | Report draft/list/get | tenant-scoped; status `DRAFT` | APP-401 | M |
| APP-602 | `IEmissionEngine` + synthetic snapshot | `IsSynthetic=true`; no shell calculation | APP-601 | M |
| APP-603 | Dashboard summary | counts + latest snapshot + saving | APP-602 | M |
| APP-604 | Download SAS link | short-lived; `report.download` | APP-601 | S |
| APP-605 | Reports/dashboard Gherkin | `dashboard.feature` green | APP-603 | S |

## E7 — Security & audit

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-701 | Audit events | state changes recorded; no secrets/PII | APP-303 | M |
| APP-702 | Rate limiting + idempotency | auth/upload limits; `Retry-After` | APP-203 | S |
| APP-703 | Headers/CORS/CSRF | CSP/HSTS/CORS allowlist | APP-101 | S |
| APP-704 | Security test suite | IDOR, upload, auth, headers | APP-702 | M |
| APP-705 | RLS verification | cross-tenant queries denied at DB level | APP-102 | M |

## E8 — Verifier (read-only)

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-801 | Read-only evidence room | view report/evidence/download only | APP-602 | M |
| APP-802 | Verifier capabilities (deferred) | backlog; define later | APP-801 | — |

## E9 — Frontend shell (stack TBD)

> **Decision needed:** Blazor (one .NET stack) or React/TypeScript. Add an ADR before APP-901.

| ID | Story | Acceptance | Depends | Size |
|---|---|---|---|---|
| APP-901 | Frontend scaffold + app shell/nav + installation switcher | responsive; accessible | APP-203 | M |
| APP-902 | Auth screens against the stub | register/login/verify/reset/accept invite | APP-901 | M |
| APP-903 | Dashboard + documents UI | upload UX, status chips, empty/error states | APP-502 | L |
| APP-904 | Reports + evidence UI | figures, goods, flags, drill-down | APP-602 | L |
| APP-905 | Team + permission-group UI | groups, assignment, overrides | APP-303 | L |
| APP-906 | Playwright + axe E2E | journeys + accessibility | APP-905 | M |

## E10 — Production auth (separate, later)

| ID | Story | Acceptance | Depends |
|---|---|---|---|
| APP-1001 | Choose and integrate provider | managed provider or ASP.NET Core Identity | APP-203 |
| APP-1002 | MFA + email + reset + rotation | current industry practice; documented | APP-1001 |
| APP-1003 | Security review + pen test | high findings closed | APP-1002 |

## E11 — Production engine (separate, later)

| ID | Story | Acceptance | Depends |
|---|---|---|---|
| APP-1101 | Replace engine stub with real service | same `IEmissionEngine` contract; no UI change | APP-602 |
| APP-1102 | Verification/partner hand-off | evidence dossier; accredited partner | APP-1101 |
| APP-1103 | Engine validation intelligence | tests + compliance matrix | APP-1101 |

---

## Suggested sequence

| Milestone | Stories | Outcome |
|---|---|---|
| **M0** | Review this spec + ADR-001 | decisions locked |
| **M1** | E1, E2 (stub), E3 | shell foundation, auth stub, real permissions |
| **M2** | E4, E5 | tenants/team + document upload |
| **M3** | E6, E8 | dashboard, engine stub, verifier read-only |
| **M4** | E7, E9 | security hardening + frontend |
| **M5** | E10 | production auth |
| **M6** | E11 | production engine |

## Open questions

1. **Frontend stack:** Blazor or React/TypeScript? (Needed before E9.)
2. Consultant default group: upload or read-only?
3. Member delete scope: own uploads only, or all?
4. Internal `ADMIN` role outside tenant permissions?
5. Retention period (proposed 24 months).
6. Verifier capabilities beyond read-only — deferred.
