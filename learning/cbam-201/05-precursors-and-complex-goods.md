# Module 5 — Precursors & Complex Goods

## 5.1 The precursor rule
A **precursor** is any input material into a production process that is itself an **Annex I
(CBAM) good**. **Fact** (IR 2025/2547 Art. 1(7)). For **complex goods**, embedded emissions
include the **embedded emissions of the precursors**:

```
EE_inpMat = Σ (M_i × SEE_i)
```
where `M_i` = mass of precursor i consumed and `SEE_i` = its specific embedded emissions.
**Fact** (Annex IV).

## 5.2 Why this widens everything
- A "finished" product (e.g. a steel casting) carries the SEE of its **crude steel**, which
  carries the SEE of **pig iron/DRI**, etc. Scope follows the chain. **Fact**.
- An operator therefore needs **either** a verified `SEE_i` from the upstream supplier **or**
  a **default** value for that precursor. **Fact** (`../../research/cbam-data-catalogue.md` D3).

## 5.3 Where precursor data comes from
- Upstream supplier's verified data (communication / registry), or
- EC **default values** for that precursor (IR 2025/2621). **Fact**.
- Steel-specific: batch **mill identification number** links downstream goods to the upstream
  mill (IR 2023/1773 Art. 3(2)). **Fact**.

## 5.4 Worked example A — steel, complex good (illustrative)
Downstream product: galvanised steel strip.

| Input | Mass (t) | SEE (tCO₂e/t) | Contribution |
|---|---|---|---|
| Crude steel precursor | 1,020 | 1.94 | 1,978.8 |
| Direct processing (reheat, coating) | — | — | 60.0 |
| Indirect (electricity) | — | — | 15.0 |
| **Total embedded (per functional unit of 1,000 t strip)** | | | **2,053.8** |

`SEE_strip = 2,053.8 / 1,000 = **2.05 tCO₂e/t**` (illustrative). Note the **precursor dominates**
— so upstream verified data is the biggest lever. **(Illustrative)**

## 5.5 Worked example B — primary aluminium (illustrative)
- Electricity ~**14 MWh/t** × grid EF (say **0.3 tCO₂e/MWh**) ≈ **4.2 tCO₂e/t** (indirect).
- **PFC** from anode effects (CF₄/C₂F₆, GWP AR6 ≈ 7380/12400) adds a route-dependent term.
- If actual data is unavailable, defaults apply — often much higher. **(Illustrative)**

Lesson: for aluminium, **electricity (and PFC)** dominate — so PPAs/GOs and anode-effect
control are the main SEE levers. **Fact/logic**.

## 5.6 Practical checklist
- [ ] List all CBAM-covered precursor inputs.
- [ ] For each: mass (M_i) + a **verified** SEE_i or a documented default.
- [ ] Keep the upstream evidence (verification report / supplier data).
- [ ] Declare the production route + qualifying parameters.

## Outcome check
1. Define precursor and write the EE_inpMat formula.
2. For the steel example, which term dominates and why does that matter commercially?
3. Name the two main SEE levers for primary aluminium.
