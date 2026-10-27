# Data Inputs Reference — What Gets Submitted to the Authority

Field-level view of every data input that flows to a regulator. Consolidates and deepens:
`cbam-data-catalogue.md` (A–H), `cbam-registry-workflow.md`, `cbam-input-sources.md`, and the
CIRPASS-2 mock registry schema in `tools.md`.

**Two authorities, three submission surfaces:**

| Surface | Authority / system | Who submits | What is submitted |
|---|---|---|---|
| **O3CI (operator)** | EU CBAM Registry (DG TAXUD) | Non-EU **installation operator** (exporter) | installation identity + direct/indirect emissions + precursors + evidence (uploaded once, confidential) |
| **AMM + annual declaration** | EU CBAM Registry | **Authorised CBAM declarant** (importer) | authorisation details + annual declaration + certificate surrender |
| **DPP registry** | EU DPP Registry (CIRPASS-2 mock for dev) | **Economic Operator** | passport *metadata only*; the payload is hosted at the EO's `liveURL` |

> The CBAM Registry is the financial/wedge system (live, definitive phase). The DPP Registry
> stores registration metadata, not the passport body. They are **different submissions**.

---

## 1. CBAM — Operator submission (O3CI)

The exporter (non-EU installation operator) uploads, once, for reuse by all linked declarants.

### 1.1 Installation & operator identity (catalogue A)
| # | Data item | Anchor |
|---|---|---|
| A1 | Operator company name, address, identifiers | IR 1773 Art 3(2) |
| A2 | Country of origin | IR 1773 Art 3(2) |
| A3 | Installation UN/LOCODE + coordinates of main emission source | IR 1773 Art 3(2) |
| A4 | **Production route** (Annex II §3) + route-qualifying parameters | IR 1773 / IR 2547 |
| A4b | Route-parameter values (steel: EAF scrap ratio, DRI share, hot-metal ratio, BF coke rate; aluminium: cell technology) | Annex IV §2 |
| A5 | Steel-mill identification number (per raw-material batch) | IR 1773 Art 3(2) |
| A6 | CN/HS code(s) of goods | QReport XSD |
| A7 | Registered-operator status + verifier registration | O3CI flow |
| A8 | Reporting period / installation reporting year | definitive annual declaration |

### 1.2 Direct emissions — source streams (catalogue B)
| # | Data item | Anchor |
|---|---|---|
| B1 | Source-stream inventory (fuels, materials, gases) | Annex III |
| B2 | Fuel/feedstock quantities consumed (t, TJ, Nm³) — **activity data ADi** | Annex III |
| B3 | NCV per fuel batch (laboratory) | Annex III |
| B4 | Emission factor (tCO₂/TJ) + oxidation/conversion factor | Annex III |
| B5 | Carbon content / biomass fraction (mass-balance method) | Annex III |
| B6 | Process-emission inputs (limestone, electrodes, anodes) | Annex III |
| B7 | Mass-balance streams (input/output, negative outputs) | Annex III |
| B8 | Transferred gases (BF gas, COG inherent CO₂) | Annex III |
| B9 | Flared / vented / unmonitored gas transfers | Annex III |

### 1.3 Indirect emissions — electricity (catalogue C)
| # | Data item |
|---|---|
| C1 | Electricity consumption (MWh) |
| C2 | MWh per tonne of goods |
| C3 | Electricity emission factor (grid / country) |
| C4 | PPA + Guarantees of Origin evidence (contractual factor) |
| C5 | Own generation / CHP heat-electricity allocation |
| C6 | Grid / self-consumption split |
| C7 | Imported/exported heat (steam/hot water) + heat-source emission factor |
| C8 | CHP fuel split + heat/electricity allocation basis |

### 1.4 Precursors — complex goods (catalogue D)
| # | Data item |
|---|---|
| D1 | Precursor list (CBAM-covered inputs consumed) — `EEInpMat = Σ Mi × SEEi` |
| D2 | Mass of each precursor (Mi) |
| D3 | SEE of each precursor (SEEi) — verified supplier data or EC default |
| D4 | Steel batch mill-ID cross-reference (downstream Ch.73) |

### 1.5 Production & allocation (catalogue E)
| # | Data item |
|---|---|
| E1 | Production volumes per product/good (activity level ALg) |
| E2 | Process allocation (per-process emissions → products) |
| E3 | Product quality/chemistry per heat/batch (EN 10204 MTC) |
| E4 | Output/by-product mass (mass balance) |
| E5 | **Determination flag** per product (actual vs default) — the wedge lever |

