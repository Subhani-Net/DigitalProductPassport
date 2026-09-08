# Glossary

DPP terminology. Add new terms as you encounter them.

- **DPP (Digital Product Passport)**: A structured, machine-readable dataset carrying
  sustainability and lifecycle information about a product, as mandated under EU law.
- **ESPR (Ecodesign for Sustainable Products Regulation)**: EU Regulation (2024/1781);
  the framework law establishing DPPs per product category.
- **Battery Passport**: The first DPP category, required under the EU Battery Regulation
  (2023/1542) from 18 Feb 2027 for EV, LMT, and industrial (>2 kWh) batteries.
- **Economic Operator**: The responsible legal entity (manufacturer, importer, or
  distributor) obligated to submit DPP data.
- **LMT battery**: Light Means of Transport battery — e-bikes, e-scooters, cargo bikes.
- **ESS**: Energy Storage System — stationary battery systems (grid, telecom, solar).
- **Second-life / remanufactured battery**: A used battery repaired or repurposed; under
  Article 65 the repurposer becomes a new manufacturer.
- **Recycled content**: Share of recycled material in a product; must be reported for
  battery passports.
- **EU DPP Registry**: The central EU database that stores submitted passports.
- **Semantic Repository**: The EU's common reference for DPP data definitions across categories.
- **CIRPASS / CIRPASS-2**: EU-funded consortium deploying the reference code for the passport registry.
- **CEN/CENELEC**: European standardisation bodies; their DPP standard suite is the
  normative basis for implementations.
- **JSON-LD**: Linked-data JSON format used for DPP payloads so the registry can interpret them.
- **EPCIS / GS1 / UN Transparency Protocol**: Global supply-chain traceability standards
  bridged into DPP payloads.
- **QR code**: Physical carrier on the product linking to its passport.
- **Data adapter**: A tool that translates a company's ERP/system data into DPP-compliant
  payloads (the "transport bridge" market).
- **Zero-Knowledge Proof (ZKP)**: A cryptographic method that lets one party prove a
  statement is true (e.g. carbon footprint, recycled content) without revealing the
  underlying data. Relevant to DPP as a way to prove compliance while protecting
  proprietary supply-chain data.
- **SNARK**: Succinct Non-interactive Argument of Knowledge — a class of zero-knowledge
  proofs that are small and fast to verify. Practical option for DPP compliance proofs
  on-chain or in supply-chain verifications.
- **Privacy-preserving verification**: The idea of verifying DPP claims without exposing
  the full underlying data — cited as the kind of high-complexity logic that is hard to
  commoditize in the DPP tooling market.
- **DID (Decentralised Identifier)**: W3C standard identifier (W3C DID Core 1.0) usable
  without a central registry; candidate identity layer for products, batches, manufacturers.
