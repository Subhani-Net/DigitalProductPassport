# Jobs-to-be-Done — The "Beyond Processing" Core

The product is **not** a data processor. Taking JSON in → calculating → emitting a number is
the **commodity substrate** (CarbonChain / cbam-tools / Dpp-tool already own it). The
**mandatory core** — the reason customers pay and the moat — is the six jobs *around* the
processing. Each is stated as: **challenge → our solution → how we continuously improve.**

Companion docs: `product-spec.md` (the what) · `system-intricacies.md` (the how) ·
`../competition/friction-gap-analysis.md` (why us) · `../research/data-layer.md` (the data).

---

## J1 — Extract (get the inputs from messy reality)

- **Challenge:** inputs don't exist in clean form — paper logs, weighbridge tickets, utility
  bills, MTC/CoA PDFs, Excel, ERP, meters. Mills are non-technical; every customer differs.
  A calculator is useless without the data, and the data is the hard part.
- **Solution:** an **adapter/plugin seam** (`format → JSON`); **S0/S1-first** (files, not OT
  access); **column auto-map + unit auto-detect + per-row validation feedback**.
- **Improve continuously:** add adapters (CSV→XLSX→PDF→ERP→OT); learn mapping patterns per
  customer segment; AI document extraction; a template library per segment.

## J2 — Judge (make the data true & verifier-survivable)

- **Challenge:** a *number* is not enough — it must survive an **accredited verifier**.
  Route-specific (BOF/EAF/DRI/PFC), methodology traps (GHG Protocol vs CBAM allocation),
  boundaries, mass-balance. A naive engine gets these wrong.
- **Solution:** **validation intelligence** — plausibility checks, boundary completeness,
  mass-balance consistency, route-qualified parameters, methodology-conformance flags,
  actual-vs-default determination.
- **Improve continuously:** every verifier finding, every consultant rule, and every new
  route/sector is **encoded into the rule library**. That library *is* the moat, and it compounds.

## J3 — Prove (make the output defensible)

- **Challenge:** even a correct number fails an audit without evidence. Today = hundreds of
  hours digging through PDFs/emails.
- **Solution:** **provenance** (raw + derived, hash-chained to source); determination flag per
  line; an **evidence dossier**; a **read-only drill-down** for the verifier.
- **Improve continuously:** automate evidence assembly; score dossier completeness; feed the
  partner-verifier's findings back into what we capture.

## J4 — Coordinate (two-sided hand-off + trust)

- **Challenge:** the importer is liable, the exporter holds the data, and neither will expose
  secrets. Duplicate submissions and loose links break trust.
- **Solution:** **upload-once** (idempotent), **EORI link**, **role-based access**,
  **zero-exposure hand-off** (the supplier's recipe/energy mix is never shown to the importer).
- **Improve continuously:** network effects (more importers reuse the same supplier data);
  graduate to **zero-knowledge attestation (SNARK)** when the P2 spike justifies it.

## J5 — Advise (decision support)

- **Challenge:** customers don't know *what* to collect, or *what it saves them*. A passive
  processor leaves them to guess.
- **Solution:** **actual-vs-default cost delta** ("collect these fields, save €X"); certificate
  settlement math; a **readiness score**; a **collection checklist**.
- **Improve continuously:** benchmark data (worldsteel/IAI/EC defaults); default-vs-actual
  intelligence; per-route best-practice playbooks.

## J6 — Complete (fulfil the compliance action)

- **Challenge:** submission, declaration, certificates, and the DPP are **external obligations**,
  not internal transforms. Processing data ≠ being compliant.
- **Solution:** registry **submission + proof of registration**; **declaration assembly**;
  **certificate settlement**; the **DPP bridge** (sell-twice).
- **Improve continuously:** track regulatory drift via **schemas-as-data**; extend to new
  product categories and the DPP wave.

---

## The continuous-improvement engine (this is the moat)

One loop, three inputs:

```
verifier findings ──┐
customer data edge cases ──►  encode as a rule  ──►  spec stub (@ignore) ──►  code ──►  green
new routes / sectors / acts ──┘        (validation / evidence library)
```

- **Cadence:** each sprint promotes the highest-value rule.
- **The moat:** accumulated encoded judgment — the more real data and verifier feedback we see,
  the better the library, and the harder it is for a generic calculator to catch up.
- **Mechanisms:** spec-first Gherkin stubs, the compliance matrix, and the verifier-grade
  consultant (knowledge encoded, never held only in heads).

## Mapping to the rest of the spec

| Job | Pillar (product-spec §0) | Guarantee (system-intricacies §1) |
|---|---|---|
| J1 Extract | 1. Capture | G4 identity, G6 security |
| J2 Judge | 2. Validation intelligence | G3 determinism |
| J3 Prove | 3. Audit room | G2 provenance |
| J4 Coordinate | 4. Trust & hand-off | G5 role/confidentiality, G3 idempotency |
| J5 Advise | 2/4 (economics) | — |
| J6 Complete | 4 (transfer + sell-twice) | G1 schema versioning |

## Definition of "the product works"

A customer hands us **messy inputs** and receives a **verifiable, registrable, defensible
declaration** — with **advice** on what saved them money and **trust** that nothing sensitive
leaked. The number in the middle is the easy part; these six jobs are the product.
