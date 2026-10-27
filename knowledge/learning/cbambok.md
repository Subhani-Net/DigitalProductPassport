# CBAMBOK — CBAM Body of Knowledge

A structured collection of the terms, instruments, processes, workflows, and units needed to
reach **SME level** on the EU Carbon Border Adjustment Mechanism. Reference companion to the
`cbam-101/`→`cbam-301/` courses and the `glossary.md` learning queue.

**Tagging:** Fact = anchored in an EU instrument (article cited) · Claim = secondary/vendor ·
**[verify]** = confirm against the latest consolidated act before relying on it.

---

## 1. Legal instruments (legislation map)

| Instrument | What it does |
|---|---|
| **Regulation (EU) 2023/956** | The CBAM Regulation — created CBAM. Published 16 May 2023; in force 17 May 2023. |
| **Regulation (EU) 2025/2083 (the "Omnibus")** | Amends CBAM. In force 20 Oct 2025. Introduced the 50 t de-minimis, moved the declaration deadline to 30 Sep, delayed certificate sales to Feb 2027, cut quarterly holding to 50%. |
| **IR (EU) 2023/1773** | Transitional-period reporting + calculation methodology (Annex III/IV). |
| **IR (EU) 2024/3210** | The CBAM Registry. |
| **IR (EU) 2025/2547** | Definitive-period **calculation** (definitions in Art. 1). |
| **IR (EU) 2025/2546** | **Verification** rules. |
| **Del. Reg. (EU) 2025/2551** | **Accreditation** of verifiers. |
| **IR (EU) 2025/2620** | Definitive-period **benchmarks**. |
| **IR (EU) 2025/2621** | Definitive-period **default values**. |
| **Directive 2003/87/EC (EU ETS)** | The carbon market CBAM mirrors; free-allocation phase-out drives the CBAM factor. |
| **MRR (EU) 2018/2066 · AVR (EU) 2018/2067** | EU ETS monitoring/reporting + accreditation/verification rules — the "data discipline" CBAM borrows. |

> Act numbers from KB + secondary glossaries; confirm on EUR-Lex before formal citation. **[verify]**

---

## 2. Legal definitions (anchored)

| Term | Definition (anchored to source) | Source |
|---|---|---|
| **Goods** | Goods listed in Annex I. | Reg 2023/956 Art 3(1) |
| **Greenhouse gases** | Those specified in Annex I per good. | Art 3(2) |
| **Emissions** | Release of GHGs into the atmosphere from the production of goods. | Art 3(3) |
| **EU ETS** | The EU allowance-trading system (excluding aviation). | Art 3(5) |
| **Direct emissions** | Emissions from production processes, incl. production of heat/cooling consumed, wherever produced. | Art 3(21) |
| **Embedded emissions** | Direct emissions + indirect emissions (electricity consumed), per Annex IV. | Art 3(22) |
| **Tonne of CO₂e** | One metric tonne CO₂, or equivalent quantity of another Annex I gas by GWP. | Art 3(23) |
| **CBAM certificate** | Electronic certificate = 1 tonne CO₂e of embedded emissions. | Art 3(24) |
| **Production processes** | Chemical/physical processes to produce goods in an installation. | Art 3(26) |
| **Default value** | Value from secondary data representing embedded emissions. | Art 3(27) |
| **Actual emissions** | Emissions from primary data of the production processes. | Art 3(28) |
| **Carbon price** | Amount paid in a third country under a carbon scheme (tax/levy/fee/allowances). | Art 3(29) |
| **Installation** | Stationary technical unit where a production process is carried out. | Art 3(30) |
| **Operator** | Any person operating/controlling an installation in a third country. | Art 3(31) |
| **Indirect emissions** | Emissions from generation of electricity consumed in production, wherever generated. | Art 3(34) |
| **Functional unit** | Reference unit for calculating embedded emissions. | IR 2025/2547 Art 1(1) |
| **Activity level** | Quantity of goods to which the same functional unit applies, produced in the system boundaries in a period. | IR 2025/2547 Art 1(2) |
| **System boundary** | Group of chemical/physical processes included in the calculation under one aggregated goods category. | IR 2025/2547 Art 1(3) |
| **Aggregated goods categories** | Categories per Table 1 Annex I. | IR 2025/2547 Art 1(4) |
| **Reporting period** | The calendar year during which the good was produced. | IR 2025/2547 Art 1(5) |
| **Production route** | Specific technology used in a production process to produce goods. | IR 2025/2547 Art 1(6) |
| **Precursor** | Any input material into a process that is itself an Annex I good. | IR 2025/2547 Art 1(7) |
| **Source stream** | Specific fuel/raw material/product giving rise to emissions (or in a mass balance). | IR 2025/2547 Art 1(8) |
| **Activity data** | Fuel/material consumed or produced, in TJ, tonnes, or Nm³ for gases. | IR 2025/2547 Art 1(12) |

