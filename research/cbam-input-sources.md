# CBAM Input Sources — Static / Dynamic / Real-time

What a CBAM platform must READ from mills & producers, and in which formats/devices.
Purpose: (a) design the C3 ingestion layer, (b) define the MVP collaboration set with early
customer mills. Fact-based, sources inline; "Claim" = vendor/secondary statements.

## 1. What the CBAM math needs (the canonical input categories)

From Reg (EU) 2023/956 Annex IV + Implementing Reg (EU) 2023/1773 Annex III:

- **Activity data** = amounts of fuels/materials consumed or produced (TJ, tonnes, Nm³
  for gases). Per source stream: ADi = fuel quantity × NCVi.
- **Calculation factors:** net calorific value (NCV), emission factor (tCO2/TJ), oxidation/
  conversion factor, carbon content, biomass fraction — from ISO/IEC 17025-accredited labs.
- **Direct emissions:** calculation-based (activity data × factors) OR measurement-based
  (CEMS: flue-gas GHG concentration × flow).
- **Indirect emissions:** electricity MWh per tonne + emission factor of consumed
  electricity (grid / PPA / GOs).
- **Precursors (complex goods):** mass of each CBAM-covered input × its specific embedded
  emissions (SEEi).
- **Installation metadata (IR 2023/1773 Art. 3(2)):** country of origin, UN/LOCODE of
  installation, company name/address, geographical coordinates of main emission source,
  production route + route-qualifying parameters, and for steel the **steel mill
  identification number** of the batch.
- **Communication Template V2.1 sheets:** A_InstData, B_EmInst (source streams, process
  emissions, mass-balance corrections, PFC), C_InstEnergy (heat/electricity balance),
  D_Processes, E_SEE, F_CHP, Summary_Products.
- **Quarterly report XSD (QReport_ver23.00):** declarant, importer, commodity (HS/CN),
  origin country, imported quantity (net mass), DirectEmissions (actual vs default,
  tCO2e/t), IndirectEmissions (MWh/t + factor), installation operator ID + installation
  ID/name/coords, production-method qualifying params, supporting documents (base64).

> Source: eur-lex.europa.eu/eli/reg/2023/956/oj ; eur-lex.europa.eu/eli/reg_impl/2023/1773/oj ; cbam.lkslaw.com (XSD explorer, communication template guide)

## 2. STATIC sources (documents & metrology)

| Source | What it carries | Format | CBAM use |
|---|---|---|---|
| Mill Test Certificate EN 10204 (3.1/3.2) | grade, heat no., chemical + mechanical results | PDF (often digitally signed; PAdES/PDF-A) | product/heat identity → batch mapping |
| Certificate of Analysis (CoA) | composition, methods, batch/sample, signature | PDF | fuel/raw-material properties (NCV, carbon) |
| Weighbridge tickets | gross/tare/net per vehicle | printed / PDF / ticketing DB | mass activity data (scrap, product, fuels) |
| Electricity/gas bills + utility interval data | kWh/MWh, periods, tariffs | PDF / EDI EDIFACT / AMI feed | indirect emissions MWh/t |
| PPA + Guarantees of Origin (AIB EECS registry) | 1 GO/MWh, source attributes | e-certificates | electricity emission factor claim |
| ISO 50001 energy audit / EnMS data | metered energy per use | CSV/SQL exports | energy balances, cross-checks |
| GHG report (ISO 14064-1) / EPD (EN 15804) / PCF (ISO 14067) | verified footprints | PDF; machine-readable EN ISO 22057 / openEPD API | cross-reference & upstream data |
| Customs/invoice docs | EORI, HS/CN codes, quantities, origin | UBL / Peppol (EN 16931) / EDIFACT / GST e-invoice JSON (India) / ICEGATE | importer-side mapping |
| ISCC EU/PLUS certificates | recycled/renewable material criteria | PDF + public registry | recycled-content evidence |
| CBAM verification report (per installation) | verifier opinion | PDF | proof of verified actuals |
| EC definitive default values | country/CN defaults | XLSX (EC publication) | default-vs-actual comparison |

## 3. DYNAMIC sources (systems & databases)

| System | Typical data | Integration path |
|---|---|---|
| ERP — SAP S/4HANA | materials, purchases, energy, production | IDoc/RFC/BAPI, OData/REST |
| ERP — Oracle JD Edwards / Dynamics 365 | same | web services / cloud APIs |
| ERP — Tally (India SMEs) | purchases, GST data | limited programmatic; exports |
| MES (ISA-95 L3) | lot/batch production records, equipment states | DB/CSV, B2MML, OPC UA, MQTT |
| LIMS | sample results (chemistry, NCV, carbon) | CSV/DB exports; ISO 17025 audits |
| Weighbridge ticketing software | per-vehicle net weights | PC DB export / API |
| Utility/AMI/MDMS platforms | interval energy data | flat files, DLMS-COSEM (IEC 62056), APIs |
| EEA grid emission factors | national electricity GHG intensity | published dataset |
| worldsteel / IAI benchmark data | intensity benchmarks | published datasets |

