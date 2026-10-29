# Practice — Many-to-many (2 installations × 2 importers)

Exercises the importer-side mapping: the same CN code sourced from **two installations** with
**different SEE**, consumed by **two importers**. This is the model from
`knowledge/research/declaration-and-mapping.md`, made concrete.

## The map
```
        Installation A (EAF, SEE 0.374538) ──┬──► Importer X : 1,200 t
        CN 7214                             └──► Importer Y :   500 t
        Installation B (BF-BOF, SEE 2.03754) ┬──► Importer X :   800 t
        CN 7214                             └──► Importer Y :   300 t
```

## Files
| File | Shows |
|---|---|
| `installations.json` | per-installation SEE by CN code (uploaded once, shared) |
| `import-records.json` | importer × installation × CN × quantity (the mapping) |
| `declarations.json` | aggregated declaration per importer (lines + totals + certificates) |
| `mapping.md` | the calculation walkthrough and default comparison |

## The numbers
| Importer | Quantity | Embedded (actual) | vs default (2.10) |
|---|---|---|---|
| **X** | 2,000 t | **2,079.4776 tCO₂** | 4,200.00 → saves **2,120.52** |
| **Y** | 800 t | **798.5310 tCO₂** | 1,680.00 → saves **881.47** |

Certificate obligation: X 51.9869 (2026) / 2,079.4776 (2034); Y 19.9633 / 798.5310.

## What you should take away
1. **Installation mapping is mandatory for actual values** — SEE differs per installation, so the
   importer must know quantity per source.
2. **Declarations aggregate per CN**, but the calc is per (installation, CN, quantity).
3. **One installation → many importers** (A serves X and Y); data is uploaded once.
4. **No installation → default** (punitive) — the mapping is a direct cost lever.
5. **Same data, different consumers** — each importer's declaration is derived from the shared
   installation SEEs + their own quantities.
