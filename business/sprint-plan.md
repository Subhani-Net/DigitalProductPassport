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
| **E8** | **Present & Customer Conversations** (3rd dimension) | all milestones | Explainer ×3 segments, demo scripts, target list, signal log, pilot offer — **no milestone done without a Present artifact** |

---

## 3. Parallel tracks — learning ∥ technical (decided Sept 2026)

Learning and technical progress run **simultaneously, in the same sprint** — each learning
story is paired with a small **technical micro-output** produced from it. This keeps momentum
and converts study into working artefacts immediately.

**Guardrail (the only rule):** *build trails learning by one step.* Never freeze a schema,
encode a calculation, or testify conformance on an **unvalidated spec**. If the learning for a
decision isn't done, the technical task stays a throwaway prototype (fixtures only), not a
frozen interface. Enforced by the `AGENTS.md` checklist + schema-as-data + fixture regression.

**Why it's sound:** most technical tasks *are* documentation-driven, so learning and building
feed each other; the risk (rework from unvalidated specs) is neutralised by keeping the trail
one step behind and everything reversible via git.

### 3.1 Milestone view — Learn ∥ Implement ∥ Present (appended Oct 2026)

Purpose: eliminate **build-to-avoid** by making every milestone ship a customer-facing artifact.
**No dates change** — these map onto the existing sprint windows.

| Milestone | Learn | Implement | Present (per segment) | By (existing sprint) |
|---|---|---|---|---|
| **M-A — Conversation-ready** | 7-question checklist signed off (from 101/201) | harness + calc-stub + registry client *(done)* | **explainer ×3** (exporter/importer/verifier) + **15-name target list** (5/5/5) | S2 (24 Oct) |
| **M-B — Demo v0** | actual-vs-default economics, verification | sample steel → **SEE calc** → actual-vs-default saving + evidence summary | **10-min demo script ×3** + one-pager | S3 (7 Nov) |
| **M-C — Signal** | objections → FAQ | refine output from feedback | **5 conversations** (≥1 per segment) + signal log | S4 (21 Nov) |
| **M-D — Demo v1 (sell-twice)** | DPP fields + registry | + JSON-LD passport, host, registry metadata/proof | demo v1 → **pilot offer** | S5–S6 (19 Dec) |
| **M-E — Pilot** | real-data quirks | harden ingestion | **paid pilot / LOI / case study** | S7+ (aligns M2) |

### 3.2 Present gate rule + operating rules

- **Gate:** a milestone is *not done* without its Present artifact; from **M-C**, the planned
  conversations must actually have happened.
- **Signal rubric:** **Strong** = asks price / trial / introduces a colleague / shares real data ·
  **Medium** = detailed questions, compares to current tool · **Weak** = polite interest, no follow-up.
- **Solution-led, not probing** — three pain hypotheses:
  - **Exporter:** "so EU importers use your verified actuals instead of penalising defaults — win/retain buyers."
  - **Importer:** "declaration-ready, verifier-ready data → lower certificate cost + audit risk."
  - **Verifier:** "evidence dossiers + recalculation → faster, more reliable audits."
- **All three segments** are targeted until there is a presentable MVP for each.
- **Detail + scripts:** `presentation-plan.md`. **File map:** `../INDEX.md`.

### 3.3 Gap accommodation (from `product-gaps.md`, priority-ordered)

Folded into the existing frozen-date sprints as spec/decision items. Gaps are tracked as work
items `G01–G10` in `../workitems/README.md`.

| Gap | Action | Sprint |
|---|---|---|
| G09 non-goals | lock batteries/fertilisers/cement/hydrogen/downstream as non-goals | S2 (now) |
| G02 cold-start | decide **exporter-first** onboarding order + invite mechanics | S2 (M1/D-gate) |
| G01 activation | spec the first-value path (sign-up → upload → auto-map → SEE → saving) | S3–S4 |
| G03 platform ops | spec tenancy + billing tiers + deadline reminders (minimal) | S4–S5 |
| G04 our compliance | watch DPP Service Provider DA; draft GDPR/liability position | ongoing (act on DA) |
| G05–G08 | engine long tail / security / lifecycle / production-readiness spec | Phase 2–3 (consultant) |
| G10 validation | run the solution-led demo path (presentation-plan) — continuous | S3+ |