- **Verifiable Credential (VC)**: Cryptographically signed claim (e.g. "recycled content =
  X%") that a third party can verify without contacting the issuer.
- **GS1 Digital Link**: Standard for encoding identifiers in URLs so one QR/RFID tag serves
  multiple uses (POS checkout + DPP landing page) based on context.
- **Catena-X / Gaia-X**: European frameworks for secure cross-company data sharing;
  mature in automotive/battery (data spaces, connectors, semantic models).
- **EDC (Eclipse Dataspace Connector)**: Open-source connector used to move data between
  companies under access-control policies.
- **AAS (Asset Administration Shell)**: Industry 4.0 standard for a digital twin of an
  asset; an alternative route to JSON-LD for structuring DPP data.
- **Data space**: Decentralised architecture where parties share data under agreed
  governance/policies rather than a central database.
- **Data lineage**: Tracking a product's state transitions across its lifecycle
  (manufacture → distribution → repair → resale → recycling).
- **UNTP (UN Transparency Protocol)**: UN/CEFACT framework for trusted product traceability
  data; part of the emerging DPP data surface.
- **eIDAS seal**: Qualified electronic seal under the EU eIDAS regulation, used to sign DPP
  data so recipients can verify the issuer/authenticity (part of the OpenDPP surface).
- **OID4VC**: OpenID for Verifiable Credentials — protocol to issue/present VCs over OIDC;
  used via Keycloak extensions in the catalogue.
- **CELEX**: Official EU legal-documents database; used by TracePass to cite the exact
  instrument + provision governing each DPP field.
- **SLSA provenance**: Supply-chain security metadata attesting to how a software artifact
  was built (used by the npm `@tracepass/dpp-schemas` package).
- **llms.txt**: Convention for listing the AI/LLM-relevant docs of a site/repo so AI agents
  can discover an API (used by the OpenDPP Knowledge Bundle).
- **Catena-X**: European automotive data space (open source, Eclipse Foundation) for secure
  cross-company data sharing; runs on EDC + AAS.
- **Manufacturing-X**: German umbrella initiative (Plattform Industrie 4.0) reusing Catena-X
  tech across many sectors via vertical data spaces.
- **Material-X / Base Metals data space**: Vertical for iron, steel, aluminium; certification
  centers on Product Carbon Footprint (PCF) and energy-mix tracking.
- **Tex-X / Textile Data Space**: Textile vertical; validates material sustainability
  certificates (GOTS, OEKO-TEX) and EU-registry format alignment.
- **Tractus-X**: The Eclipse open-source project behind Catena-X (incl. the DPP Verification
  add-on with a mock wallet engine).
- **EDC (Eclipse Dataspace Connector)**: Open-source connector for governed data exchange
  between companies; the transport standard in Catena-X/Manufacturing-X.
- **SAMM / BAM**: Catena-X Semantic Aspect Meta Model / its build tooling — the consortium's
  way of defining and validating data aspects (JSON-LD payloads are checked against them).
- **TISAX**: VDA information-security assessment for the automotive supply chain (Level 2 =
  high standard); part of Catena-X certification.
- **CAB (Conformity Assessment Body)**: Accredited org (e.g. TÜV Rheinland) that audits and
  certifies software against a standard's requirements.
- **PCF (Product Carbon Footprint)**: Total GHG emissions of a product; the core validated
  metric in the metals data space.
- **GOTS / OEKO-TEX**: Textile sustainability certifications referenced by the textile data space.
- **Fly ash**: Coal-combustion by-product used as a supplementary cementitious material in
  concrete; export-grade material must be classified to quality standards.
- **BS EN 450**: European standard for fly ash for concrete; **Category S** = ultra-fine class.
- **ASTM C 618**: US standard classifying fly ash — **Class F** is the common pozzolanic class.
- **Supplementary cementitious material (SCM)**: Material (e.g. fly ash, slag) added to
  concrete/cement for performance/sustainability.
- **CAMBEX**: [Unverified] — user reference related to construction/cement and DPP
  legislation; meaning to be confirmed.
- **ESPR Working Plan (2025–2030)**: COM(2025) 187, adopted 16 Apr 2025 — the Commission's
  five-year schedule of which product groups get delegated acts and when; mid-term review 2028.
- **Delegated act (DA)**: Product-specific ESPR instrument setting ecodesign + DPP
  requirements; dates are indicative; obligation starts ≥18 months after adoption.
- **Intermediate product**: A product processed further before final use (e.g. iron & steel,
  aluminium) vs a **final product** (textiles, tyres, furniture).
- **CBAM**: EU Carbon Border Adjustment Mechanism — carbon-pricing on imports; its emissions
  data substantially overlaps the iron & steel / aluminium DPP carbon fields.
- **ETS (EU Emissions Trading System)**: EU carbon market; steel operators already report
  emissions here — a data head-start for DPP carbon-intensity fields.
- **Authorised CBAM Declarant**: EU-import status required under the CBAM definitive phase
  (live 1 Jan 2026) to import covered goods (steel, aluminium, etc.).
- **Embedded emissions**: GHG emitted to produce a good; reported/verified under CBAM and
  reused for the steel/aluminium DPP carbon fields.
- **Unsold-products destruction ban / disclosure duty**: ESPR measure in force 19 Jul 2026
  for large enterprises — no destroying unsold apparel/accessories/footwear; unsold volumes
  must be disclosed (medium companies phase in 2030). The near-term textiles compliance wedge.
- **Sell-twice engine**: The harmonization + verified-data pipeline built once and sold for
  the in-force wedge (CBAM / unsold disclosure) now, then extended to the DPP module later
  (~2028–29).

## CBAM workflow terminology (from research/cbam-registry-workflow.md)

- **Accreditation**: credential granted by a national accreditation body to a *verifier*
  (competence, independence, methodology). Applies to the **body**, never to data.
- **Verification**: assurance review of the *data* — the accredited verifier checks the
  operator's emissions data + evidence (traceability, recalculation, completeness,
  plausibility, risk-sampling, possibly site visits) and issues a **verification report**.
  Forensic-validity-style: "reasonable assurance", not absolute proof.
- **Validation** (ETS-style term): checking the *monitoring plan/methodology* before use —
  distinct from verifying the *reported numbers* after.
- **O3CI**: "Operators of Third-Country Installations" — the CBAM Registry module where
  non-EU installation operators upload/share installation + emissions data (confidential
  treatment) and where accredited verifiers review it and issue verification reports.
- **Registered Operator**: status of a non-EU installation operator after O3CI onboarding
  (EU Login + 2FA, company docs, proof of representation).
- **AMM**: Authorisation Management Module — where EU importers / indirect customs
  representatives apply for authorised-CBAM-declarant status with their national authority.
- **NCA**: National Competent Authority — the EU member-state authority granting
  authorisations and receiving verifier-registration applications.
- **DRMC**: Data Reconciliation for Monitoring and Control — reconciles declarant's goods,
  emissions, certificates and penalties; monitors thresholds and the 50%-rule.
- **EORI linking**: the mechanism by which a declarant shares its EORI number with the
  supplier so the registry can connect the supplier's verified data to the declarant's
  reports (data flows registry→declarant, never declarant→supplier-by-email).
- **Actual vs default values**: actual = installation's own verified emissions; default =
  conservative fallback figures when verified actual data is unavailable — defaults are
  costlier by design.
- **Independence / self-review threat**: impartiality rule (ISO/IEC 17029 / ISO 14065): a
  verifier cannot provide assurance on work performed by its own affiliated company — which
  is why our platform's outputs need a *third-party* accredited verifier's stamp.
- **Arm's-length verification entity**: a separate, firewalled legal entity we *might*
  create to hold verifier accreditation — keep-open option gated on volume, not a roadmap
  target (partner-only until volume justifies).
- **Certificate surrender vs deduction**: declarants *purchase* CBAM certificates at the
  ETS-linked price and *surrender* them to settle the annual declaration; the carbon price
  already paid in the origin country is *deducted* from the liability.
- **Workhorse vs stamp (our operating model)**: we run all data-layer activity (capture,
  calculation, submission, validation intelligence) on both sides; the accredited verifier
  provides the assurance stamp. Partner-only stamp, locked Sep 2026.
