# Friction-Gap Analysis — Where the Incumbents Are Weak

The four friction pillars that are the *real* product (see `../business/product-spec.md` §0),
checked against the incumbents. Purpose: confirm we are not building into their strength, and
identify what we **adopt** as building blocks vs what we **build** as the wedge.

## 1. Pillar × incumbent — weakness map

| Pillar | Incumbent reality | Our wedge (the friction we kill) |
|---|---|---|
| **Capture** | CarbonChain: ERP/CTRM/Excel, both sides. Minespider: Excel + AI pre-fill. CleanCarbon: *manual service*. **SAP: declarant-only — no non-EU supplier product.** | Self-serve **S0/S1-first** capture with column auto-map + unit auto-detect for **non-technical non-EU mills**; the supplier side SAP leaves open. |
| **Validation intelligence** | CarbonChain: "SGS-validated methodology + AI/human" (claimed). Circularise: mass-balance. CleanCarbon: in-house ISO 14065/17029 (certificate ≠ accreditation). | **Metals-route-specific** (BOF/EAF/DRI, PFC, scrap, boundaries) + **CELEX-traceable** + verifier-ready evidence, with the stamp left to **accredited partner verifiers** (not a thin self-claim). |
| **Audit room** | SAP: Green Ledger (declarant-side). Circularise: chain-of-custody. No incumbent has a *verifier-facing* evidence room. | **Read-only drill-down room for verifiers** — the third user class; validation intelligence productized *for* the auditor. |
| **Trust / zero-exposure** | Circularise: permissioned disclosure (partial). Minespider: blockchain identity (traceability, not zero-knowledge). | **Zero-exposure hand-off** — supplier recipe/energy mix never shown to the importer; proof not data (SNARK, P2 spike). |

## 2. Building blocks to adopt (do not rebuild)

| Incumbent | Adopt as |
|---|---|
| **Circularise** | n-tier "Collect" pattern · GS1 Digital Link carrier · auditable mass-balance/chain-of-custody |
| **Minespider** | one-click EU-DPP-registry submission pattern (proves the bridge sells) |
| **SAP** | Green Ledger / ERP integration as the **integration target** — we integrate via API, we don't compete |
| **CleanCarbon** | India services-reach as the **Xero-style partner/services line** pattern |
| **CarbonChain** | both-sides + methodology = the *commodity bar*; their gaps (no DPP, no India services, closed evidence) are our opening |

## 3. Positioning statement (the holistic differentiator)

> We do not sell a CBAM calculator. We turn a messy non-EU supplier's data into a
> **clean, verifier-ready, zero-exposure upload once** — so the importer's declaration
> survives audit at the lowest cost, and the supplier wins/retains EU business.

The calculator and the canonical model are the *commodity substrate*; the four pillars above
are the friction-reduction offering. Phased build of those pillars is in
`../business/product-spec.md` §0.

> Sources: `landscape.md` + dossiers (`carbonchain`, `sap`, `circularise`, `minespider`) +
> `../cleancarbonai/` — all fetched 6–7 Sep 2026.
