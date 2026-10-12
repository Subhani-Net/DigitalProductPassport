# Sprint Plan & Backlog — DPP/CBAM Platform

Agile layer over `product-roadmap.md` **§5 (single source of truth)**. Keys (P/M/L/C/S/D/T)
are defined in `../terminology.md`. Cadence: **2-week sprints**, solo + AI, lean ceremonies.
This doc adds the *how we sequence the work* lens; §5 owns the dates, this doc owns the
*stories and acceptance criteria*.

Anchor: **Sept 2026**. Sprints 0–2 = P0 (foundation/learning); Sprints 3+ = P1 (build).

---

## 1. Definitions of Done (DoD)

### Build story DoD (every C-chunk piece)
- [ ] Works: small, independently verifiable slice of functionality.
- [ ] **T1 conformance** passed against CIRPASS-2 mock registry / TracePass schema (where applicable), recorded in `compliance-matrix.md`.
- [ ] **No-break regression**: prior fixtures still pass.
- [ ] **Schemas-as-data** — no hard-coded field sets.
- [ ] Compliance-matrix row added/updated with evidence + date.
- [ ] `product-roadmap.md` §5 / `project-gantt.md` status updated (single source of truth).
- [ ] Committed with a clear message; reversible via git.

### Learning story DoD (every L-block)
- [ ] Notes recorded in the correct KB doc with **citations** and **Fact / Claim / [Unverified]** tags.
- [ ] One-page takeaways summary (what it changes in our design).
- [ ] **Feeds its linked decision gate(s)** and/or the M1 overlap map.

### Discovery story DoD
- [ ] 8–12 structured interviews (importers, non-EU suppliers, 2–3 accredited verifiers).
- [ ] Findings doc: ranked pains, willingness-to-pay, payer/anchor recommendation, exporter-thesis result.
- [ ] Decision recorded + roadmap §2/§5 updated.

---

## 2. Epics

| Epic | Name | Roadmap link | Done when |
|------|------|--------------|-----------|
| **E0** | Foundation, Learning & Decisions | P0 / M1 | L1–L7 done, discovery gate run, M1 overlap map approved, D1–D7 closed |
| **E1** | Canonical Data Contract | C2 (keystone) | Versioned canonical model + CBAM∩DPP overlap map, loaded as data |
| **E2** | Ingestion & Harmonization | C3, C4 | ERP/CSV → canonical model, unit-normalized, validated |
| **E3** | CBAM Emissions Engine | C5 / M2 | Actual + default embedded-emissions output, verifier-ready |
| **E4** | Passport & Registry Integration | C6 / T1 | JSON-LD passport generated, hosted at EO-owned URL, registered, proof verified |
| **E5** | Self-Assurance & Trust | C7, C8 | T2 harness run recorded; versioned lineage + integrity |
| **E6** | Sell-Twice Proof | C9 / M3 | One dataset → CBAM output + steel passport end-to-end |
| **E7** | GTM Enablement (parallel) | P2 prep | Consultancy offer, pricing validated, partner-verifier MOU |

---

## 3. Story backlog

Story IDs: `E<epic>-<id>`. Effort: **S** 1–2d · **M** 3–5d · **L** 6–10d (solo focus-days).

### E0 — Foundation, Learning & Decisions

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E0-HARNESS | Stand up conformance harness baseline + request EU DPP Registry **test-env** access | mock registry + spike host restart script; test-env account requested | S | — |
| E0-L1 | Study CBAM calculation rules (IR 2023/1773, 2025/2547/2546) → wedge spec | notes + takeaway in `research/regulations.md`; calc inputs listed | M | — |
| E0-L2 | Study EC Registry User Guide (Economic Operators) + test-env walkthrough | notes in `research/tools.md`/`regulations.md`; T1 target clarified | M | E0-HARNESS |
| E0-L4 | Study TracePass iron & steel field set | field inventory (in-force vs anticipated) → feeds C2 | M | — |
| E0-L5 | Study GS1 Digital Link | carrier notes → feeds C6 | S | — |
| E0-L6 | Study CEN/CENELEC DPP standards (acquire docs) | standard IDs + data-model implications; purchase recorded as budget item | M | — |
| E0-L7 | Study Tractus-X DPP Verification add-on | T2 harness run plan | M | — |
| E0-DG | **Discovery gate** — 8–12 interviews | findings doc + payer/anchor decision | M–L | — |
| E0-M1 | Build **CBAM ∩ steel-DPP overlap map** | field-to-field map approved | M | E0-L1, E0-L4, E0-L6 |
| E0-DEC | Close decision gates **D1–D7** | each recorded with inputs→choice→rationale→rollback | S | E0-M1, E0-DG |

### E1 — Canonical Data Contract (C2)

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E1-C2a | Canonical model (JSON Schema draft 2020-12), versioned, CELEX-traceable | schema validates fixture; version field present | M | E0-M1 |
| E1-C2b | CBAM↔DPP field mapping encoded as data | mapping file; no hard-coding | M | E1-C2a |
| E1-C2c | Schema-as-data engine (load/validate/version) | engine loads a swapped schema without code change | M | E1-C2a |

### E2 — Ingestion & Harmonization

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E2-C3 | Ingestion: ERP/CSV/JSON → canonical model + validation | bad inputs rejected; good canonicalized; fixture regression green | M | E1-C2 |
| E2-C4 | Harmonization: unit normalization + rules-as-data | units normalized; mapping rules data-driven; no regression | M | E2-C3 |
| E2-VAL | Validate C2–C4 scaffolding (gate to engage domain consultant) | scaffolding reviewed; consultant brief written | S | E2-C4 |

