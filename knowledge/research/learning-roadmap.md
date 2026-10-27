# Learning Roadmap — DPP Landscape & Building Your System

Purpose: understand the commodity open layers well enough to design on top of them, then
build the complex logic layers that differentiate. Working assumption (from `tools.md` and
`../exploration/saas-opportunity.md`): the transport layers are free and standardized; the moat is in
trust, verification, lineage, and harmonization logic.

Cross-references: `regulations.md` · `standards.md` · `architecture.md` · `tools.md` ·
`../exploration/saas-opportunity.md` · `sources.md` · `glossary.md`

---

## Phase 0 — Context & regulatory driver (est. 1 week)

Goal: know why the market exists and who is obligated.

- Read `regulations.md`: ESPR (2024/1781) as the framework; Battery Regulation (2023/1542)
  and the 18 Feb 2027 deadline; Economic Operator concept; trickle-down compliance.
- Read the EC DPP page and GOV.UK battery-passport survey (`sources.md`).
- Internalize the commercial shape from `../exploration/saas-opportunity.md`: the 4 revenue categories and
  the moat argument.

**Checkpoint:** explain, in one paragraph, why a Tier-2 chemical refiner in India is now
legally forced to digitize its data.

---

## Phase 1 — Commodity layers: learn their FUNCTIONALITY (est. 3–4 weeks)

Goal: for each free/open layer, know exactly what it does, its boundaries, its API — so you
can build on top instead of around it. Do not skip this; it is the whole point of this phase.

### 1.1 Identification & data carriers
- **GS1 Digital Link / GTIN:** how one QR code resolves to different contexts (POS vs DPP).
  Run the official **GS1 Resolver** locally (`tools.md`). Understand link types, resolver DB.
- **W3C DIDs & Verifiable Credentials:** DID Core 1.0, `did:web`/`did:key` methods, VC data
  model, and **OID4VC issuance** via Keycloak-oid4vc (`tools.md`). Understand "verify without
  a central DB."
- **eIDAS seal:** qualified electronic seal, EU trust list, and how a recipient verifies the
  issuer of a passport.

**Hands-on:** issue a VC and verify it; resolve a Digital Link QR to a test page.

### 1.2 Data exchange layer
- **EU DPP Registry (central) vs data spaces (decentralized):** how payloads are submitted
  (API, OpenID Connect / OAuth). Clone **CIRPASS-2 Mock EU Registry**, read its auth flow,
  endpoints, and DB schema (`tools.md`).
- **Data spaces:** Gaia-X operating model, **Eclipse Dataspace Connector (EDC)** — connector,
  contract negotiation, usage-control policy. See Catena-X as the mature automotive/battery
  implementation (`architecture.md`).

**Hands-on:** run the mock registry locally; submit a passport payload and retrieve it; sketch
an EDC-based flow where two suppliers exchange data under policy.

**Tactical shortcut (see `standards.md`):** the Catena-X / Manufacturing-X certification paths
force you through defined metrics (SAMM/BAM semantic validation, EDC interop, TISAX L2, and
the Tractus-X DPP Verification add-on). Building to them is a working blueprint. Strategy for
the venture: build the core EDC + credential engine in the Catena-X sandbox, then swap
semantic modules per vertical — Material-X (PCF) for steel/aluminium, Tex-X (fiber
composition) for textiles. Remember: data-space certification ≠ legal EU DPP compliance.

### 1.3 Semantic layer
- **JSON-LD** as the interchange format; the Semantic Repository idea (`regulations.md`).
- **AAS (Asset Administration Shell):** how the open-dpp platform models a passport with AAS
  submodels vs a pure JSON-LD route (`tools.md`, `architecture.md`). Pick a mental model for
  each and note trade-offs.
- **TracePass DPP Schemas:** explore all 13 categories; study the **190 fields in force vs 214
  anticipated**; understand field provenance via CELEX citations and the unit registry
  (`tools.md`). This is your field-level compliance map.
- **CEN/CENELEC DPP standard suite:** what the standards actually specify (data quality,
  carriers, registry interfaces) — read the deliverables referenced by freeDPP.
- **Vocabulary Hub / Semantic Treehouse:** how DPP vocabularies get published and consumed
  (JSON Schema / JSON-LD / API generation).

