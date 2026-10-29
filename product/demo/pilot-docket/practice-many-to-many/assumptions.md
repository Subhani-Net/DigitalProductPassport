# Assumptions Register — many-to-many practice

| ID | Item | Assumption / value | Flag | Why |
|---|---|---|---|---|
| M1 | Installation B dataset | BF-BOF SEE 2.03754 (from the demo BF-BOF fixture) | illustrative | second source for contrast |
| M2 | Quantities | X: 1,200/800 t; Y: 500/300 t | illustrative | to show the mapping |
| M3 | Country for defaults | both installations in India → default 2.10 | illustrative | defaults are CN+country, not installation |
| M4 | Certificate factor | 2.5% (2026) / 100% (2034) | fact | CBAM phase-in |
| M5 | Importer identity | DEMO-IMP-X / DEMO-IMP-Y | illustration | fictitious |

## Reconciliation
- X: 449.4456 + 1,630.0320 = **2,079.4776** ✓
- Y: 187.2690 + 611.2620 = **798.5310** ✓
- Defaults are **CN+country**, so they do **not** distinguish A from B — actuals do.
