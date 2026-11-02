# LCA & EPD — Deep Primer (with the CBAM bridge)

**Purpose:** understand LCA / PCF / EPD well enough to (a) speak credibly to customers and
advisors, (b) review a supplier's EPD or PCF, and (c) know exactly where CBAM ends and LCA
begins. This is a *learning* document, not a product spec.

**Tagging convention (repo-wide):** **Fact** = from a cited standard/regulation ·
**Claim** = vendor/marketing statement · **[verify]** = not yet confirmed against the
instrument. Numbers marked *illustrative* are for shape, not truth.

---

## 1. Why this matters to us

- Customers and competitors will say "we do LCA/EPD/CCF." We need to answer without bluffing.
- We **do not build** LCA/EPD engines (commodity, data-heavy, licensed). We build the **CBAM
  validation + evidence layer** and can consume EPD/PCF data as *inputs*.
- The risk to avoid: conflating a full life-cycle suite with the narrow, regulated CBAM job.

---

## 2. LCA fundamentals

### 2.1 What it is
**Life Cycle Assessment** is a structured method to quantify the environmental impacts of a
product, service, or system across its life. It is a **methodology**, not a software product.
The governing standards are **ISO 14040** (principles & framework) and **ISO 14044**
(requirements & guidelines). **Fact.**

### 2.2 The four phases (ISO 14040/14044)
1. **Goal & scope definition** — why, for whom, functional unit, system boundary, allocation,
   data-quality rules, review type.
2. **Inventory analysis (LCI)** — every input (energy, materials, water) and output (emissions,
   waste) per unit of the system.
3. **Impact assessment (LCIA)** — convert the inventory into impact categories (climate,
   acidification, eutrophication, water, land, etc.).
4. **Interpretation** — sensitivity, uncertainty, completeness, consistency; conclusions.

### 2.3 Goal & scope — the decisions that decide the result
- **Functional unit** — the quantified performance the study is based on, e.g. "1 tonne of
  hot-rolled coil delivered to gate." Everything scales to this.
- **Reference flow** — the amount of product needed to deliver the functional unit.
- **System boundary** — which processes are inside:
  - **Cradle-to-gate** — raw material extraction → factory gate (no use, no end-of-life).
  - **Gate-to-gate** — one plant only.
  - **Cradle-to-grave** — includes use and disposal.
  - **Cradle-to-cradle** — includes recycling/recovery as a loop.
- **Cut-off criteria** — mass/energy/impact thresholds below which inputs are ignored
  (must be declared; a source of gaming).
- **Allocation** — how burdens are split between co-products (see §2.8).
- **Data quality** — primary vs secondary, geography, year, technology.

### 2.4 Inventory (LCI)
The "shopping list" of the system: ore, scrap, ferroalloys, fuels, electricity, transport,
auxiliaries; outputs: CO₂, CH₄, N₂O, PFCs, waste, co-products. Each flow has a **quantity**
and an **emission factor**. The hard part is not the maths — it is **boundary completeness**
and **data quality**.

### 2.5 Impact assessment (LCIA)
- **Classification** — assign flows to impact categories.
- **Characterisation** — multiply each flow by a **characterisation factor** (e.g. GWP100:
  1 kg CH₄ = ~28–30 kg CO₂e; 1 kg N₂O = ~265–273 kg CO₂e; PFCs are thousands).
- **GWP100** values come from **IPCC AR5/AR6**; the version matters and must be declared.
  **[verify current factors against the cited IPCC report]**
- Optional: normalisation and weighting (value-laden — usually excluded from EPDs).

### 2.6 Interpretation
Sensitivity (which inputs dominate?), uncertainty (ranges, not single numbers),
completeness and consistency checks. An LCA without interpretation is a data dump.

### 2.7 Attributional vs consequential
- **Attributional** — "what share of existing burdens belongs to this product?" (most EPDs).
- **Consequential** — "what changes if I make/buy one more unit?" (policy, market signals).
They can give very different answers; never compare across types.

