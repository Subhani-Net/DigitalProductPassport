# CBAM Report — Shree Balaji Steel & Alloys (2026)

**Installation:** DEMO-STEEL-EAF-01 · Raipur, IN · **Route:** EAF · **Period:** 2026 (annual)

## Emissions summary
| Component | tCO₂ |
|---|---|
| Direct (natural gas + electrodes) | 29,826.24 |
| Indirect (purchased electricity) | 149,952.00 |
| **Total embedded (installation)** | **179,778.24** |
| **Total production** | 480,000 t |
| **SEE (mass-based)** | **0.374538 tCO₂/t** |

## Per-good report (mass allocation — default)
| CN code | Product | Activity (t) | SEE (tCO₂/t) | Embedded (tCO₂) | Determination | Evidence |
|---|---|---|---|---|---|---|
| 7214 | TMT bars / rods | 300,000 | 0.374538 | 112,361.40 | actual | `02-fuel-invoice/`, `01-electricity-bill/`, electrodes register |
| 7213 | Wire rod | 120,000 | 0.374538 | 44,944.56 | actual | same shared streams |
| 7208 | Hot-rolled flat | 60,000 | 0.374538 | 22,472.28 | actual | same shared streams |
| **Total** | | **480,000** | | **179,778.24** | | |

*Override available:* if the mill reports per-product SEE (flat higher), use Path B in
`allocation.md`; it reconciles to the same installation total.

## Actual vs default (why verified actuals matter)
| Metric | Value |
|---|---|
| Actual SEE | 0.374538 tCO₂/t |
| EC default (EAF, illustrative) | 0.45 tCO₂/t |
| Delta | 0.075462 tCO₂/t |
| **Installation saving vs default** | **36,221.76 tCO₂ ≈ €2,729,671.83** (at €75.36/t, full factor) |

## Assumptions (see `assumptions.md`)
- Annual electricity 211,200 MWh (440 kWh/t), grid EF 0.71.
- Natural gas NCV 0.0000355 TJ/Nm³, EF 56 (lab/standard).
- Mass-based allocation (same EAF route).

## Status
**Verifier-ready, not verified.** The accredited verifier's report is required to use these
actuals in a declaration. Evidence trail attached in `verifier-dossier.md`.
