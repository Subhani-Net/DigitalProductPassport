# Product Gaps & Uncovered Scope

What the spec covers: the data engine, the 4 friction pillars, the 6 beyond-processing jobs,
the JSON seam + guarantees. What it **does not yet cover** — the gaps below. Each: *gap → why it
matters → suggestion → when.*

## 1. Customer journey & activation (biggest gap)

- **Gap:** the spec describes what happens *inside* the engine, but nothing about how a
  customer arrives, signs up, and reaches first value in one session.
- **Why it matters:** "streamlined capture" is our wedge — but the *first 15 minutes* is where
  the friction claim is won or lost. Without onboarding, the demo can't become a customer.
- **Suggestion:** specify the **activation path** — sign-up → connect/upload first file →
  auto-mapped preview → SEE + saving in minutes → invite supplier/verifier. Make "time-to-first-
  value" an acceptance criterion.
- **When:** Phase 1 (it *is* the capture wedge).

## 2. Two-sided network cold-start (chicken-and-egg)

- **Gap:** exporter↔importer is a network; we haven't specified **who we onboard first** and how
  the second side joins without the first.
- **Why it matters:** two-sided products die on cold-start. This is a go-to-market risk, not just
  a feature.
- **Suggestion:** lock **exporter-first** (our thesis: supplier-side is under-served; SAP is
  declarant-only). Define the **invite mechanics**: exporter invites importer via EORI link, or
  importer invites its suppliers.
- **When:** Phase 1 decision (before pilot).

## 3. Operational / back-office (not in the spec)

- **Gap:** no spec for multi-tenancy, billing/entitlements, notifications/deadlines, support,
  analytics/dashboard, observability, backup/DR.
- **Why it matters:** a working engine ≠ a product someone can run and pay for.
- **Suggestion:** add a **"platform operations"** section: tenant isolation, subscription
  tiers (L/B/H), deadline reminders (30 Sep declaration, quarterly holding), customer dashboard,
  logging/observability.
- **When:** Phase 1 minimal (tenancy + billing + reminders), Phase 2 fuller.

## 4. Regulatory obligations on US (not just our customers)

- **Gap:** we've mapped *customer* obligations (CBAM, DPP) but not *our own* as a SaaS/DPP
  service provider.
- **Why it matters:** a platform in this space has its own duties.
- **Suggestion:** explicitly track and plan for:
  - **DPP Service Provider delegated act (Q2–Q3 2027)** — registration + **portability** duties
    (EO-owned URL is our partial answer, but confirm).
  - **GDPR** (supplier contacts, verifier names) — data-subject rights, DPIA.
  - **Liability** — contract terms/caps (importer stays liable; we warrant *correctness of
    method*, not the customer's raw data).
- **When:** watch item now; act when the DA lands.

## 5. Engine completeness (the calculation long tail)

- **Gap:** the engine covers mass/energy/volume + electricity + precursors. Not yet: **CEMS**
  (measurement-based), **mass-balance method**, **PFC slope**, **heat/CHP**, **by-products**,
  **biomass**, **own-generation**.
- **Why it matters:** real installations hit these; without them, we fall back to defaults
  (costs the customer money) or produce wrong SEE.
- **Suggestion:** sequence these into Pillar 2 p2/p3 (already stubbed); lock the order with the
  consultant.
- **When:** Phase 2–3 (consultant-driven).

## 6. Security & compliance posture (as product features)

- **Gap:** TISAX/ISO 27001 readiness is named in the roadmap but not specified as features.
- **Suggestion:** encryption at rest/in transit, secret management, role/permission model,
  audit log of *our* actions, SOC2-style controls — as explicit requirements.
- **When:** Phase 1 posture starts; full cert on customer demand (T3).

## 7. Data lifecycle

- **Gap:** retention, deletion (right to erasure), schema **migration** of existing customer
  data across versions, portability.
- **Suggestion:** define retention windows, export/delete, and schema-upgrade migration rules.
- **When:** Phase 2 (once real data exists).

## 8. Production readiness

- **Gap:** async/long-running jobs (large files), retries/idempotency, error UX, rate limits,
  deployment model (SaaS vs on-prem), regions/data residency.
- **Suggestion:** specify async import job semantics (already have idempotency key), deployment
  (Docker-first, single region to start).
- **When:** Phase 1–2.

## 9. Explicit non-goals (to prevent scope creep)

- **Out:** batteries (Minespider turf), fertilisers, cement, hydrogen, electronics.
- **Deferred:** downstream-expansion engine (P3/P4), textiles (P3), own verification entity
  (keep-open), SNARK (P2 spike).
- **Suggestion:** record these as locked non-goals so we don't drift.

## 10. Market validation (a risk, not a scope gap — but call it out)

- **Gap:** willingness-to-pay / payer routing / verifier adoption are **unvalidated** (discovery
  deferred). This is the biggest *existential* gap, not a product gap.
- **Suggestion:** keep the solution-led demo path (§ presentation-plan) as the de-risking trigger;
  don't let spec/engineering run indefinitely ahead of it.

---

## Top 5 to close first

1. **Customer journey / activation** (1) — it *is* the capture wedge.
2. **Exporter-first cold-start decision** (2).
3. **Platform operations minimal** — tenancy + billing + reminders (3).
4. **Our regulatory obligations** — DPP Service Provider DA watch (4).
5. **Lock the non-goals** (9).
