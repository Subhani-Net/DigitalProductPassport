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
| *(to add from chunk C1 onward)* | | | | | | |

## Pending harness set-up

- [ ] CIRPASS-2 mock registry running locally (S1)
- [ ] TracePass iron & steel JSON Schema loaded as validator
- [ ] EC DPP Registry "User Guide for Economic Operators" reviewed (L2)
