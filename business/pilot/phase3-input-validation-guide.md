# Phase 3 — Input Validation Guide (DPP CBAM)

**Purpose:** explain, in detail, how we map and validate a pilot installation's inputs — so the
process is repeatable and a reviewer can follow it. This is the “why” behind the Phase 3
templates.

**Companion templates:** `boundary-worksheet.md`, `source-stream-inventory.md`,
`precursor-register.md`, `production-by-cn.md`, `unit-period-check.md`, `gap-register.md`,
`cn-code-helper.md`.

> **Regulatory anchors:** Reg. (EU) 2023/956 Annex IV; IR 2025/2547 (definitive calculation);
> IR 2025/2546 (verification); IR 2025/2621 (default values). Where a detail is uncertain, it is
> marked **[verify]** against the instrument.

---

## 0. The responsibility model

| Actor | Owns | We rely on them for |
|---|---|---|
| **Operator (customer)** | the installation, the monitoring plan, the facts | process flow, meters, documents, confirmations |
| **Veriflow (us)** | the drafting, validation and evidence pack | boundary draft, stream inventory, precursor list, reconciliation, gap register |
| **Accredited verifier** | the verification opinion | assessing the boundary/method/evidence; issuing the report |

**We draft → the customer confirms → the verifier assesses.** We never impose a boundary or
silently accept an incomplete one. The customer's confirmation is part of the evidence.

Why this matters: the operator is legally responsible for the monitoring approach; a boundary we
invent is worthless. Our value is turning their facts into a **structured, validated, traceable**
pack.

---

## 1. System boundary — whose job, and what to ask

### Who defines it
The **operator** owns the boundary and monitoring plan. We **derive a draft** from their process
facts and have them confirm it. The verifier checks that the boundary is complete and consistent
with the methodology.

### What to ask the customer
Ask for **facts, not conclusions**:

1. **Process flow / site layout** — even a hand-drawn diagram. Every step from raw input to
   finished good.
2. **Process list** — coke oven, sinter, BF, BOF, EAF, LF, casting, rolling, reheat, pickling,
   coating, extrusion, anodising, etc.
3. **Inputs/outputs per step** — what goes in, what comes out, including by-products and gases.
4. **Fuel and gas lines** — NG, BFG, BOFG, COG, hydrogen; reduction agents (coke, coal, PCI).
5. **On-site generation** and imported/exported heat/electricity.
6. **Meter map** — what is measured, where, unit, calibration.
7. **Entity vs installation** — co-located tenants, shared utilities, the fence line.
8. **Existing documents** — monitoring plan, ETS/BRSR/ISO 50001/GHG report.
9. **Production route + qualifying parameters** (BF-BOF/EAF/DRI; primary/secondary Al).

### How we derive the draft
1. Draw the **process boxes** from the flow diagram.
2. Draw the **flows** (mass, energy, gases) between them.
3. Mark **metered points** and data sources.
4. Decide **inside/outside** for shared utilities, offices, logistics.
5. Check **route consistency** (BF-BOF vs EAF vs DRI vs Al).
6. List **open questions** in the gap register.

### What to leave out
- Office/canteen/admin loads (unless material).
- Logistics outside the gate.
- Double-counted shared utilities.

### Worked examples
- **Integrated BF-BOF:** coke oven → sinter → BF → BOF → casting → rolling → reheat. Gases BFG,
  BOFG, COG are internal flows; captive power is inside. Offices are out.
- **Re-roller:** boundary starts at **HRC input** (a precursor), then reheat → rolling → pickling
  → coating. The ore/ironmaking stages are upstream, captured through the precursor's SEE — not
  re-drawn here.

### Customer confirmation
Use `boundary-worksheet.md` §7: name, role, date, email confirmation. This becomes part of the
evidence.

---

## 2. Source streams — checklist, not open-ended

### The problem with both extremes
- **“Send everything”** → noise, unreadable files, wasted time.
- **“Send what you think”** → omissions (the most common cause of a failed verification).

### The method
Provide a **structured checklist by class**, and ask the customer to mark **Used / Not used /
Unknown**. Then validate completeness against the route.

Classes: fuels · process materials · gases · electricity · heat/steam · flaring/venting ·
mass-balance streams. See `source-stream-inventory.md`.

### Route-completeness prompts

| Route | What you expect to see |
|---|---|
| BF-BOF | coke/coal/PCI, sinter inputs, BFG, BOFG, lime/dolomite, electricity, reheat fuel |
| EAF | scrap, electrodes, electricity, oxygen, alloys, slag formers |
| DRI | gas/H₂, pellets, electricity |
| Primary Al | alumina, anodes, potline electricity, PFC/anode effects, casting fuel |
| Secondary Al | scrap, remelt fuel, electricity |
| Extrusion | ingot/billet, electricity, furnace gas |

