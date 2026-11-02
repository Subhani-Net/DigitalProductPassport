# Module 3 — What to Ask For (and how to validate the answer)

You cannot calculate a complex good without **upstream data**. This module is the request you
send, the reply you should accept, and the red flags that mean "use the default."

## 3.1 Who you ask
- Your **precursor supplier** (the installation that made the pig iron / crude steel / HRC /
  ingot).
- If you buy through a **trader**, the trader may not have the data — push to the **installation**
  (CBAM data lives at the installation, not the trader).
- For imported precursors, the **third-country supplier**; actual data needs a **valid verification
  report covering the right period**, else defaults. **Fact** (EEPC India, E4).

## 3.2 The precursor data request (copy this table)

| # | Field | Why |
|---|---|---|
| 1 | Operator legal name + installation address | identity |
| 2 | Installation ID (if registered in the CBAM registry / O3CI) | reuse + verification |
| 3 | Product description + **CN code** | scope + default lookup |
| 4 | **Production route** (BF-BOF / EAF / DRI; primary / secondary Al) | method + benchmark |
| 5 | **Reporting period** (year) + production dates | period matching |
| 6 | **Direct SEE** (tCO₂e/t) | core input |
| 7 | **Indirect SEE** (tCO₂e/t) — if applicable | scope (verify §1.6) |
| 8 | **Total SEE** (tCO₂e/t) | cross-check |
| 9 | **Allocation method** (mass / energy / economic) | comparability |
| 10 | **Precursor list** with mass and SEE (if the supplier's good is itself complex) | recursion |
| 11 | **Verification**: verifier name, accreditation body, standard (ISO 14064-3 / 14065 / 17029), report reference, period covered, expiry | admissibility |
| 12 | **Data quality / uncertainty** + any default flags | risk |
| 13 | **Mill / batch / heat number** linking your purchase to the data | traceability |
| 14 | Carbon price paid in country of origin (if any) | Art. 9 deduction |
| 15 | Evidence pack: monitoring plan, meter/invoice samples | audit trail |

## 3.3 A message you can send

> Subject: CBAM precursor data request — [product], [period]
>
> Hello [Name],
>
> For our CBAM reporting we need the **specific embedded emissions (SEE)** of the [HRC / pig iron /
> ingot] we bought from you in [year], at installation level.
>
> Could you send: CN code, production route, reporting period, **direct SEE** (tCO₂e/t),
> **indirect SEE** if applicable, allocation method, and the **verification report** (verifier,
> accreditation, standard, period). If any line is on **default values**, please flag it.
>
> If your product is itself complex, please include the precursor list (`mass × SEE`).
>
> We will keep the data confidential and use it only for CBAM. Happy to share our data-request
> template. Thanks — [Name]

## 3.4 How to validate the reply (accept / reject)

**Accept** when: the CN code matches; the **period covers the right year**; the verifier is
**accredited** and the statement is current; direct/indirect are separated; allocation is stated;
precursors are included; units are `tCO₂e/t`; and the evidence pack exists.

**Red flags → treat as unavailable (use default, flag it):**
| Red flag | Why it fails |
|---|---|
| "Here's our **EPD**" | EPD boundary ≠ CBAM; not a CBAM SEE |
| No verifier, or an **expired** report | actual data must be verified for the right period |
| **Period mismatch** (2024 data for 2026 goods) | reporting-period rule |
| SEE **implausibly low** vs route benchmark | plausibility / anti-fraud |
| Allocation **undocumented** | verifier will reject |
| Electricity factor unclear (grid vs PPA) | indirect reliability |
| **Missing precursors** on a complex good | understates SEE |
| kg vs t, CO₂ vs CO₂e confusion | unit error |
| Rounded to one decimal too early | precision/traceability |

## 3.5 Internal data you already have
- Purchase invoices and **weighbridge tickets** (mass `Mᵢ`).
- **MES / production logs** (output, yield, batch).
- **Mill certificates** and **batch/heat numbers** (link downstream → upstream).
- Energy bills and meter logs (direct/indirect).
- Contract terms and supplier correspondence (evidence).

## 3.6 Contract levers (the durable fix)
- Supplier obligation to provide **verified CBAM data by a date** each year.
- **Audit / information rights** and data-sharing via the registry (O3CI).
- **Price/review clause** if defaults are used because data was not supplied.
- **Confidentiality** — the supplier's recipe stays theirs (this is our zero-exposure design).

## 3.7 If you cannot get data in time
1. Use the **default** for that precursor (with the applicable mark-up).
2. **Document** why (request sent, no reply / no verification).
3. **Flag** the line as default in the declaration.
4. Plan the switch to actual next year; put the supplier on a data-obligation clause.

> Defaults are legal but punitive. Your commercial pitch is the **gap** between default and
> verified actual — quantify it in € per tonne and per shipment.

## Outcome check
1. Name five fields a precursor reply must contain to be usable.
2. Why is an EPD not acceptable as a CBAM SEE?
3. What do you do if the verifier's report covers 2024 but your good is 2026?
4. Which two contract clauses most reduce next year's risk?
