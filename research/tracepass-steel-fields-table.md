# TracePass — Iron, Steel & Aluminium: Full Field Table (v2)

Source: `reference/tracepass-dpp-schemas/templates/steel.json` (TracePass, Apache-2.0). Category: **Iron, Steel & Aluminium**. Version: **2**. Instrument: **EU ESPR - Iron, Steel & Aluminium (EU) 2024/1781** (effective 2027-01-01, mandatory 2028-01-01).

Counts: **84 fields**, **29 required**.

| # | Key | Description (EN) | Type | Unit | Required | Category |
|---|---|---|---|---|---|---|
| 1 | `globalUniqueId` | GS1 Digital Link URI (ISO 15459). Primary DPP identifier for the product. | string |  | N | product_identification |
| 2 | `gtin` | GTIN-14 product identifier (14-digit Global Trade Item Number). | string |  | N | product_identification |
| 3 | `batchLotNumber` | Production batch or lot number (GS1 AI 10). For steel products this is typically the heat number. | string |  | Y | product_identification |
| 4 | `serialNumber` | Individual item serial number for high-value products (coils, plates). | string |  | N | product_identification |
| 5 | `productType` | Product category classification within iron, steel, and aluminium. | enum |  | Y | product_identification |
| 6 | `productName` | Commercial product name including grade and delivery condition. | string |  | Y | product_identification |
| 7 | `cnCode` | Combined Nomenclature code (EU customs, 8 digits). Critical for CBAM goods identification and benchmark determination. | string |  | Y | product_identification |
| 8 | `steelGradeDesignation` | Steel grade per EN 10027-1 (symbolic name) and EN 10027-2 (numeric), or aluminium alloy per EN 573/EN 1706. | object |  | Y | product_identification |
| 9 | `manufacturerName` | Legal name of the manufacturer or economic operator. | string |  | Y | manufacturer_origin |
| 10 | `manufacturerAddress` | Registered address of the manufacturer. | string |  | Y | manufacturer_origin |
| 11 | `countryOfManufacture` | ISO 3166-1 alpha-2 country code of production location. Determines CBAM default benchmark values and carbon price. | string |  | N | manufacturer_origin |
| 12 | `facilityId` | Production facility identifier. For CBAM: installation ID in CBAM registry. Installation-level emissions data is tied to this ID. | string |  | Y | manufacturer_origin |
| 13 | `importerName` | Legal name of the EU importer, if the product is imported. | string |  | N | manufacturer_origin |
| 14 | `importerAddress` | Registered address of the EU importer. | string |  | N | manufacturer_origin |
| 15 | `euAuthorisedRepresentative` | Authorised representative in the EU if the manufacturer is non-EU. | string |  | N | manufacturer_origin |
| 16 | `primaryMaterialType` | Primary material classification. CBAM distinguishes carbon steel, stainless, low-alloy, high-alloy for benchmark determination. | enum |  | N | material_composition |
| 17 | `chemicalComposition` | Elemental composition per EN 10204 mill certificate. Weight percentages for each alloying element. | array | weight_% | Y | material_composition |
| 18 | `recycledContentPercentage` | Total recycled material content by weight. ESPR will set minimum thresholds via delegated act (expected 2027-2028). | number | % | N | material_composition |
| 19 | `preConsumerScrapPct` | Pre-consumer (internal/process) scrap content by weight. | number | % | N | material_composition |
| 20 | `postConsumerScrapPct` | Post-consumer (end-of-life) scrap content by weight. | number | % | N | material_composition |
| 21 | `recycledContentVerification` | Method used to verify recycled content claims. | enum |  | N | material_composition |
| 22 | `coatings` | Surface coatings applied to the product (galvanizing, painting, etc.). | array |  | N | material_composition |
| 23 | `yieldStrengthMpa` | Minimum yield strength ReH in megapascals, from EN 10204 mill certificate. | number | MPa | Y | mechanical_properties |
| 24 | `tensileStrengthMpa` | Tensile strength Rm in megapascals. | number | MPa | Y | mechanical_properties |
| 25 | `elongationPct` | Elongation at break A5 (%) from tensile test. | number | % | Y | mechanical_properties |
| 26 | `impactEnergy` | Charpy V-notch impact test results per ISO 148-1. | object | J | Y | mechanical_properties |
| 27 | `hardness` | Hardness test result (Brinell, Rockwell, or Vickers). | object |  | N | mechanical_properties |
| 28 | `productionRoute` | Primary steelmaking or aluminium smelting route. Determines CBAM default benchmark. | enum |  | Y | production_data |
| 29 | `productionDate` | Date of manufacture or final processing. | date |  | N | production_data |
| 30 | `heatNumber` | Steel heat/melt number for traceability to a specific melt. | string |  | Y | production_data |
| 31 | `heatTreatment` | Delivery condition / heat treatment applied to the steel product. | enum |  | Y | production_data |
| 32 | `electricityGridIntensity` | Grid emission factor in gCO2/kWh. Critical for aluminium indirect emissions calculation under CBAM. | number | gCO2/kWh | N | production_data |
| 33 | `renewableSharePct` | Share of renewable electricity used in production. | number | % | N | production_data |
| 34 | `electricityConsumedKwhPerT` | Electricity consumption per tonne of product. Especially critical for EAF and aluminium smelting. | number | kWh/t | N | production_data |
| 35 | `rawMaterialOrigin` | Origin of raw materials (iron ore, bauxite, scrap, etc.) for supply chain traceability. | array |  | N | production_data |
| 36 | `reductionAgent` | Primary reductant used in iron/aluminium reduction. Determines direct process emissions. | enum |  | Y | production_data |
| 37 | `totalCarbonFootprint` | Product carbon footprint per ISO 14067 / EU PEF. Cradle-to-gate value in kgCO2e/kg. Overlaps with CBAM embedded emissions. | object | kgCO2e/kg | N | carbon_footprint |
| 38 | `scope1DirectEmissions` | Direct emissions from the production installation. THE primary CBAM field for iron/steel. | number | tCO2e/t | Y | carbon_footprint |
| 39 | `scope2IndirectEmissions` | Indirect emissions from purchased electricity/heat. Counted in CBAM for aluminium only; required in DPP for all. | number | tCO2e/t | N | carbon_footprint |
| 40 | `scope3UpstreamEmissions` | Upstream value chain emissions (raw materials, transport). CBAM counts precursor emissions only. | number | tCO2e/t | N | carbon_footprint |
| 41 | `precursorEmissions` | Emissions from CBAM precursor inputs (e.g., pig iron, DRI, sinter, pellets). Summed into total CBAM embedded emissions. | array | tCO2/t | Y | carbon_footprint |
| 42 | `calculationMethodology` | Standard or methodology used for carbon footprint calculation. | enum |  | Y | carbon_footprint |
| 43 | `thirdPartyVerification` | Third-party verification of carbon footprint data. Mandatory for CBAM from 2026 definitive phase. | object |  | Y | carbon_footprint |
| 44 | `carbonIntensityClass` | Performance class (A-G) when established by delegated act. | enum |  | N | carbon_footprint |
| 45 | `euEtsBenchmarkProduct` | EU ETS product benchmark reference for EU producers. | string |  | N | carbon_footprint |
| 46 | `dataQuality` | Quality level of emissions data: actual verified, actual unverified, or default benchmark values. | enum |  | Y | carbon_footprint |
| 47 | `cbamGoodsType` | Simple (no CBAM precursors, e.g. pig iron) or Complex (contains CBAM precursors, e.g. steel plate from pig iron). | enum |  | Y | cbam |
| 48 | `totalSpecificEmbeddedEmissions` | Total embedded emissions per tonne for CBAM declaration (direct + precursor for steel; direct + indirect + precursor for aluminium). | number | tCO2/t | Y | cbam |
| 49 | `carbonPricePaid` | Carbon price already paid in country of origin. Deducted from CBAM certificates an importer must surrender. | object | EUR/tCO2 | N | cbam |
| 50 | `cbamDeclarantEori` | EU Economic Operators Registration and Identification number of the CBAM declarant (importer). | string |  | N | cbam |
| 51 | `cbamAccountNumber` | CBAM account ID in the EU CBAM registry. | string |  | N | cbam |
| 52 | `svhcPresent` | Whether the product contains Substances of Very High Concern above 0.1% w/w threshold per REACH Article 33. | boolean |  | Y | substances_of_concern |
| 53 | `svhcCandidateListSubstances` | List of SVHC substances present above 0.1% w/w, with CAS numbers and concentrations. | array |  | N | substances_of_concern |
| 54 | `reachRegistrationNumbers` | REACH registration numbers for applicable substances. | array |  | N | substances_of_concern |
| 55 | `restrictedSubstancesCompliance` | Compliance with REACH Annex XVII substance restrictions. | boolean |  | Y | substances_of_concern |
| 56 | `gwpTotal` | Global warming potential total per declared unit (kg CO2 eq.). EN 15804+A2 indicator. | number | kg CO2e | N | environmental_performance |
| 57 | `odp` | Ozone depletion potential in kg CFC-11 eq. per declared unit. | number | kg CFC-11 eq. | N | environmental_performance |
| 58 | `ap` | Acidification potential in mol H+ eq. per declared unit. | number | mol H+ eq. | N | environmental_performance |
| 59 | `waterUse` | Water use in m3 world eq. per declared unit. | number | m3 world eq. | N | environmental_performance |
| 60 | `epdReferenceUri` | URI to the Environmental Product Declaration document. | url |  | N | environmental_performance |
| 61 | `epdProgramOperator` | Name of the EPD program operator (e.g. IBU, EPD International, BRE). | string |  | N | environmental_performance |
| 62 | `lifecycleModules` | Covered LCA modules per EN 15804+A2 (e.g. A1-A3, C1-C4, D). | string |  | N | environmental_performance |
| 63 | `declaredUnit` | Declared or functional unit for EPD environmental indicators. | string |  | N | environmental_performance |
| 64 | `expectedServiceLifeYears` | Expected product service life in years. | number | years | N | circularity_end_of_life |
| 65 | `recyclabilityPercentage` | Percentage of product mass that is recyclable. | number | % | N | circularity_end_of_life |
| 66 | `endOfLifeInstructions` | URI to dismantling, recycling, or end-of-life guidance. | url |  | N | circularity_end_of_life |
| 67 | `magneticSeparability` | Whether the steel product can be magnetically separated from waste streams. | boolean |  | N | circularity_end_of_life |
| 68 | `expectedScrapGrade` | Expected scrap classification at end of life per industry standards. | string |  | N | circularity_end_of_life |
| 69 | `ceMarking` | Whether CE marking is applied (required for construction products under CPR). | boolean |  | N | compliance_certification |
| 70 | `declarationOfPerformanceUri` | URI to the Declaration of Performance document for construction products. | url |  | N | compliance_certification |
| 71 | `inspectionCertificateType` | EN 10204 inspection document type: 2.1 (declaration), 2.2 (test report), 3.1 (mill cert by manufacturer QA), 3.2 (mill cert with third-party countersignature). | enum |  | Y | compliance_certification |
| 72 | `inspectionCertificateUri` | URI to the EN 10204 mill certificate PDF or structured data. | url |  | Y | compliance_certification |
| 73 | `responsibleSteelCertification` | ResponsibleSteel site and/or product certification (voluntary, 13 principles, 4 progress levels for decarbonisation). | object |  | N | compliance_certification |
| 74 | `asiCertification` | Aluminium Stewardship Initiative certification (Performance Standard + Chain of Custody V2.1). | object |  | N | compliance_certification |
| 75 | `euEtsInstallationId` | EU ETS installation permit ID. EU ETS installations are exempt from CBAM when selling within the EU. | string |  | N | compliance_certification |
| 76 | `isoCertifications` | ISO management system certifications held (e.g. ISO 9001, ISO 14001, ISO 50001). | array |  | N | compliance_certification |
| 77 | `otherCertifications` | Other voluntary certifications (SCS, Cradle to Cradle, etc.). | array |  | N | compliance_certification |
| 78 | `supplyChainEvents` | Supply chain traceability events (EPCIS 2.0 aligned): mining, smelting, rolling, finishing, shipping, etc. | array |  | N | supply_chain_traceability |
| 79 | `dataCarrier` | Type of data carrier used to link to the DPP (QR, NFC, RFID, DataMatrix). | enum |  | N | dpp_metadata |
| 80 | `accessLevel` | Default access tier for this DPP: public, restricted (recyclers/processors), or authority-only. | enum |  | N | dpp_metadata |
| 81 | `registryEntryUri` | URI in the EU DPP central registry (operational from July 2026). | url |  | N | dpp_metadata |
| 82 | `dataFormat` | Machine-readable data format per ESPR requirements. | string |  | N | dpp_metadata |
| 83 | `languages` | Available languages for this DPP per ESPR Article 8. | array |  | N | dpp_metadata |
| 84 | `ceMarkingStatus` | Whether the product bears CE marking and its validity | enum |  | Y | compliance_certification |
