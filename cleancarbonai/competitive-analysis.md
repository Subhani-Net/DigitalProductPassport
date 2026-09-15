# CleanCarbon.ai — Competitive Analysis (vs our roadmap)

Fact-based read of their pipeline against our `../business/product-roadmap.md` P1/P2 (CBAM-first
wedge → DPP). Goal: **replicate the wedge mechanics, out-build them on the DPP side.**

## What they actually are

A CBAM-reporting **consulting + light SaaS** business for Indian exporters. Pipeline =
ingest plant/energy data → calculate embedded emissions → produce EU-ready XML/Excel
quarterly reports → optionally verified/validated in-house (ISO 14065/17029 certificates) →
"reduce carbon tax" (actual values beat defaults). This is exactly our C3→C5 wedge, delivered
as a service with a 12-hour/same-day turnaround claim.

## Replicate (validated mechanics worth copying)

1. **4-step onboarding, per-vertical landing pages** (iron & steel / aluminium / suppliers /
   tractor OEMs) — the "send us your plant and energy details → we calculate → quarterly
   reports → stay export-ready" motion is the CBAM wedge productized. Our C3/C4 ingestion
   + C5 engine maps 1:1; their sector pages validate our vertical focus.
2. **Free lead-gen tools:** CBAM Tax Calculator (product + emissions → €75.36/t exposure)
   and **HSN→CN code checker**. Cheap to build; high-funnel. The €75.36/€75.28 certificate
   price feed is public (EC publishes quarterly).
3. **EU-ready XML/Excel output** — the CBAM Registry's actual upload format (XML structure +
   XLS support file). Our C5 must emit the same formats as a first-class output.
4. **Supplier-side tooling** (invoice/shipment-linked emissions, supplier communication,
   real-time supply-chain dashboard) — their version of multi-tier aggregation. Maps to our
   harmonization chunk; their Escorts-Kubota case ("35 suppliers, 100% data submission")
   proves the demand.
5. **ERP integration claim** ("Smooth integration with your ERP") as the SME wedge — the
   sales argument we already planned for data adapters.
6. **Institutional trust stack:** Ministry of Commerce + SEPC "Carbon Cell" + EEPC
   partnership + SEBI ESG-rating registration. For the Indian-exporter segment, government
   endorsement is the acquisition channel.
7. **Verification in-house** (ISO 14065 + ISO/IEC 17029 + ISO 14064-1 certificates) →
   "verified & validated reports" as a product feature. Note for us: this is the P2
   verification-body option in `../compliance-matrix.md` §3 — build OR partner.

## Where they are weak (our improvement space)

1. **No DPP path.** Zero mentions of the EU DPP Registry, CEN/CENELEC, JSON-LD, GS1 Digital
   Link, QR carriers, data spaces, or the ~2028 steel DPP obligation. They end at the CBAM
   report. **Our sell-twice engine (CBAM data → DPP passport) is the structural
   differentiator.**
2. **No methodology transparency:** no published formulas, emission-factor tables, or
   boundaries for their calculator — only "subject to verification" disclaimers. Our
   compliance matrix + CELEX-traceable schemas beat that on auditability (a real sales
   argument to EU importers who bear the legal liability).
3. **Quality gaps:** inconsistent stats (200/400/500+ clients; 5 vs 8 years in production),
   duplicated feature bullets, "Lorem ipsum" placeholders on their own CBAM resources page,
   dead links. Marketing outruns engineering — an execution-quality opening.
4. **Educational content is mostly the EC FAQ reproduced** — commodity content; not a moat.
5. **No public API, no named ERP/SAP/Tally integrations, no tech stack transparency** —
   their "ERP integration" is a claim, not a documented integration layer. Our documented
   adapter/API surface can win enterprise procurement scrutiny.
6. **India-focused delivery** (phone/WhatsApp, Calendly, consulting-led). A product-led,
   self-serve or API-first wedge for EU importers + non-Indian suppliers is open territory.

## Positioning against them (for our roadmap)

| Dimension | CleanCarbon.ai | Us (planned) |
|-----------|----------------|--------------|
| Wedge | CBAM reports (India exporters) | CBAM data pipeline (any jurisdiction) |
| Data model | Opaque | Schemas-as-data, CELEX-traceable, compliance-matrix evidence |
| Endgame | Stops at CBAM report | CBAM → DPP passport → Registry (sell-twice) |
| Identity/carrier | None | GS1 Digital Link, QR, EO-owned URLs |
| Verification | In-house certs (claimed) | T1/T2 harnesses + verifier-partnership option |
| Interop | None | EDC/AAS, JSON-LD, data spaces (P2) |
| Moats | Government endorsements | Mass-balance/PCF engine + trust layer + DPP bridge |

## Action items for our build (small chunks)

1. C5 must emit **CBAM XML/Excel formats** (registry upload structure) — add to C5 exit
   criteria and to the compliance matrix targets.
2. Add a **CN/HSN checker + CBAM tax estimator** as a free lead-gen tool to P1/P2 scope
   (tiny build, high funnel value; needs the EC quarterly price feed).
3. Track the **certificate price feed** (Q1 €75.36 / Q2 €75.28) as a data input in C2.
4. Keep the **verifier-or-partner decision** open until P2 (ISO 17029/14065 route
   now has a concrete market precedent).
5. Their "12-hour/same-day report" is service-led throughput — our automated pipeline can
   match it product-led; use it as the P2 marketing benchmark.

> Sources: all pages in `sources.md`; analysis is ours, grounded only in captured facts.
