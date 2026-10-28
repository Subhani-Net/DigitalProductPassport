# Syllabus — Programme Plan & Next Steps

The overall picture: where we are, the four rails we're running, and the ordered syllabus of
what's done and what's next. Master dates live in `business/product-roadmap.md` §5; the work
register is `business/workitems/`.

---

## Where we are (one glance)

- **Stage:** pre-seed, pre-revenue, solo founder (London), sweat-only until the raise.
- **Product:** spec complete; **working** calculator + registry client + **44 green tests**
  (86 spec stubs); seedable demo data pack; **Step 01** of the pilot docket done.
- **Business:** investor deck/pitch/website + outreach pack + right-sized raise (~£1.0–1.25M).
- **Knowledge:** CBAM 101/201 complete; deep research (workflow, data catalogue, data layer,
  submission cadence, market sizing, competitors).

## The four rails (run in parallel)

| Rail | Purpose | Lead / state |
|---|---|---|
| **Knowledge** | understand the domain | done enough — deepen on demand |
| **Product** | build the engine | foundation working; C2–C9 next |
| **Pilot (docket)** | prove on realistic documents | **in progress** (Step 01 done) |
| **Business** | raise + sell | investor pack + outreach ready |

---

## Syllabus — parts, modules, status

### Part A — Knowledge foundation ✅
| # | Module | Status |
|---|---|---|
| A1 | CBAM 101 (foundations) | ✅ |
| A2 | CBAM 201 (practitioner) | ✅ |
| A3 | CBAMBOK + glossary | ✅ |
| A4 | Research: regulations, registry workflow, data catalogue, data layer, submission cadence, market sizing, competitors | ✅ |

### Part B — Technical foundation ✅ (partial)
| # | Module | Status |
|---|---|---|
| B1 | DppCore: CBAM calculator (direct/indirect/precursors) | ✅ tested |
| B2 | Declaration + certificate settlement + economics | ✅ tested |
| B3 | Registry client (OIDC → register → proof) | ✅ T1-REG-002 |
| B4 | Test suite (unit/schema/BDD/integration) | ✅ 44 green / 86 stubs |
| B5 | Seedable demo data pack | ✅ |

### Part C — Pilot docket (concierge, synthetic documents) 🚧 ← current work
| Step | Document | Status |
|---|---|---|
| 01 | Electricity bill | ✅ (528,400 kWh → 375.164 tCO₂ indirect) |
| 02 | Fuel invoice (natural gas) | ✅ (180,000 SCM → 6.39 TJ → 357.84 tCO₂ direct) |
| 03 | Weighbridge ticket | ⬜ next |
| 04 | Mill Test Certificate (EN 10204 3.1) | ⬜ |
| 05 | Heat/batch production log | ⬜ |
| 06 | Monthly fuel register | ⬜ |
| 07 | Company identity pack | ⬜ |
| 08 | Route & product declaration | ⬜ |
| 09 | Extraction sheet (all docs → canonical) | ⬜ |
| 10 | Pilot report (SEE + evidence + actual-vs-default saving) | ⬜ |

### Part D — Product build (planned; each chunk test-gated)
| # | Chunk | Pillar |
|---|---|---|
| D1 | C2 canonical model (schemas-as-data) | keystone |
| D2 | C3 ingestion (docket/files → canonical) | Capture |
| D3 | C4 harmonization (units/NCV/rules-as-data) | Capture/Validation |
| D4 | C5 CBAM engine (**M2** sellable) | Validation |
| D5 | C6 passport + registry submit + DPP host | Audit/Trust |
| D6 | C7 T2 self-assurance run | Audit |
| D7 | C8 lineage + integrity | Audit |
| D8 | C9 sell-twice proof (**M3**) | Trust |

### Part E — Business & GTM (parallel)
| # | Action | Status |
|---|---|---|
| E1 | Investor pack: deck, pitch, business plan, investment plan, website, brand | ✅ (refine) |
| E2 | Target list framework (small/medium Indian exporters) | ✅ (fill real names) |
| E3 | **5 exporter conversations** | ⬜ this week |
| E4 | Concierge pilot (on signal, 2 weeks) | ⬜ |
| E5 | Raise (SEIS £250k + EIS £0.75–1.0M) | ⬜ |

### Part F — Moat & certification (later, gated on demand)
| # | Item |
|---|---|
| F1 | Verifier-grade consultant (post C2–C4) — encode validation intelligence |
| F2 | Partner accredited verifier (the stamp — never us) |
| F3 | T2 self-assurance → T3 on customer demand |
| F4 | Accumulate the validation rule library (the compounding moat) |

---

## Milestones

| Milestone | Meaning | State |
|---|---|---|
| **M1** | Overlap map + decisions closed | ✅ |
| **Pilot-P1** | Docket complete (Steps 01–10) | 🚧 |
| **Pilot-P2** | First real concierge pilot delivered | ⬜ |
| **M2** | CBAM engine sellable — first revenue | ⬜ |
| **M3** | Sell-twice proof (CBAM → DPP) | ⬜ |
| **Pilot-P3** | First paying customer / LOI | ⬜ |

---

## Immediate next steps (ordered)

1. **Step 02 — fuel invoice** (docket).
2. **Fill 5 real SME exporter names** (EEPC India / FIEO / IndiaMART / DGFT).
3. **Send 5 outreach messages** (solution-led, from `business/outreach/`).
4. **Investor:** refine deck, work warm intros.
5. **Background:** start **C2 canonical model** so the docket's extraction becomes the schema.

## How the rails feed each other

```
Docket (C) ── real requirements ──► Product (D) codifies them
   │                                      │
   ▼                                      ▼
Demo + evidence ──────────────► Conversations (E3) ──► signal ──► Raise (E5)
                                                   │
                                                   ▼
                                      Consultant (F1) encodes the moat
```

**Principle:** declare annually, manage risk continuously — and let the pilot define the build.