### 1.6 Aluminium-specific PFC (catalogue F)
| # | Data item |
|---|---|
| F1 | Smelting electricity (MWh/t Al, ~13–15) |
| F2 | Anode-effect count/frequency/duration (→ CF₄/C₂F₆) |
| F3 | Cell technology class (CWPB/PFPB/SWPB/HSS) |
| F4 | Alumina/anode/additives inputs + bath chemistry |
| F5 | PFC GWP set used (AR6: 7380 / 12400) |

---

## 2. CBAM — Declarant submission (AMM + annual declaration)

### 2.1 Authorisation (AMM)
Three tabs: **Stakeholder details · Activity details · Financial & operational details
(incl. guarantee)**. NCA assesses within ~120 days.

### 2.2 Annual declaration (Art. 35 Reg 2023/956)
| Field | Notes |
|---|---|
| Total quantity of each type of CBAM good | net mass per CN code |
| **Actual total embedded emissions** | direct (and indirect where applicable) |
| **Total indirect emissions** | |
| Carbon price due in the country of origin | deductible if evidenced |
| Quantity of CBAM certificates surrendered | after CBAM factor + deduction |

### 2.3 Declarant-side import fields (QReport XSD / Communication Template V2.1)
| Field | Format rule |
|---|---|
| Declarant identity + **EORI** + role | IDs `an..17` |
| Per-consignment: net mass, procedure, measurement unit, origin country | |
| Commodity (HS/CN code) | codes `n4` |
| DirectEmissions (actual vs default, tCO₂e/t) | determination flag; decimals `dec16-6` |
| IndirectEmissions (MWh/t + factor) | |
| Installation operator ID + installation ID/name/coords + production-method params | |
| Signatures (methodology + data confirmation) | |
| Supporting documents (CoA, MTC, verification report) | base64 |
| Unit code | **EMU1 = tCO₂e/t** |

---

## 3. DPP — Economic Operator metadata submission

The EO registers **metadata only** (the passport payload lives at `liveURL`, hashed into the
Proof of Registration).

| Field | Required | Notes |
|---|---|---|
| `upi` | ✅ | Unique Product Identifier, e.g. `urn:epc:id:sgtin:…` (≤200 ch) |
| `reoId` | ✅ | Responsible Economic Operator ID (LEI/EORI, ≤50 ch) |
| `facilitiesId[]` | ✅ | Facility ID(s) where produced (e.g. GLN) |
| `liveURL` | ✅ | Primary URL hosting the DPP payload (https) |
| `backupURL` | ✅ | Backup URL |
| `commodityCode` | ✅ | HS/TARIC (`^[0-9]{4,10}$`) |
| `granularityLevel` | ✅ | `MODEL` / `BATCH` / `ITEM` |
| `deactivated` | ITEM only | boolean |
| `modelUpi` | BATCH/ITEM | model-level cross-reference |
| `batchUpi` | ITEM only | batch-level cross-reference |

Registry returns: **`registryId`** + **Proof-of-Registration JWT** (contains `dppHash` =
SHA-256 of the payload fetched from `liveURL`).

---

## 4. Identifiers & units (cross-cutting)

**Identifiers:** EORI (declarant/supplier link) · LEI (reoId) · GLN (facility) · UPI/GS1 GTIN
(product) · UN/LOCODE (installation) · CN/HS/TARIC (goods).

**Units:** t (mass) · TJ/GJ (energy) · Nm³ (gas) · kWh/MWh (electricity) · tCO₂e (total) ·
**tCO₂e/t** (SEE) · tCO₂/TJ (fuel EF) · tCO₂/MWh (electricity EF) · % (factors/yield).

**Data-quality tiers:** ≤1.5% uncertainty for >500 ktCO₂/y; <7.5% below 10 ktCO₂/y
(catalogue G5 — verify against IR 2025/2546).

---

## 5. Actual vs default → what actually gets submitted

- **Actual values** require an **accredited verifier's report** (Art. 8) → verified data is
  submitted and used.
- **No verified data** → **EC default values** (IR 2025/2621) are submitted, flagged as default,
  with a punitive mark-up (~10% 2026 → ~30% 2028).
- This is the entire commercial wedge: **converting defaults → verified actuals** is what our
  engine monetises, and the fields above (§1–§2) are the raw material for it.

> Sources: `cbam-data-catalogue.md`, `cbam-registry-workflow.md`, `cbam-input-sources.md`,
> `tools.md` (mock registry schema) — all sourced to EUR-Lex / DG TAXUD. Numbers tagged
> [verify] where secondary.
