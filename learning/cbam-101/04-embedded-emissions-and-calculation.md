# Module 4 — Embedded Emissions & Calculation

## 4.1 The core quantity: embedded emissions

- **Embedded emissions** = the greenhouse gases emitted to produce a good, expressed per tonne
  of product: **Specific Embedded Emissions (SEE)**, in **tCO₂e per tonne**. **Fact**.
- It has two parts:
  - **Direct emissions** — from fuel/processes *at the installation* (e.g. coke, gas, process
    reactions such as PFCs in aluminium).
  - **Indirect emissions** — from **purchased electricity** consumed (MWh/t × the electricity's
    emission factor). **Fact**.
- For **complex goods**, SEE also includes the embedded emissions of **precursors** (covered
  inputs carried into the product). **Fact**.

## 4.2 How direct emissions are measured (three ways)

| Method | What it is | When used |
|---|---|---|
| **Calculation-based** | Activity data × emission factors (ADi = quantity × NCV; then × factor) | Standard, most sources |
| **Measurement-based (CEMS)** | Continuous stack measurement (concentration × flow) | Where required/available |
| **Mass-balance** | Full input/output carbon balance of the installation | Certain streams (e.g. some steel) |

**Fact** (Reg 2023/956 Annex IV + IR 2023/1773 Annex III). Inputs must be **reliable data**
from monitored sources; lab factors come from accredited labs (ISO/IEC 17025). **Fact**.

## 4.3 The inputs the math needs (canonical list)
- **Activity data** — quantities of fuels/materials (TJ, t, Nm³).
- **Calculation factors** — net calorific value, emission factor, oxidation factor, carbon
  content, biomass fraction.
- **Electricity data** — MWh/t + emission factor (grid / PPA / Guarantees of Origin).
- **Precursor data** — mass × the precursor's SEE.
- **Installation metadata** — country, UN/LOCODE, coordinates, production route + route
  parameters; for steel, the **mill identification number**. **Fact**
  (`research/cbam-input-sources.md`).

## 4.4 Actual values vs default values — the commercial heart

- **Actual values** = the installation's **own monitored and verified** emissions. Requires
  good monitoring + a **verifier's report**. **Fact**.
- **Default values** = EC-published **country/CN** fallbacks used when actual values are not
  available. **Fact** (IR 2025/2621).
- Defaults are **punitive** — commonly higher than real performance, so relying on them costs
  more. **Claim** (~20–25% higher; `research/goto-market-sizing.md`).
- **Incentive:** importers and their suppliers are pushed to produce **verified actual data**
  to avoid the default penalty. This is the whole data chain in one sentence. **Fact/logic**.

## 4.5 Sector specificity (101-level preview)
- **Steel** — route matters: **BF-BOF** (blast furnace–basic oxygen, coal-heavy), **EAF**
  (electric arc, scrap + electricity), **DRI** (direct reduced iron, gas/H₂). SEE differs
  sharply by route. **Fact** (sectors in `research/cbam-input-sources.md`).
- **Aluminium** — primary is electricity-dominated (~13–15 MWh/t) **plus PFC emissions**
  (CF₄/C₂F₆ from **anode effects**, very high GWP); secondary (recycled) is far lower. **Fact**.

## 4.6 Monitoring plan as a data blueprint
An installation's **monitoring plan** defines the data boundaries, source streams, measuring
equipment, and calculation approach — the "digital blueprint" an auditor checks *before* site
work. **Fact**.

## Outcome check
1. Define SEE and its two components.
2. When can an importer use actual values, and what unlocks them?
3. Why are default values commercially bad, and what behaviour do they drive?
