# Practice — One installation, multiple CN codes (end-to-end)

Follows the recommended capability: **accept whatever the exporter gives**, allocate across goods,
and produce the CBAM report. This is the chain a real pilot exercises.

## Scenario
Shree Balaji Steel & Alloys (EAF, Raipur) produces **three goods** in one installation:
- **7214** TMT bars/rods — 300,000 t
- **7213** Wire rod — 120,000 t
- **7208** Hot-rolled flat — 60,000 t

Shared streams (natural gas, electrodes, electricity) → allocated → **SEE per CN code**.

## The four stages (and where to look)

| Stage | Question | File |
|---|---|---|
| **1. Calculate** | how do shared emissions become per-good SEE? | `allocation.md` |
| **2. Record** | the canonical installation model (`goods[]` + allocation + assumptions) | `installation-data.json` |
| **3. Submit** | the importer's declaration lines per CN code | `importer-declaration.json` |
| **4. Provide** | what the verifier sees (drill-down, recalculation) | `verifier-dossier.md` |

Plus: `report.md` (the CBAM report) and `assumptions.md` (the gap register).

## The numbers
- Direct **29,826.24** + indirect **149,952.00** = **179,778.24 tCO₂** (480,000 t).
- **SEE = 0.374538 tCO₂/t** (mass allocation; uniform across goods).
- vs EC default EAF 0.45 → **36,221.76 tCO₂ saved ≈ €2.73M** (at €75.36/t, full factor).
- Importer importing 2,000/800/500 t → **1,235.975 tCO₂** embedded → 30.899 certs (2026, 2.5%) / 1,235.975 (2034, 100%).

## Key lessons
1. **Shared streams, per-good results** — allocation is the core modelling problem.
2. **Two paths, one truth** — mass-rules or per-product override; both reconcile to the installation total.
3. **Assumptions are first-class** — no blank fields; every gap is flagged and visible.
4. **Same data, two consumers** — the importer's declaration lines and the verifier's dossier come from one model.

> Standalone illustrative annual dataset; not derived from the smaller single-month Step-01/02 documents.