If an expected stream is missing, **flag it** — do not assume it is not used.

### Handling “Unknown”
- Ask a targeted follow-up (e.g., “Do you flare BFG?”).
- Check the process flow and invoices for evidence.
- If still unknown, record it in the gap register and use a conservative approach; the verifier
  will challenge an unexplained omission.

### Worked example — BF-BOF
Expected: coke, coal/PCI, sinter inputs, BFG/BOFG/COG, electricity, reheat gas, lime/dolomite,
oxygen. If the customer’s checklist omits BFG, that is a red flag (gas transfer attribution).

---

## 3. Precursors — the list is defined by the regulation

### Who defines the list
**Annex I of Reg. (EU) 2023/956** defines covered inputs. We provide the covered-input checklist
(`precursor-register.md` + `cn-code-helper.md`); the customer marks what they consume; we validate
against **purchase invoices, mill certificates and weighbridge tickets**.

Only **CBAM-covered** inputs are precursors. Ore, limestone, coal, packaging are not.

### What to ask
- Purchase invoices for primary metal inputs (billets, scrap, DRI, alumina, unwrought Al).
- Mill certificates / supplier data sheets.
- Weighbridge tickets / mass logs.
- Supplier verification reports (if any).

### How to validate
1. **Against purchases** — every covered input in the invoices must appear in the register.
2. **Against the route** — re-roller buys HRC; caster buys pig iron/crude steel; extruder buys
   ingot/billet.
3. **Against the process flow** — does the input feed a process step?
4. **Catch omissions** — if they buy a covered input not listed, flag it (understated SEE).
5. **SEE source** — `Actual (verified report ref)` only with a valid report for the right period;
   otherwise `Actual (unverified)` or `Default`.
6. **Recursion** — a precursor’s SEE already includes its own precursors; do not add the chain
   again.

### Worked examples
- **Re-roller:** 1,050 t HRC (7208) × 1.90 tCO₂e/t (verified) = 1,995 tCO₂e. If the supplier has no
  verification, use the HRC default and flag the cost.
- **Casting plant:** pig iron (7201) + crude steel (7206/7207); scrap (7204) is excluded from CBAM
  scope.
- **Extruder:** unwrought aluminium (7601) / billets; profiles (7604) are the output.

---

## 4. Production outputs by CN code — how to validate

### What to ask
- Production logs (by product, period).
- Sales invoices / shipping documents.
- Customs/export invoices (HS/CN codes).
- Stock records (opening/closing).

### Validation steps
1. **CN classification** — map each product to a CN code; confirm with customs/sales invoices;
   customer confirms. Ambiguity → gap register.
2. **Period** — same reporting year, 12 months; note missing months.
3. **Reconciliation** — `production ≈ sales + closing stock − opening stock`.
4. **Mass balance / yield** — input mass vs output mass. If inputs ≫ outputs, check stock, scrap,
   by-products; if outputs > inputs, check units/period.
5. **Energy intensity** — MWh/t and fuel/t vs route benchmarks.
6. **Allocation** — if one process makes several goods, document the rule.
7. **Net mass** — tonnes, not pieces; convert and record.

### Worked example
1,000 t CRC (7209) from 1,050 t HRC (7208): yield 95.2%. Sales 980 t + stock increase 20 t =
1,000 t produced. Energy: 70 tCO₂e direct. SEE = (1,995 + 70) / 1,000 = 2.065 tCO₂e/t.
*Illustrative.*

### “Does the input suffice the output?”
This is the mass-balance question. If 1,000 t out needs ~1,050 t in (95% yield), and the customer
reports 1,000 t in, either the output is overstated, an input is missing, or there is a stock
change. Investigate before calculating.

---

## 5. Units, periods and gaps — how to find them

### Unit normalisation
- Energy: kWh/MWh/MJ/GJ/TJ → **MWh or GJ** (1 MWh = 3.6 GJ).
- Gas: SCM/Nm³/m³ → **Nm³ with a stated basis**; do not assume SCM = Nm³.
- Mass: kg/t → **tonnes (net)**.
- Emissions: CO₂/CO₂e → **tCO₂e** with the GWP version.
- Money: ₹/€ → **€** with the FX source/date.

Record the original value **and** the converted value.

### Period coverage
- 12 months, same calendar year; list missing months.
- Align invoice dates, production logs and sales.
- Any mismatch → gap register.

