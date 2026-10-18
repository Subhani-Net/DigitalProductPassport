# Role Model — DPP Registry vs CBAM Application

> The full **product specification** (outcomes → rules → scenarios) is in
> `../../../business/product-spec.md`. These feature files are its executable mirror.

Two different role models are at play; do not conflate them.

## 1. DPP Registry roles (CIRPASS-2 mock, what our integration tests hit today)

| Role | Keycloak client | What it does |
|---|---|---|
| `admin` (public authority) | `public-authority` | Manage metadata schemas (`POST /schema/v1`), validator configs |
| `eo` (Economic Operator) | `eo-EO-…` | Submit DPP metadata + fetch proof of registration |
| `eu` (End User) | `web-portal-fe` (public) | Read/browse passports (read-only) |
| internal | `registry-be`, `validator-be`, `renderer-be` | service-to-service |

## 2. CBAM application roles (our product's three user classes)

| Role | CBAM actor | Registry module | Actions |
|---|---|---|---|
| **Importer** | Authorised CBAM Declarant | AMM | authorisation, EORI link, retrieve verified data, annual declaration, certificates |
| **Exporter** | Non-EU installation operator | O3CI | register installation, upload data, verifier-ready evidence, share via EORI |
| **Verifier** | Accredited verifier | O3CI | review, recalculate, drill-down audit, issue verification report |

**Answer:** the exporter, importer, and verifier are **three distinct actors** — not all "EO".
"EO" is a DPP/ESPR term for the manufacturer/importer/distributor that registers a passport.

## 3. Test status by role

| Role | Status | Where |
|---|---|---|
| `eo` (DPP submit) | ✅ runnable | `registry-*.feature` |
| Importer (declarant) | 🟡 spec stub (`@ignore`) | `roles/cbam-importer.feature` |
| Exporter (operator) | 🟡 spec stub (`@ignore`) | `roles/cbam-exporter.feature` |
| Verifier | 🟡 spec stub (`@ignore`) | `roles/cbam-verifier.feature` |
| admin (public authority) | 🟡 spec stub (`@ignore`) | `roles/platform-admin.feature` |
| `eu` (end user) | 🟡 spec stub (`@ignore`) | `roles/end-user.feature` |

Stubs are tagged `@ignore` so they don't fail the suite; they are the **living specification**
to implement against.
