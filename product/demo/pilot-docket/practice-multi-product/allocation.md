# Allocation — one installation, multiple CN codes

## The problem
An installation produces **three goods** but its source streams and electricity are **shared**.
We must split the installation's emissions across the goods to get a **SEE per CN code**.

## Inputs (annual, 2026)
| Stream | Quantity | Factor | Energy | tCO₂ |
|---|---|---|---|---|
| Natural gas (reheat) | 13,521,127 Nm³ | NCV 0.0000355 TJ/Nm³, EF 56 | 480.0 TJ | 26,880.00 |
| Graphite electrodes | 960 t | NCV 0.033 TJ/t, EF 93 | 31.68 TJ | 2,946.24 |
| Electricity | 211,200 MWh | EF 0.71 tCO₂/MWh | — | 149,952.00 (indirect) |

**Direct = 29,826.24 tCO₂ · Indirect = 149,952.00 tCO₂ · Total = 179,778.24 tCO₂**

## Goods & activity levels
| CN code | Product | Activity (t) | Share |
|---|---|---|---|
| 7214 | TMT bars / rods | 300,000 | 62.5% |
| 7213 | Wire rod | 120,000 | 25.0% |
| 7208 | Hot-rolled flat | 60,000 | 12.5% |
| **Total** | | **480,000** | 100% |

## Path A — rules-based mass allocation (default)
Same EAF route for all goods → allocate by mass:
```
SEE = 179,778.24 / 480,000 = 0.374538 tCO₂/t   (uniform across goods)
```
| CN | Activity (t) | SEE (tCO₂/t) | Embedded (tCO₂) |
|---|---|---|---|
| 7214 | 300,000 | 0.374538 | 112,361.40 |
| 7213 | 120,000 | 0.374538 | 44,944.56 |
| 7208 | 60,000 | 0.374538 | 22,472.28 |
| **Total** | 480,000 | | **179,778.24** ✓ |

## Path B — per-product override (if the mill already reports by product)
The mill says flat products need more rolling energy; we **accept the override** and reallocate to
the same installation total (no double counting):
| CN | Activity (t) | SEE (tCO₂/t) | Embedded (tCO₂) |
|---|---|---|---|
| 7214 | 300,000 | 0.350000 | 105,000.00 |
| 7213 | 120,000 | 0.400000 | 48,000.00 |
| 7208 | 60,000 | 0.446304 | 26,778.24 |
| **Total** | 480,000 | | **179,778.24** ✓ |

**Rule:** override is used only if it **reconciles** to the installation total; any residual is
recorded in the Assumptions Register. Both paths produce the same total — the split differs.