---

## 3. Scope & goods

- **Six sectors (Annex I, by CN code):** cement · iron & steel · aluminium · fertilisers ·
  electricity · hydrogen. **Fact**.
- **Downstream anti-circumvention items** included (e.g. steel fasteners, pipe fittings). **Claim/Fact**.
- **Coverage follows the imported good's CN code.** **Fact**.
- **Precursors:** covered inputs carried into a product — widen scope + footprint. **Fact**.
- **De minimis:** cumulative annual **net mass ≤ 50 t** of cement/steel/aluminium/fertilisers
  → exempt (replaced the €150/consignment rule). **Not** electricity or hydrogen. ~90% of
  importers exempt but >99% of embedded emissions captured. **Fact** (Reg 2025/2083).

---

## 4. Actors & institutions

| Actor | Role |
|---|---|
| **Authorised CBAM declarant** | Only entity permitted to import CBAM goods (above de-minimis); EU importer or indirect customs rep; NCA authorises (up to 120 days). |
| **Indirect customs representative** | EU-established agent; can/must be the declarant (mandatory for non-EU importers); same obligations/penalties. |
| **Operator (non-EU installation)** | Origin of data; registers in O3CI; uploads installation + emissions data (confidential). |
| **Accredited verifier** | Independent body accredited by a NAB; verifies actual values, methodology, boundaries, foreign carbon-price claims. |
| **National Competent Authority (NCA)** | Authorises declarants, enforces, penalises. |
| **Customs authorities** | Border enforcement of covered goods/declarations. |
| **European Commission (DG TAXUD)** | Owns the Registry; publishes guidance + default values. |
| **DRMC** | Registry module: reconciliation/monitoring of goods, emissions, certificates, penalties. |

**Fact** (`../research/cbam-registry-workflow.md`, glossaries).

---

## 5. Workflows

### 5.1 Registry modules
- **AMM** (Authorisation Management Module) — declarant authorisation (applications opened 31 Mar 2025).
- **O3CI** — non-EU operators upload data; verifiers review and issue reports.
- **DRMC** — monitoring/reconciliation.
- **Access:** via the **EU Customs Trader Portal** (single sign-on); the definitive CBAM Registry
  supersedes the transitional registry. **Fact**.

### 5.2 End-to-end data flow
```
operator → O3CI (uploads installation + emissions data)
   → accredited verifier (reviews, issues verification report)
   → CBAM Registry
   → declarant retrieves via EORI link → annual declaration auto-populated
   → declarant surrenders certificates (by 30 Sep following year)
```
**Fact**. Data flows **registry→declarant**, never exporter→importer directly; confidential treatment.

### 5.3 Periodic obligations
- **Annual declaration** (by **30 Sep** following the import year; first = 30 Sep 2027 for CY2026).
- **Certificate sales** begin **1 Feb 2027** on the **common central platform**. **Fact**.
- **Quarterly minimum holding:** from **2027**, hold certificates covering **≥50%** of emissions
  accrued year-to-date (assessed 31 Mar/30 Jun/30 Sep/31 Dec; reduced from 80% by the Omnibus). **Fact**.
- **Sell-back / repurchase:** request by **30 June** each year; capped. **Fact**.

---

## 6. Emissions accounting