### 2.8 Allocation (the biggest source of disagreement)
Multi-output processes (e.g. a BF produces hot metal, slag, BFG, BOFG) need a rule:
- **Mass allocation** — by mass of outputs.
- **Energy allocation** — by energy content (common for fuels/gases).
- **Economic allocation** — by revenue share.
- **System expansion / substitution** — credit co-products by avoided production.
- **Recycling**: closed-loop, open-loop, **cut-off** (recycled content), or **avoided-burden**
  (end-of-life credit). The choice can swing a steel PCF by a large margin.

### 2.9 Data quality & uncertainty
Primary (measured, plant-specific) > secondary (database, industry average). Geography
matters (India grid vs EU grid). Year matters (grid decarbonises). Technology matters
(BF-BOF vs EAF vs DRI). Declare all four.

### 2.10 Common pitfalls
- Boundary cherry-picking (exclude the dirty step).
- Inconsistent allocation between compared products.
- Outdated or wrong-geography emission factors.
- Mixing attributional and consequential results.
- Presenting a single number without uncertainty.
- "Carbon neutral" claims from offsets, not reductions.

---

## 3. PCF — Product Carbon Footprint (ISO 14067)

A **climate-only** footprint of a product, built on LCA principles. **Fact.**
- Unit: **kgCO₂e per functional/declared unit** (for steel usually per tonne).
- Boundary: often cradle-to-gate; must be declared.
- Covers only GWP (not acidification, water, etc.).
- Standards: **ISO 14067**, **GHG Protocol Product Standard**, **PAS 2050** (older).
- **PCF ≠ LCA**: PCF is one impact category; LCA is the full method. **PCF ≠ CBAM**: CBAM has
  its own prescribed boundary, allocation and verification rules (see §5).

---

## 4. EPD — Environmental Product Declaration

### 4.1 Type I / II / III labels
- **Type I** (ISO 14024) — third-party certified ecolabel (e.g. EU Ecolabel).
- **Type II** (ISO 14021) — self-declared environmental claim.
- **Type III** (ISO 14025) — **Environmental Product Declaration**: quantified, verified,
  published LCA-based declaration. **Fact.**

### 4.2 What an EPD contains
- Product identification and **declared unit** (e.g. 1 t of steel).
- **System boundary and modules** covered.
- LCA results by indicator (GWP-total/fossil/biogenic, acidification, eutrophication, etc.).
- Data year, geography, technology, data quality.
- **PCR** reference and version.
- **Program operator** and registration number; **validity period**.
- **Verification statement** (independent third-party).

### 4.3 PCR and program operator
- **Product Category Rules (PCR)** define the rules for a product category (boundary, data,
  indicators) so EPDs are comparable within the category.
- A **program operator** administers the PCR, registers the EPD, and runs/oversees
  verification (examples: IBU, International EPD System, BRE, UL Environment, NSF, Kiwa).
- Without the PCR and program operator, a "declaration" is not a Type III EPD.

### 4.4 EN 15804 modules (construction products, incl. steel)
**EN 15804+A2** is the core PCR for construction products. Modules:
- **A1** raw material supply · **A2** transport to factory · **A3** manufacturing
  → **A1–A3 = cradle-to-gate**.
- **A4** transport to site · **A5** construction/installation.
- **B1–B7** use stage (use, maintenance, repair, replacement, refurbishment, energy, water).
- **C1–C4** end-of-life (deconstruction, transport, waste processing, disposal).
- **D** benefits/loads beyond the system (recycling, recovery).
Most steel EPDs declare **A1–A3** (and optionally C/D). Records in our TracePass inventory
use `lifecycleModules` like `A1-A3` (see `../research/tracepass-steel-fields-table.md`).
**Fact.**

### 4.5 Verification and validity
An EPD is only a Type III declaration if an **independent third party** verifies the LCA
(ISO 14064-3 / ISO 14065 for bodies) and the program operator publishes it. EPDs have a
**validity period** (often ~5 years) and must be re-verified. **Fact.**

