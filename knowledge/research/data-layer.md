# Data Layer — Capture, Transfer, Transform (CBAM)

The nitty-gritty of how exporter data becomes importer declaration data. This is the heart of
the product (feeds C2 canonical model, C3 ingestion, C4 harmonization, C5 engine). Consolidates
and deepens `cbam-data-catalogue.md` (A–H), `cbam-input-sources.md` (S0–S3), and
`data-inputs-reference.md`.

## 0. The two-sided flow

```
[EXPORTER / installation operator]                [IMPORTER / declarant]
   capture (A–F)                                       consume (declaration)
        │                                                    ▲
        ▼                                                    │
   transfer: upload ONCE → O3CI (confidential) ── EORI link ─┘
        │   (transform: raw → canonical → verified)
        ▼
   [CBAM Registry]  stores verified installation + emissions data
```

One canonical dataset is **written once** by the exporter and **read by many importers** —
the upload-once/reuse-many property is the whole point of the data layer.

---

## 1. Data capture (exporter side)

### 1.1 What is captured (field groups A–F)

| Group | What | Key fields |
|---|---|---|
| **A — Identity** | installation & operator | company/address/IDs, country, UN/LOCODE + coords, production route + route params, mill ID, CN code |
| **B — Direct** | source streams (fuels/materials/gases) | quantity (t / TJ / Nm³), NCV, emission factor, oxidation factor, carbon/biomass fraction, process inputs, mass-balance streams, transferred/flared gas |
| **C — Indirect** | electricity | MWh, MWh/t, grid EF, PPA+GO evidence, own-gen/CHP, heat in/out |
| **D — Precursors** | covered inputs | precursor list, mass (Mi), SEE (SEEi) |
| **E — Production** | allocation | production volume (ALg), process allocation, grade/chemistry, by-product mass, **determination flag** |
| **F — Aluminium** | PFC | smelting MWh/t, anode-effect data, cell technology, bath chemistry, PFC GWP set |

### 1.2 Capture stages & sources

| Stage | Source | Format | Effort for the mill |
|---|---|---|---|
| **S0 paper/manual** | logs, weighbridge tickets, energy bills, route declaration | paper / PDF | minimal — send docs |
| **S1 files** | ERP/MES/LIMS exports, Mill Test Certificates (EN 10204), Certificates of Analysis | CSV / XLSX / PDF | export + upload |
| **S2 dynamic** | ERP (SAP OData/IDoc, Oracle, Dynamics, Tally), MES (ISA-95), LIMS, utility/MDMS | API / DB | IT access |
| **S3 real-time** | PLC/DCS (OPC UA/Modbus), SCADA, historian (AVEVA PI), smart meters, CEMS | telemetry | OT access |

**Streamlined capture principle:** start at **S0/S1** (files) — enough to prove the engine; the
"easier way" is column auto-mapping + unit auto-detection on upload, not asking for S2/S3 access
up front.

### 1.3 Units & normalization (the harmonization core)

| Physical form | Captured as | Normalise to | Rule |
|---|---|---|---|
| Solid/liquid fuel mass | tonnes | **TJ** (energy) | `energy = mass × NCV(TJ/t)` |
| Gas volume | Nm³ | **TJ** | `energy = volume × NCV(TJ/Nm³)` |
| Energy already | TJ | TJ | use as-is |
| Electricity | MWh | MWh | `indirect = MWh × EF(tCO₂/MWh)` |
| Emissions result | tCO₂e | **tCO₂e/t** (SEE) | `SEE = (direct+indirect+precursor)/activity` |

**NCV** (net calorific value) is the key conversion factor: lab-supplied (ISO 17025) or standard.
**Oxidation factor** defaults to **1.0** when absent.

### 1.4 Identifiers (every row is traceable)

EORI (declarant/supplier link) · LEI (reoId) · GLN (facility) · UPI/GS1 GTIN (product) ·
UN/LOCODE (installation) · CN/HS/TARIC (goods) · **steel mill ID** (batch → upstream mill).

### 1.5 Data quality

- Metrology: calibrated meters (MID for electricity, OIML weighbridges).
- Factors: ISO/IEC 17025 labs, or standard values.
- Uncertainty tiers: **≤1.5%** (>500 ktCO₂/y) · **<7.5%** (<10 ktCO₂/y) — [verify IR 2025/2546].

---

## 2. Data transfer (exporter → registry → importer)

### 2.1 Upload once (O3CI)
- Operator registers in O3CI (EU Login + 2FA, company docs, proof of representation).
- Uploads installation + emissions data **once**; registry gives **confidential treatment**.
- "Upload once, instead of submitting to each declarant separately."

