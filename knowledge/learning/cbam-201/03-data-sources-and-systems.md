# Module 3 — Data Sources & Systems

Where CBAM data actually lives, and how to collect it. Full detail:
`../../research/cbam-input-sources.md`.

## 3.1 The three data velocities

| Class | Examples | CBAM use |
|---|---|---|
| **Static** | Mill Test Certificates (EN 10204), Certificates of Analysis, weighbridge tickets, energy bills, PPA/GO certificates, verification reports, EC defaults | identity, factors, activity data, evidence |
| **Dynamic** | ERP (SAP OData/IDoc, Oracle, Dynamics, Tally), MES (ISA-95), LIMS, utility/MDMS, grid emission factors, benchmarks | bulk activity data, calculations |
| **Real-time** | PLC/DCS (OPC UA, Modbus), SCADA, historians (AVEVA PI), time-series (MQTT/Sparkplug), smart meters (DLMS-COSEM), CEMS, XRF/OES | high-resolution activity data, direct measurement |

**Fact/Claim** (`../../research/cbam-input-sources.md`).

## 3.2 What each system typically yields
- **ERP** — purchases, energy, production volumes, material master.
- **MES** — lot/batch production records, equipment states.
- **LIMS** — chemistry, NCV, carbon content (lab results).
- **Utility/MDMS/AMI** — interval electricity (kWh/MWh).
- **Weighbridge software** — net masses per vehicle.
- **DCS/historian/CEMS** — process tags, gas flows, stack concentrations. **Fact**.

## 3.3 Collection path — stage-gated (MVP)
| Stage | Inputs | Effort |
|---|---|---|
| **S0** paper/manual | logs, tickets, bills, route declaration | minimal |
| **S1** files | CSV/XLSX exports, MTC/CoA PDFs | export + upload |
| **S2** dynamic | ERP OData/IDoc, LIMS CSV, utility feeds | IT access |
| **S3** real-time | OPC UA/historian, smart meters, CEMS | OT access |

**Default MVP path = S0 → S1** (prove the engine), S2/S3 post-M2. **Fact**
(`../../research/cbam-input-sources.md` §6).

## 3.4 By plant area (what each process exposes)
- **Steel BF-BOF:** coke/coal/PCI rates, hot-metal chemistry, scrap weight, oxygen flow,
  converter gas recovery, reheat fuel, electricity/t.
- **Steel EAF:** scrap mix + chemistry, electricity (~440 kWh/t), electrodes, alloys.
- **Steel DRI:** gas/H₂ consumption, ore/pellets, %Fe.
- **Aluminium primary:** potline DC electricity, anode-effect data (→ PFCs), bath chemistry;
  **secondary:** scrap mix, remelt fuel. **Fact** (`../../research/cbam-input-sources.md` §5).

## 3.5 Practical collection principles
1. **Map to the canonical model** — each source maps to an activity-data/factor field.
2. **Evidence-first** — every number needs a traceable source artifact (invoice, meter log, CoA).
3. **Unit discipline** — normalize to the legal units (TJ, tonnes, Nm³, MWh, tCO₂e/t) at ingest.
4. **Version & audit** — keep raw + derived, timestamped.

## Outcome check
1. Give one static, one dynamic, and one real-time CBAM data source.
2. Which system holds NCV/chemistry, and which holds interval electricity?
3. Why start with S0/S1 rather than S2/S3?