### 4.6 Steel EPDs — specifics
- Declared unit is typically **1 tonne of steel product**.
- Indicators include **GWP-total** (kgCO₂e), **GWP-fossil**, **GWP-biogenic**, **GWP-luluc**,
  plus acidification/eutrophication/water.
- **worldsteel** publishes LCI data and a steel PCR; many producers use it. **[verify current
  worldsteel PCR/version]**
- Scrap allocation and electricity source are the biggest swing factors (BF-BOF vs EAF vs DRI).

### 4.7 Aluminium EPDs — specifics
- Split **primary** (electrolysis, PFC emissions, very electricity-intensive) vs **secondary**
  (recycling, much lower).
- Electricity source dominates primary aluminium GWP (coal-heavy India vs hydro).
- PFCs (CF₄, C₂F₆) are high-GWP and must be included in primary smelting.

### 4.8 How to read an EPD (quick checklist)
1. Type III EPD or just a PCF/marketing claim?
2. Which **PCR** + version, which **program operator**, valid until when?
3. **Declared unit** — 1 t? 1 m³?
4. **Boundary/modules** — A1–A3 only, or A1–A5/C/D?
5. **Data year and geography** — India plant or industry average? Which grid?
6. **GWP indicators** — total/fossil/biogenic/luluc; units.
7. **Allocation** — scrap, co-products, energy.
8. **Electricity** — grid vs PPA; location- vs market-based.
9. **Verifier** — who, to what standard; is the statement current?
10. **Comparability** — same PCR, same boundary, same data year?

---

## 5. LCA / PCF / EPD vs CBAM — the bridge

| Dimension | LCA / PCF / EPD | CBAM |
|---|---|---|
| Legal force | Voluntary / market / procurement | **Mandatory**, penalised |
| Governing rules | ISO 14040/44, ISO 14067, ISO 14025, EN 15804, PCR | **Reg. (EU) 2023/956 + Annex IV + IR 2025/2547** |
| Boundary | Life-cycle, chosen modules | **Installation-level** production of the good |
| Unit | Functional / declared unit | **Tonne of goods per CN code** |
| Impacts | Many (LCA) / GWP (PCF/EPD) | **Carbon only** (direct; indirect where applicable) |
| Allocation | LCA choices (declared) | **Prescribed CBAM rules** |
| Precursors | Included as modelled | **Added recursively with CBAM rules** |
| Data quality | Declared | Verified by an **accredited CBAM verifier** |
| Verification | Third-party LCA/EPD verification | **ISO 14064-3 / 14065 / 17029 + Del. Reg. 2025/2551** |
| Output | EPD publication / PCF report | **Verifier report + registry declaration** |

**Key facts to hold:**
- For **iron & steel and aluminium**, only **direct emissions** are counted initially; indirect
  (electricity) may be reviewed later. **Fact** per EEPC India CBAM portal, cross-checked
  against Annex II — **[verify clause-by-clause]**.
- CBAM allows a deduction for a **carbon price effectively paid in the country of origin**
  (Art. 9), evidenced — an EPD does not provide this.
- **An EPD cannot substitute for a CBAM declaration.** Different boundary, allocation,
  verification and legal rules. EPDs can be **inputs/reference** (e.g. a supplier's precursor
  EPD), never the compliance artifact.

---

## 6. Worked example — where the numbers diverge (illustrative)

Take 1 tonne of hot-rolled coil from a BF-BOF plant. *All numbers illustrative only.*

| Question | LCA/PCF/EPD answer | CBAM answer |
|---|---|---|
| Boundary | A1–A3 (ore → gate), maybe C/D | Installation production of the good |
| Result | e.g. "2.0 tCO₂e/t GWP-total A1–A3" | "e.g. 1.8 tCO₂e/t direct SEE" |
| Includes upstream ore/transport? | Yes (A1/A2) | Only where CBAM rules include precursors |
| Includes electricity? | Yes (often) | Not initially for steel (direct only) |
| Verified by | LCA verifier under EPD scheme | Accredited CBAM verifier |