### Cross-source reconciliation
| Data | Compare |
|---|---|
| Electricity | bill vs meter vs production |
| Gas | invoice vs meter |
| Precursor mass | purchase vs weighbridge |
| Output | production vs sales vs stock |
| Fuel | purchase vs consumption log |

### Factor register
NCV, emission factor, oxidation factor, carbon content, biomass fraction, grid factor, GWP,
density — each with **source and version**.

### Plausibility (sanity, not calculation)
- SEE ranges: BF-BOF ~2.0–2.3; EAF ~0.4–0.6; DRI ~1.0–1.4; primary Al ~14–16; secondary lower.
- Energy intensity: EAF ~440 kWh/t; primary Al ~13–15 MWh/t.
- Yield: HRC→CRC ~90–97%.

Outliers are a prompt to investigate, **not** a reason to adjust the number.

### How to find gaps
Run the templates and compare sources. Look for:
- Blank/zero fields, missing months.
- Unit mismatches, period mismatches.
- Missing calibration, missing verification reports.
- CN ambiguity, boundary ambiguity.
- Route-incomplete streams/precursors.
- Plausibility outliers.

### Gap register
Every gap gets: `data point · category · status · impact · fallback · owner · due · notes`.
Every gap has a **fallback** so the pilot can still deliver.

**Important distinction:** an EU **default value** is a per-tonne SEE fallback for the good; it is
**not** a substitute for a missing monthly meter reading. If activity data is missing, you either
use a documented estimate (where permitted) or fall back to the default SEE for the line, and flag
it. **[verify the permitted estimation rule]**

---

## 6. The Phase 3 workflow (days 3–5)

| Step | Input | Output | Gate |
|---|---|---|---|
| 3.1 Boundary | process flow, meters | boundary worksheet (draft) | customer confirms |
| 3.2 Source streams | checklist + documents | inventory + route check | no unexplained omissions |
| 3.3 Precursors | purchases, mill certs | precursor register | every covered input accounted for |
| 3.4 Outputs | production, sales, stock | production by CN | reconciliation + mass balance |
| 3.5 Units/factors | raw values | normalised values + factor register | every figure has unit/period/source |
| 3.6 Gaps | all of the above | gap register | every gap has fallback + owner |

**Gate to Phase 4:** every figure has an evidence-log row, or a documented gap with a fallback.

---

## 7. What “sufficient” means

Data is sufficient for the pilot when:
- The boundary is confirmed.
- Every **source stream** expected for the route is present or explained.
- Every **covered precursor** is listed with mass and SEE source.
- Every **output** is mapped to a CN code and reconciled.
- Every figure has a **unit, period, source and determination flag**.
- Gaps are recorded with a fallback.

It is **not** sufficient if:
- A stream or precursor is missing without explanation.
- Figures have no source.
- Units/periods are inconsistent.
- Someone “estimated” without documentation.

---

## 8. Common failure modes

| Failure | Cause | Response |
|---|---|---|
| Missing source stream | open-ended request | route-completeness check |
| Missing precursor | customer self-selected | validate against purchases |
| Output > inputs | units/period/stock error | reconcile; check net mass |
| Wrong CN | description-based guess | customs invoice + confirm |
| Unit mismatch | SCM vs Nm³ | convert with density/NCV; record |
| Defaults everywhere | no supplier verification | quantify the cost; plan actuals |
| Unreviewable EPD | wrong boundary | use as reference only; CBAM needs its own data |
| Retrospective plan | plan written after the year | document what was actually done; do not backdate |

---

## 9. Where to record everything

- Boundary decisions → `boundary-worksheet.md`
- Streams → `source-stream-inventory.md`
- Precursors → `precursor-register.md`
- Outputs → `production-by-cn.md`
- Units/factors → `unit-period-check.md`
- Gaps → `gap-register.md` / `.csv`
- Every figure → `evidence-log-template.md` / `.csv`
- Final deliverable → `diagnostic-report-template.md`

---

## 10. Key references

- Reg. (EU) 2023/956, Annex IV (embedded emissions).
- IR (EU) 2025/2547 (definitive calculation), IR 2025/2546 (verification), IR 2025/2621 (defaults).
- `knowledge/research/cbam-data-catalogue.md` — sections B, D, E, G.
- `knowledge/research/cbam-input-sources.md` — where data lives, by plant area.
- `knowledge/learning/cbam-201/02-monitoring-plans-and-data-quality.md`
- `knowledge/learning/cbam-precursors/` — precursor calculation and scenarios.
