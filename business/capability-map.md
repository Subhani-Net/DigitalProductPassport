# Capability Map & Honest Self-Assessment

**Purpose:** a clear-eyed view of where we are **deep**, **partial**, **thin** or **absent**, so
we sell only what we can deliver and close the right gaps. Not investor copy — internal truth.

**Legend:** Deep = defensible today · Partial = works in pilot, not productised · Thin = weak
vs competitors · Absent = not started.
**Decision:** Build (our IP) · Partner (buy/adopt) · Defer (not now) · Licence (data/tooling).

---

## 1. Capability map

| Capability | Status | vs Sentra / incumbents | Decision |
|---|---|---|---|
| CBAM domain knowledge (scope, SEE, precursors, timeline) | **Deep** | At parity for the exporter job | **Build** |
| CBAM calculation engine (`CbamCalculator`, declaration/factor) | **Deep** | Parity on the core maths | **Build** |
| Canonical JSON seam + schema versioning/determinism | **Deep** | Ahead (spec-first, tested) | **Build** |
| Evidence/dossier design (source → factor → figure trail) | **Partial** | Ahead of "calculate-only" tools | **Build** |
| Pilot docket (synthetic documents + readings + runs) | **Partial** | Ahead of generic SaaS demos | **Build** |
| Ingestion (bills, invoices, tickets, mill certs) | **Partial** | Behind platform vendors | **Build** (narrow) |
| Registry XML / declaration output | **Thin** | Competitors claim it | **Build** (parity needed) |
| Verifier-ready (not verified) dossier | **Partial** | Our wedge; few claim it | **Build + Partner** |
| Verification stamp (accreditation) | **Absent** | N/A — never ours | **Partner only** |
| LCA engine (ISO 14040/44) | **Absent** | Sentra strong | **Partner / Defer** |
| EPD generation (ISO 14025 / EN 15804) | **Absent** | Sentra strong | **Partner / Defer** |
| Factor library (25k+) | **Thin** | Sentra strong | **Licence public sources** |
| Steel plant archetypes (150+) | **Thin** | Sentra claims strong | **Defer / partner** |
| Zero-exposure / SNARK trust layer | **Absent** (P2 spike) | Rare | **Build (gated)** |
| Exporter→importer reuse via EORI | **Thin** (design only) | Rare | **Build** |
| Brand / trust / references | **Absent** | Incumbents strong | **Earn via pilots** |
| Delivery capacity (solo, part-time) | **Thin** | Competitors have teams | **Sequence, don't scale yet** |
| Support/CS at volume | **Absent** | Incumbents strong | **Defer** |
| Enterprise ERP/PLM integrations | **Absent** | SAP/CarbonChain strong | **Defer** |

---

## 2. Where we are genuinely deep (defend these)

1. **Regulated calculation correctness** — the CBAM SEE maths, precursor handling, allocation.
2. **Evidence discipline** — every figure traceable to a document/factor; audit room.
3. **Spec-first engineering** — Gherkin spec, deterministic JSON, test harness (rare in this niche).
4. **Honest boundary** — "verifier-ready, not verified"; partner-only stamp (trust-safe).

These are the seeds of the moat: **encoded validation intelligence**, not breadth.

---

## 3. Where we are thin (and must not pretend)

- **Breadth** (CCF/LCA/EPD) — do not compete.
- **Data libraries** (factors, plant archetypes) — licence or partner.
- **Production ingestion at scale** — start narrow (S0/S1 documents), not ERP.
- **Brand and references** — earned one pilot at a time.
- **Capacity** — one pilot at a time; don't promise volume.
- **Registry output** — must reach parity before claiming "declaration-ready".

---

## 4. The "am I out of depth?" verdict

**On breadth: yes.** A funded platform with a 25k-factor library and 150 plant models is years
ahead on horizontal coverage. Competing there is unwinnable and unnecessary.

**On the specific job: no — but only if we stay narrow.** We can produce a **CBAM
verifier-ready evidence pack for an exporter** better than a generic carbon-accounting suite,
because we own the regulated calculation + evidence + reuse job. That is a real, paid,
penalty-driven need.

**The condition:** we must (a) prove one pilot end-to-end, (b) get one expert review, (c) reach
registry-output parity, (d) never claim to be a full LCA/EPD suite.

---

## 5. 90-day gap-closing plan (small chunks)

| # | Chunk | Closes | Test |
|---|---|---|---|
| 1 | Pilot v0 → expert review → v1 on real customer data | Verifier-readiness proof | customer accepts v1; expert written critique |
| 2 | Registry XML/Excel output for the C5 declaration | Parity gap | sample validates against the registry structure |
| 3 | Evidence dossier template (source→factor→figure) | Audit-room productisation | one dossier survives expert review |
| 4 | Ingestion for 3 document types (bill, invoice, weighbridge) | Capture thinness | 3 pilot docs parsed with provenance |
| 5 | Licence/public factor set + provenance | Data thinness | every factor has source/version |
| 6 | One-page website + domain email | Trust thinness | live, consistent with positioning |
| 7 | Partner verifier intro (one) | Stamp gap | named partner path for pilot v1 |
| 8 | Positioning + objection script | Sales clarity | can answer "Sentra does LCA/EPD" in one line |

---

## 6. Guardrails (from AGENTS.md)

- **Commodity vs defensible IP:** adopt factor libraries, LCA/EPD engines, verifiers; build only
  validation intelligence + evidence + reuse + trust.
- **No fake breadth:** never market CCF/LCA/EPD we don't have.
- **No fake verification:** "verifier-ready, not verified"; the stamp is a partner's.
- **Small chunks:** each row above is independently verifiable and reversible.
