# Submission Cadence & Importer Risk

How often CBAM data is submitted, why it is retrospective, and how the importer manages the
risk. Companion to `cbam-registry-workflow.md` and `data-inputs-reference.md`.

## Two submissions — don't conflate them

| | **Operator (installation / exporter)** | **Declarant (importer)** |
|---|---|---|
| System | O3CI portal of the CBAM Registry | AMM + annual declaration |
| Content | installation identity + emissions data for the reporting year | annual CBAM declaration, per good / CN code |
| Rhythm | **annual data; uploaded once, reused by many declarants** | **once per year — by 30 Sep for the prior calendar year** |
| Legal liability | none (data provider) | **yes — the importer** |

So the legal act is **once per year per importer**, not "once per installation". The installation
data is the *input*, uploaded once and shared.

## Frequency going forward

- **Annual** — data + declaration + certificate surrender, by **30 Sep** of the following year.
- **Quarterly (from 2027)** — the **certificate-holding rule** (hold ≥50% of year-to-date
  emissions at each quarter-end). This is *provisioning*, **not** a data submission. `[verify %/date]`
- **Transitional quarterly reporting is over** (Oct 2023 – Dec 2025 only).
- **Missing information** is not a separate submission — each declaration line is flagged
  **actual vs default** inside the annual declaration.

## Retrospective by design (not "back-dating")

You import during the calendar year, then declare that year by 30 Sep of the next. So
**CY2026 → declared Sep 2027**, and every year follows the same pattern. This is inherent to the
annual model — not a first-year exception. `[verify]` There may be a specific allowance to use
defaults more liberally for the **first** definitive-period declarations (IR 2025/2547/2548).

## Importer risk — and how to manage it

| Risk | Why | Mitigation |
|---|---|---|
| **Data risk** | no verified actuals → punitive defaults (~10% 2026 → ~30% 2028) | collect verified actuals **in-year**; contractual supplier duties; O3CI data |
| **Verification risk** | actuals need an **accredited verifier**; capacity is scarce (SGS/BV were still applicants) | book verification early; verifier-ready evidence |
| **Certificate-price risk** | ETS-linked price + certificates must be surrendered | buy/hold through the year; **quarterly ≥50% holding** forces provisioning |
| **Liability risk** | importer owns accuracy; **€100/t** penalty, **3–5×** for unauthorised import | audit trail; honest default flags where data is missing; contracts/insurance |

**Net:** declare annually, retrospectively — but manage risk **continuously**. This is exactly why
the product's value is **in-year capture + verifier-ready evidence**, not a year-end calculator.
