# Tools

Open-source repositories, platforms, and infrastructure for DPP data handling.

## EU DPP Registry & Semantic Repository (official)

- **Type:** Official infrastructure
- **Summary:** Central registry for passports; Semantic Repository as the common reference
  for DPP data. Uniform machine-readable models and documented APIs across Europe.
- **Relevance to DPP:** The target system every submission goes to.
> Source: single-market-economy.ec.europa.eu — Digital Product Passport — gov — 15 Aug 2026

## OpenDPP Catalogue (cirpass2.eu) — curated open-source solutions

The EC-funded CIRPASS-2 consortium curates an open catalogue of DPP building blocks
("OpenDPP Catalogue", open for submissions). Entries as of the last check:

| Solution | Vendor | Category | Stack / License | Repo |
|----------|--------|----------|-----------------|------|
| open-dpp platform | open-dpp GmbH (DE) | Full DPP | TypeScript/Vue, NestJS, Docker, AGPL-3.0, v2.4.0 | https://github.com/open-dpp/open-dpp |
| Transpareo Time Machine | Transpareo AG (CH) | Full DPP renderer | JS/CSS, GPL-3.0, v2.4.0 | https://github.com/transpareo/transpareo-time-machine |
| TracePass DPP Schemas | TracePass LTD | Full DPP (schemas) | Pure JSON, Apache-2.0, v0.1.1 | https://github.com/malinoto/tracepass-dpp-schemas |
| THREAD | Hestia Technology | Interoperability (textile) | OpenAPI, MIT, v1 | https://github.com/hestiatechnology/thread |
| OpenDPP Knowledge Bundle (OKF) | OpenDPP UAB (LT) | Workflow & Integration (AI-ready docs) | JS/JSON/Markdown, Apache-2.0, v1.4.1 | https://github.com/OpenDPP/opendpp-knowledge |
| Semantic Treehouse – DPP Vocabulary Hub | Semantic Treehouse (NL) | Ontology | PHP Symfony 7.2, Apache-2.0, v4.3 | https://dpp.vocabulary-hub.eu/ |
| GS1 Resolver | GS1 | Redirect (Digital Link) | Python/JS/CSS, Apache-2.0 | https://github.com/gs1/GS1_DigitalLink_Resolver_CE |
| Keycloak-oid4vc | adorsys / Keycloak | Verifiable Credentials / IAM | Java, Apache-2.0 | https://github.com/adorsys/keycloak-oid4vc |

Details and intelligence:

- **open-dpp platform** — full DPP lifecycle platform built on **Asset Administration Shell (AAS)**,
  documented REST API, full import/export, role-based access, GDPR-compliant, German cloud
  or on-prem. Flagship "whole passport" reference.
- **Transpareo Time Machine** — embeddable SPA that renders a passport as an interactive card
  with a **scrubbable timeline replaying every version of the passport** (data lineage UX)
  plus **client-side cryptographic authenticity verification**.
- **TracePass DPP Schemas** — the concrete compliance map: **913 fields across 12 categories**
  (battery, textile, electronics, construction, iron & steel, chemicals, packaging,
  furniture, tyres, jewellery, toys, FMCG). Each field: data type, validation rules,
  24 EU-language labels, and a citation to the governing instrument (34-entry CELEX registry
  + unit registry). **343 fields required by instruments in force; 187 anticipated under a
  named future instrument.** Also on npm as `@tracepass/dpp-schemas` (SLSA provenance).
- **THREAD** — open standard for textile supply-chain data exchange toward the DPP mandate;
  sector-specific readiness signal for textiles.
- **OpenDPP Knowledge Bundle (OKF)** — the entire OpenDPP Integration API projected into
  cross-linked Markdown for **AI agents / LLM tooling** (llms.txt). Covers the full
  OpenDPP surface: **AAS + UNTP/W3C-VC + GS1 Digital Link + eIDAS-sealed DPP**. Signals
  that DPP integrations are being built for AI-agent consumption.
- **Semantic Treehouse – DPP Vocabulary Hub** — the semantic repository for DPP data models;
  publish/reuse vocabularies and emit **JSON Schema / JSON-LD / APIs**. The practical
  front-end to the EU Semantic Repository idea.
- **GS1 Resolver** — official GS1 open-source resolver that redirects a GS1 Digital Link QR
  to the right web resource without touching existing systems.
- **Keycloak-oid4vc** — issues Verifiable Credentials via the widely-deployed Keycloak IAM;
  the pragmatic identity route for enterprises that already run Keycloak.

Catalogue taxonomy (the filter categories) maps the DPP stack layers: DID / DID Resolver /
Verifiable Credentials / Digital Wallet (+ encryption key mgmt) / Full DPP / Storage /
Data Space / Interoperability Frameworks / Ontology / Redirect / IAM / Auth & Authz /
VC Schema / VC API / Data Exchange Gateway / Message Broker / Verified Compute /
Workflow & Integration.

