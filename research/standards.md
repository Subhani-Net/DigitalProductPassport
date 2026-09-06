# Standards

Data standards, schemas, and technical models behind the DPP.

## CEN/CENELEC DPP standard suite

- **Type:** Standard
- **Summary:** Official European standards for the Digital Product Passport, published
  under the EC's standardisation mandate. They define the DPP server requirements, data
  fields, and lifecycle.
- **Relevance to DPP:** Are the normative basis referenced by implementations such as
  freeDPP. The freeDPP project notes CEN/CENELEC standards were not finished until
  ~early summer 2026.
> Source: OttoHandle/freeDPP — https://github.com/OttoHandle/freeDPP — github — 28 May 2026

## TracePass DPP Schemas (OpenDPP Catalogue)

- **Type:** Schema
- **Summary:** Pure JSON schema definitions mapping the 900+ data fields legally mandated
  for submission across product categories.
- **Relevance to DPP:** Practical field-level blueprint for payloads.
> Source: OpenDPP Catalogue / TracePass — github — from initial research pass [URL to verify]

## GS1 & EPCIS / UN Transparency Protocol

- **Type:** Standard
- **Summary:** Global supply-chain standards (GS1 data strings, EPCIS events, UN
  Transparency Protocol) used to express factory-floor events for EU registry ingestion.
- **Relevance to DPP:** Bridges existing supply-chain IDs/traceability to DPP JSON-LD contexts.
> Source: OpenEPCIS / DPP-Ready — github — from initial research pass [URL to verify]

## JSON-LD context / semantic data model

- **Type:** Standard
- **Summary:** DPP payloads are structured as JSON-LD so the registry and Semantic Repository
  can interpret them uniformly.
- **Relevance to DPP:** Conversion of raw events to JSON-LD contexts is a core integration step.
> Source: OpenEPCIS / DPP-Ready — github — from initial research pass [URL to verify]

## Zero-knowledge proofs & SNARKs (DPP application)

- **Type:** Technology
- **Summary:** Cryptographic proofs (ZKPs; SNARKs as the practical class) that let a party
  prove a DPP claim — carbon footprint, recycled content, provenance — is true without
  disclosing the underlying confidential data.
- **Relevance to DPP:** Enables privacy-preserving compliance across supply chains; protects
  supplier proprietary data while satisfying regulators. Viewed in the market as
  high-complexity logic that cannot be commoditized by a generic open-source script.
- **Notes:** Mentioned in the DATA4CIRC & RecAL webinar; position as a differentiator for
  DPP tooling vs. the free "transport bridge" layer.
> Source: DATA4CIRC & RecAL — https://youtube.com/watch?v=si6j-ALrcjQ — webcast — 2026

## Emerging OpenDPP technical surface (from CIRPASS-2 catalogue)

- **Type:** Architecture
- **Summary:** The catalogue's flagship implementations converge on a technical surface of
  **AAS (Asset Administration Shell) + UNTP/W3C Verifiable Credentials + GS1 Digital Link +
  eIDAS-sealed data**, exposed via REST APIs (OpenAPI), with semantic vocabularies published
  through a Vocabulary Hub (JSON Schema / JSON-LD / API generation).
- **Relevance to DPP:** This is the practical, vendor-neutral stack the reference ecosystem
  is standardising on — a concrete refinement of the 3-layer framework in `architecture.md`.
- **Notes:** Textile sector already has a dedicated exchange standard (THREAD). Vocabularies
  are meant to be reusable/community-published, aligning with the EU Semantic Repository idea.
> Source: CIRPASS-2 OpenDPP Catalogue — https://cirpass2.eu/open-source-dpp-catalogue/ — web — 2026

## Catena-X & Manufacturing-X — certification as a learning blueprint

- **Type:** Certification / validation frameworks
- **Summary:** Catena-X has an operational certification architecture run by Conformity
  Assessment Bodies (CABs, e.g. TÜV Rheinland). Passing it forces a developer through defined
  software metrics — effectively a working blueprint for the code.
- **Relevance to DPP:** Useful shortcut: build to the Catena-X (Tractus-X) open core, then
  target verticals by swapping semantic modules.

### Catena-X certification metrics
1. **Semantic model validation (SAMM / BAM):** payloads must match the consortium's Aspect
   Models; the test harness flags mismatches in JSON-LD.
2. **EDC interoperability check:** data transfers via the standard Eclipse Dataspace Connector.
3. **Information security audit (TISAX Level 2):** data-sovereignty/security standards.
4. **Tractus-X DPP Verification add-on** (2025, community): public repo with a mock wallet
   engine for testing DPP compliance certificates — a step-by-step developer guide.

### Manufacturing-X — same core, sector verticals
- Umbrella initiative (German government + Plattform Industrie 4.0), uses the same Eclipse EDC
  and AAS stack, but spans multiple sectors with specialized verticals rather than one app
  marketplace:
  - **Material-X / Base Metals data space:** Iron, steel, aluminium. Certification emphasizes
    **Product Carbon Footprint (PCF)** computation and energy-mix tracking.
  - **Tex-X / Textile Data Space:** textiles. Validation focuses on material sustainability
    certifications (GOTS, OEKO-TEX) and format alignment with the EU DPP registry.

### Strategic use for the venture
- Build the core EDC app to Gaia-X/Catena-X in the Catena-X sandbox (most mature reference
  code, test registries, documentation) → then "swap semantic modules" per vertical:
  Material-X PCF schema for steel/aluminium exporters (carbon tax), Tex-X fiber composition
  for fashion brands.
> Source: AI-generated analysis — [Unverified] — 2026
> Note: distinguish data-space certification (industry credential) from legal EU DPP
> compliance (obligation to the EU Registry) — they are NOT the same thing.

## Battery Pass project (consortium standard-setting)

- **Type:** Project
- **Summary:** Consortium backed by Audi, BMW, and BASF that established reference data
  schemas for battery passport submissions.
- **Relevance to DPP:** De-facto reference for battery data fields, used by corporations
  pushing ERP data to Brussels.
> Source: [Unverified] — from initial research pass; verify Battery Pass project details