### E3 — CBAM Emissions Engine (C5 / M2)

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E3-C5a | Embedded-emissions engine — **actual values** (SEE method) | matches hand-computed test vectors | L | E2-VAL, consultant |
| E3-C5b | **Default-value** fallback + actual-vs-default comparison | defaults applied when data missing; flagged | M | E3-C5a |
| E3-C5c | Verifier-ready output (evidence dossier, unit consistency, audit trail) | passes verifier-scrutiny design checklist | M | E3-C5a |

### E4 — Passport & Registry Integration (C6 / T1)

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E4-C6a | Passport generator (JSON-LD per CEN model) | valid JSON-LD; validates against schema | M | E1-C2 |
| E4-C6b | DPP host + **EO-owned URL namespace** (stable redirect layer) | register at customer domain; provider switch = DNS change | M | E4-C6a |
| E4-C6c | Registry client (OIDC per-EO, register/update, proof+JWKS verify) | round-trip to mock + test env; T1 evidence rows | M | E4-C6a, E0-HARNESS |

### E5 — Self-Assurance & Trust

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E5-C7 | **T2 self-assurance run** (TracePass + Tractus-X) | results auto-recorded in compliance matrix | M | E4-C6c |
| E5-C8 | Lineage + integrity (versioned store, dppHash chain, detached JWS) | version replay works; tamper detected | M | E4-C6 |

### E6 — Sell-Twice Proof (C9 / M3)

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E6-C9 | One dataset → **CBAM output + steel passport**, overlap % documented | P1 exit criteria met; demo recorded | M | E3-C5, E4-C6 |

### E7 — GTM Enablement (parallel, not blocking P1)

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E7-G1 | Pre-verification consultancy offer (scope, deliverables, pricing) | one-page offer ready to send | S | E0-DG |
| E7-G2 | Pricing validation (L/B/H against 3–5 prospects) | pricing confirmed/adjusted | S | E0-DG |
| E7-G3 | Partner accredited verifier MOU (TÜV-SÜD-type / India-reach) | signed MOU or letter of intent | M | E0-DG |

---

## 4. Sprint schedule

| Sprint | Dates (2026–27) | Goal | Stories | Exit |
|--------|-----------------|------|---------|------|
| **S0** | 15–26 Sep 2026 | Learning opens + harness baseline | E0-HARNESS, E0-L1, E0-L4 (start) | CBAM spec notes; harness restart scripted |
| **S1** | 29 Sep–10 Oct 2026 | Learning core + discovery | E0-L2, E0-L4 (finish), E0-L5, E0-DG (interviews start) | Field inventory; interviews underway |
| **S2** | 13–24 Oct 2026 | **M1 gate** | E0-L6, E0-L7, E0-DG (finish), E0-M1, E0-DEC | **M1: overlap map approved; D1–D7 closed** |
| **S3** | 27 Oct–7 Nov 2026 | Data contract | E1-C2a, E1-C2b (start) | Canonical model v0.1 |
| **S4** | 10–21 Nov 2026 | Data contract + ingestion | E1-C2b, E1-C2c, E2-C3 (start) | Overlap encoded; ingestion v0 |
| **S5** | 24 Nov–5 Dec 2026 | Ingestion + harmonization | E2-C3 (finish), E2-C4, E2-VAL | Scaffolding validated; consultant briefed |
| **S6** | 8–19 Dec 2026 | Engage consultant + engine design | consultant engaged; E3-C5a (start) | Calc model drafted |
| **—** | 20 Dec–4 Jan | Holiday buffer | — | — |
| **S7** | 5–16 Jan 2027 | CBAM engine core | E3-C5a (finish) | Test vectors pass |
| **S8** | 19–30 Jan 2027 | **M2** (first sellable) | E3-C5b, E3-C5c | **M2: CBAM engine sellable** |
| **S9** | 2–13 Feb 2027 | Passport + host | E4-C6a, E4-C6b | Passport JSON-LD; host live |
| **S10** | 16–27 Feb 2027 | Registry integration | E4-C6c, E5-C7 (start) | T1 round-trip passed |
| **S11** | 2–13 Mar 2027 | Trust + assurance | E5-C7 (finish), E5-C8 | T2 run recorded; lineage works |
| **S12** | 16–27 Mar 2027 | **M3** (P1 exit) | E6-C9 | **M3: sell-twice proof** |

Parallel: E7-G1/G2/G3 run alongside S3–S10 (opportunistic, non-blocking).

---

## 5. Traceability

| Roadmap milestone | Epics | Sprints |
|---|---|---|
| **M1** (overlap map + decisions) | E0 | S0–S2 |
| **M2** (CBAM engine sellable, first revenue) | E1, E2, E3 | S3–S8 |
| **M3** (P1 exit, sell-twice) | E4, E5, E6 | S9–S12 |
| P2 GTM prep | E7 (parallel) | S3–S10 |

---

## 6. Lean ceremonies

- **Sprint planning** (15 min): pick stories, confirm sprint goal.
- **Daily discipline:** one commit = one working increment; update compliance matrix + §5 status.
- **Sprint review** (30 min): demo working functionality or recorded evidence; mark DoD.
- **Retro** (one paragraph, same doc): what broke, what to change.
- **Backlog grooming:** at each milestone gate (M1/M2/M3); re-derive story order from §5.

**Status:** backlog defined; S0 not yet started. Roadmap §5 remains the date master.