- **Embedded emissions = direct + indirect** (Art 3(22)). Computed per Annex IV / IR 2025/2547;
  for **complex goods**, includes the embedded emissions of **precursors**. **Fact**.
- **Direct methods:** calculation-based (activity data × factors), measurement-based (**CEMS**),
  **mass balance**. **Fact**.
- **Indirect:** electricity **MWh/t × emission factor** (grid / PPA / Guarantees of Origin). **Fact**.
- **Indirect treatment nuance:** reporting/charging of indirect emissions differs by sector and
  phase-in — widely stated as counted for cement & fertilisers, and largely direct for steel &
  aluminium during the phase-in. **[verify]** against Annex IV / IR 2025/2547.
- **Actual vs default values:** actual = verified primary data; default = EC fallback
  (country/CN); defaults carry a conservative mark-up. **Fact**.
- **CBAM factor (phase-in factor):** share of embedded emissions actually paid for — rises from
  **2.5% (2026) to 100% (2034)**, mirroring the EU ETS free-allowance phase-out. **Fact**.
- **Default-value mark-up:** reported ~**10% (2026) rising toward ~30% by 2028** for aluminium,
  cement, steel; ~1% for fertilisers. **Claim [verify]**.

---

## 7. Industrial processes (sector vocabulary)

### 7.1 Iron & steel
- **Routes:** **BF-BOF** (blast furnace–basic oxygen; coke/coal-heavy, ~70% of world steel),
  **EAF** (electric arc; scrap + electricity), **DRI / H₂-DRI** (direct reduced iron; gas/H₂). **Fact**.
- **Terms:** iron ore, **sinter**, **pellets**, **coke**, **PCI** (pulverised coal injection),
  **hot metal** (molten iron), **BOF**, **EAF**, **crude steel**, **slab / billet / bloom**
  (semi-finished), **HRC** (hot-rolled coil), **ferroalloys**, **HBI** (hot-briquetted iron),
  **scrap**, **alloying**, **continuous casting**. **Fact**.

### 7.2 Aluminium
- **Primary route:** bauxite → **alumina** (**Bayer process**) → **Hall–Héroult** electrolysis
  in a **potline** (~13–15 MWh/t). **Anode effect** → **PFCs (CF₄/C₂F₆)**, very high GWP;
  cell technologies **CWPB / PFPB / SWPB / HSS**. **Fact**.
- **Secondary route:** recycled **scrap** remelting (far lower emissions; direct only). **Fact**.
- **Products:** ingot, **billet**, **slab**. **Fact**.