**Lesson:** the two numbers look similar and are **not interchangeable**. Never present an EPD
number as a CBAM SEE, or vice versa.

---

## 7. Reviewing a supplier's EPD/PCF — 12 checks

1. Is it a **Type III EPD** (ISO 14025) or a self-declared PCF?
2. Which **PCR and version**?
3. Which **program operator**; registration number; validity date?
4. **Declared unit** and product scope (which CN codes?).
5. **Modules** covered (A1–A3? A1–A5? C/D?).
6. **Data year** and **geography** (plant-specific or average? Indian grid?).
7. **GWP indicators** and units (total/fossil/biogenic/luluc).
8. **Allocation** of scrap, co-products, energy.
9. **Electricity** source and factor (grid vs PPA; location vs market).
10. **Precursors** included and their data source.
11. **Verifier** identity, standard, statement date.
12. **Comparability** — can it sit beside another EPD without boundary mismatch?

---

## 8. Questions to ask a supplier / consultant

- "Which boundary and modules does this number cover?"
- "Which PCR and version? Who is the program operator?"
- "Is the data plant-specific or industry average — and for which year?"
- "How is scrap and co-product allocation handled?"
- "What electricity factor was used, and is it location- or market-based?"
- "Are precursors included, and from which source?"
- "Who verified it, to what standard, and when does it expire?"
- "Can this be mapped to our installation / CN code for CBAM — or is it a different boundary?"

---

## 9. Glossary

| Term | Meaning |
|---|---|
| **LCA** | Life Cycle Assessment — ISO 14040/14044 method. |
| **LCI** | Life Cycle Inventory — the quantified flows. |
| **LCIA** | Life Cycle Impact Assessment — flows → impact categories. |
| **Functional unit** | The quantified performance the study is based on. |
| **Reference flow** | Product amount needed to deliver the functional unit. |
| **System boundary** | Which processes are inside the study. |
| **Cradle-to-gate** | Raw material → factory gate (A1–A3). |
| **Cradle-to-grave** | Includes use and end-of-life. |
| **Allocation** | Splitting burdens across co-products. |
| **Characterisation factor** | Multiplier converting a flow to an impact (e.g. GWP100). |
| **GWP100** | Global Warming Potential over 100 years, in CO₂e. |
| **PCF** | Product Carbon Footprint — ISO 14067 (climate only). |
| **EPD** | Environmental Product Declaration — ISO 14025 Type III. |
| **PCR** | Product Category Rules. |
| **Program operator** | Body administering a PCR and registering EPDs. |
| **Declared unit** | Unit the EPD results are stated per (e.g. 1 t). |
| **Module** | Life-cycle stage block in EN 15804 (A1–D). |
| **PFC** | Perfluorocarbon (CF₄, C₂F₆) — high-GWP aluminium smelting emissions. |
| **SEE** | Specific Embedded Emissions — the CBAM per-tonne figure. |

---

## 10. Sources & standards

- ISO 14040:2006 — LCA principles & framework.
- ISO 14044:2006 (+ amendments) — LCA requirements & guidelines.
- ISO 14067:2018 (+ amendment) — Carbon footprint of products. **[verify current edition]**
- ISO 14025:2006 — Type III environmental declarations.
- EN 15804:2012+A2:2019 — Core PCR for construction products.
- ISO 14064-1 / 14064-3 — GHG inventories / verification.
- GHG Protocol Product Standard; PAS 2050 (superseded in many uses).
- Regulation (EU) 2023/956 (CBAM), Annex IV; Implementing Reg. (EU) 2025/2547;
  Del. Reg. (EU) 2025/2551; Reg. (EU) 2025/2083 (Omnibus).
- EEPC India CBAM portal — https://cbam.eepcindia.org/ (scope, modules, direct-only for
  iron/steel & aluminium) — fetched 2026-11-01.
- Internal: `../research/standards.md`, `../research/cbam-input-sources.md`,
  `../research/tracepass-steel-fields-table.md`, `../research/declaration-and-mapping.md`.
