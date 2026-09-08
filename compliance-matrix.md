# Compliance Matrix

Living record mapping **guideline/standard → our implementation → test evidence**. This IS
our self-certification evidence (Tier 2 of the certification model in `product-roadmap.md`).
Per `AGENTS.md`, every build chunk must update it.

## How to record a row

| Column | Meaning |
|--------|---------|
| ID | Stable code (e.g. T1-MET-001) |
| Guideline / standard | What we must conform to (CBAM calc rule, TracePass field, CEN/CENELEC, registry API, JSON Schema draft...) |
| Source | CELEX / spec / repo reference |
| Our implementation | Module/file that realises it |
| Test harness | Which tool/endpoint verified it (CIRPASS-2 registry, TracePass validator, Tractus-X harness...) |
| Evidence | Result + date (e.g. "201 Created, registryId ..., 2026-09-05") |
| Status | Pending / Passing / Blocked / Deferred |

## Matrix

| ID | Guideline / standard | Source | Our implementation | Test harness | Evidence | Status |
|----|----------------------|--------|--------------------|--------------|----------|--------|
| T1-REG-001 | Mock EU registry registration: metadata entry + reachable DPP at liveURL (decentralized hosting), reoId from JWT claim, Proof-of-Registration JWT | CIRPASS-2 mock-eu-registry (v1.1.1) | S1 spike: REST POST via client-credentials token; static DPP host on :9090 | mock-eu-registry :8082 + Keycloak :8180 (realm cirpass-2), client `eo-EO-529900T8BM49AURSDO10` | 201 → registryId `e3eb36a2-a965-11f1-b830-05558a99e842`; dppHash `sha256:caecf7ef…`; proof JWT retrieved (reoId `EO-529900T8BM49AURSDO10`, reoName `EO-Company123`) — 2026-09-05 | Passing |

## Pending harness set-up

- [x] CIRPASS-2 mock registry running locally (S1 — docker compose env up, all 8 services healthy)
- [ ] TracePass iron & steel JSON Schema loaded as validator (needs schema uploaded to dpp-validator via `public-authority` client — defer until C2/C6)
- [ ] EC DPP Registry "User Guide for Economic Operators" reviewed (L2)
- [ ] **EU DPP Registry testing environment** — public since 20 Jul 2026:
  `https://registry.acc.product-passport.ec.europa.eu` (create a separate EU-login account
  for testing); live env `https://registry.product-passport.ec.europa.eu`; helpdesk
  `EC-HELPDESK-DPP@ec.europa.eu` (+32 2 296 04 31). Authoritative T1 conformance target
  beyond the mock. (Source: EC DPP Registry page, 7 Sep 2026)
- [ ] CEN/CENELEC DPP standard documents acquired (paywalled via national standards body — budget item; exact standard IDs to be confirmed in L6)

---

## Operating model — conform → build → learn/hire → validate

### 1. Conformance targets (what we must conform to)

| # | Target | Governing artifact | Our conformance mechanism | Learning block / chunk |
|---|--------|--------------------|---------------------------|------------------------|
| 1 | **CBAM embedded-emissions calculation** (steel & aluminium) | Implementing Reg. (EU) 2023/1773 (calc methodology) + default values + Art. 8 verification rules (Reg 2023/956) | C5 calculation engine; verifier-passable outputs (monitoring data, unit consistency, audit trail) | L1 → C5 |
| 2 | **CBAM declarant/reporting flow** | CBAM Registry + annual declaration mechanics | Wedge output format + import/declaration data mapping | L1 |
| 3 | **TracePass iron & steel field set** | 913 fields / 12 categories, CELEX-traceable (343 in force, 187 anticipated) | C2 schema engine loads TracePass schemas-as-data; field registry with legal citations | L4 → C2 |
| 4 | **CEN/CENELEC DPP standards** | Six adopted Jul 2026 + two Sept 2026 (implementing decisions; IDs [verify L6]) | Data model (JSON-LD), carrier, registry-interface alignment in C6 | L6 |
| 5 | **Registry API + decentralized hosting** | EU DPP Registry (live + test env, 20 Jul 2026); CIRPASS-2 mock as local proxy | C6 registration client (OIDC, register, update strategies, proof fetch + JWKS verify) + DPP host at EO-owned liveURL | S1 done (mock) → C6 |
| 6 | **JSON Schema draft 2020-12** | Registry/validator validation vocabulary | C2 schema engine (validate all payloads with the same draft) | C2 |
| 7 | **GS1 Digital Link (carrier)** | GS1 standard | Adopt GS1 resolver; QR/URI generation in C6 | L5 |

