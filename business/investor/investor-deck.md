# Investor Deck

Self-contained: a reader with **zero prior knowledge of CBAM** should understand every slide.
Numbers sourced from `../research/goto-market-sizing.md`, `../research/regulations.md`,
`../research/cbam-registry-workflow.md`, `../product-spec.md`, `investment-plan.md`. Figures
tagged `[verify]` where secondary. **Currency discipline: € = revenue/market · £ = the UK raise.**

---

## Slide 1 — Title

**The compliance infrastructure for Europe's carbon border tax.**

An enterprise data + workflow platform for **non-EU steel & aluminium suppliers** to shield EU
importers from punitive defaults — and to keep their export orders.

*Exporter-first · in-force wedge now · DPP network later.*

## Slide 2 — What is CBAM (the plain explanation)

- **CBAM = the EU's Carbon Border Adjustment Mechanism** (Regulation (EU) 2023/956). It puts a
  **price on the carbon embedded in goods imported into the EU**, matching the carbon cost EU
  producers already pay under the Emissions Trading System (ETS) — to stop "carbon leakage."
- **The reporting phase is over.** The **financial (definitive) phase went live 1 Jan 2026** —
  importing without verified emissions data now carries structural cost.
- **Scope:** cement, **iron & steel, aluminium**, fertilisers, electricity, hydrogen — by customs
  (CN) code, including the **precursors** used to make them. Steel & aluminium are the
  highest-density frictions (complex precursor chains).

## Slide 3 — The financial penalty driving the market

| Lever | Number |
|---|---|
| Certificate price | **€75.36/t** (Q1 2026) |
| Default-value mark-up | **~10% (2026) → ~30% (2028)** `[verify]` |
| Excess-emissions penalty | **€100/tCO₂e** (indexed) |
| Unauthorised import | **3–5×** the standard penalty |
| CBAM factor (share payable) | **2.5% (2026) → 100% (2034)** |

**What a default costs, in concrete terms (illustrative, full phase-in):** a BF-BOF supplier's
**verified actual 2.04 tCO₂/t** vs the **default 2.10 tCO₂/t** = 0.06 tCO₂/t × €75.36 ≈
**€4.5/t** — i.e. **~€4,500 per 1,000 t**, **~€45,000 per 10,000 t** — borne by the importer, who
pressures the supplier. As the CBAM factor ramps to 100%, this compounds.

**The split that matters: the EU importer is liable, but the non-EU supplier holds the data.**

## Slide 4 — Market size & the network geometry

| Layer | Who | Size |
|---|---|---|
| **Liable side** | EU importers of metals (goods >50 t/yr) | **6,000–12,000** |
| **Data side (the TAM)** | non-EU suppliers feeding them | **20,000–50,000** |
| **Velocity** | importers who applied for authorisation | **>12,000** (Jun 2026) |

This is a **legally compelled operational budget**, not discretionary SaaS — and it's a **two-sided
network**: every verified supplier serves *many* importers; every importer pulls *many* suppliers.

## Slide 5 — The underlying data problem (the liability split)

- **Who pays ≠ who has the data.** Importers face the fines; the **non-EU factory** holds the raw
  emissions data — in **fragmented, unstructured form** (mill test certificates, coal/utility
  invoices, hand-kept weighbridge logs).
- **The enterprise gap:** SAP and legacy carbon platforms build for the **declarant (EU buyer)**.
  The **supplier-side data-extraction layer is unserved.**
- Result: importers fall back to punitive defaults; suppliers lose orders to whoever can provide
  verified data.

## Slide 6 — The carbon calculation problem (why calculators fail)

- **Route specificity** — blast furnace (≈2.1 tCO₂/t) vs electric arc (≈0.45 tCO₂/t) vs DRI vs
  aluminium (≈16.5, electricity + PFC).
- **Precursor roll-ups** — embedded carbon of upstream covered inputs, before the goods hit the port.
- **Methodology rigour** — mass-balance vs CEMS vs calculation-based, and CBAM-specific allocation
  (not the GHG Protocol).
- **The binary moat:** if the numbers fail an **accredited verifier's audit**, the value is zero.
  A calculator calculates; a **workflow system proves**.

## Slide 7 — The product (four friction pillars)

