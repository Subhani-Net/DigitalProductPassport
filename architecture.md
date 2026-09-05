# DPP Technical Architecture

Where to actually learn the DPP technical stack, and a 3-layer architecture framework
for thinking like a software builder.

> Source: AI-generated analysis (from another AI conversation) — [Unverified] — 2026

## Learning path (real technical core)

### 1. CIRPASS & CIRPASS-2 — official blueprints
- EC-funded consortium building the DPP technical blueprints.
- **Where:** CIRPASS Project website → Public Deliverables ("DPP Architecture", "Data Models" reports).
- **Why:** Shows the databases, APIs, and decentralized registries the EU intends to use.
> Source: cirpassproject.eu [URL to verify] — [Unverified]

### 2. W3C Decentralised Identifiers (DIDs)
- Identity layer for products, batches, manufacturers — cryptographically verifiable without
  a central government database.
- **Where:** W3C DID Core 1.0 specification.
- **Why:** How to issue, resolve, and manage the cryptographic keys anchoring a product's identity.
> Source: W3C DID Core 1.0 — https://www.w3.org/TR/did-core/ — [Unverified]

### 3. GS1 Digital Link
- Bridges physical labels (QR/RFID) to web data structures.
- **Where:** GS1 Digital Link Standard developer docs.
- **Why:** Structure URLs so one QR code both checks out at a grocery register and serves a
  context-aware DPP landing page.
> Source: GS1 Digital Link Standard — [URL to verify] — [Unverified]

### 4. Catena-X & Gaia-X — cross-company data exchange
- Mature operating models for secure cross-company data sharing (automotive/battery).
- **Where:** Catena-X GitHub repos and open-source tools.
- **Why:** APIs, semantic data models, access-control wrappers that let suppliers pass data
  up the chain securely.
> Source: Catena-X / Gaia-X — github [URL to verify] — [Unverified]

## 3-layer architecture framework

| Layer | Question | Standards |
|-------|----------|-----------|
| 1. Identification | How do we identify the object? | W3C DIDs, GS1 Digital Links, Verifiable Credentials, semantic web URIs |
| 2. Data exchange | How do we securely move data between companies? | Decentralised data spaces, Eclipse Dataspace Connectors (EDC), access-control policies |
| 3. Semantic | How do we format data so everyone understands it? | JSON-LD schemas, Asset Administration Shells (AAS) |

## Relation to existing KB notes

- Aligns with `saas-opportunity.md`: the identification + data-exchange layers are the
  hard/decentralised parts; the semantic layer maps to the 900+ field schemas in `tools.md`.
- Adds AAS (Asset Administration Shells, from Industry 4.0) as a data-modelling route that
  was previously missing from the KB — a key option vs. pure JSON-LD.
- Note the nuance vs. earlier AI claim: DIDs/VCs are the *emerging identity layer*, not yet a
  hard EU mandate (normative base is GS1/CEN-CENELEC/JSON-LD).
