# Assumptions Register — whole submission reports

| ID | Item | Assumption / value | Flag | Why |
|---|---|---|---|---|
| S1 | Installations & quantities | E1/E2/E3 and the import matrix | illustrative | scenario |
| S2 | SEE values | per-installation, illustrative (EAF/BF-BOF) | illustrative | from the practice datasets |
| S3 | Defaults | 2.10 tCO₂/t for all CN, for comparison | illustrative | real defaults are **CN+country**, and differ by country (IN vs TR) |
| S4 | Certificate factor | 2.5% (2026) / 100% (2034, context) | fact | CBAM phase-in |
| S5 | Foreign carbon price | none (0) in these examples | illustration | add if origin country prices carbon |
| S6 | Declarant identity | DEMO EORIs for X/Y/Z | illustration | fictitious |

## Reconciliation
- X: 449.4456 + 1,630.0320 + 585.0000 + 220.0000 = **2,884.4776** ✓
- Y: 187.2690 + 80.0000 + 44.6304 + 312.0000 = **623.8994** ✓
- Z: 1,365.0000 + 440.0000 + 112.3614 = **1,917.3614** ✓
- Each importer's per-CN aggregation sums to its total embedded.

## Note on defaults
Defaults are set per **CN code + country of origin**. The comparison here uses a single 2.10
figure only to illustrate the saving; a real declaration would use each origin's default
(IN vs TR would differ).
