# Units, Periods & Factors — Phase 3

**Purpose:** normalise every figure to a consistent unit and period, and record the factors used,
so the calculation is reproducible and a verifier can follow it.

## 1. Unit normalisation

| Quantity | Accept | Normalise to | Conversion notes |
|---|---|---|---|
| Energy | kWh, MWh, MJ, GJ, TJ | MWh or GJ | 1 MWh = 3.6 GJ; 1 TJ = 1,000 GJ |
| Gas volume | SCM, Nm³, m³ | Nm³ (state basis) | Do not assume SCM = Nm³ without a basis |
| Mass | kg, t | tonnes (net) | 1 t = 1,000 kg |
| Emissions | kgCO₂e, tCO₂, tCO₂e | tCO₂e | State CO₂ vs CO₂e; GWP version |
| Money | ₹, € | € (state rate/date) | Record FX source |
| Concentration | ppm, mg/Nm³ | declared | For CEMS only |

> Record the **original value and unit** in the evidence log, plus the converted value.

## 2. Period coverage

- [ ] Reporting period is the **calendar year** (or the exact declared period).
- [ ] **12 months** covered; list any missing months.
- [ ] All sources use the **same period** (bills, production, sales).
- [ ] Any date mismatch is recorded in the gap register.

## 3. Cross-source reconciliation

| Data | Source A | Source B | Match? | Action |
|---|---|---|---|---|
| Electricity | utility bill | meter/interval data | | |
| Gas | invoice | meter/flow | | |
| Precursor mass | purchase invoice | weighbridge | | |
| Output | production log | sales invoices + stock | | |
| Fuel | purchase | consumption log | | |

## 4. Calculation factor register

| Factor | Value | Unit | Source | Version/date | Used for |
|---|---|---|---|---|---|
| NCV | | GJ/t or GJ/1,000 Nm³ | lab CoA / standard | | fuel energy |
| Emission factor | | tCO₂/TJ | lab / standard | | combustion |
| Oxidation factor | | — | standard | | combustion |
| Carbon content | | % | lab | | mass balance |
| Biomass fraction | | % | lab / certificate | | biomass correction |
| Grid factor | | tCO₂e/MWh | EEA / country | | indirect |
| GWP (CH₄, N₂O, PFC) | | — | IPCC AR6 | | CO₂e |
| Density | | kg/Nm³ | lab / standard | | volume→mass |

> Every factor must have a source and version. Standard values are allowed only where the rules
> permit them.

## 5. Plausibility checks

| Metric | Expected (steel) | Expected (aluminium) |
|---|---|---|
| SEE | BF-BOF ~2.0–2.3; EAF ~0.4–0.6; DRI ~1.0–1.4 | primary ~14–16; secondary lower |
| Electricity | EAF ~440 kWh/t | primary ~13–15 MWh/t |
| Yield | HRC→CRC ~90–97% | extrusion depends on profile |

> Outliers are a signal to investigate — not to adjust the number to fit the benchmark.

## 6. Gap register

Record every missing, inconsistent or unverified item in `gap-register.md` with a fallback
(default) and a cost estimate.

## 7. Checklist

- [ ] Every figure has a unit and a period.
- [ ] Converted values are recorded alongside originals.
- [ ] Factors have a source and version.
- [ ] Cross-source mismatches are explained or logged.
- [ ] Outliers investigated.