### 7.3 Cement
- **Clinker** production: **calcination** (CaCO₃ → CaO + CO₂) in a **kiln** — process CO₂ plus
  fuel. **SCM** (supplementary cementitious materials) like **fly ash**/**slag** reduce clinker. **Fact**.

### 7.4 Fertilisers
- **Ammonia** via **Haber–Bosch** (natural gas feedstock), **nitric acid** (N₂O emissions),
  **urea**, ammonium nitrate. **Fact**.

### 7.5 Hydrogen
- **SMR** (steam methane reforming → grey), **electrolysis** (green if renewable), blue (SMR+CCS).
  **Fact**.

### 7.6 Electricity
- Grid **emission factors**, **Guarantees of Origin**, cross-border electricity. **Fact**.

---

## 8. Measurement units & factors

| Unit / factor | Meaning |
|---|---|
| **tCO₂e** | Tonne of CO₂ equivalent — the common currency of CBAM. |
| **tCO₂e/t** | Specific embedded emissions (SEE) — the key product intensity. |
| **tCO₂/TJ** | Emission factor of a fuel. |
| **TJ, GJ** | Energy (activity data). |
| **Nm³** | Normal cubic metre (gas volume). |
| **t, kg** | Mass (net mass for imports). |
| **kWh / MWh / GWh** | Electricity energy. |
| **MWh/t** | Electricity intensity (esp. aluminium). |
| **NCV** | Net calorific value (energy per mass/volume of fuel). |
| **GWP (AR6)** | Global Warming Potential; e.g. CF₄ ≈ 7380, C₂F₆ ≈ 12400. |
| **% / ppm** | Concentrations; oxidation/conversion factors; biomass fraction. |

---

## 9. Data, classification & IT terms

| Term | Meaning |
|---|---|
| **CN code** | Combined Nomenclature customs code — defines CBAM scope. |
| **HS / TARIC** | Harmonised System / EU integrated tariff — related classification. |
| **EORI** | Economic Operators Registration and Identification number (links declarant ↔ supplier). |
| **UN/LOCODE** | Location code for installations. |
| **Monitoring plan** | Installation's data boundary + source streams + methods blueprint. |
| **CEMS** | Continuous Emissions Monitoring System. |
| **Mass balance** | Emissions from the carbon balance of inputs/outputs. |
| **Tier (1/2/3)** | MRV data-quality/uncertainty tiers. |
| **XSD / Communication Template** | EC data-exchange formats (definitive model supersedes transitional QReport). |
| **Schemas:** A_InstData, B_EmInst, C_InstEnergy, D_Processes, E_SEE, F_CHP, Summary_Products | Communication Template V2.1 sheets. |

---

## 10. Carbon markets & MRV (EU ETS vocabulary)

| Term | Meaning |
|---|---|
| **EU ETS** | Cap-and-trade carbon market. |
| **Allowance (EUA)** | Right to emit 1 tCO₂e. |
| **Free allocation / benchmark** | Free allowances by product benchmark; phased out 2026–2034. |
| **MRV** | Monitoring, Reporting & Verification cycle. |
| **MRR / AVR** | EU ETS Monitoring & Reporting / Accreditation & Verification Regulations. |
| **Union Registry** | Holds ETS accounts/allowances (distinct from CBAM Registry). |
| **Scope 1/2/3** | GHG Protocol categories (direct / purchased energy / value chain). |

---

## 11. Verification & accreditation

- **Verification** = third-party assurance of the *data* (traceability, completeness,
  plausibility, recalculation, sampling, site visit). **Fact**.
- **Accreditation** = NAB credential for the *verifier body* (ISO/IEC 17029, ISO 14065, Del.
  2025/2551; 12 accreditation activity groups). **Fact**.
- **Independence / self-review threat** — a verifier cannot assure its own affiliate's work;
  the stamp stays third-party. **Fact**.
- **Materiality / reasonable vs limited assurance** — verifier thresholds/levels. **Fact**.

---

## 12. Penalties & money

| Item | Figure | Source |
|---|---|---|
| **Excess-emissions penalty** | **€100/tCO₂e** (indexed), per unsurrendered certificate; obligation not extinguished | Claim/Fact |
| **Unauthorised import penalty** | Enhanced **3×–5×** standard (reduced if ≤10% over) | Claim |
| **Transitional reporting penalty** | €10–50/t (legacy) | Claim |
| **Certificate price** | Tracks ETS; Q1 2026 €75.36, Q2 2026 €75.28 | Fact |
| **Carbon-price deduction** | Deduct carbon price already paid in country of origin (evidence required) | Fact |

---

## 13. Sources
- Reg (EU) 2023/956; Reg (EU) 2025/2083 (Omnibus); IR 2023/1773; IR 2024/3210; IR 2025/2546/2547/
  2620/2621; Del. Reg. 2025/2551; Directive 2003/87/EC; MRR 2018/2066; AVR 2018/2067.
- EC DG TAXUD CBAM pages + user manuals (`../research/cbam-registry-workflow.md`).
- CORA CBAM glossary (official definitions w/ article refs) — https://importer.cora-online.com/cbam-knowledge/glossary
- CBAM Tools glossary — https://cbam-tools.com/glossary
- Steel value chain (routes) — https://hub.truesourcemetals.com/chain/steel/ ; steelonthenet abbreviations.
- KB internals: `../research/cbam-data-catalogue.md`, `../research/cbam-input-sources.md`,
  `../research/glossary.md`, `../research/regulations.md`.

> Living document — extend as terms surface. Tag new entries Fact/Claim/[verify].
