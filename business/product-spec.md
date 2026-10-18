# Product Specification — CBAM / DPP Platform

The whole product defined **top-down** (customer outcome → business rule → examples), using
Specification by Example. Companion to `specification-by-example.md` (the method) and
`sprint-plan.md` (the schedule). This is the document to *understand the product* before
implementation detail.

Executable mirror: `../tests/DppCore.Tests/Features/roles/*.feature` (Gherkin, mostly
`@ignore @stub` until built).

---

## Segment 1 — Importer (Authorised CBAM Declarant)

**Outcome:** *"I get declaration-ready, verifier-ready data and lower my certificate cost."*

| # | Rule (Feature) | Examples (scenarios) | Status |
|---|---|---|---|
| 1.1 | Authorisation | apply with EORI → NCA decision ≤120 days · rejected application | stub |
| 1.2 | Retrieve supplier data | link supplier via EORI · retrieve verified embedded emissions · **fall back to defaults when no verified data** | stub |
| 1.3 | Assemble annual declaration | assemble from verified actuals · assemble from defaults · flag missing/incomplete data | stub |
| 1.4 | Settle certificates | surrender certificates · deduct foreign carbon price · quarterly minimum holding | stub |
| 1.5 | Audit room | share a read-only evidence room (drill-down to source docs) with the verifier | stub |

**Questions (→ later):** exact NCA status workflow; default-value catalogue integration (IR 2025/2621).

## Segment 2 — Exporter (Non-EU installation operator)

**Outcome:** *"I submit verifier-ready data once and EU importers use it."*

| # | Rule (Feature) | Examples (scenarios) | Status |
|---|---|---|---|
| 2.1 | Register installation (O3CI) | register with confidential treatment of data | stub |
| 2.2 | Upload emissions data once | upload installation + emissions; stored once for reuse by many declarants | stub |
| 2.3 | Verifier-ready evidence | produce evidence dossier (source records, factors, audit trail) · data-quality tiers | stub |
| 2.4 | Share with importer | link importer via EORI → importer retrieves verified data | stub |
| 2.5 | Validation feedback | flag anomaly (e.g. GHG-Protocol method used instead of CBAM allocation) before the verifier sees it | stub |

## Segment 3 — Verifier (Accredited)

**Outcome:** *"I audit faster via a read-only evidence room."*

| # | Rule (Feature) | Examples (scenarios) | Status |
|---|---|---|---|
| 3.1 | Evidence review | drill down from SEE figure to raw invoices/meter logs | stub |
| 3.2 | Recalculation | recalc a sample that matches methodology · recalc that finds a mismatch | stub |
| 3.3 | Verification report | issue report → enables verified actuals · flag non-conformity | stub |
| 3.4 | Independence guard | self-review of own affiliate's work is blocked | stub |

## Segment 4 — Platform administrator (public authority / our SaaS)

**Outcome:** *"The platform stays conformant and secure."*

| # | Rule (Feature) | Examples (scenarios) | Status |
|---|---|---|---|
| 4.1 | Schema management | publish a metadata schema version → it becomes the active validation schema | stub |
| 4.2 | Role access | change a user's role mapping → permissions change | stub |
| 4.3 | Self-assurance (T1/T2) | run conformance harness; record compliance-matrix evidence | runnable (partial) |

## Segment 5 — End user

**Outcome:** *"I can read and verify a product's passport."*

| # | Rule (Feature) | Examples (scenarios) | Status |
|---|---|---|---|
| 5.1 | Read passport | scan GS1 Digital Link → view information permitted for my access level | stub |

## Cross-cutting — Trust layer (P2+, zero-exposure)

**Outcome:** *"Verify a claim without exposing the supplier's proprietary data."*

| # | Rule (Feature) | Examples (scenarios) | Status |
|---|---|---|---|
| 6.1 | Zero-exposure attestation | importer verifies a PCF claim without seeing the recipe/energy mix (SNARK) | stub (P2 ZK spike) |

---

## Cross-cutting rules that apply everywhere

| Rule | Example |
|---|---|
| Data provenance | every figure is anchored to its source document (immutable) |
| Methodology conformance | background checks flag non-CBAM methods (GHG Protocol vs EU allocation) |
| Actual vs default | determination flag on every product line |
| Determinism | same inputs → same SEE, every time (already tested) |

## What is already runnable vs stubbed

- **Runnable (green):** CBAM calculation (`cbam-calculation.feature`), DPP registry
  connectivity/authorization/registration (`registry-*.feature`).
- **Stubbed (`@ignore`):** all role outcomes above (`roles/*.feature`) — promoted sprint by sprint.

## How this maps to the build

Importer 1.2/1.3 + Exporter 2.2/2.3 + Verifier 3.1/3.2 sit on the **C2 canonical model** and
the **C5 engine** (already started). The role stubs are the acceptance criteria those chunks
must satisfy — so C2 is shaped by these outcomes, not the other way around.
