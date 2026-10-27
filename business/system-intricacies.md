# System Intricacies — Challenges, Fixes, Mandatory vs Good-to-Have

Deep spec of *how the system works* once data is JSON-in. Companion to `product-spec.md`
(the what/why) and `../knowledge/research/data-layer.md` (the data pipeline). This is the "how and the
gotchas" document.

## 0. Locked architecture — JSON is the canonical seam

- **JSON is the single canonical model.** Every external source (ERP, Excel, PDF, OT, future
  formats) is converted by an **adapter/plugin → JSON** at the boundary. Downstream
  (validate → normalize → calc → provenance → transfer → declare → assure → sell-twice) works
  **only on JSON**. New formats = new adapters, never core changes. **(locked Oct 2026)**
- **Why:** gives us a deterministic, testable, versioned core and a clean anti-corruption layer.

## 1. The six guarantees (what "control" actually means)

| # | Guarantee | Why it matters | Fix / implementation |
|---|---|---|---|
| G1 | **Schema versioning** | regulatory drift (acts change) | schemas-as-data; every payload carries a `schemaVersion`; old versions load, new validate |
| G2 | **Provenance** | every figure must trace to a source doc | store **raw + derived**; hash-chain derived → source (`sha256` link), immutable |
| G3 | **Determinism / idempotency** | same input → same output; re-run safe | pure functions; **idempotency key = installation + reporting period + schemaVersion** |
| G4 | **Identity binding** | which installation/EO/declarant | stable IDs: UN/LOCODE + LEI/EORI + mill ID + CN code; never rely on display names |
| G5 | **Role & confidentiality** | importer liable / exporter holds secrets | role-based access (supplier/importer/verifier); zero-exposure hand-off |
| G6 | **Security** | secrets, PII, tampering | TLS, secret management (never in repo), detached-JWS/eIDAS seal on submission |

## 2. Challenges → fixes → implementation (by pillar)

### Pillar 1 — Capture
| Challenge | Why it breaks | Fix | Implementation |
|---|---|---|---|
| Messy paper/Excel/PDF inputs | no clean structured data | S0/S1 adapters + auto-map + unit auto-detect | adapter interface `format → JSON`; column-mapping rules + user confirmation |
| Column/format ambiguity | wrong field → wrong number | mapping rules + review of unmapped columns | auto-map with confidence + surfaced review list |
| Missing/partial rows | incomplete data | required-field validation + defaults flagged | reject + report per-row errors back to exporter |
| Format sprawl | every customer differs | adapter/plugin seam | JSON-first core; add CSV/XLSX/PDF adapters, then ERP/OT connectors |

### Pillar 2 — Validation intelligence
| Challenge | Why it breaks | Fix | Implementation |
|---|---|---|---|
| Route-specific wrongness | generic calc misses BOF/EAF/DRI/PFC | route metadata + route-qualified params | route registry keyed to calculation rules |
| Unit/NCV errors | mass vs energy vs volume | normalization rules + plausibility | convert mass/volume → TJ via NCV; keep energy/MWh; flag impossible intensity |
| Methodology mismatch | GHG Protocol vs CBAM allocation | conformance flags | rule set comparing declared method vs CBAM |
| Precursor errors | double-count / missing covered inputs | covered-inputs registry (Annex I) | only Annex-I inputs contribute; `EEInpMat = Σ Mi×SEEi` |
| Actual vs default | silent wrongness | determination flag + cost delta | flag each line; show € saving of actual |

### Pillar 3 — Audit room
| Challenge | Why it breaks | Fix | Implementation |
|---|---|---|---|
| No traceability | can't prove the number | provenance (G2) | drill-down SEE → source doc via hash links |
| Verifier over-privilege | confidentiality + independence | read-only scoped role | verifier view = read-only evidence room |
| Evidence incomplete | report fails | dossier assembly | auto-collect source records + factors into a pack |

### Pillar 4 — Trust & hand-off
| Challenge | Why it breaks | Fix | Implementation |
|---|---|---|---|
| Duplicate uploads | conflicting data | upload-once + idempotency | storage keyed by installation+period |
| Loose supplier↔importer link | wrong data retrieved | EORI linkage model | explicit link; registry-mediated retrieval |
| Secret exposure | suppliers won't share | zero-exposure hand-off | importer sees verified results, not recipe/energy mix (SNARK later) |

## 3. Mandatory vs good-to-have (per pillar)

| Pillar | **Mandatory** (end-to-end must work) | **Good-to-have** (phased/later) |
|---|---|---|
| 1. Capture | JSON schema + ingest + validate; CSV/XLSX adapter; column auto-map; unit auto-detect; error feedback | ERP/MES/LIMS connectors; real-time OT; AI doc extraction; multi-tenant portal |
| 2. Validation | route-specific calc; unit/NCV normalize; oxidation default; precursor pass-through; actual-vs-default + cost delta | plausibility checks; boundary/completeness; methodology flags; mass-balance consistency; PFC slope |
| 3. Audit room | provenance (raw+derived + hash); determination flag per line | read-only verifier login; drill-down; dossier auto-assembly; partner hand-off |
| 4. Trust | upload-once (idempotent); EORI link; role-based access | zero-exposure hand-off; SNARK attestation; DPP bridge (sell-twice) |

## 4. Intricacies inventory (the long tail of gotchas)

- **NCV/unit ambiguity** — mass/volume need NCV, energy doesn't; auto-detect vs explicit.
- **Oxidation factor default** — missing → 1.0.
- **Precision** — keep `dec16-6`; never round intermediate values.
- **Flared/vented/transferred gas** — counted at origin; BF gas/COG inherent CO₂ attribution.
- **Heat/CHP import-export** — heat-source EF + allocation basis.
- **By-products** — mass-balance allocation.
- **Aluminium PFC** — anode-effect count/duration → CF₄/C₂F₆ (GWP AR6 7380/12400).
- **Raw vs derived storage** — keep both; derived links back to raw (provenance).
- **Determinism** — no wall-clock, no float drift; fixed arithmetic; explicit rounding policy.
- **Identity** — UN/LOCODE, LEI, EORI, GLN, UPI/GS1, CN/HS/TARIC, steel mill ID.

## 5. Cross-cutting implementation notes (locked choices)

- **Idempotency key:** `installationId + reportingPeriod + schemaVersion`.
- **Provenance:** `derived.sha256 = sha256(raw.json + ruleSet)`; store as a chain.
- **Schemas-as-data:** the canonical model is a JSON Schema (draft 2020-12); versioned in-repo.
- **Determinism:** pure, side-effect-free transforms; `seed(demo data) → same outputs` is a test.

> Mirrors the Gherkin stubs in `../tests/DppCore.Tests/Features/pillars/` and
> `../tests/DppCore.Tests/Features/roles/`. This is the "how", those are the "what".