## 4. Story backlog

Story IDs: `E<epic>-<id>`. Effort: **S** 1–2d · **M** 3–5d · **L** 6–10d (solo focus-days).

### E0 — Foundation, Learning & Decisions

| ID | Learning story | Acceptance | Parallel technical micro-output | Effort | Depends |
|----|----------------|-----------|----------------------------------|--------|---------|
| E0-HARNESS | Stand up conformance harness baseline + request EU DPP Registry **test-env** access | mock registry + spike host restart script; test-env account requested | runnable rig (mock registry + validator + TracePass) — **done-ish** | S | — |
| E0-L1 | Study CBAM calculation rules (IR 2023/1773, 2025/2547/2546) → wedge spec | notes + takeaway in `research/regulations.md`; calc inputs listed | **calc input list** coded as a stub schema/F#/C# model (fixtures only) | M | — |
| E0-L2 | Study EC Registry User Guide (Economic Operators) + test-env walkthrough | notes in `research/tools.md`/`regulations.md`; T1 target clarified | registry-client skeleton (OIDC + register call to **test env**) | M | E0-HARNESS |
| E0-L4 | Study TracePass iron & steel field set | field inventory (in-force vs anticipated) → feeds C2 | TracePass steel schema **loaded and validated** against the fixture | M | — |
| E0-L5 | Study GS1 Digital Link | carrier notes → feeds C6 | QR/URI resolver spike against GS1 Resolver | S | — |
| E0-L6 | Study CEN/CENELEC DPP standards (acquire docs) | standard IDs + data-model implications; purchase recorded | JSON-LD passport **skeleton** (throwaway until CEN confirmed) | M | — |
| E0-L7 | Study Tractus-X DPP Verification add-on | T2 harness run plan | harness wired into CI (dry run) | M | E0-HARNESS |
| E0-DG | **Discovery gate** — 8–12 interviews | findings doc + payer/anchor decision | — (commercial) | M–L | — |
| E0-M1 | Build **CBAM ∩ steel-DPP overlap map** | field-to-field map approved | mapping expressed as a **machine-readable table** (C2 seed) | M | E0-L1, E0-L4, E0-L6 |
| E0-DEC | Close decision gates **D1–D7** | each recorded with inputs→choice→rationale→rollback | stack/library choice recorded (technical-landscape decisions) | S | E0-M1, E0-DG |

> The technical-landscape decisions (stack, libraries, DB, CI) are **not a separate spike** —
> they are the accumulated micro-outputs of L1–L7 + E0-HARNESS, closed at E0-DEC.

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

### E8 — Present & Customer Conversations (3rd dimension, mandatory)

| ID | Story | Acceptance | Effort | Depends |
|----|-------|-----------|--------|---------|
| E8-P1 | **Exporter explainer** (1 page) | verified actuals → avoid defaults, win/retain EU buyers; no jargon | S | E0-L1 |
| E8-P2 | **Importer explainer** (1 page) | declaration-ready + verifier-ready → lower certificates + audit risk | S | E0-L1 |
| E8-P3 | **Verifier explainer** (1 page) | evidence dossiers + recalculation → faster, reliable audits | S | E0-L1 |
| E8-P4 | **Target list** — 15 names (5 exporter / 5 importer / 5 verifier) | name + contact route + why-fit | S | — |
| E8-P5 | **Demo v0 script ×3 + one-pager** (10 min) | script per segment + one-pager; runs on sample data | M | E8-P1..P3, E3-C5 |
| E8-P6 | **Signal-log template** | segment, ask, signal strength, next step, date | S | — |
| E8-P7 | **Objection FAQ** | top 10 objections + answers | S | E8-P5 |
| E8-P8 | **Demo v1 (sell-twice) script + pilot-offer one-pager** | script + offer (€8–15k pilot) | M | E4-C6 |
| E8-P9 | **Case-study template** | one-page template for the first pilot | S | E8-P8 |

