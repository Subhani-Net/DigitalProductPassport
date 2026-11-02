# Module 1 — What a Precursor Is (and why it dominates)

## 1.1 Definition
A **precursor** is an input material into a production process that is **itself an Annex I
(CBAM) good**. **Fact** — IR 2025/2547 Art. 1(7); see `../cbambok.md`.

Two kinds of goods:
- **Simple good** — produced from inputs that are *not* CBAM goods (e.g. pig iron from ore).
- **Complex good** — produced from one or more CBAM **precursors** (e.g. cold-rolled coil made
  from hot-rolled coil; a casting made from crude steel).

> The test is not "does it have inputs?" — every product does. The test is: **is an input itself
> a CBAM good?** Only then does it become a precursor for CBAM.

## 1.2 Scope follows the chain
```
iron ore → pig iron/DRI → crude steel → hot-rolled coil → cold-rolled coil → galvanised strip
           (CBAM)         (CBAM)        (CBAM)            (CBAM)              (CBAM)
```
Each stage carries the embedded emissions of the stage before it. A galvanised strip's SEE is
mostly the coil; the coil's SEE is mostly the crude steel; the crude steel's SEE is mostly pig
iron/DRI. **Fact/logic** (Annex IV).

## 1.3 Why this matters commercially
- The precursor is usually the **dominant term** in a complex good's SEE. In the Module 2
  example the precursor is ~97% of the total.
- So the biggest lever is **upstream verified data**, not squeezing the final plant.
- A verified upstream SEE (e.g. 1.90 instead of a 2.20 default) can move the final number by
  ~0.3 tCO₂e/t — at €75.36/t that is ~€23/t, i.e. **~€23,000 per 1,000 t** *[illustrative]*.
- This is why "we only calculate our own plant" is not a CBAM strategy for a complex good.

## 1.4 What counts — and what does not
| Input | Is it a CBAM precursor? |
|---|---|
| Pig iron, DRI, crude steel, HRC, CRC, billet, slab | **Yes** (Annex I iron/steel) |
| Aluminium ingot, billet, unwrought aluminium | **Yes** (Annex I aluminium) |
| Iron ore, limestone, coal, natural gas | **No** — not Annex I goods (their emissions come via the process, not as precursor SEE) |
| Ferro-alloys (most 7202 subheadings, per Annex I exclusions) | **Usually no** — check the exclusion list |
| Electricity | Not a "precursor" — it is the **indirect** emissions route (and currently excluded for steel/aluminium — §1.6) |
| Packaging, lubricants, office supplies | No |

> Always check the exact **CN code** against Annex I. Scope is code-based, not description-based.
> **Fact.**

## 1.5 The recursion
If a precursor is itself complex, its SEE already includes **its** precursors. So you do not
"add the whole chain" again at the final stage — you add the precursor's **SEE** (which already
contains the chain). See Module 2 (§2.4).

## 1.6 A discrepancy you must resolve before quoting a customer
Our own materials disagree on **indirect emissions**:
- The **EEPC India CBAM portal** (fetched 2026-11-01) says that for **iron & steel and
  aluminium**, only **direct emissions** are counted initially (Annex II), with indirect
  excluded for now.
- `../../research/tracepass-steel-fields-table.md` (field 48) describes "direct + precursor for steel;
  **direct + indirect + precursor for aluminium**."

**These conflict.** Do not rely on either in a customer deliverable until you have checked
**Annex II of Reg. (EU) 2023/956** and **IR 2025/2547** clause by clause. **`[verify]`**

This is a good habit for the whole course: **the instrument wins over any summary, including
ours.**

## 1.7 Common misconceptions
| Misconception | Reality |
|---|---|
| "All our inputs are precursors." | Only **CBAM-covered** (Annex I) inputs. |
| "We can use the supplier's EPD number." | An EPD is a different boundary; CBAM needs a **verified SEE for the right period** (or a default). |
| "Scope 3 = precursor emissions." | CBAM counts **only** covered precursor emissions — a narrow slice of Scope 3. |
| "Precursor emissions are added on top of the same emissions again." | No — you add `Mᵢ × SEEᵢ`, where `SEEᵢ` is the precursor's *specific* embedded emissions. |
| "If we don't have data, we can estimate." | Only **actual (verified)** or **default** — with the default mark-up. No home-made estimates. |

## Outcome check
1. What makes an input a *precursor* rather than just a material?
2. Name three steel precursors and one aluminium precursor.
3. Why is the upstream supplier's verified data the biggest commercial lever?
4. What is the indirect-emissions discrepancy, and what do you do about it?
