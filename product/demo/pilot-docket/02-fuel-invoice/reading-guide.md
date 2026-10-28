# Reading Guide — Fuel Invoice (Natural Gas)

## What it is
A purchase invoice for fuel consumed at the plant (here, pipeline natural gas for a reheat/rolling
furnace). For a mill, it is the **source of the direct-emissions activity data** (fuel quantity).

## How to read it (top to bottom)
1. **Supplier + GSTIN** — who supplied the gas.
2. **Invoice No. / Date / Due date** — payment metadata (not used for CBAM).
3. **Delivery period** — the period the gas was consumed; **must map to the reporting year**.
4. **Gas meter readings** — opening and closing reading in **SCM**; difference = quantity.
5. **Invoice line** — **Qty (SCM)** and rate. The **Qty** is the number CBAM needs.
6. **Taxes / total** — ₹ amounts; **not used for CBAM**.

## What CBAM uses (and what it ignores)

| Use for CBAM | Ignore |
|---|---|
| **Quantity (SCM ≈ Nm³)** | ₹ rate, CGST/SGST, invoice total |
| **Delivery period** | invoice no., due date |

**The invoice gives quantity only.** To calculate emissions you need two more things, which are
**NOT on the invoice**:
- **NCV** — net calorific value (TJ per Nm³ or per SCM), from the **lab / Certificate of Analysis**.
- **Emission factor** — tCO₂ per TJ for natural gas, from the standard/lab.

**Formula:** `direct tCO₂ = quantity(Nm³) × NCV(TJ/Nm³) × EF(tCO₂/TJ) × OF`.

## Gotchas
- **SCM vs Nm³** — Standard Cubic Metre is standardised volume ≈ Nm³; confirm the supplier's
  reference conditions (some use Sm³ at 15 °C).
- **NCV is not on the invoice** — the single biggest surprise. You must get the CoA/lab value.
- **Volume vs mass** — gas is volumetric; coal is mass (tonnes) and needs its own NCV in TJ/t.
- **Delivery period ≠ calendar month** — allocate to the right year.
- **Multiple fuels / suppliers** — sum each stream separately; each has its own EF.
- **Invoices ≠ consumption reconciliation** — cross-check with the gas meter and the monthly register.
- **12 months** — CBAM is annual; one invoice is one month.

## Synthetic-doc note
Fabricated sample (marked SPECIMEN). Real formats vary; the *fields* above are what matter.