---

## 5. Sprint schedule

Each sprint carries **both tracks** (learning ∥ technical). Technical micro-outputs trail the
learning by one step (§3 guardrail).

| Sprint | Dates (2026–27) | Goal (Learn/Implement) | Stories | Present (gate) | Exit |
|--------|-----------------|------------------------|---------|----------------|------|
| **S0** | 15–26 Sep 2026 | Learning opens + harness baseline | E0-HARNESS, E0-L1 + calc-input stub, E0-L4 (start) | — | CBAM spec notes; rig runnable |
| **S1** | 29 Sep–10 Oct 2026 | Learning core | E0-L2 + registry-client skeleton, E0-L4 (finish), E0-L5 | — | Field inventory |
| **S2** | 13–24 Oct 2026 | **M1 gate** | E0-L6 + JSON-LD skeleton, E0-L7 + CI harness, E0-M1, E0-DEC *(E0-DG discovery deferred)* | **M-A: explainers ×3 + 15-name target list** | **M1: overlap map; D1–D7 closed** |
| **S3** | 27 Oct–7 Nov 2026 | Data contract | E1-C2a, E1-C2b (start) | **M-B: demo-v0 script ×3 + one-pager** | Canonical model v0.1 |
| **S4** | 10–21 Nov 2026 | Data contract + ingestion | E1-C2b, E1-C2c, E2-C3 (start) | **M-C: 5 conversations (mixed) + signal log** | Overlap encoded; ingestion v0 |
| **S5** | 24 Nov–5 Dec 2026 | Ingestion + harmonization | E2-C3 (finish), E2-C4, E2-VAL | objection FAQ | Scaffolding validated |
| **S6** | 8–19 Dec 2026 | Consultant + engine design | consultant engaged; E3-C5a (start) | **M-D: demo v1 + pilot offer** | Calc model drafted |
| **—** | 20 Dec–4 Jan | Holiday buffer | — | — | — |
| **S7** | 5–16 Jan 2027 | CBAM engine core | E3-C5a (finish) | **M-E: pilot conversations begin** | Test vectors pass |
| **S8** | 19–30 Jan 2027 | **M2** (first sellable) | E3-C5b, E3-C5c | pilot feedback loop | **M2: CBAM engine sellable** |
| **S9** | 2–13 Feb 2027 | Passport + host | E4-C6a, E4-C6b | demo-v1 walkthroughs | Passport JSON-LD; host live |
| **S10** | 16–27 Feb 2027 | Registry integration | E4-C6c, E5-C7 (start) | pilot-candidate shortlist | T1 round-trip passed |
| **S11** | 2–13 Mar 2027 | Trust + assurance | E5-C7 (finish), E5-C8 | pilot offer issued | T2 run recorded; lineage works |
| **S12** | 16–27 Mar 2027 | **M3** (P1 exit) | E6-C9 | sell-twice demo to pilot | **M3: sell-twice proof** |

Parallel: E7-G1/G2/G3 (GTM) and E8 (Present) run alongside S2–S12. **All three segments**
(exporter/importer/verifier) are targeted until each has a presentable MVP.

---

## 6. Traceability

| Roadmap milestone | Epics | Sprints |
|---|---|---|
| **M1** (overlap map + decisions) | E0 | S0–S2 |
| **M2** (CBAM engine sellable, first revenue) | E1, E2, E3 | S3–S8 |
| **M3** (P1 exit, sell-twice) | E4, E5, E6 | S9–S12 |
| P2 GTM prep | E7 (parallel) | S3–S10 |

---

## 7. Lean ceremonies

- **Sprint planning** (15 min): pick stories, confirm sprint goal.
- **Daily discipline:** one commit = one working increment; update compliance matrix + §5 status.
- **Sprint review** (30 min): demo working functionality or recorded evidence; mark DoD.
- **Retro** (one paragraph, same doc): what broke, what to change.
- **Backlog grooming:** at each milestone gate (M1/M2/M3); re-derive story order from §5.

**Status:** backlog defined; S0 not yet started. Roadmap §5 remains the date master.