## 4. REAL-TIME sources (devices, protocols, plant networks)

| Device/system | Signal | Protocol/format | CBAM use |
|---|---|---|---|
| PLC / DCS (level 1–2) | process tags | OPC UA / OPC DA / Modbus / Profinet / EtherNet/IP / HART (4–20 mA, NAMUR NE43) | flows, temps, pressures → source-stream monitoring |
| SCADA | tag database | legacy: Modbus RTU, Profibus, IEC 60870-5, DNP3 | aggregation for historian |
| Historian (AVEVA PI, Honeywell PHD, Wonderware) | instrument time-series | OPC HDA, SQL, REST | high-resolution activity data |
| Time-series DB / streaming (Influx, Timescale, Kafka) | telemetry | MQTT/Sparkplug, SQL, REST | modern plants |
| Smart meters (MID) | kWh intervals | DLMS-COSEM / IEC 62056, ANSI C12 | electricity activity data |
| Gas flow meters | Nm³ flows | 4–20 mA/HART into PLC/DCS | fuel gas streams (NG, BF gas, COG) |
| CEMS (stack) | SO2/NOx/CO/CO2/O2, flow | analyzer → DAHS, 1-min → hourly avg | measurement-based direct emissions (ETS IR 2018/2066 style) |
| XRF / OES spark analyzers | elemental composition | instrument output files | scrap/alloy/heat chemistry |
| Level/tank sensors | fuel storage levels | 4–20 mA/HART | fuel stock reconciliation |
| Weighbridges (static/dynamic rail, OIML R106 cl.0.2) | in/out masses | ticketing systems | mass balance |

## 5. By plant area (what each process exposes)

**Steel — BF-BOF:** coke/coal/PCI rates, hot metal chemistry (C, Si), scrap weights, oxygen
flows, converter gas recovery volumes, slag chemistry, lime/dolomite, reheat furnace fuel,
electricity per tonne; iron + carbon balances (IR 2023/1773 Annex III mass-balance method).
**Steel — EAF:** scrap mix + chemistry, electricity ~440 kWh/t (indirect driver), electrodes
(graphite), oxygen lancing, oxy-fuel, alloys, slag formers (CaO/MgO).
**Steel — DRI:** NG or H2 consumption, iron ore pellets, product %Fe (90–94%).
**Aluminium — primary:** potline DC electricity 13–15 MWh/t Al (dominant), **anode effects
(count/frequency/duration → CF4/C2F6 PFCs via slope method**, GWP AR6 7380/12400), bath
chemistry, casting fuel; cell technologies CWPB/PFPB/SWPB/HSS/VSS for PFC factors.
**Aluminium — secondary:** scrap mix, remelt fuel, electricity (direct only per CBAM rules).

## 6. MVP collaboration set (stage-gated inputs from early mills)

| Stage | Inputs | Effort for the mill | We deliver |
|---|---|---|---|
| S0 — paper/manual (day 1) | production logs, weighbridge tickets, energy bills, fuel purchase records, route declaration | minimal — send documents | baseline actual-vs-default gap; C5 on defaults first |
| S1 — files | XLSX/CSV exports (ERP/MES/LIMS), MTC/CoA PDFs | export + upload | ingestion adapters: CSV/XLSX/PDF |
| S2 — dynamic | ERP OData/IDoc (SAP) or Tally exports; LIMS CSV; utility feeds | IT access | API adapters, unit normalization |
| S3 — real-time | OPC UA / historian reads, smart meters, CEMS where present | OT access | streaming adapters (optional, post-MVP) |

Default path for the MVP: **S0 → S1** (files) is enough to prove the engine; S2/S3 are
post-M2 scaling. Every stage maps to C3 ingestion adapters and feeds the canonical model
(C2) — the consultant (engaged post-C4) details the per-process schema for S1/S2.

## 7. Key sources

- Reg (EU) 2023/956 (Annex IV); IR (EU) 2023/1773 (transitional reporting/monitoring)
- Definitive-phase acts: IR 2025/2547 (calculation), IR 2025/2546 (verification), Del. 2025/2551 (accreditation), IR 2024/3210 (registry), IR 2025/2621 (default values)
- EC CBAM file share: QReport XSD (+stypes.xsd), XLS structure, Communication Template V2.1
- EC sector guidance: iron & steel (5d), aluminium (5e) installations
- EEA grid emission-intensity dataset; worldsteel sustainability indicators; IAI LCI + PFC statistics
- Indicative transitional defaults (secondary source, verify vs EC): steel BF 2.10, steel EAF 0.45, primary Al 16.50 tCO2/t
