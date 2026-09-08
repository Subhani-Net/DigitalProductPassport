# CBAM Master Data-Request Catalogue (Definitive Model)

What to collect from manufacturers/suppliers (installations) to build a CBAM submission —
targeting the **definitive phase** (annual declaration, registered operators, verified
actuals). Purpose: (1) mill-facing data-request checklist, (2) seed for the C2 canonical
schema, (3) compliance-matrix rows. Rows are mapped to legal source; per-mill mapping is
done by the domain consultant + the mill itself.

Sources: Reg (EU) 2023/956 Annex IV; IR (EU) 2023/1773 (method/reporting) + Communication
Template V2.1; IR 2025/2547 (definitive calc), IR 2025/2546 (verification); QReport XSD
(transitional archive). Cross-ref: `research/cbam-input-sources.md` (where the data lives).

Stage keys (MVP onboarding): S0 paper/manual · S1 files (CSV/XLSX/PDF) · S2 dynamic (ERP/
MES/LIMS/utility) · S3 real-time (OPC UA/historian/CEMS).

## A. Installation & operator identity (one record per installation)

| # | Data item | Legal anchor | Likely source / format | Stage | Provided by |
|---|-----------|--------------|------------------------|-------|-------------|
| A1 | Operator company name, address, identifiers | IR 1773 Art 3(2); O3CI onboarding | registration docs | S0 | Operator |
| A2 | Country of origin | IR 1773 Art 3(2) | declared | S0 | Operator |
| A3 | Installation UN/LOCODE + coordinates of main emission source | IR 1773 Art 3(2) | registry/O3CI | S0 | Operator |
| A4 | Production route (Annex II §3) + route-qualifying parameters | IR 1773 Art 3(2); IR 2547 | declared per route | S0 | Operator + consultant |
| A5 | Steel-mill identification (per raw-material batch, steel) | IR 1773 Art 3(2) | MTC/EN 10204 3.1 | S1 | Mill / upstream |
| A6 | CN/HS code(s) of goods | QReport XSD CommodityCode | commercial invoices | S0 | Importer |
| A7 | Registered-operator status + verifier registration | definitive O3CI flow | EC registry | S0 | Operator/verifier |

## B. Direct emissions — source streams (fuels & process)

| # | Data item | Legal anchor | Likely source / format | Stage | Notes |
|---|-----------|--------------|------------------------|-------|-------|
| B1 | Source-stream inventory (fuels, materials, gases) per installation | IR 1773 Annex III (source-stream classes) | declared inventory | S0 | consultant validates classes |
| B2 | Fuel/feedstock quantities consumed (t, TJ, Nm³) per stream | Annex III: activity data ADi | weighbridge tickets, ERP purchases, meters | S1/S2 | mass via weighbridge, volume via meters |
| B3 | NCV per fuel batch (laboratory) | Annex III: calculation factor | CoA / LIMS | S1/S2 | ISO 17025 lab |
| B4 | Emission factor per fuel (tCO2/TJ) + oxidation/conversion factor | Annex III | lab / standard values | S1 | lab or standard |
| B5 | Carbon content / biomass fraction | Annex III | CoA / LIMS | S1 | when mass-balance method |
| B6 | Process-emission inputs (e.g. limestone → CaCO3, electrodes, anodes) | Annex III Method A/B | purchase + chemistry data | S1 | standard factors allowed |
| B7 | Mass-balance streams (input/output, negative outputs) | Annex III mass-balance method | production records, MES | S1/S2 | outputs negative AD |
| B8 | Transfers in/out of gases (BF gas, COG inherent CO2) | Annex III transfer rules | meter/plant data | S2/S3 | destination attribution |

## C. Indirect emissions — electricity

| # | Data item | Legal anchor | Likely source / format | Stage | Notes |
|---|-----------|--------------|------------------------|-------|-------|
| C1 | Electricity consumption (MWh) per period/installation | IR 1773 Art 3(3); Annex IV | utility bills, smart meters | S1/S3 | MID meters |
| C2 | MWh per tonne of goods | Art 3(3); Template C_InstEnergy | calc from C1 + production | S1 | |
| C3 | Electricity emission factor (grid / country) | Annex IV | EEA grid factor | S0 | location-based |
| C4 | PPA + Guarantees of Origin evidence (for actual/contractual factor) | Annex IV §5; RED II Art 19 | PPA/GO docs (AIB EECS) | S1 | only if claiming low factor |
| C5 | Own generation / CHP heat-electricity allocation | Template C_InstEnergy; IR 1773 Eq.47 | plant energy logs | S2 | export heat/electricity rules |
| C6 | Grid/self-consumption split | Annex IV boundary | meters | S3 | |

