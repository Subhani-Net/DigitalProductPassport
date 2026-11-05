# ADR-001 — Backend stack, storage and authentication (proposed)

**Status:** Proposed — pending review.
**Date:** 5 November 2026.
**Scope:** the **application shell** (auth, tenants, uploads, dashboard, display). The CBAM
calculation engine remains C#/.NET and is untouched.

## Context

- The engine (`product/src/DppCore`) is **C#/.NET**, tested with xUnit + Reqnroll.
- The raw app-shell spec (`specs/1. … Schema Spec.txt`, `specs/2. … OpenAPI Spec.txt`) was
  written in **Prisma/Node** with **AWS S3** pre-signed uploads.
- The marketing site is deployed to **Azure Static Web Apps**; the contact form is already an
  Azure Function + Table Storage.
- The shell must be secure, multi-tenant, and quick to show customers, while the engine is
  delivered manually in phases.

## Decision drivers

1. One stack vs two (team cognitive load, reuse of types/validation).
2. Azure alignment (hosting, identity, storage, observability).
3. Time to a credible customer-facing shell.
4. Security and tenant isolation.
5. Cost and operability at pilot scale.

## Options

### A. Node/TypeScript + Prisma + S3 (matches the raw spec)
- Pros: fastest to the exact spec; strong ecosystem for web apps; Prisma migrations.
- Cons: a second stack alongside C#/.NET; S3 is off-Azure; duplicate domain models.

### B. C#/.NET + EF Core + Azure Blob (recommended)
- Pros: one stack with the engine; Azure-native (Blob SAS, Entra, App Service/Container Apps);
  shared types/validation; easier long-term maintenance.
- Cons: more up-front work than Prisma; the raw spec must be translated (fields stay identical).

### C. Hybrid — Node shell + C# engine API
- Pros: best tool per layer; clear service boundary.
- Cons: two deployables, two auth integrations, more operational surface for a solo founder.

## Recommendation

- **Stack:** **B** — C#/.NET + EF Core — unless there is a hard reason to prefer TypeScript.
- **Storage:** **Azure Blob Storage with SAS** (private container, per-tenant prefix,
  short-lived, single-use where possible). The contract is storage-agnostic (`uploadUrl`,
  `storageKey`), so S3 remains possible without changing the API.
- **Auth:** **managed** (Entra External ID, Auth0 or Clerk) to reduce security risk, or
  ASP.NET Core Identity if building; the OpenAPI contract stays the same either way.
- **Database:** PostgreSQL (Azure Database for PostgreSQL) with row-level security; single
  database, tenant column, RLS — not database-per-tenant at pilot scale.

## Consequences

- The Prisma schema in `data-model.md` is the **logical** model; EF Core migrations are the
  implementation. Keep the OpenAPI contract identical.
- The upload flow uses Azure Blob SAS; the UI still calls `upload-intent` and `PUT`s to the URL.
- Managed auth changes the login endpoints (hosted UI/redirects). If we keep the email/password
  endpoints in `openapi.yaml`, we build auth; if we adopt managed auth, mark those endpoints as
  internal/removed and update the contract.
- Document the decision in `compliance-matrix.md` when implemented.

## Open questions

1. **Stack:** confirm B (C#/.NET) or choose A (Node/Prisma).
2. **Storage:** confirm Azure Blob or keep S3.
3. **Auth:** managed provider vs build.
4. **Tenancy:** single DB + RLS (recommended) vs schema/database per tenant.
5. **Timeline:** does "customer impression" require the shell before the engine produces a real
   report? If yes, seed a **synthetic report** clearly labelled as a pilot example.