### 2. Capabilities we build (ours)

| Capability | Realises | Chunk |
|------------|----------|-------|
| Schema engine (schemas-as-data, versioned, CELEX-traceable) | Targets 3, 6 | C2 |
| Ingestion + harmonization (ERP/CSV → canonical model, unit normalization) | Target 1 inputs | C3, C4 |
| Calculation engine (CBAM actual/default values; PCF; mass-balance) | Target 1 | C5 (M2) |
| Passport generator (JSON-LD per CEN model) + DPP host (liveURL/backupURL, EO domain) | Targets 4, 5 | C6 |
| Registration client (OIDC per-EO, register/update, proof verify via JWKS) | Target 5 | C6 |
| Trust layer (dppHash chain, detached JWS, later eIDAS seal / VCs) | Targets 4, 5 | C8 |
| **Verifier enablement / validation intelligence** (evidence dossiers, audit trails, recalculation support served to the verifier user class) | Targets 1, 2 | C7, C8 |
| Conformance CI (mock registry, dpp-validator, TracePass, Tractus-X runs auto-recorded) | All | C7 |
| Compliance-matrix automation (test runs → evidence rows, not manual notes) | All | C7+ |

### 3. Learn vs hire vs external validation

**Learn ourselves (no hire — public primary sources):** CBAM calc rules, JSON Schema,
GS1 Digital Link, registry API, TracePass field set. All are documented primary material.

**Buy (material cost, not hiring):** CEN/CENELEC standard documents (paywalled) — one-time
purchase via a national standards body.

**External validation/verification to include (non-negotiable):**
- **Official EU DPP Registry testing environment** — the authoritative conformance target;
  request access now (test env launched 20 Jul 2026).
- **Accredited CBAM verifier — partner-only (LOCKED Sep 2026).** Under Reg 2023/956 Art. 8,
  embedded-emissions data used by declarants must be verified by an accredited body. We
  cannot verify ourselves (independence/self-review rule, ISO 17029/14065): our C5 outputs
  must be designed to pass verifier scrutiny, and at P2 we partner with an accredited
  verification body (TÜV SÜD-type; India-reach preferred) so customers get verified
  reports. **Own arm's-length verification entity = keep-open option gated on volume,
  NOT a roadmap target.**
- **Free harnesses (T1/T2):** CIRPASS-2 dpp-validator, TracePass schema validation,
  Tractus-X DPP Verification add-on — run in CI (C7).
- **T3 CAB certification** — only on customer demand (P2+).

**Hire (gated, not now):**
- Steel PCF / mass-balance domain expert — at P2, only if calculation accuracy becomes a
  liability or a differentiation lever (this is the defensible-IP layer).
- Regulatory/legal counsel — when the **DPP Service Provider delegated act** lands
  (Q2–Q3 2027); it defines duties for platforms like ours.
- Verification-body partnership — at P2, for the customer verification path.

### 4. How the matrix is maintained

Every chunk run produces evidence: CI executes the harnesses (C7) and each result becomes a
row here (machine-generated, not manual). The matrix stays the living T2 self-certification
record; the official registry test env upgrades it from "mock-conformant" to
"EU-conformant" evidence as soon as access is granted.