### 2.2 EORI link → importer retrieval
- Importer shares its **EORI** with the supplier.
- Registry links the supplier's verified data to the importer's reports.
- **Data flows registry → declarant, never exporter → importer by email.**

### 2.3 Formats
- CBAM **QReport XSD** + **Communication Template V2.1** sheets: `A_InstData`, `B_EmInst`,
  `C_InstEnergy`, `D_Processes`, `E_SEE`, `F_CHP`, `Summary_Products`.
- Type/format rules: IDs `an..17`, codes `n4`, decimals `dec16-6`, unit code **EMU1 = tCO₂e/t**.

---

## 3. Data transformation (raw → canonical → declaration)

### 3.1 Canonical model (C2) — the single shape
One internal model serves both sides (and later the DPP — the sell-twice property). Direction:
```jsonc
installation { id, country, unLocode, productionRoute, routeParameters }
reportingPeriod, production { cnCode, activityLevelTonnes }
sourceStreams[] { name, activityData, unit, ncvTJPerUnit, emissionFactorTCO2PerTJ, oxidationFactor }
electricity { mwh, emissionFactorTCO2PerMWh, contractualFactor }
precursors[] { name, massTonnes, seeTCO2PerTonne }
result { directTCO2, indirectTCO2, seeTCO2PerTonne, determination }
```
Already stubbed as `../../product/src/model/calc-inputs.schema.json` (throwaway; finalised in C2).

### 3.2 Harmonization rules (C4) — rules-as-data, never hardcoded
- **Unit normalization:** convert t/Nm³ → TJ via NCV; keep TJ/MWh as-is.
- **Oxidation default:** missing → 1.0.
- **Precursor pass-through:** only CBAM-covered inputs (Annex I) count; `EEInpMat = Σ Mi×SEEi`.
- **Determination:** each line flagged actual vs default.
- **Traceability:** every derived number keeps its source reference.

### 3.3 Sell-twice
The same canonical data produces **CBAM output today** and the **steel/aluminium DPP later** —
one transform, two consumers.

---

## 4. Nitty-gritty edge cases (what breaks naive implementations)

| Case | Correct handling |
|---|---|
| Mass vs energy vs volume stream | only mass/volume need NCV; energy is direct |
| Missing oxidation factor | default 1.0 |
| Missing verified data | fall back to **defaults**, flag as default, show cost delta |
| Flared/vented/unmonitored gas | counted at origin |
| Transferred gases (BF gas, COG) | destination attribution (inherent CO₂) |
| Heat/CHP import-export | heat-source EF + allocation basis (Eq. 47) |
| By-products | mass-balance allocation |
| Aluminium PFC | anode-effect count/duration → CF₄/C₂F₆ (GWP AR6 7380/12400) |
| Non-CBAM methodology | flag (e.g. GHG Protocol vs EU allocation) |
| Precision | decimals `dec16-6`; don't round intermediate values |

---

## 5. Open decisions (deferred to C2/C5)

- **D3** canonical data-contract shape (lock against TracePass steel + CBAM A–F).
- **D5** CBAM engine depth (actual vs default; verification flow).
- Whether to store raw + derived (audit trail) or derived only.
- Column auto-mapping + unit auto-detection as the "streamlined capture" differentiator.

---

## 6. The JSON seam & control guarantees (locked Oct 2026)

- **JSON is the canonical seam.** Every external source is converted by an **adapter/plugin →
  JSON** at the boundary; the core works only on JSON. New formats = new adapters.
- **At JSON-in we control everything downstream** — but "control" requires these guarantees,
  not just a shape (full detail: `../../business/system-intricacies.md` §1):
  1. **Schema versioning** — every payload carries `schemaVersion`; schemas-as-data.
  2. **Provenance** — raw + derived stored; derived hashes link back to source.
  3. **Determinism / idempotency** — pure functions; idempotency key = installation + period + schemaVersion.
  4. **Identity binding** — UN/LOCODE + LEI/EORI + mill ID + CN code.
  5. **Role & confidentiality** — supplier/importer/verifier scopes; zero-exposure hand-off.
  6. **Security** — TLS, secrets out of repo, detached-JWS/eIDAS on submission.

> Sources: `cbam-data-catalogue.md`, `cbam-input-sources.md`, `data-inputs-reference.md`,
> `tools.md` (mock registry schema). All anchored to EUR-Lex / DG TAXUD; numbers tagged
> [verify] where secondary.
