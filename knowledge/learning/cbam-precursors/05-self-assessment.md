# Module 5 — Self-Assessment

Answer before opening the key. Aim for 8/10.

## Part A — Precursors (Q1–5)
1. Define a **precursor** and say which regulation defines it.
2. Which of these are precursors: pig iron, iron ore, HRC, coal, aluminium ingot, packaging?
3. Write the formula for `EE_inpMat` and for `SEE_good`.
4. Why is `Mᵢ` consumption and not output? Give the yield example.
5. Explain recursion in one sentence — why don't you add the whole chain twice?

## Part B — Calculation (Q6–7)
6. Output 2,000 t; precursor consumption 2,100 t at SEE 1.80; direct emissions 120 t.
   (a) `EE_inpMat`? (b) total? (c) SEE? (d) if the default is 2.10, what is the SEE and the
   difference?
7. Name three calculation errors a verifier would flag.

## Part C — Data & timeline (Q8–10)
8. List six fields a precursor data reply must contain to be usable.
9. Who files the CBAM declaration, and what does the exporter actually provide?
10. "Everyone submits by 30 Sep 2027." Explain what is due, for which year, and why that does
    not mean everyone calculates on that day.

---

## Answer key

**1.** An input material that is itself an **Annex I (CBAM) good**; defined in **IR 2025/2547
Art. 1(7)**.

**2.** Precursors: **pig iron, HRC, aluminium ingot**. Not precursors: iron ore, coal (not Annex I
goods), packaging. (Check ferro-alloy exclusions separately.)

**3.** `EE_inpMat = Σ(Mᵢ × SEEᵢ)`; `SEE_good = Total embedded emissions ÷ tonnes of good produced`.

**4.** Because you lose material in processing. If 1,000 t output needs 1,050 t input, `Mᵢ = 1,050`
but you divide by **1,000**.

**5.** Each precursor's SEE **already contains its own precursors**, so adding `Mᵢ × SEEᵢ` carries
the chain once; adding the chain again would double-count.

**6.**
- (a) `2,100 × 1.80 = 3,780 tCO₂e`
- (b) `3,780 + 120 = 3,900 tCO₂e`
- (c) `3,900 ÷ 2,000 = 1.95 tCO₂e/t`
- (d) default: `2,100 × 2.10 = 4,410`; total `4,530`; SEE `2.265 tCO₂e/t`; difference
  **0.315 tCO₂e/t** (≈ €23.7/t at €75.36).

**7.** Any three: consumption vs output/yield; allocation undocumented; mixing EPD boundary with
CBAM; missing precursors; wrong period; unit errors (kg/t, CO₂/CO₂e); double-counting the chain.

**8.** Any six: operator/installation identity; CN code; production route; reporting period;
direct SEE; indirect SEE (if applicable); allocation method; precursor list; verifier +
accreditation + standard + report period; data quality/default flags; mill/batch ID; evidence.

**9.** The **EU importer** files the declaration and surrenders certificates. The exporter
**supplies installation data + evidence** (and may register to reuse it); the verifier verifies.

**10.** Due: the **annual declaration + certificate surrender for CY2026 imports**. The
calculation happens in the **Jan–Sep 2027 window** from data captured during 2026; verification
also happens then. September is the **deadline**, not the start. Quarterly from 2027 is
**certificate holding**, not a data submission.

---

## Capstone exercise (do this before your first pilot)

You are the CBAM lead for a **galvanised steel strip** exporter (CN 7210) selling to two EU
importers. The plant buys **HRC (CN 7208)** from one supplier and **zinc (not a CBAM good)** from
another. Output last year: 12,000 t. HRC consumption: 12,600 t.

Produce a one-page plan covering:
1. **Scope:** which inputs are precursors; simple/complex.
2. **Data request:** the exact fields you will ask the HRC supplier for (use Module 3).
3. **Calculation:** the worksheet with placeholders, including yield and allocation.
4. **Timeline:** what happens in-year vs the Jan–Sep window; when you book the verifier.
5. **Risk:** what you do if the HRC supplier sends an EPD instead of a verified CBAM SEE.
6. **Reuse:** how the same dataset serves both importers.

**Pass bar:** a colleague can execute the plan without asking you what "precursor," "SEE," or
"30 Sep" mean.
