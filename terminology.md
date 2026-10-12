# Terminology — Our Shortcut Legend

Decode the letter/number keys used across the KB, roadmap, gantt, and compliance matrix.

## P0–P4 — Phases (big stages)

| Key | Meaning |
|-----|---------|
| **P0** | Foundation — learning/research (Sep → late Oct 2026). |
| **P1** | Core engine build (CBAM-first) (Nov 2026 → Mar 2027). |
| **P2** | Go-to-market, Vertical 1 (Steel & Aluminium) (Q2 2027 → 2028). |
| **P3** | Vertical 2 (Textiles) (2027 → 2029). |
| **P4** | Moat & scale (2029+). |

## M0–M3 — Milestones / bootstrap

| Key | Meaning |
|-----|---------|
| **M0** | Repo bootstrap commit set (git init, layout, reference clones). |
| **M1** | Foundation exit (~late Oct 2026): CBAM ∩ steel-DPP overlap map approved; decision gates D1–D7 closed. |
| **M2** | CBAM engine sellable (~Jan 2027) — first revenue point. |
| **M3** | P1 exit / sell-twice proof (~Mar 2027): one dataset → CBAM output + steel passport. |

## L1–L7 — Learning blocks (guided study)

| Key | Topic | Status |
|-----|-------|--------|
| **L1** | CBAM embedded-emissions calculation rules | To do |
| **L2** | EC DPP Registry "User Guide for Economic Operators" + test-env access | To do |
| **L3** | CIRPASS-2 mock-EU-registry (endpoints, auth, metadata schema) | Done |
| **L4** | TracePass iron & steel field set | To do |
| **L5** | GS1 Digital Link | To do |
| **L6** | CEN/CENELEC DPP standards (documents paywalled) | To do |
| **L7** | Tractus-X DPP Verification add-on | To do |

## C1–C9 — Build chunks (small, verifiable deliverables)

| Key | Chunk |
|-----|-------|
| **C1** | Tooling/env bootstrap (effectively done as M0 + S1). |
| **C2** | Data contract — canonical model + CBAM∩DPP overlap, schemas-as-data (**keystone**). |
| **C3** | Ingestion (ERP/CSV → canonical model, validation). |
| **C4** | Harmonization (unit normalization, mapping rules-as-data). |
| **C5** | CBAM/embedded-emissions engine (**M2**). |
| **C6** | Passport generator + DPP host + registry submit (**T1** gate). |
| **C7** | T2 self-assurance run (TracePass + Tractus-X), compliance-matrix evidence. |
| **C8** | Lineage + integrity (versioned store, hash/detached JWS, later eIDAS/VC). |
| **C9** | Sell-twice proof — one dataset → CBAM + steel passport (**M3**). |

## S1 — Spike

One-off risk-kill experiment before real build. **S1** = submit a minimal payload to the
mock registry and retrieve it. **S1 PASSED** (evidence: compliance matrix `T1-REG-001`).

## D1–D7 — Decision gates (deferred choices, decided at a named point)

| Key | Decision |
|-----|----------|
| **D1** | Core language/framework |
| **D2** | Own core vs build on open-dpp (AGPL) |
| **D3** | Canonical data-contract shape |
| **D4** | Registry integration approach |
| **D5** | CBAM engine depth (actual vs default values, verification flow) |
| **D6** | eIDAS seal / VCs now vs later |
| **D7** | QR carrier adoption |

## Two different "T" sets — do not confuse

**Roadmap Targets (T1–T4):**

| Key | Target |
|-----|--------|
| **T1** | Vertical 1 live (Steel & Aluminium) |
| **T2** | Vertical 2 live (Textiles) |
| **T3** | Cross-vertical engine (one core, N verticals) |
| **T4** | Defensible moat proven in production |

**Certification Tiers (T1–T4):**

| Key | Tier |
|-----|------|
| **T1** | Legal-function conformance (payloads/APIs work against the registry) — non-negotiable |
| **T2** | Self-assurance (free harnesses → compliance matrix) |
| **T3** | Third-party CAB certification (on demand) |
| **T4** | Vertical data-space alignment (Material-X, Tex-X) |

## Other recurring terms

| Term | Meaning |
|------|---------|
| **CBAM** | EU Carbon Border Adjustment Mechanism (Reg 2023/956); definitive phase live 1 Jan 2026. |
| **DPP** | Digital Product Passport. |
| **EO** | Economic Operator (manufacturer/importer/distributor). |
| **ESPR** | Ecodesign for Sustainable Products Regulation (Reg 2024/1781). |
| **DA** | Delegated Act (product-specific ESPR instrument; dates indicative). |
| **O3CI / AMM / NCA / DRMC** | CBAM Registry modules: third-country installations / authorised declarant / national competent authority / reconciliation monitoring. |
| **reoId / UPI** | responsible economic operator ID / unique product identifier (registry metadata fields). |
| **PCF / SEE** | Product Carbon Footprint / Specific Embedded Emissions. |
| **Moat (3-layer)** | Layer 1 plumbing (commodity) · Layer 2 regulated calculation (engineerable) · Layer 3 validation intelligence (the moat). |
