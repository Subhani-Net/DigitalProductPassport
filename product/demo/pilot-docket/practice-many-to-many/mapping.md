# Mapping — two installations, two importers

## The setup
| Installation | Route | CN 7214 SEE |
|---|---|---|
| DEMO-STEEL-EAF-01 (Shree Balaji) | EAF | **0.374538** tCO₂/t |
| DEMO-STEEL-BFBOF-01 (Bharat Integrated) | BF-BOF | **2.03754** tCO₂/t |

Same CN code, **very different SEE** — this is why the importer must map quantity to installation.

## Import records (who took what from where)
| Importer | Installation | CN | Quantity (t) |
|---|---|---|---|
| X | EAF (A) | 7214 | 1,200 |
| X | BF-BOF (B) | 7214 | 800 |
| Y | EAF (A) | 7214 | 500 |
| Y | BF-BOF (B) | 7214 | 300 |

## Calculation (per line: quantity × that installation's SEE)
**Importer X**
- 1,200 × 0.374538 = **449.4456**
- 800 × 2.03754 = **1,630.0320**
- **Total = 2,079.4776 tCO₂** → declaration line: CN 7214, 2,000 t, 2,079.4776 tCO₂

**Importer Y**
- 500 × 0.374538 = **187.2690**
- 300 × 2.03754 = **611.2620**
- **Total = 798.5310 tCO₂** → declaration line: CN 7214, 800 t, 798.5310 tCO₂

## If they used the default instead (7214, India, default 2.10)
| Importer | Default embedded (qty × 2.10) | Actual | Saving |
|---|---|---|---|
| X | 2,000 × 2.10 = 4,200.00 | 2,079.48 | **2,120.52 tCO₂** |
| Y | 800 × 2.10 = 1,680.00 | 798.53 | **881.47 tCO₂** |

## Certificate obligation
| Importer | 2026 (2.5%) | 2034 (100%) |
|---|---|---|
| X | 51.9869 certs | 2,079.4776 certs |
| Y | 19.9633 certs | 798.5310 certs |

## What this proves
1. **Same CN, different sources → different SEE** — a single average would be wrong.
2. **Each importer aggregates its own quantities** per CN, from possibly many installations.
3. **One installation serves many importers** — the SEE is uploaded once and reused (A feeds X and Y).
4. **Installation mapping is the cost lever** — no installation → punitive default.
