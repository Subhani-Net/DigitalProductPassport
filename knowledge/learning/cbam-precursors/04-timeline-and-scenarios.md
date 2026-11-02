# Module 4 — The Timeline, and the Scenarios (the confusing part)

## 4.1 The only thing to remember: two clocks

```
CAPTURE CLOCK  (1 Jan – 31 Dec, the reporting year)
  monitor, meter, invoice, collect supplier data, keep evidence
                     │
                     ▼
DECLARE CLOCK  (1 Jan – 30 Sep of the NEXT year)
  assemble → verify → declare → surrender certificates
```

- **Everyone's declaration for the 2026 import year is due 30 Sep 2027.** That is the
  *declaration* deadline, **not** the moment everyone starts calculating.
- The **calculation window** is the months after the year ends and before 30 Sep — but it only
  works if you **captured data during the year**. You cannot reconstruct January's meter readings
  in August.
- So: **calculate after, capture during.** That resolves "how can everyone submit in September?"

## 4.2 Who submits what (three different actors)

| Actor | What they do | What they file |
|---|---|---|
| **EU importer** (declarant) | aggregates lines, holds certificates, bears liability | **the annual CBAM declaration** + certificate surrender |
| **Non-EU exporter** (operator) | supplies installation data + evidence to the importer (may register in the registry to reuse across buyers) | **no declaration** — data provider |
| **Accredited verifier** | verifies the installation's emissions report | **verification report** (feeds the declaration) |

> The exporter does not "submit the CBAM declaration." The importer does. The exporter's job is to
> make the importer's declaration **accurate and cheap** — that is the product.

## 4.3 The annual cycle (dates)
| Date | Event |
|---|---|
| 1 Jan 2026 | Definitive phase begins; only authorised declarants import above 50 t |
| 31 Mar 2026 | Grace period for declarant applications filed by this date ends |
| 1 Feb 2027 | **Sale of CBAM certificates begins** |
| 1 Jan – 30 Sep 2027 | Assemble + verify + declare **CY2026** |
| **30 Sep 2027** | **First annual declaration + certificate surrender (for 2026 imports)** |
| Each quarter in 2027 | **Hold ≥50%** of year-to-date emissions at quarter-end — **provisioning, not a data submission** `[verify %/date]` |
| 30 Sep 2028 | Declaration + surrender for **2027** imports |
| 30 Sep each year | Same pattern for the prior calendar year |

**Fact** — Reg. (EU) 2023/956 as amended by Reg. (EU) 2025/2083 (Omnibus); repo
`../../research/submission-cadence-and-risk.md`. **`[verify quarterly %/date]`**

## 4.4 What "everyone submits by Sep 2027" actually means
- It applies to **goods imported in CY2026**.
- People calculate **between Jan and Sep 2027**, using data captured during 2026.
- **Verification** happens in that window too — and capacity is scarce, so **book early**.
- There is **no separate "calculation submission"**. The only recurring data submission is the
  annual declaration; quarterly is **certificate holding**.
- 2027 imports are declared by **30 Sep 2028** — the cycle repeats, not a one-off.

## 4.5 First-year nuances
- 2026 is the **first definitive year**; the transitional quarterly reports ended Dec 2025.
- There may be a limited allowance to use defaults more liberally in the **first**
  definitive-year declarations (IR 2025/2547/2548). **`[verify]`**
- The **50 t de minimis** is at **importer** level — a small importer may be out of scope even if
  you export to them.
- Penalties: **€100/tCO₂e** for shortfall; **3–5×** for unauthorised import. **Fact.**

## 4.6 Scenario matrix — what changes the answer

| # | Scenario | What you calculate | What you file / flag |
|---|---|---|---|
| 1 | **Simple good**, one installation, same year | direct (+ indirect if applicable) actual | verify; declare actual |
| 2 | **Complex good**, precursor same installation & year, **verified** | `M × SEE_verified` added | declare actual precursor |
| 3 | Precursor from **multiple installations / periods**, same CN code | **weighted average** of SEE | document the average |
| 4 | Precursor **unverified / no reply** | use **default** for that line | flag **default** |
| 5 | Precursor produced in a **different year** | reporting period default = year of the complex good; use verified data for the right period, weighted average, or default | flag period/actual-default |
| 6 | One exporter → **many EU importers** | one installation dataset | each importer declares; you upload once, reuse (O3CI) |
| 7 | Importer below **50 t/yr** | out of CBAM scope | no declaration (confirm importer threshold) |
| 8 | Data/verification **late** | provisional: defaults | flag; upgrade next cycle |

**Fact** for the weighted-average / right-period rules — EEPC India E4; `[verify]` against
Annex IV / IR 2025/2547.

## 4.7 A worked timeline (2026 shipment)
1. **Feb 2026** — you ship 500 t to an EU importer. Capture: invoice, weighbridge, mill cert,
   energy bills. Send precursor request to the HRC supplier.
2. **Mar–Dec 2026** — keep capturing monthly; chase the supplier; store evidence.
3. **Feb 2027** — certificates go on sale; the importer starts provisioning.
4. **Mar–Jun 2027** — assemble the installation file; get the **verifier** engaged (book early).
5. **Jul–Aug 2027** — verification; fix non-conformities; finalise SEE.
6. **By 30 Sep 2027** — importer files the declaration and surrenders certificates.
7. **2027 activity** — repeat for the 30 Sep 2028 cycle.

## 4.8 Confusions, resolved
**"If everyone submits by Sep 2027, how do they all calculate?"**
> They don't calculate *on* that date. They calculate in the Jan–Sep 2027 window from data
> captured during 2026. September is the *deadline*, not the *start*.

**"Do I (exporter) submit anything?"**
> No declaration. You supply data + evidence to your importer (and may register to reuse it).
> The importer files; the verifier verifies.

**"Is quarterly reporting back?"**
> No. Transitional quarterly reporting ended Dec 2025. From 2027, quarterly is **certificate
> holding** (provisioning), not a data submission.

**"Can I use last year's number?"**
> Only with the right-period/verified rules or a weighted average; otherwise default. Your
> precursor's reporting period defaults to the year the complex good was produced.

**"What if our verifier is booked out?"**
> That is a real risk (capacity is scarce). Book early; if you can't, the line goes to default —
> which is exactly the cost your customer will feel.

## Outcome check
1. Draw the two clocks from memory.
2. Who files the CBAM declaration — exporter or importer?
3. What is due on 30 Sep 2027, and for which year?
4. What is the quarterly obligation from 2027, and what is it *not*?
5. Walk through scenario 5 (precursor from a different year) in three sentences.
