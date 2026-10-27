# Reading Guide — Electricity Bill

## What it is
A monthly electricity invoice from the distribution utility (here, a state discom) to an
industrial consumer. For a mill, it is the **source of the indirect-emissions activity data**
(purchased electricity, in kWh).

## How to read it (top to bottom)
1. **Consumer No. / Tariff** — identifies the connection; tariff should be industrial/HT.
2. **Billing period** — the date range the kWh belongs to. **Critical for CBAM**: consumption must
   be assigned to the right reporting (calendar) year.
3. **Meter No. + readings** — previous and present reading; **difference** = raw units.
4. **CT/PT multiplier** — for HT connections the meter may not record full units; the
   **units consumed = difference × multiplier**. (Here it is 1.0, so they match.)
5. **Units Consumed (kWh)** — **the one number CBAM needs.** It is *active energy* (kWh), not kVAh.
6. **Maximum demand / power factor / charges** — commercial data; **not used for CBAM**.
7. **Due date** — payment; irrelevant to CBAM.

## What CBAM uses (and what it ignores)

| Use for CBAM | Ignore |
|---|---|
| **Units consumed (kWh)** | ₹ charges, duty, meter rent |
| **Billing period** (date range) | demand charges, power factor, max demand |
| CT/PT multiplier (applied to get kWh) | due date, payment terms |

**Formula:** `indirect emissions (tCO₂) = kWh ÷ 1000 × grid emission factor (tCO₂/MWh)`.
The **grid emission factor is not on the bill** — it comes from the country/grid dataset
(e.g., EEA / national grid average).

## Gotchas (why real bills surprise people)
- **kVAh vs kWh** — some bills show apparent energy (kVAh); CBAM needs **kWh**.
- **CT/PT multiplier** — forgetting it under-counts by the multiplier factor.
- **Billing period ≠ calendar month** — may straddle two months; allocate correctly.
- **Estimated/actual readings** — some bills use estimated readings, corrected next cycle.
- **Multiple meters / multiple connections** — sum all electricity for the installation.
- **12 bills needed** — CBAM is annual; one bill is a month, not the year.
- **Own generation** — if the mill self-generates, that is a separate (direct) stream, not on the bill.

## Synthetic-doc note
This is a fabricated sample (marked SPECIMEN). Real utility formats vary by state; the *fields*
above are what matter, not the exact layout.
