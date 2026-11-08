# CBAM Pilot — Operational Toolkit

Run a **2-week concierge pilot** end-to-end: request the right documents, produce a draft SEE with
an evidence trail, get an independent expert review, and deliver a **verifier-ready** diagnostic
pack. Based on `reference/cbam_pilot_toolkit.pdf` (digest:
`../../knowledge/research/cbam-pilot-toolkit.md`).

The engine is manual for now; this kit is how we deliver it consistently.

## Artifacts

| File | Use |
|---|---|
| `data-request-checklist.md` | What to ask the client for (send on day 0) |
| `diagnostic-report-template.md` | The deliverable we hand back |
| `evidence-log-template.md` / `.csv` | Trace every figure to a source document |
| `runbook.md` | The step-by-step operating procedure |
| `phase3-input-validation-guide.md` | **Full Phase 3 process** — responsibility, boundary, streams, precursors, outputs, units, gaps |
| `boundary-worksheet.md` | Phase 3 — draft/confirm the system boundary |
| `source-stream-inventory.md` | Phase 3 — structured source-stream checklist |
| `precursor-register.md` | Phase 3 — CBAM-covered inputs, mass and SEE source |
| `production-by-cn.md` | Phase 3 — outputs by CN, reconciliation and mass balance |
| `unit-period-check.md` | Phase 3 — units, periods, factors, plausibility |
| `gap-register.md` / `.csv` | Phase 3 — gaps with fallback, impact, owner, due |
| `cn-code-helper.md` | Common steel/aluminium CN codes (verify against Annex I) |
| `../../product/demo/pilot-docket/` | Synthetic dry-run data before the first client |

## Roles

| Role | Who | Does |
|---|---|---|
| **Pilot lead** | Founder | Qualify, request, map, draft, deliver |
| **Independent reviewer** | Expert bench (paid 3 hrs) | Stresses the methodology before v1 |
| **Partner verifier** | Accredited body (later) | Issues the verification report |
| **Client contact** | Exporter owner/export head | Supplies documents, confirms scope |

## Action checklist (the focus)

- [x] Data-request checklist drafted
- [x] Diagnostic report template drafted
- [x] Evidence log template drafted
- [x] Runbook drafted
- [x] Phase 3 templates drafted (boundary, streams, precursors, outputs, units, gaps, CN helper)
- [ ] Dry-run on the synthetic pilot docket
- [ ] Prepare privacy/NDA note for clients
- [ ] Book one independent reviewer (3 hrs)
- [ ] Run first client pilot
- [ ] Deliver v1 + walkthrough
- [ ] Introduce a partner verifier
- [ ] Convert to an annual plan

## Guardrails

- **“Verifier-ready, not verified.”** Never put “verified” on our draft.
- **Privacy:** documents are accessed by the pilot lead and the independent reviewer only; the
  client’s recipe and energy tariffs are never shared with buyers.
- **No ERP access** is required for the pilot; scanned PDFs and spreadsheets are fine.
- **One pilot at a time**; time-box to two weeks.
- **Defaults are legal but costly** — flag every default line and quantify the gap.
- **No fabricated figures**; use placeholders until the source is confirmed.

## Status

Toolkit drafted (Nov 2026). Next: dry-run on `product/demo/pilot-docket/`, then the first client
pilot. Link the pilot to a tracker row in `../outreach/tracker.md`.
