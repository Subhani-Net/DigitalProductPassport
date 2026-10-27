# Step 01 — Concierge Test Run (electricity bill)

Documents the manual/scripted extraction → canonical → calculation for this one document.
This is the "do things that don't scale" step; the same steps become the C3 ingestion pipeline.

## 1. Extract (from the bill)
| Field | Value |
|---|---|
| Units consumed | **528,400 kWh** |
| Billing period | 2026-09-01 → 2026-09-30 |
| CT/PT multiplier | 1.0 |
| Grid emission factor | **0.71 tCO₂/MWh** *(from the country/grid dataset — not on the bill)* |

## 2. Normalise
```
MWh = 528,400 kWh / 1000 = 528.4 MWh
```

## 3. Calculate (indirect emissions)
```
indirect tCO₂ = 528.4 MWh × 0.71 tCO₂/MWh = 375.164 tCO₂
```

## 4. Integrity check (document is internally consistent)
| Check | Result |
|---|---|
| readings: 3,014,600 − 2,486,200 | 528,400 ✓ |
| energy: 528,400 × ₹5.10 | ₹26,94,840 ✓ |
| demand: 1,120 × ₹420 | ₹4,70,400 ✓ |
| FPPCA: 528,400 × ₹0.85 | ₹4,49,140 ✓ |
| duty: 8% of ₹36,14,380 | ₹2,89,150.40 ✓ |
| total: sub + duty + meter rent | ₹39,05,030.40 ✓ |

## 5. What this feeds
`canonical-electricity.json` → the `electricity` fragment of the client's canonical model.
Later steps add source streams, production, and precursors; then the full **SEE** is computed.

## 6. Notes / open
- **Monthly only** — the annual figure needs 12 bills (or a utility consumption statement).
- **Grid EF** — confirm the India grid factor (here 0.71 used for the demo) against the official
  dataset before relying on it.
- **Own generation** — if the mill self-generates, that is a separate direct stream (step 02+).

## Outcome
The pipeline works for this document: **528,400 kWh → 375.164 tCO₂ indirect (September)**.