**Hands-on:** take the battery category, map its TracePass fields into a JSON-LD/AAS model,
and validate a sample payload against the bundled JSON Schema.

### 1.4 Domain layer — industrial process & verifier expectations (with the consultant)

Timing: the **external domain consultant (verifier-grade)** is engaged **after** the
connectivity/schema/transformation scaffolding is validated (post-C4), to detail the
schema, data-capture identification, and the CBAM/PCF calculation + validation models.

- Steel routes: **BOF** (blast-oxygen: coke/coal, hot metal) vs **EAF** (scrap, electricity);
  DRI/HBI inputs; mass flows (iron balance, yield), energy balance per tonne crude steel.
- Aluminium: primary (electrolysis, anode effects — CF4/C2F6) vs secondary (remelt);
  electricity intensity as the dominant emission driver.
- What a CBAM verifier will test: activity-data traceability, emission-factor choice,
  boundaries/allocation, mass-balance consistency, default-vs-actual thresholds.
- Outcome: consultant-approved schema details + data-capture checklist + calculation model
  notes, recorded as design contract inputs for C5 (we buy the knowledge, never the stamp).

---

## Phase 2 — Complex logic layers: the differentiators (est. 4–6 weeks)

Goal: this is where a proprietary, venture-backed system must live (`tools.md` strategic note).

### 2.1 Data lineage & lifecycle state machine
- Passports are not static. Study versioned, event-driven updates (Transpareo Time Machine's
  replayable timeline is the UX reference). Model state transitions:
  manufacture → distribution → repair → resale → recycling (incl. Article 65 re-minting).
- Design an event-sourced store + versioned passport output.

### 2.2 Multi-tier aggregation & verification
- Ingest Tier 1–4 supplier data; the hard problem is verification and reconciliation
  (graph databases, identity resolution, data-quality scoring).
- Study the battery value chain data (black mass, recycled content certificates) as the
  concrete example (`../exploration/companies.md`).

### 2.3 Cryptographic trust & verified compute
- ZK proofs / SNARKs: what they prove, when they are justified, and the trade-offs
  (prove carbon footprint without revealing the recipe). See `standards.md`, `glossary.md`.
- Client-side authenticity verification (as Transpareo does) and eIDAS-sealed data.
- Understand *where* verified compute sits in your architecture (it is the anti-fraud layer).

### 2.4 Data harmonization (AI mapping)
- Legacy ERP/PLM/spreadsheets → compliant fields. Semantic mapping, unit normalization
  (TracePass unit registry), and AI-assisted field mapping is the volume play.

### 2.5 Compliance math engines
- Recycled content, scope-3/carbon-footprint calculation, battery due-diligence data — the
  "real-time chemical mass-balance engines" named in `tools.md`. This is genuinely hard,
  defensible IP.

---

## Phase 3 — Design your system (est. 4 weeks)

1. **Pick a vertical** (battery / textile / electronics / other) and map its mandatory fields
   via TracePass.
2. **Draw the architecture** across the 3 layers (`architecture.md`): adopt identity/resolver/
   registry infra; decide what to build vs buy for each layer.
3. **Adopt, don't rebuild:** open-dpp as a base platform; GS1 Resolver; Keycloak for IAM;
   mock registry for integration testing.
4. **Prototype end-to-end:** raw supplier data → harmonized → verified → compliant payload →
   submitted to (mock) registry → rendered passport with lineage + authenticity.
5. **Identify the moat:** which step (lineage, verification, ZK, mass-balance, harmonization)
   will be your proprietary layer — and validate that it cannot be a one-week open-source script.

**Exit criteria:** a demo where a fabricated supplier dataset produces a CELEX-traceable,
cryptographically verifiable passport across the full lifecycle — with a defensible,
non-commodity component you can name.

---

## Continuous learning sources
- CIRPASS-2 site (deliverables, newsletters, Expert Working Groups, Lighthouse Pilots):
  https://cirpass2.eu — subscribe to the stakeholder community.
- Catalogue for reference implementations: https://cirpass2.eu/open-source-dpp-catalogue/
- Data4Circ / RecAL webinar and the EuroCommerce angle (`../exploration/people.md`,
  `../exploration/consultancies.md`).
- Add every new source to `sources.md` as you go.
