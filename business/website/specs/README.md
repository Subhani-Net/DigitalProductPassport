# Application Shell Spec — Veriflow Web App

**Scope:** the customer-facing **application shell** — screens, interactions, file upload and
management, display of results, and the security of all user interaction. It is **not** the CBAM
calculation engine.

## Separation of concerns (do not mix)

| Area | Location | What it is |
|---|---|---|
| **Marketing site** | `business/website/*.html` | Public pages, pricing, pilot, contact form |
| **Application shell spec** | `business/website/specs/` (this folder) | Auth, tenants, uploads, dashboard, display, security |
| **CBAM engine** | `product/src/DppCore/`, `product/tests/DppCore.Tests/`, `business/product-spec.md`, `business/specification-by-example.md` | The regulated calculation, evidence, and engine BDDs — **untouched** |

The engine is built **manually and in phases**. The app shell must present its outputs and manage
the documents/evidence around it; it must **not** pretend to calculate SEE in the browser.

## Source inputs (kept for reference)

- `1. The Database Architecture (Schema Spec).txt` — the original Prisma-style data model.
- `2. The REST API Endpoints (OpenAPI Spec).txt` — the original API draft.

The enhanced spec below supersedes them for implementation. The originals stay for traceability.

## Enhanced spec files

| File | Purpose |
|---|---|
| `README.md` | This scope + how to review |
| `data-model.md` | Enhanced entities, tenancy, statuses, constraints (Prisma + EF Core notes) |
| `openapi.yaml` | Corrected/expanded API contract (auth, tenants, documents, reports, security) |
| `ui-flows.md` | Screens, states, roles/permissions, upload UX, display rules |
| `security.md` | AuthN/AuthZ, tenant isolation, file security, privacy, audit |
| `features/*.feature` | Gherkin acceptance specs for the app shell (`@ignore @stub`) |
| `decisions/ADR-001-stack-storage-auth.md` | Stack/storage/auth decision (proposed) |

## Non-goals (explicit)

- No CBAM SEE calculation in the shell; the engine is manual/phased.
- No LCA, EPD or full ESG reporting.
- No verification stamp; the accredited verifier remains external.
- No “verified” claim anywhere in the UI — only **“verifier-ready.”**

## How to review

1. Read `data-model.md` and `openapi.yaml` together — they must agree.
2. Check `ui-flows.md` against the roles/permissions matrix.
3. Check `security.md` against every endpoint and upload path.
4. Read the Gherkin features; promote `@ignore @stub` to runnable as slices ship.
5. Resolve the ADR questions (stack, storage, auth) before implementation.

## Status

Draft, November 2026. The raw `.txt` specs are inputs; this set is the reviewable baseline.
