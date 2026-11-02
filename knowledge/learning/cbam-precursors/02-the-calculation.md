# Module 2 — The Calculation

## 2.1 The formula
For a **complex good**:

```
Total embedded emissions (tCO₂e)
  = direct emissions of the installation
  + indirect emissions (where applicable)
  + EE_inpMat

EE_inpMat = Σ (Mᵢ × SEEᵢ)
```
- `Mᵢ` = **mass of precursor i consumed** to produce the output (tonnes).
- `SEEᵢ` = precursor i's **specific embedded emissions** (tCO₂e per tonne).
- **Fact** — Annex IV; `../../research/cbam-data-catalogue.md` D1–D3.

Then:
```
SEE_good = Total embedded emissions / tonnes of good produced   (tCO₂e/t)
```

## 2.2 The two traps: consumption vs output, and yield
`Mᵢ` is what you **consume**, not what you **sell**. If 1,000 t of finished coil needs 1,050 t of
HRC (95.2% yield), then `Mᵢ = 1,050`, and you divide the total by **1,000** (output). Using
1,000 for both is the most common arithmetic error.

## 2.3 Direct / indirect / precursor — keep them separate
| Bucket | What | Note |
|---|---|---|
| **Direct** | Fuel combustion + process emissions at your installation | Always in scope |
| **Indirect** | Electricity/heat consumed | Included only where the rules say so — **verify** (§1.6) |
| **Precursor** | `Σ(Mᵢ × SEEᵢ)` for CBAM-covered inputs | Always in scope for complex goods |

Keep the three visible in your working. A verifier will ask for each separately.

## 2.4 Recursion — do not double-count the chain
If HRC is itself complex (made from crude steel), its `SEE_HRC` **already includes** the crude
steel's emissions. At the CRC stage you add `M_HRC × SEE_HRC` — you do **not** also add crude
steel again. The recursion is handled *inside* each precursor's SEE. **Fact/logic.**

## 2.5 Worked example — cold-rolled coil (illustrative)

**Given**
- Output: **1,000 t** cold-rolled coil (CN 7209).
- Precursor: **1,050 t** hot-rolled coil (CN 7208) — 95.2% yield.
- Precursor SEE (verified actual): **1.90 tCO₂e/t**.
- Direct processing emissions (pickling, rolling, annealing, reheat): **70 tCO₂e**.
- Indirect: excluded for steel (per §1.6 — **verify**).

**Step 1 — precursor contribution**
```
EE_inpMat = 1,050 × 1.90 = 1,995 tCO₂e
```

**Step 2 — total**
```
Total = 1,995 + 70 = 2,065 tCO₂e
```

**Step 3 — SEE**
```
SEE = 2,065 / 1,000 = 2.065 tCO₂e/t
```

**Step 4 — compare with default**
If the HRC default is **2.20** instead of the verified **1.90**:
```
EE_inpMat = 1,050 × 2.20 = 2,310
Total      = 2,310 + 70   = 2,380
SEE        = 2.38 tCO₂e/t
```
Difference: **0.315 tCO₂e/t** → at €75.36/t ≈ **€23.7/t** → **~€23,700 per 1,000 t**.
*All numbers illustrative.*

**Lesson:** the precursor choice (verified vs default) moves the number ~6× more than the
plant's own direct emissions (70 t). That is the commercial argument for upstream data.

## 2.6 Multi-precursor example (illustrative)
A casting plant consumes several covered inputs:

| Precursor | Mᵢ (t) | SEEᵢ (tCO₂e/t) | Source | Contribution (tCO₂e) |
|---|---|---|---|---|
| Crude steel | 1,100 | 1.95 | verified | 2,145.0 |
| Pig iron | 80 | 2.10 | default | 168.0 |
| **EE_inpMat** | | | | **2,313.0** |
| Direct processing | — | — | — | 90.0 |
| **Total** | | | | **2,403.0** |
| **SEE (per 1,000 t output)** | | | | **2.403 tCO₂e/t** |

Note the **mix of verified and default** per precursor — that is normal. Flag each line.

## 2.7 Allocation (when one process makes several goods)
If the installation produces multiple CN codes, you need an allocation rule (mass is the usual
CBAM default for many cases, with per-product treatment where required). **Do not invent a
rule** — check Annex IV / IR 2025/2547 and document it. Allocation choices are a classic verifier
red flag. **`[verify exact rule]`**

## 2.8 Actual vs default at every node
Each precursor line is independently:
- **actual** — verified SEE for the right period, or
- **default** — EC default for that CN code/country (with the applicable mark-up).
A single report can mix them. The declaration flags actual vs default **per line**. **Fact.**

## 2.9 A calculation worksheet you can reuse
| Field | Value | Source |
|---|---|---|
| Output good + CN code | | invoice/production log |
| Output tonnes | | production log |
| Precursor 1 + CN code | | purchase records |
| M₁ (consumption) | | weighbridge/ERP |
| SEE₁ (actual/default) | | verified report / EC default |
| M₁ × SEE₁ | | calc |
| … repeat per precursor | | |
| EE_inpMat | | sum |
| Direct emissions | | meters/calc |
| Indirect (if applicable) | | electricity data |
| Total | | sum |
| SEE | total ÷ output | calc |
| Determination per line | actual/default | flag |

## Outcome check
1. Write the two formulas (total and SEE).
2. Why is `Mᵢ` consumption, not output?
3. In the worked example, what happens to SEE if yield drops from 95.2% to 90%?
4. Explain recursion in one sentence.
5. Why must allocation be documented?
