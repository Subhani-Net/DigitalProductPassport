# Handoff — DPP CBAM Input Validation (fork)

**Session name:** DPP CBAM input validation
**Fork point:** 7 November 2026
**Focus:** Phase 3 — Map & validate: system boundary, source streams, precursors, production
outputs by CN code, units and gaps.

## Where we are

- The **pilot toolkit** is operational: `business/pilot/` — data request checklist, diagnostic
  report template, evidence log, and the 2-week `runbook.md`.
- The current work is **Phase 3 of the runbook** — turning the five open process questions into
  concrete tools.
- The **app-shell spec** is separate (`business/website/specs/`): C#/.NET + EF Core, single DB +
  RLS, Azure Blob + SAS, permission groups, auth/engine stubs, story plan.
- The **CBAM engine** and its BDDs in `product/` are untouched and manual/phased.
- Leads (`business/outreach/leads-india-exporters.md`, `leads-priority.md`, `tracker.md`) and the
  expert bench (`expert-bench.md`) exist.

## Principles agreed in the parent session

1. **We draft, the customer confirms, the verifier assesses.** The operator owns the monitoring
   plan/boundary; we never impose one.
2. Use **structured checklists** (by source-stream class / Annex I input), not open-ended
   "send everything" and not a rigid list.
3. Validate production outputs via **CN mapping, period alignment, sales/production
   reconciliation, mass balance/yield, energy intensity, allocation**.
4. Maintain a **gap register**: every gap has a fallback (default) and a cost estimate.
5. **Verifier-ready, not verified** — never label unverified data “verified”.

## Open questions to resolve in this fork

1. Confirm the **“we draft, they confirm”** model (vs letting the customer define the boundary).
2. Keep source-stream/precursor requests as **checklists** (vs free-form).
3. Build all six Phase 3 templates, or start with boundary + source streams + gap register?
4. Add a **CN-code lookup helper** (common steel/aluminium codes) to the pilot kit?
5. CN validation strictness: accept the customer’s classification, or require **customs/sales
   invoices** as evidence?

## Proposed deliverables

- `business/pilot/boundary-worksheet.md`
- `business/pilot/source-stream-inventory.md`
- `business/pilot/precursor-register.md`
- `business/pilot/production-by-cn.md`
- `business/pilot/unit-period-check.md`
- `business/pilot/gap-register.md` (+ `.csv`)
- Update `business/pilot/runbook.md` Phase 3 to reference them.

## Read first

- `business/pilot/runbook.md` — Phase 3
- `business/pilot/data-request-checklist.md` — what we already ask for
- `knowledge/research/cbam-data-catalogue.md` — sections B (source streams), D (precursors),
  E (production/allocation), G (evidence)
- `knowledge/research/cbam-input-sources.md` — where the data lives, by plant area
- `knowledge/research/cbam-pilot-toolkit.md` — source digest + accuracy flags
- `knowledge/learning/cbam-201/02-monitoring-plans-and-data-quality.md` — monitoring plan
- `knowledge/learning/cbam-precursors/` — precursor calculation and scenarios

## Next step

Build the Phase 3 templates, update the runbook, then **dry-run the whole kit** on
`product/demo/pilot-docket/` before the first client pilot.
