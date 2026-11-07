# CBAM Pilot Toolkit — Source Digest

**Source:** `reference/cbam_pilot_toolkit.pdf` — 3 pages, “VERIFLOW — CBAM Margin Optimization
Diagnostic”, © 2026, marked Private & Confidential. Extracted 2026-11-07 (PyMuPDF).
**Nature:** internal pilot toolkit — two operational artifacts, not a regulatory source.

## What the toolkit contains

### A. Data Request Checklist (client intake)
1. **Facility & Boundary Mapping** — plant layout/process flow; production outputs by EU CN code.
2. **Direct Fuel & Energy (Scope 1)** — fuel purchase invoices/delivery logs; coke/reducing-agent
   records for BF/DRI.
3. **Electricity & Utilities (Scope 2)** — monthly grid bills (MWh); captive power plant fuel logs.
4. **Upstream Precursor Inflow** — raw material invoices + mill certificates (billets, scrap, DRI,
   alumina, unwrought aluminium); weighbridge tickets for precursor mass.

Submission guidance: scanned PDFs, local spreadsheets, clear images are acceptable; **no ERP
integration needed**. Privacy assurance: restricted access; recipes/energy tariffs not shared with
buyers.

### B. Diagnostic & Cost-Mitigation Report (deliverable template)
- **Executive Financial Dashboard** — estimated CBAM tax savings; actual calculated SEE; EU default
  fallback rate; “export pricing power multiplier”.
- **Section 1 — Process Boundary & Metallurgy Mapping** — production route (BF-BOF / EAF /
  aluminium); system boundaries; precursor table (actual supplier sheets vs EU default, status).
- **Section 2 — Direct vs Indirect Emissions Breakdown** — Scope 1 fuel/coke/mass balance; Scope 2
  grid + captive power; domestic tax-credit deduction.
- **Section 3 — Audit-Ready Evidence Log & Drill-Down Ledger** — variable → value → source document
  link.
- **Section 4 — Strategic Next Actions** — deploy the dossier to buyers; appoint an accredited
  verifier; scale to an annual contract.

## Accuracy flags (correct before sending)

| Phrase in the toolkit | Issue | Use instead |
|---|---|---|
| “VERIFIED INPUT” | We are not the verifier; “verified” requires an accredited report | “Actual (verified report ref)” or “Default substituted” |
| “Empanelled metallurgical process engineers” | Not a current capability | “Independent specialist review” / “partner” |
| “Domestic Tax Credit Deduction” | It is an **Art. 9 carbon-price-paid deduction**, evidence-based — not a blanket tax credit | “Carbon price paid in India (Art. 9), subject to evidence” |
| “Punitive EU Default Fallback Rate” | Defaults are deliberately conservative; “punitive” is rhetoric | “EU default value (conservative)” |
| “EU Registry upload stamp” | The verifier issues the verification; the operator uploads data; the importer declares | “Verifier report → operator/declarant upload per the registry flow” |
| “Estimated CBAM Tax Savings” | The certificate saving accrues primarily to the **importer**; the exporter benefits via price/orders | “Buyer-side certificate saving; exporter pricing benefit” |
| “Compliance Context: Definitive Phase Enforcement (EU Registry Framework)” | Broad but acceptable; keep precise | “Definitive phase; annual declaration + certificate surrender by 30 Sep for prior CY” |

## Operational actions extracted (the focus)

1. Finalize the **data-request checklist** and use it in every pilot.
2. Finalize the **diagnostic report template** and keep the deliverable consistent.
3. Use the **evidence log** for every figure (source → value → determination).
4. Follow the **runbook**: qualify → request → register → map → draft → expert review → v1 → deliver.
5. Test the whole kit on the **synthetic pilot docket** before the first client.
6. Log every pilot signal in `business/outreach/tracker.md`.
7. Hand off to an accredited verifier when the client is ready (partner, not us).

## Where this lives now

| Toolkit element | Operational file |
|---|---|
| Data Request Checklist | `business/pilot/data-request-checklist.md` |
| Diagnostic report template | `business/pilot/diagnostic-report-template.md` |
| Evidence log | `business/pilot/evidence-log-template.md` (+ `.csv`) |
| End-to-end process | `business/pilot/runbook.md` |
| Overview + action checklist | `business/pilot/README.md` |
| Synthetic test data | `product/demo/pilot-docket/` |
| Expert review | `business/outreach/expert-bench.md` |
| Client pipeline | `business/outreach/tracker.md` |

## Status

Toolkit extracted and operationalised. Next: dry-run on the synthetic docket, then the first
client pilot. Keep the raw PDF in `reference/` (gitignored); this digest and the operational files
are tracked.
