# Competition Landscape — Matrix & Threat Scorecards

Synthesized from arena research waves (all sources fetched 6–7 Sep 2026; per-player
evidence in `dossiers/`). Rubric: `README.md` (threat scored against OUR moat, not market
size). "Claim:" = vendor statement; "Fact:" = independently verifiable.

## Arena A — CBAM / emissions wedge (in-force market)

| Player | CBAM depth | Importer/declarant vs supplier side | Verification signal | DPP | Threat |
|--------|-----------|------------------------------------|---------------------|-----|--------|
| **CarbonChain** | Productized modules: "CBAM for declarants", "CBAM for installations"; EU templates; cost formula incl. carbon-price-paid deduction | **Both sides** explicitly | "Methodology validated against the GHG Protocol by SGS"; ISO 27001; AI+human verification | none | **HIGH** |
| **SAP** (Sustainability Footprint Mgmt + Green Ledger) | Announced Jun 2026: "end-to-end CBAM solution… starting with CBAM declarants"; embedded emissions, certificates, report generation | Declarants (EU importers) | "audit-ready… Green Ledger" | none (footprint only) | **HIGH** (large EU declarants) |
| **CleanCarbon.ai** | Full service (see `../cleancarbonai/`) | India exporters + EU-side buyers | in-house ISO 14065/17029 certs | none | HIGH (India-exporter segment) |
| Sinai | CBAM module: "cost simulations", "generate, validate and submit CBAM reports", "auditable and verifiable" | companies outside EU | "verified by TÜV" | none | MEDIUM |
| Greenly | CBAM module: "quarterly XML reports for direct download to the EU portal", declarant + international-supplier tabs, €75.36 Q1-2026 price content | both sides | ISO 14040/14044 LCA output | YES (DPP/ESPR retail module) | MEDIUM (FR/EU SMEs) |
| Normative | CBAM = coaching session only, no software module | n/a | "independently verified by TÜV SÜD" | none | LOW |
| Persefoni | none found | n/a | SOC2/ISO 27001, ledger audit trail | none | LOW |
| Watershed | none found | n/a | third-party assured methodologies | none | LOW |
| Salesforce Net Zero Cloud | none found | n/a | audit-ready reports | none | LOW |
| Sweep | none found | n/a | audit trails, KPMG/ERM partners | none | LOW |

**Arena A read:** only CarbonChain, SAP (declarants) and CleanCarbon (India service) fight
our M2 revenue directly; generalists own enterprise Scope-1-3 spend but have no CBAM/DPP
depth. Greenly shows the SME wedge with XML-to-portal automation.

## Arena B — DPP platforms (2028–29 market)

| Player | DPP product | Registry integration | Supplier-side | Standards/tech | Threat |
|--------|-------------|---------------------|---------------|----------------|--------|
| **Minespider** | Battery passport + "register it directly in the EU DPP registry in one click from the app" (registry live 19–20 Jul 2026); REST API/ERP; blockchain-secured IDs; metals/mining | **YES — live submission** | metals, mines, OEMs | blockchain; CBAM/ESPR/CSRD positioning | **HIGH** (batteries-first) |
| **Circularise** | "Collect n-tier supplier data / Trace auditable Mass Balance / Share DPPs" + GS1 Digital Link, ERP/PLM APIs | not found | **n-tier + mass balance** | GS1 (GTIN+serial), ISO 27001 | **HIGH** (moat-layer overlap) |
| **Circulor** | "DPPs with supply chain trust & assurance", templates "built to ESPR and CEN/CENELEC JTC 24 (prEN18239)"; 624k DPPs issued claim; BV/TÜV/Volvo partners | not found (commentary) | mines→vehicles | CEN prEN18239 alignment | MEDIUM–HIGH |
| DPP-Tool | DPP generator SaaS: QR, JSON-LD, GS1 Digital Link; free→€399/mo; CSV/REST; 5-product free tier | not found | GLN supplier mgmt | GS1 Digital Link, JSON-LD | MEDIUM (price anchor) |
| PassportCraft | DPP SaaS: GS1 QR/Digital Link, JSON-LD+CSV export, MCP/agent connector, OpenAPI | not found | none | GS1, JSON-LD | LOW–MEDIUM |
| iPoint (Assent) | Compliance platform with DPP data-prep positioning; automotive logos (Ford, Tesla, BMW…) | not found (API guidance blog) | SustainHub | none stated | MEDIUM |
| SAP | No DPP product page (404); DPP via footprint data + Green Token (mass balance, blockchain) | not found | weak | mass balance via Green Token | MEDIUM |
| atma.io (Avery Dennison) | ReadyDPP full-service; connected-product cloud; CIRPASS member | not found | item-events | none stated | LOW |
| esprregistry / Infodpp | SEO/content hubs (LinkDaddy LLC / OriginPass) | no | no | no | LOW |

