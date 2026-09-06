# CleanCarbon.ai — Methodology & Calculations

Everything their site states about CBAM math. Cross-check with `../research/regulations.md`.

## Core formula (verbatim)

"CBAM Cost = Embedded CO₂ Emissions × EU Carbon Price (€/tonne CO₂). If the exporter's home
country already applies a carbon tax, that amount can be deducted from the total CBAM
charge."

> Source: https://cleancarbon.ai/iron-and-steel/ (FAQ) — 6 Sep 2026

## Certificate prices (their published table — fact-checkable against EC)

| Period | Publication date | Price |
|--------|------------------|-------|
| Q1 2026 | 7 April 2026 | **€75.36** / t CO₂e |
| Q2 2026 | 6 July 2026 | **€75.28** / t CO₂e |

Also stated as "€75.36 (INR 8,000) Per Tonne of CO2e" on the CN-code checker page.
Fact (from their EC-faq reproduction): "the price of CBAM certificates will mirror the ETS
allowance price… calculated depending on the weekly average auction price of EU ETS
allowances".

> Source: https://cleancarbon.ai/cbam-estimator-and-calculator/ ; /cbam-cn-code-checker/ ; /cbam-resources/ — 6 Sep 2026

## Actual vs default values

- Verbatim: "Use actual plant-level emission data. If unavailable, the EU allows default
  values (conservative estimates)."
- Iron & steel page: "Cost Penalties: Default carbon values can raise your product cost by
  20–25%" (Claim)
- Aluminium page: "Using incorrect or missing data can lead to higher default emissions,
  increasing future CBAM costs."

> Source: /cbam-for-indian-suppliers/ ; /iron-and-steel/ ; /cbam-reporting-for-aluminium-cost/ — 6 Sep 2026

## Data required for a report (iron & steel FAQ, verbatim)

- "Energy and fuel consumption records."
- "Material input and output data."
- "Process-specific emission factors."
- "Production volumes per product type."
- "Third-party verification reports (if applicable)."

Aluminium page adds: "Quantity of aluminium exported to the EU; Direct emissions from
production; Indirect emissions from electricity use."

> Source: /iron-and-steel/ ; /cbam-reporting-for-aluminium-cost/ — 6 Sep 2026

## Registry & process mechanics (their EU-faq reproduction; regulatory facts)

- Regulation: CBAM Regulation (EU) 2023/956 (10 May 2023); transitional period from
  1 Oct 2023; definitive period January 2026
- Two ways to file: manual entry OR **XML structure upload** to the CBAM Transitional
  Registry (supporting XLS published by the Commission)
- Verification: "verification by an external independent body will only be mandatory from
  2026" (i.e., now mandatory in the definitive phase)
- Penalties: €10–50 per tonne of unreported emissions
- De minimis: consignments ≤ €150 intrinsic value exempt
- Free-allowance phase-out: CBAM applies to the non-free-allowance share until 2034
- Covered sectors: iron/steel, cement, fertilisers, aluminium, hydrogen, electricity
- Exclusions: EEA members and Switzerland
- Article 35 report contents: quantity per good type; actual total embedded emissions;
  total indirect emissions; carbon price paid in origin country

> Source: https://cleancarbon.ai/cbam-resources/ — 6 Sep 2026

## Methodology transparency of CleanCarbon itself

- Formulas/emission factors behind THEIR calculator: **NOT FOUND** — the pages describe
  what is calculated, not how (no emission-factor tables, no boundary definitions published)
- Calculator disclaimer: "Your free CBAM tax calculation is subject to verification."

> Source: /cbam-estimator-and-calculator/ — 6 Sep 2026
