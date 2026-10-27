# CBAM 201 — Cheatsheet

## Core formula
```
SEE = (direct + indirect embedded emissions) / activity level
      + Σ (precursor mass × precursor SEE)      [complex goods]
```

## Direct-emission methods
Calculation-based `AD_i × EF_i × OF_i` (AD_i = quantity × NCV) · CEMS · mass balance.

## Key numbers
| Item | Value |
|---|---|
| CBAM factor | 2.5% (2026) → 100% (2034) |
| Default-value mark-up | ~10% (2026) → ~30% (2028) for Al/cement/steel; ~1% fertilisers **[verify]** |
| Certificate price | Q1 2026 €75.36/t; Q2 2026 €75.28/t |
| Certificate sales start | 1 Feb 2027 |
| Annual declaration + surrender | 30 Sep (first 30 Sep 2027) |
| Quarterly minimum holding | ≥50% (from 2027) |
| Sell-back request | by 30 June |
| Excess-emissions penalty | €100/tCO₂e; unauthorised 3×–5× |
| Data-quality thresholds | ≤1.5% (>500 kt/y); <7.5% (<10 kt/y) **[verify]** |

## Method/act map
Calc: IR 2025/2547 · Benchmarks: IR 2025/2620 · Defaults: IR 2025/2621 · Verification:
IR 2025/2546 · Accreditation: Del. 2025/2551 · Registry: IR 2024/3210 · Omnibus: Reg 2025/2083.

## Sector drivers
- **Steel:** route (BF-BOF/EAF/DRI), coke/coal, scrap ratio, electricity.
- **Aluminium:** electricity (~13–15 MWh/t) + **PFC** (anode effects; CF₄/C₂F₆ GWP 7380/12400).
- **Cement:** calcination process CO₂ + kiln fuel; SCM reduces clinker.

## Collection path
S0 paper → S1 files → S2 dynamic (ERP/MES/LIMS/utility) → S3 real-time (OPC UA/historian/CEMS).

## Registry
O3CI (operator + verifier) · AMM (declarant) · DRMC (monitoring). EU Login + 2FA, via EU
Customs Trader Portal.

## Verification dossier (must-have)
Monitoring plan · activity data + source evidence · ISO 17025 lab factors · route params ·
precursor SEE · calibration/uncertainty · mass-balance · audit trail.

## Actual vs default rule
If verified actual data is obtainable → **use it** (saving grows with the CBAM factor);
otherwise defaults (budget the mark-up; invest in monitoring).
