# ADR-001 — Backend stack, storage, tenancy, auth (accepted)

**Status:** **Accepted** — 5 November 2026.
**Scope:** the **application shell** (auth stub, tenants, permissions, uploads, dashboard, display).
The CBAM calculation engine remains a separate, manual, phased concern.

## Decisions

| Decision | Choice |
|---|---|
| **Backend stack** | **C#/.NET + EF Core** (one stack with the engine) |
| **Database** | **Single database + row-level security (RLS)** |
| **File storage** | **Azure Blob Storage + SAS** (private container, per-tenant prefix, short-lived) |
| **Authentication** | **Stub now**; production auth is a **separate story** using current industry practice |
| **Engine** | **Stub now** (`IEmissionEngine`); real engine is a **separate story**, manual and phased |
| **Authorization** | **Permission groups + per-installation, per-member granular permissions** |
| **Verifier** | **Read-only for now**; exact verifier capabilities defined later |

## Context

- The engine (`product/src/DppCore`) is C#/.NET, tested with xUnit + Reqnroll.
- The raw app-shell spec used Prisma/Node + S3; we translate the **logical model** to EF Core and
  keep the **OpenAPI contract** identical.
- The shell must be credible to customers before the engine is production-ready. Auth and engine
  are stubbed; the **permission and tenant model is real** from day one.

## Consequences

- The Prisma schema in `data-model.md` is the logical model; **EF Core migrations** are the
  implementation. No API shape changes.
- Upload flow uses **Azure Blob SAS** (`upload-intent` → `PUT` → `complete`); `uploadUrl` and
  `storageKey` keep the contract storage-agnostic.
- **RLS** is enforced in PostgreSQL (session variable + policies), not just in application code.
- **Auth stub** implements the same interface the production provider will implement; it is
  clearly marked dev-only and must never be deployed as the real auth.
- **Engine stub** returns a synthetic `EngineReportSnapshot` marked `isSynthetic=true`; the UI
  labels it **"Pilot sample — engine pending."**
- Permission checks are **server-side** and derived from permission groups + overrides; roles are
  just system group templates.

## Follow-up stories (separate)

1. **Auth production** — choose provider/managed vs ASP.NET Core Identity; MFA, email, reset,
   token rotation, lockout; security review.
2. **Engine production** — real SEE pipeline, precursor handling, evidence, verifier hand-off.
3. **Verifier capabilities** — define the read-only evidence room scope and future actions.

## Open questions (tracked in `implementation-stories.md`)

- Does a consultant get upload rights by default, or only on a granted permission group?
- Can `EXPORTER_MEMBER` delete their own documents without an explicit permission?
- Retention period for documents/reports (proposed 24 months after last activity).
- Do we need an internal `ADMIN` role outside tenant permissions? (Proposed: yes, separate.)