> "The calculator is the commodity. The product is the friction around it."

| Capture | Validation | Audit room | Trust & hand-off |
|---|---|---|---|
| unstructured factory data → normalised | rules engine flags anomalies pre-audit | read-only workspace for accredited verifiers | one-click registry upload; EORI-linked data shield |

*Beyond processing (the six jobs):* Extract · Judge · Prove · Coordinate · Advise · Complete
(`../jobs-to-be-done.md`).

## Slide 8 — How it works, end-to-end

1. **Supplier uploads plant data once** → platform normalises, calculates, evidence-packs.
2. **Verified SEE** maps via **EORI link** to the EU CBAM Registry.
3. **Verifier** audits in a **read-only room** — drilling to source docs **without exposing the
   supplier's recipe or energy pricing** (zero-exposure).
4. **Reused by every EU buyer** the supplier sells to — and the same data pack becomes the
   **Digital Product Passport (2028–29)**.

## Slide 9 — Why us / the moat

1. **Compounding validation intelligence** — every verifier finding and metallurgical route query
   builds a proprietary rule library; generic software can't catch up.
2. **Supplier-side network lock** — once a factory maps its plant to our engine, switching cost is
   high and grows with every importer that reuses the data.
3. **Privacy as architecture** — zero-exposure proof: compliance without exposing factory unit
   economics.

## Slide 10 — Competition (where they are weak)

| Competitor | Strength | Fatal flaw for metals CBAM | Our advantage |
|---|---|---|---|
| SAP / ERPs | declarant-side scale | blind to non-EU factory floors | built from the factory floor up |
| CarbonChain | strong methodology | closed evidence; no DPP | open verifier rooms + DPP continuity |
| Minespider / Circularise | traceability / battery DPP | no CBAM registry engine | metallurgical-route engine |
| CleanCarbon | India regional | manual, un-scalable verification | programmatic, audit-ready software |

## Slide 11 — The demo (end-to-end, seedable)

A seedable data pack runs the whole journey — capture → validate → upload-once → importer
declaration → verifier drill-down → **the € saving** — anchored to EC defaults + worldsteel/IAI.
**The punchline:** a supplier moving from punitive default to **verified actuals**, saving its
importer **~€4,500/1,000 t** (~€45,000 on a 10,000 t shipment) in avoided certificate cost.

## Slide 12 — Business model (who pays)

- **The economic buyer:** non-EU **exporters pay to keep their contracts**; EU **importers
  subsidise seats** to de-risk their audits.
- **Supplier tiering:** Low €1–3k · Base €8–15k · Enterprise €30–60k (by plant volume/complexity).
- **The Xero flywheel:** we onboard accredited verifiers + customs brokers **for free**; they bring
  their whole client ecosystems through our software.

## Slide 13 — Revenue model

| Scenario | ARR |
|---|---|
| Conservative (wedge) | **€0.3–0.45M** (2028) → **€1.2–1.8M** |
| Enterprise capture | **€1.5–6M** |
| Blue-sky (textiles + channel + geography) | **£10M+** |

Right-sized: a capital-efficient seed-scale SaaS. *(Revenue in €; the raise is £ — see next.)*

## Slide 14 — The ask (right-sized, UK SEIS/EIS)

- **£250k SEIS** — core product hardening (MVP to sellable).
- **£0.75–1.0M EIS** — market acquisition (30+ customers, steel DPP, security).
- **Series A deferred** — re-priced on traction (≥£1M ARR, >100 customers).

| Q4 2026 | H1 2027 | 2027–28 | 2028–29 |
|---|---|---|---|
| M1 done | CBAM engine live · first revenue | metals GTM · registry-live | textiles · DPP |

## Slide 15 — Roadmap

- **M1** (~Oct 2026) — overlap map + decisions *(done)*.
- **M2** (~early 2027) — CBAM engine sellable, first revenue.
- **M3** (~Q1 2027) — sell-twice proof (CBAM → DPP).
- **P2** (2027–28) — steel/aluminium GTM, registry-live.
- **P3** (2027–29) — textiles; **P4** (2029+) — scale + downstream.

## Slide 16 — The ask, in one line

*Invest to build the supplier-side compliance wedge: the friction is the product, the verification
bottleneck is the window — and the regulatory clock is already running.*
