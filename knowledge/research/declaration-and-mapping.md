# Importer Declaration & Installation Mapping (the many-to-many)

How goods, installations and importers connect — and why the importer must track quantity **per
installation** for actual values. Companion to `data-layer.md` and `submission-cadence-and-risk.md`.

## The answer up front
- **Installations** upload their data once (per installation, per year) and share it via EORI.
- **Importers** importing the **same CN code from different installations** must apply each
  **installation's own SEE** — so they **do** need to know how much came from each installation
  (for **actual values**).
- **Defaults** do **not** need installation mapping: a default value is per **CN code + country**,
  not per installation. (So defaults hide installation differences; actuals expose them.)
- **Multiple importers from one installation** is fine: the installation data is uploaded once and
  reused by every linked declarant with their own quantities.

## The three levels

| Level | Key | Example |
|---|---|---|
| **1. Installation data** | (installation, CN code) → **SEE** | Inst A · 7214 · 0.374538 tCO₂/t |
| **2. Import records** | (importer, installation, CN code) → **quantity** | Importer X · Inst A · 7214 · 1,200 t |
| **3. Declaration** | (importer, CN code) → total quantity + total embedded | X · 7214 · 2,000 t → 2,081 tCO₂ |

The declaration is **aggregated per CN code**, but the underlying calculation is
**per (installation, CN code, quantity)**.

## Worked example
Two installations produce **7214**, with very different SEE:
- **Inst A** (EAF): SEE **0.374538** tCO₂/t
- **Inst B** (BF-BOF): SEE **2.04** tCO₂/t

**Importer X** imports 7214: 1,200 t from A + 800 t from B
```
embedded = 1,200 × 0.374538 + 800 × 2.04
         = 449.446 + 1,632.000
         = 2,081.446 tCO₂   (declared line: CN 7214, 2,000 t, 2,081.446 tCO₂)
```
**Importer Y** also buys from A: 500 t
```
embedded = 500 × 0.374538 = 187.269 tCO₂   (same installation SEE, different quantity)
```
**If X used defaults for everything** (7214, India, default 2.10):
```
2,000 × 2.10 = 4,200 tCO₂   →  actuals save 2,118.55 tCO₂
```

## Rules the system must implement
1. **Link** each import line to an **installation** (installation ID from the customs/supplier record).
2. **Apply** that installation's **SEE** to the line's quantity (actual) — or the **CN+country
   default** (no installation).
3. **Flag determination per line** (actual vs default).
4. **Aggregate per CN code** for the declaration: total quantity + total embedded.
5. **Certificate obligation** = total embedded × CBAM factor − foreign carbon-price deduction.
6. **Reuse** the same installation SEE across all importers (uploaded once).

## Implementation implication (gap to close)
Our canonical model so far is **installation-centric** (`installation` + `goods[]`). We also need
an **importer-side declaration model**:

```
declaration {
  declarant { eori, name }, year,
  lines[] {
    cnCode, installationId, netMassTonnes,
    seeTCO2PerTonne, determination,          // actual or default
    embeddedTCO2                              // quantity × SEE
  },
  totals { byCn: {...}, totalEmbeddedTCO2e }
}
```

This is the C6 (declaration/report) counterpart to C2 (installation model). Practised in
`../../product/demo/pilot-docket/practice-multi-product/` (single installation); extend it to two
installations + two importers as the next practice.

## Why it matters
- **Correctness:** averaging installations understates or overstates emissions — the declaration
  must respect each source's SEE.
- **Risk:** if the importer can't identify the installation for a consignment → it falls to the
  **punitive default**; hence installation mapping is a concrete cost lever.
- **Trust:** the same installation data serves everyone, so no conflicting numbers — one source of
  truth, many quantities.
