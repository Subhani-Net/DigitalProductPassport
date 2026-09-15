# Go-to-Market & Market Sizing

Market read for the CBAM → DPP platform (recorded Sep 2026). Tagging discipline:
**Fact** = sourced figure; **Estimate** = model input to validate at pilots. Sources inline.

## Business & product model (decision, Sep 2026)

- **Self-serve SaaS is the product; services are an offering or third-party — on the Xero
  model.** The software is open to all customers (EU importers/declarants AND non-EU
  suppliers). Hand-holding services are delivered either by us as an optional managed
  offering or by a **partner ecosystem** (verifiers, consultants, customs agents = the
  "accountants/bookkeepers" of the Xero model) building on our platform.
- **Two-sided flow (the product core):**
  - **Supplier side:** ingestion + **validation of input** → suppliers get validated,
    verifier-ready input (their proprietary data stays theirs).
  - **Importer side:** receives **validated input + formatting** → CBAM XML/Excel,
    declaration-ready, audit-evidenced.
- **Trust direction: aiming at SNARK / zero-exposed data.** Validation happens so that the
  supplier's proprietary detail is **never exposed to the consumer/importer counterparties** —
  proof via zero-knowledge attestation, not data sharing. SNARK stays gated by the P2 ZK
  spike for feasibility/timing (see `../business/product-roadmap.md` §4), but is now the explicit
  target architecture of the trust layer.
- **Verification stamp = partner accredited verifiers only (locked Sep 2026).** We maximise
  our capability everywhere in the ecosystem *except* the stamp itself: an own arm's-length
  accredited verification entity is a keep-open option gated on volume, not a roadmap
  target. Independence rule (ISO 17029/14065): a verifier cannot assure work done by its
  own affiliate — so the stamp stays third-party until volume justifies a firewalled
  separate entity.
- **Three user classes:** supplier, importer, **and the verifier** — validation intelligence
  (evidence dossiers, audit trails, recalculation support) is productized *for verifiers*
  to make their audits efficient; their efficiency is our wedge on the assurance side.
- **Moat = encoded validation intelligence (3-layer view).** Plumbing (schemas, transforms,
  connectivity, registrations) is plain engineering — commodity. The moat is layer 3: the
  schema/calculation/validation models that encode metallurgy + industrial-process +
  verifier-grade judgment — designed in with an **external verifier-grade consultant**
  (engaged after the C2–C4 scaffolding is validated, to detail schema, data capture and
  calculation models). This is our differentiation vs plain-software competitors who have
  only layers 1–2.

## Market shaping (facts, Sep 2026)

- CBAM definitive phase live since 1 Jan 2026; annual declarations + certificates; first
  certificate surrender **30 Sep 2027**. (cbamguide.com, Jul 2026)
- **50 t/yr de minimis** (Omnibus, Oct 2025): only importers above the threshold are in
  scope — smaller but higher-value buyer pool. (DEHSt/FT Mercati)
- By Jun 2026: **>12,000 EU importers applied** for authorisation; **>4,100 authorised**;
  "thousands more" importing iron/steel/aluminium still to apply. (cbamguide.com)
- CBAM certificate price: Q1 2026 €75.36/t; Q2 2026 €75.28/t (EU quarterly publication).
- Steel safeguard regime tightened 1 Jul 2026 — a second compliance driver on the same
  buyers. (CSDDD Navigator)
- Competition forming: CarbonChain (both sides), SAP (declarants, Jun 2026), CleanCarbon
  (India service); Minespider submits to the live EU DPP Registry (batteries). Accredited
  CBAM verification capacity scarce (SGS/BV still applicants). Our slot = supplier-side +
  verifier-ready evidence + zero-exposure trust + metals DPP bridge.
  (See `../competition/`.)

## Segments & sizing (Estimates — validate)

| Segment | Who | Est. in-scope | Near-term addressable |
|---|---|---|---|
| A. EU metals importers/declarants (>50 t) | steel/aluminium/fastener importers | 6,000–12,000 EU | 2,000–4,000 |
| B. Non-EU exporters/suppliers (data providers) | India, Turkey, UK, China exporters | 20,000–50,000 globally | 3,000–8,000 (India/UK beachhead) |
| C. DPP economic operators (2028–29) | EU steel/aluminium producers+importers → textiles | 1,000–3,000 (metals); 10,000+ (textiles, P3) | grows from A/B |
| D. Verification-ready services | same A/B + verifier partners | overlaps A/B | 5–15% of A/B at P2 |

**Need vs gettable:** thousands of companies *need* the software (A+B ≈ 10,000+ realistic);
the served market we can land solo in years 1–3 is **tens → low hundreds**: ~10–25 by
mid-2027 (wedge), ~50–150 by 2028, then the DPP obligation converts the same buyers.

## Why they buy (triggers, priority order)

1. **Money saved:** actual verified values vs punitive defaults (defaults raise cost
   ~20–25% — CleanCarbon claim; CarbonChain: "default values are punitive") at €75.36/t.
2. **Liability + deadline:** importer owns all liability (penalties €10–50/t); first
   certificate surrender 30 Sep 2027 → verifier-ready evidence is bought to pass audits.
3. **Market access:** EU customs verifies DPP registration at import; EU buyers demand
   verified CBAM data from suppliers.
4. **Automation:** replace spreadsheet chaos (CleanCarbon claims ~70% manual-effort cut).
5. **Second squeeze:** steel safeguard (Jul 2026) turns compliance into one buying decision.

## Pricing — low / base / high (Estimates, anchored to observed market)

| Tier | Includes | Annual price | Anchors |
|---|---|---|---|
| Low (self-serve SME) | CBAM calc + reporting for one importer/exporter, XML/Excel out | €1,000–3,000 | DPP-Tool €350–4,800/yr |
| Base (our wedge) | CBAM engine + supplier data validation + audit trail + verifier-ready outputs | €8,000–15,000 | Greenly SME; Minespider €11.9k |
| High (enterprise) | multi-site + supplier network + zero-exposure attestation + DPP module + Registry submission + managed verifier hand-off | €30,000–60,000 | Minespider €34.5k; SAP higher |
| Managed/service line (optional) | CleanCarbon-style hand-holding for exporters without capability | €2,000–5,000/client, €10k+ groups | CleanCarbon service model |

## Revenue envelope (Estimate)

- 30 Base clients by 2028 ≈ €300–450k ARR; 100 (Base+High mix) ≈ €1.2–1.8M ARR — the
  realistic P2/P3 scale-out before the textiles wave.

## Assumptions to validate (before betting)

1. Metals-declarant split of the 12k+ applicant pool (6k–12k assumption).
2. Willingness-to-pay for verifier-ready evidence vs raw calculation tools.
3. Self-serve activation for non-EU suppliers (Excel-first personas) vs services-led need.
4. SNARK/zero-exposure demand — tested by the P2 ZK spike, not assumed.
5. Partner (Xero-style) channel readiness: verifiers/customs agents who want the platform.