**Arena B read:** the open-source commodity (tools.md) + $29/mo generators set the price
floor; the *value* cluster is forming around trust/registry/traceability (Minespider,
Circulor, Circularise) — exactly our thesis. Minespider already owns "submit to EU registry
from the app" for batteries.

## Arena C — Verification / assurance (Art. 8 CBAM)

| Body | CBAM verification status | Accreditation named | DPP/ESPR services | Threat to us |
|------|--------------------------|--------------------|-------------------|--------------|
| TÜV SÜD | Verification + preliminary verification + training | **Named:** DAkkS, ACCREDIA, **NABCB (India)**, CNAS, SINGLAS…; ISO 14065 + ISO 14064-3 process | YES — ESPR portfolio incl. EU battery passport, seminars | LOW (partner; India reach) |
| TÜV Rheinland | Verification + pre-verification + reporting support ("accredited verification body") | AB not named on page | not found | LOW (partner) |
| SGS | **Pre-verification + training only**; "intends to apply for ISO/IEC 17029 extension to CBAM… subject to assessment" | ETS-accredited verifier in EU states; CBAM NOT yet | not found (news only) | LOW |
| Bureau Veritas | Verification + pre-verification + advisory; "**applicant** for CBAM verifier accreditation" | ISO 17029/14065 competence claimed | battery passport w/ Circulor | LOW |
| DNV | CBAM **advisory only** (no Art. 8 verification on its page); DPP services incl. data-integrity validation | not stated | YES — DPP creation, interoperability, data verification | LOW |
| Intertek | "end-to-end" CBAM support "with our CBAM experts and verifiers"; supplier data collection, calc, reporting | ISO 14064-3 cited for GHG verification | YES — DPP Advisory & Managed Services, textile DPP | LOW |

**Arena C read:** as of Sep 2026 only a few bodies can verify CBAM definitive-phase data —
SGS/BV are still *applicants*. Verification supply is scarce = a real market friction. This
is the benchmark that makes CleanCarbon's in-house ISO 14065/17029 claim look thin (see
`../cleancarbonai/`). Our path stays: build verifier-ready evidence; partner for the seal.

## Arena D — Adjacent infra (ecosystem, adopt not compete)

| Player | What it is | DPP relevance | Model |
|--------|-----------|---------------|-------|
| Catena-X | Governance association; DPP business area; certified member solutions (Siemens Battery Pass, Circulor PROVE, DENSO DPP…) | vendor-agnostic DPP foundation | association + certified apps |
| Eclipse Tractus-X | FOSS stack; EcoPass KIT; `digital-product-pass` repo (Java, Apache-2.0, **archived** reference impl) | adoptable reference | open source |
| Sovity | EDC connectors + data-space portal (CE open source; EE commercial) | data-space plumbing | OSS + SaaS |
| Manufacturing-X | Plattform Industrie 4.0 umbrella; AAS + GAIA-X; DataSpace Industrie 4.0 | cross-sector data ecosystem | public-private |
| GS1 | GS1 Digital Link spec v1.7.0 (Aug 2026); Conformant Resolver 1.2.0 (Jan 2026) | the carrier standard | standards body |
| **EU DPP Registry** | **Live 20 Jul 2026**; testing env `registry.acc.product-passport.ec.europa.eu`; helpdesk EC-HELPDESK-DPP@ec.europa.eu; decentralised hosting confirmed | our conformance target | official infra |

**Arena D read:** the official registry's **testing environment URL + helpdesk** are now
captured — this closes a compliance-matrix pending item. Registry stores metadata only;
hosting is decentralised (economic operators or DPP service providers) — matches our
EO-owned-URL design principle exactly.

## Threat scorecard summary

- **HIGH:** CarbonChain (wedge both sides), SAP (CBAM declarants + ERP incumbency),
  Minespider (registry-submission bridge already live, batteries), Circularise (n-tier
  supplier data + mass balance = our moat layer).
- **MEDIUM:** Sinai, Greenly (CBAM SME wedge, FR), iPoint, Circulor, DPP-Tool (price anchor).
- **LOW / adopt / partner:** the Scope-1-3 generalists (Normative, Persefoni, Watershed,
  Salesforce, Sweep), atma.io, esprregistry/Infodpp, all verifiers (TÜV SÜD is the strongest
  partner for India reach), all Arena-D infrastructure.

## Key strategic facts discovered

1. **EU DPP Registry testing environment is public** (`registry.acc…`) with an EU-login
   account — our T1 conformance can target the REAL registry, not just the CIRPASS mock.
2. **SAP entered CBAM in Jun 2026** (declarant solution on S/4HANA) — the ERP incumbency
   threat for EU importers is real; our wedge is supplier-side + DPP bridge + evidence depth.
3. **Accredited CBAM verification is scarce (SGS/BV still applicants)** — verification
   remains a bottleneck through 2026-27; verifier-ready data is a genuine wedge.
4. **Minespider submits to the EU DPP Registry from its app today** — the sell-twice bridge
   is being raced for batteries; metals/textiles (our verticals) remain open.
