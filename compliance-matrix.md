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
