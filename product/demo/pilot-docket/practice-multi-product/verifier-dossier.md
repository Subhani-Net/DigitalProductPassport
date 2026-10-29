# Verifier Dossier (read-only view)

What an accredited verifier sees — the drill-down from each figure to its source.

## 1. Identity & boundary
- Installation **DEMO-STEEL-EAF-01**, Raipur IN (UN/LOCODE INRPR), route **EAF**, scrap ratio 0.98.
- System boundary: EAF + rolling/reheat. Period: 2026 (annual).

## 2. Source streams → evidence
| Stream | Quantity | Factor | Source document |
|---|---|---|---|
| Natural gas (reheat) | 13,521,127 Nm³ | NCV 0.0000355 TJ/Nm³ · EF 56 | `02-fuel-invoice/` (quantity) + CoA/lab (NCV/EF) |
| Graphite electrodes | 960 t | NCV 0.033 TJ/t · EF 93 | electrodes purchase register + lab |
| Electricity | 211,200 MWh | EF 0.71 tCO₂/MWh | `01-electricity-bill/` (kWh) + grid EF dataset |

## 3. Recalculation
- Direct = 480.0 TJ×56 + 31.68 TJ×93 = 26,880.00 + 2,946.24 = **29,826.24 tCO₂** ✓
- Indirect = 211,200 MWh × 0.71 = **149,952.00 tCO₂** ✓
- Total = **179,778.24 tCO₂**; SEE = 179,778.24 / 480,000 = **0.374538 tCO₂/t** ✓

## 4. Allocation
- Method: **mass-based** (same EAF route). Reproducible from activity levels (300k/120k/60k).
- Override path documented and reconciles to the same total.

## 5. Assumptions & open items (from the register)
- A1 annual electricity (estimate) · A2 gas NCV (lab) · A3 allocation (method) · A4 grid EF (factor).

## 6. Verdict
- Data is **verifier-ready**: complete, reconciling, sourced. Final **verification report is issued
  by the accredited verifier** (not by us — independence rule).