## D. Precursors (complex goods) — pass-through

| # | Data item | Legal anchor | Likely source / format | Stage | Notes |
|---|-----------|--------------|------------------------|-------|-------|
| D1 | Precursor list (CBAM-covered inputs consumed) | Annex IV EEInpMat = Σ Mi×SEEi | purchase records, MES | S1/S2 | only CBAM-covered precursors |
| D2 | Mass of each precursor (Mi) | Annex IV | weighbridge, ERP | S1/S2 | |
| D3 | SEE of each precursor (SEEi) — from supplier verified data or default | Annex IV; IR 2621 defaults | supplier communication / EC defaults | S1 | default allowed when no verified data |
| D4 | Steel batch mill ID cross-reference (Ch. 73 downstream) | IR 1773 Art 3(2) | MTC | S1 | |

## E. Production & allocation

| # | Data item | Legal anchor | Likely source / format | Stage | Notes |
|---|-----------|--------------|------------------------|-------|-------|
| E1 | Production volumes per product/good (activity level ALg) | Annex IV ALg | production logs, MES | S1/S2 | per CN line |
| E2 | Process allocation (per-process emissions → products) | Template D_Processes | MES/plant records | S2 | co-product allocation |
| E3 | Product quality/chemistry (grade) per heat/batch | EN 10204 MTC / LIMS | PDF/CSV | S1 | links A5/E1 |
| E4 | Output/mass of product + by-products | mass balance | weighbridge | S1 | by-products affect allocation |

## F. Aluminium-specific (PFC + energy intensity)

| # | Data item | Legal anchor | Likely source / format | Stage | Notes |
|---|-----------|--------------|------------------------|-------|-------|
| F1 | Smelting electricity (MWh/t Al, 13–15 typical) | Annex IV indirect | potline meters | S1/S3 | dominant driver |
| F2 | Anode-effect count/frequency/duration | IAI PFC method (slope) | potline control system | S2/S3 | CF4/C2F6 |
| F3 | Cell technology class (CWPB/PFPB/SWPB/HSS/VSS) | IAI PFC factors | plant master data | S0 | selects PFC factor |
| F4 | Alumina/anode/additives inputs + bath chemistry | Annex III process | LIMS/purchase | S1 | |
| F5 | PFC GWP set used (AR6: 7380/12400) | GWP convention | declared | S0 | |

## G. Verification & evidence (definitive)

| # | Data item | Legal anchor | Likely source / format | Stage | Notes |
|---|-----------|--------------|------------------------|-------|-------|
| G1 | Monitoring methodology documentation | IR 2025/2546 | operator file | S1 | calc vs measurement method |
| G2 | Underlying evidence (source records, invoices, meter logs) | IR 2025/2546 (documentation review) | ERP/PDF/meter archives | S1/S2 | verifier-ready dossiers |
| G3 | Accredited-verifier engagement + verification report | Art. 8; IR 2025/2546 | verification report (PDF) | S1 | stamp is third-party (locked) |
| G4 | Actual-vs-default justification (where defaults used) | IR 2621; IR 2025/2547 | declared | S0 | defaults costlier by design |

## MVP default path

- **Day 1 (S0):** A1–A6, B1/B2 (from weighbridge + purchase + fuel records), C1/C3,
  D1/D3 (defaults), E1 — enough for a **defaults-based baseline** and to show the
  actual-vs-default saving.
- **Pilot (S1):** + B3–B5 (CoA/lab), C4 (PPA/GO), D3 (verified supplier SEE), G1–G3
  (evidence + verifier) — enables **verified actuals**.
- **Scale (S2/S3):** ERP/MES/LIMS automation, then real-time meters/historian/CEMS.

## Notes & open items

- Row contents are the *regulatory* requirement set; per-route detail (which B-streams a
  BOF vs EAF vs DRI plant actually reports) is validated by the domain consultant (post-C4).
- Where a row can legally be satisfied by EC default values, that is flagged (D3, G4) —
  the core wedge is converting defaults → verified actuals.
- QReport XSD (transitional) archived; definitive target = operator/verifier data model per
  IR 2025/2547 + O3CI fields (source list: EC CBAM file share + `research/sources.md`).