> Source: CIRPASS-2 OpenDPP Catalogue — https://cirpass2.eu/open-source-dpp-catalogue/ — web — 2026

## CIRPASS-2 / Mock EU Registry (GitHub) — L3 verified

- **Type:** Reference implementation (the T1 conformance target)
- **Repo:** https://github.com/CIRPASS-2/mock-eu-registry (Apache 2.0). Quarkus (Java); backend
  PostgreSQL or MariaDB; **OpenID Connect** auth. Docker image:
  `ghcr.io/cirpass-2/mock-eu-registry-pgsql-oidc:latest`.
- **CIRPASS-2 test environment (full stack, recommended for local T1):**
  https://github.com/CIRPASS-2/deploy-resources — one compose starts Keycloak + Postgres +
  mock registry + validator + extractor + renderer:
  `docker compose -p dpp_live_test_environment -f ./test_environment/docker-compose.yaml up --pull always -d`
- **Service ports:** Keycloak `8180` (realm `cirpass-2`, admin/admin); registry `8082`;
  validator `8083`; extractor `8084`; renderer-fe `4200`; app Postgres `5434`
  (postgres/postgres). Validation **disabled by default** (env `REGISTRY_VALIDATION_ENABLED`).
- **Registry API (verified from README):**
  - `POST /metadata/v1/registerDPP` (or `/metadata/v1/`) — register DPP metadata (JSON Schema 2020-12 validated). Fields (default schema): `upi`, `reoId`, `liveURL`, `backupURL`,
    `commodityCode`, `facilitiesId[]`, `granularityLevel` (MODEL/BATCH/ITEM); conditional
    `deactivated`, `modelUpi`, `batchUpi`. Roles: `admin`/`eo`/`eu`.
  - `GET /metadata/v1/{registryId}/proof` — signed Proof-of-Registration JWT (RS256), incl.
    `registryId`, `registeredAt`, `dppHash` (SHA-256 of DPP at liveURL).
  - `GET /.well-known/jwks.json` — registry public key for proof verification.
  - `POST /schema/v1`, `GET /schema/v1/current`, `DELETE /schema/v1/current` — runtime schema mgmt.
  - `GET /q/openapi` — OpenAPI doc aligned to the active schema.
  - Detached JWS (`x-jws-signature`) + DPP content validation available but off by default.
- **Key architectural fact (holistic):** the registry stores **metadata** only; the actual DPP
  payload lives at the EO's `liveURL` (decentralized). Registry hashes/optionally validates the
  payload and issues a proof. Our system must therefore ALSO host the DPP at a reachable URL,
  not just register it.
- **Keycloak pre-configured clients:** `EO-identifier` (EO submits DPPs), `public-authority`
  (schema/validator admin), `registry-be`, `validator-be`, `renderer-be`, `web-portal-fe`.
- **Container gotcha:** URLs pointing at host apps must use `host.docker.internal`, not `localhost`.
> Source: CIRPASS-2/mock-eu-registry — https://github.com/CIRPASS-2/mock-eu-registry — github — verified 2026
> Source: CIRPASS-2/deploy-resources — https://github.com/CIRPASS-2/deploy-resources — github — verified 2026

## OpenEPCIS / DPP-Ready (GitHub)

- **Type:** Open-source framework
- **Summary:** Aligns EU ESPR with GS1 data strings and the UN Transparency Protocol;
  converts factory-floor events into JSON-LD contexts the EU registry can ingest.
- **Relevance to DPP:** Bridging layer between supply-chain events and the registry.
> Source: [URL to verify] — github — from initial research pass

## OttoHandle / freeDPP (GitHub)

- **Type:** Open-source server
- **Summary:** Minimal, standards-compliant DPP server in C#/.NET Core; serialized API
  integrations, identification schemes, registry routing. Started 28 May 2026; code
  available early summer 2026 once CEN/CENELEC standards finished.
> Source: OttoHandle/freeDPP — https://github.com/OttoHandle/freeDPP — github — 28 May 2026

## Databricks DPP Solution Accelerator

- **Type:** Data pipeline toolkit
- **Summary:** Large-scale data ingestion and automated passport generation, battery-first
  data fields emphasis.
- **Relevance to DPP:** Reference for scaling passport generation pipelines.
> Source: [URL to verify] — github — from initial research pass

## Strategic note — build vs. copy

- **Summary:** Because the technical blueprint and ingestion tools are public, the basic
  "data transport bridge" is a free commodity. A startup would need proprietary,
  high-complexity logic (e.g. zero-knowledge cryptography, real-time chemical
  mass-balance engines) behind the bridge to be venture-backed.
- **Relevance to DPP:** Market positioning insight for anyone building DPP tooling.
> Source: [Unverified] — analysis from initial research pass
