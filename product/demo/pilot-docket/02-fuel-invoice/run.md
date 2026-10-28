# Step 02 — Concierge Test Run (fuel invoice)

Documents the manual/scripted extraction → canonical → calculation for the natural-gas invoice.

## 1. Extract (from the invoice)
| Field | Value |
|---|---|
| Quantity supplied | **180,000 SCM (≈ Nm³)** |
| Delivery period | 2026-09-01 → 2026-09-30 |
| NCV | **0.0000355 TJ/SCM** *(from the CoA/lab — not on the invoice)* |
| Emission factor | **56 tCO₂/TJ** *(standard/lab)* |
| Oxidation factor | 1.0 |

## 2. Normalise (volume → energy)
```
energy = 180,000 SCM × 0.0000355 TJ/SCM = 6.39 TJ
```

## 3. Calculate (direct emissions)
```
direct tCO₂ = 6.39 TJ × 56 tCO₂/TJ × 1.0 = 357.84 tCO₂
```

## 4. Integrity check (invoice internally consistent)
| Check | Result |
|---|---|
| meter: 6,00,000 − 4,20,000 | 1,80,000 SCM ✓ |
| taxable: 1,80,000 × ₹48.00 | ₹86,40,000 ✓ |
| CGST + SGST: 9% + 9% of ₹86,40,000 | ₹15,55,200 ✓ |
| invoice total: taxable + GST | ₹1,01,95,200 ✓ |

## 5. What this feeds
`canonical-fuel.json` → a `sourceStreams[]` entry (natural gas) in the client's canonical model.

## 6. Notes / open
- **Volume from invoice; NCV/EF external** — this is the key lesson of fuel data.
- **12 months** — annual figure sums all invoices / the monthly register.
- **Other fuels** — coal is mass (t) with its own NCV (TJ/t); keep each stream separate.
- Confirm the supplier's **SCM reference conditions** (15 °C vs other) before relying on NCV.

## Outcome
The pipeline works for this document: **180,000 SCM → 6.39 TJ → 357.84 tCO₂ direct (September)**.
