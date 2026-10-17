# TracePass — Iron, Steel & Aluminium Field Inventory (L4)

Source: `reference/tracepass-dpp-schemas/templates/steel.json` (TracePass, Apache-2.0),
version 2. Category label: **"Iron, Steel & Aluminium"** (steel and aluminium share one
template). Instrument: **ESPR (EU) 2024/1781**; effectiveDate 2027-01-01; mandatoryDate 2028-01-01.

**Counts (v2):** 84 fields · **29 required** · 16 anticipated · 13 categories.
(Note: the library now reports 1,004 fields / 13 categories overall — supersedes the earlier
"913 / 12" figure in `tools.md`.)

**Important:** in this dataset a field is required when `validation.required == true` (the flag
is nested under `validation`, not top-level). Anticipated fields carry `validation.anticipated`
+ a CELEX note.

## The 29 required fields

| # | key | category | dataType | unit |
|---|-----|----------|----------|------|
| 1 | batchLotNumber | product_identification | string | |
| 2 | productType | product_identification | enum | |
| 3 | productName | product_identification | string | |
| 4 | cnCode | product_identification | string | |
| 5 | steelGradeDesignation | product_identification | object | |
| 6 | manufacturerName | manufacturer_origin | string | |
| 7 | manufacturerAddress | manufacturer_origin | string | |
| 8 | facilityId | manufacturer_origin | string | |
| 9 | chemicalComposition | material_composition | array | weight_% |
| 10 | yieldStrengthMpa | mechanical_properties | number | MPa |
| 11 | tensileStrengthMpa | mechanical_properties | number | MPa |
| 12 | elongationPct | mechanical_properties | number | % |
| 13 | impactEnergy | mechanical_properties | object | J |
| 14 | productionRoute | production_data | enum | |
| 15 | heatNumber | production_data | string | |
| 16 | heatTreatment | production_data | enum | |
| 17 | reductionAgent | production_data | enum | |
| 18 | scope1DirectEmissions | carbon_footprint | number | tCO2e/t |
| 19 | precursorEmissions | carbon_footprint | array | tCO2/t |
| 20 | calculationMethodology | carbon_footprint | enum | |
| 21 | thirdPartyVerification | carbon_footprint | object | |
| 22 | dataQuality | carbon_footprint | enum | |
| 23 | cbamGoodsType | cbam | enum | |
| 24 | totalSpecificEmbeddedEmissions | cbam | number | tCO2/t |
| 25 | svhcPresent | substances_of_concern | boolean | |
| 26 | restrictedSubstancesCompliance | substances_of_concern | boolean | |
| 27 | inspectionCertificateType | compliance_certification | enum | |
| 28 | inspectionCertificateUri | compliance_certification | url | |
| 29 | ceMarkingStatus | compliance_certification | enum | |

## Category distribution (all 84 fields)

compliance_certification 10 · carbon_footprint 10 · production_data 9 · environmental_performance 8 ·
product_identification 8 · manufacturer_origin 7 · material_composition 7 · dpp_metadata 5 ·
circularity_end_of_life 5 · mechanical_properties 5 · cbam 5 · substances_of_concern 4 ·
supply_chain_traceability 1.

## CBAM ∩ steel-DPP overlap (seed for M1)

Direct overlaps: **carbon_footprint** (scope1DirectEmissions, precursorEmissions,
calculationMethodology, thirdPartyVerification, dataQuality) and **cbam** (cbamGoodsType,
totalSpecificEmbeddedEmissions, …) plus **production_data** (productionRoute, heatNumber,
reductionAgent) and **manufacturer_origin** (facilityId). These are the fields our C2 canonical
model must serve for both CBAM and the steel DPP.

## Note
TracePass template = field legally anchored; our C2 canonical model will be **generated/loaded
from it as data** (schemas-as-data), not hardcoded.

> Source: TracePass DPP Schemas — templates/steel.json v2 — Apache-2.0 — retrieved 2026-10-17
> Source: TracePass README (1,004 fields / 13 categories) — 2026
