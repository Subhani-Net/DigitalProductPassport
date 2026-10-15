# Execution-Mode Map — Desktop · Expert · Field

**Additive view only** — this file does not alter `product-roadmap.md` §5 or `sprint-plan.md`;
it annotates their chunks with *who executes them*. Source of truth for dates/chunks stays
`sprint-plan.md`; this doc is the execution lens.

## Legend

| Mode | Meaning |
|---|---|
| **D — Desktop** | Solo C# build, spec-driven, using fixtures + CIRPASS-2 mock + EC registry test environment. No plant access. |
| **X — Expert** | Verifier-grade / industrial-domain judgment that must be encoded (external consultant + partner accredited verifier). |
| **F — Field** | Real plant systems, real data, real pilot, site verification (customer IT/OT + partner verifier). |

Notation: ●●● primary · ●● significant · ● build-only contribution · ○ minor · – none.

## Chunk-by-chunk map

| Epic | Chunk | D | X | F | Gate / note |
|---|---|---|---|---|---|
| E0 | E0-HARNESS (mock registry + test env + spike host) | ●●● | – | – | Pure desktop setup |
| E0 | E0-L1…L7 (learning blocks) | ●●● | ● | – | Self-study from primary sources; expert only for optional depth |
| E0 | E0-DG discovery interviews | ● | ● | ●●● | The first genuinely field activity — talk to importers/suppliers/verifiers |
| E0 | E0-M1 overlap map (CBAM ∩ steel DPP) | ●●● | ● | – | Desktop artifact; expert sanity-checks field set |
| E0 | E0-DEC decision gates D1–D7 | ●●● | ○ | – | Desktop |
| E1 | E1-C2a canonical model | ●●● | ● | ○ | Expert validates the field set; no plant needed |
| E1 | E1-C2b CBAM↔DPP field mapping | ●●● | ● | – | Legal/domain check by expert |
| E1 | E1-C2c schema-as-data engine | ●●● | – | – | Pure desktop |
| E2 | E2-C3 ingestion (CSV/XLSX/PDF) | ●●● | – | ○ | Real mill exports arrive later (S1) |
| E2 | E2-C4 harmonization / units | ●●● | ○ | – | Pure desktop |
| E2 | E2-VAL validate scaffolding → engage consultant | ●● | ○ | – | **Gate: expert engaged here (post-C4, per locked decision)** |
| E3 | E3-C5a emissions engine (actual values) | ●●● | ●●● | ○ | Build desktop; **methodology/route nuance is expert territory** |
| E3 | E3-C5b default fallback + comparison | ●●● | ● | – | Desktop from IR 2025/2621 |
| E3 | E3-C5c verifier-ready output | ●● | ●●● | ● | Expert defines "verifier-ready"; field proves it |
| E4 | E4-C6a passport generator (JSON-LD) | ●●● | – | – | Desktop |
| E4 | E4-C6b DPP host / EO-owned URL namespace | ●●● | – | ○ | Customer DNS is field-side |
| E4 | E4-C6c registry client (OIDC, register, proof) | ●●● | – | ● | Desktop vs mock + test env; real per-EO identity is field |
| E5 | E5-C7 T2 self-assurance run | ●●● | ○ | – | Desktop |
| E5 | E5-C8 lineage + integrity | ●●● | – | – | Desktop |
| E6 | E6-C9 sell-twice proof | ●●● | ○ | ○ | Fixtures; field validates later |
| E7 | E7-G1 pre-verification consultancy offer | ● | ●● | ●● | Expert-led, field-sold |
| E7 | E7-G2 pricing validation | ● | – | ●●● | Field |
| E7 | E7-G3 partner-verifier MOU | ● | ●● | ●● | Relationship (expert/field) |

## Learning blocks (E0)

| Block | Mode | Rationale |
|---|---|---|
| L1 CBAM calc rules, L2 registry guide, L4 TracePass fields, L5 GS1, L6 CEN/CENELEC, L7 Tractus-X | D ●●● | Public primary sources — study solo |
| (optional) deep Q&A / validation of understanding | X ● | Only where nuance matters (routes, PFC, plausibility) |

## Field stages (what must be real-systems)

| Stage | Desktop (build) | Field (access + reality) | When |
|---|---|---|---|
| **S0** paper/manual | parse logs, tickets, bills | collect from mill | at pilot (post-M3) |
| **S1** files (CSV/XLSX/PDF) | ingest adapters | mill exports | at pilot |
| **S2** dynamic (ERP/MES/LIMS/utility) | API adapters | IT access, mapping | post-M2 scaling |
| **S3** real-time (OPC UA/historian/CEMS) | streaming adapters | OT access | post-M2 scaling, demand-gated |
| Monitoring-plan alignment | tooling | ●●● plant | pilot |
| Verification (site visits, report) | ✗ | ●●● partner verifier | per actual-value use |

## Effort split (estimate to reach M3 — validate at pilots)

| Mode | Share | Where it concentrates |
|---|---|---|
| **Desktop** | ~60–70% | C2→C9 — the entire MVP is buildable solo with fixtures + mock + test env |
| **Expert** | ~15–20% | Post-C4: field-set validation, calc/validation models, verifier-ready design (weeks, not FTE) |
| **Field** | ~15–25% | E0-DG discovery now; S0/S1 pilot after M3; S2/S3 only post-M2, demand-gated |

## Sequencing rules (order matters)

1. **Desktop MVP → M2/M3 first** (fixtures + mock registry + EC test env). No field needed to reach first sellable.
2. **Engage the expert after C4** (locked decision) — before C5 — so the consultant details a *proven* scaffold, not a moving target.
3. **First field pilot after M3** — one mill/customer on **S0/S1 files** (cheapest real test).
4. **S2 (ERP/MES/LIMS) then S3 (OT)** only after M2, gated on customer demand.
5. **The verification stamp is always partner (X)** — never us (independence rule).

## The blunt risk

A desktop can build a spec-perfect engine on fixtures and still fail in the field: incomplete
meters, dirty exports, boundaries that don't match the textbook. The split is therefore about
**sequencing**, not just percentage — desktop gets a sellable core; the expert makes it
defensible; the field proves it. Field work before the core wastes the consultant; too late
risks building the wrong thing.

> Cross-refs: `sprint-plan.md` (chunks/sprints — unchanged) · `product-roadmap.md` §5 (dates)
> · `../research/cbam-input-sources.md` (S0–S3 detail) · `../research/cbam-verifier-accreditation.md`.
