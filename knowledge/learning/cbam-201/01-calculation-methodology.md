# Module 1 — Calculation Methodology in Depth

## 1.1 The legal method
- Embedded emissions are calculated per **Annex IV of Reg (EU) 2023/956**, detailed by
  **IR (EU) 2025/2547** (definitive period). **Fact**.
- Definitions you must use precisely: **functional unit, activity level, system boundary,
  aggregated goods categories, reporting period, production route, precursor, source stream,
  activity data** (all in IR 2025/2547 Art. 1). **Fact** (see `../cbambok.md` §2).

## 1.2 The building blocks

**System boundary** = the group of chemical/physical processes included in the calculation for
one **aggregated goods category**. You only count emissions inside the boundary. **Fact**.

**Functional unit** = the reference unit (e.g. per tonne of product). **Fact**.

**Activity level (ALg)** = quantity of goods (in the functional unit) produced in the boundary.
**Fact**.

**Specific Embedded Emissions (SEE)** of a good (tCO₂e/t):

```
SEE = (direct embedded emissions + indirect embedded emissions) / activity level
      + Σ (precursor mass × precursor SEE)          [for complex goods]
```

**Fact** (Annex IV structure; precursor term `EEInpMat = Σ Mi × SEEi`).

## 1.3 Direct emissions — three permitted approaches

| Method | Formula / basis | Notes |
|---|---|---|
| **Calculation-based** | `Emissions = Σ (AD_i × EF_i × OF_i)`; activity data `AD_i = quantity × NCV` for fuels | Default method for most source streams |
| **Measurement-based (CEMS)** | concentration × flue-gas flow, integrated over time | Where required/available (e.g. ETS-style) |
| **Mass balance** | carbon in = carbon out (± stock changes) → emissions | Certain streams, e.g. some steel/process gas |

**Fact** (Annex III/IV methodology). `EF` = emission factor; `OF` = oxidation factor;
`NCV` = net calorific value.

## 1.4 Indirect emissions
- Electricity consumed (MWh/t) × the applicable **emission factor** (grid/country, or a
  contractual factor with **PPA + Guarantees of Origin**). **Fact**.
- Heat/cooling consumed is handled under **direct** emissions (production of heat/cooling).
  **Fact**.
- **Sector/phase-in nuance** for whether/when indirect is charged — **[verify]** (`../cbambok.md` §6).

## 1.5 Production routes are a first-class variable
- The **production route** (IR 2025/2547 Art. 1(6)) plus **route-qualifying parameters**
  (e.g. steel: EAF scrap ratio, DRI share, hot-metal ratio, BF coke rate; aluminium: cell
  technology) materially change SEE. You must declare the route and its parameters. **Fact**
  (`../../research/cbam-data-catalogue.md` A4/A4b).

## 1.6 Worked micro-example (illustrative)
Crude steel, BF-BOF, one reporting year:

| Input | Value (illustrative) |
|---|---|
| Activity level (crude steel) | 1,000,000 t |
| Direct emissions | 1,850,000 tCO₂e |
| Indirect emissions | 90,000 tCO₂e |
| Precursor contribution | 0 (integrated route) |

`SEE = (1,850,000 + 90,000) / 1,000,000 = **1.94 tCO₂e/t**` (illustrative).

## Outcome check
1. Write the SEE formula for a simple and a complex good.
2. Name the three direct-emission methods and when each fits.
3. What are "route-qualifying parameters" and why do they matter?
