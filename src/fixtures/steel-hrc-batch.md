# Fabricated steel supplier dataset (fixture) — placeholder

Provisional fixture for the P1 pipeline (S1 spike and C2+ data contract). Fictional data to
prove the CBAM → DPP sell-twice engine. Schema is provisional and finalised in C2 against
TracePass iron & steel fields + CBAM calculation inputs.

Status: **placeholder — to be shaped in C2 (data contract).**

## Narrative

A fictional European steel importer ("REO") purchases hot-rolled coil from a fictional
off-EU mill. Chain-of-custody data the REO must collect:

- Raw materials (iron ore), energy (met coal, electricity), fluxes
- Intermediate: crude steel → slabs → hot-rolled coil (HRC), batch-level

## Provisional figures (single HRC batch, BOF route)

| Stage | Input | Value | Unit |
|-------|-------|-------|------|
| Raw material | Iron ore | 1.6 | t/t crude steel |
| Energy | Metallurgical coal | 0.55 | t/t crude steel |
| Energy | Electricity | 250 | kWh/t |
| Process | Crude steel | 1000 | t |
| Product | Hot-rolled coil | 980 | t (98% yield) |
| Emissions | Direct (scope 1) | 1.85 | tCO2e/t crude |
| Emissions | Indirect (scope 2) | 0.09 | tCO2e/t crude |

## Open items (decide in C2)

- Granularity level for the registry entry (MODEL vs BATCH vs ITEM).
- CBAM actual-values route vs default-value fallback.
- Identifiers: UPI syntax (GS1 SGTIN vs urn), reoId (LEI/EORI), commodityCode (HS/TARIC).

> Placeholder note — real machine-readable fixture lands with the C2 data contract.
> See `compliance-matrix.md` and `../product-roadmap.md` (P1).
