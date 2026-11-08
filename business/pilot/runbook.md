# Pilot Runbook — 2 Weeks, One Installation

Operating procedure for the concierge pilot. Work top to bottom; do not skip the gates.

**Time-box:** 10 working days. **One pilot at a time.** **Status:** track in
`../outreach/tracker.md` (Qualified → Pilot → Paid).

## Roles

| Role | Responsibility |
|---|---|
| **Pilot lead** | Runs the process, owns the client relationship |
| **Independent reviewer** | 3-hour methodology review before v1 |
| **Partner verifier** | Accredited verification (after the pilot, on client request) |
| **Client contact** | Supplies documents, confirms scope and success metric |

---

## Phase 0 — Qualify (before the clock starts)

- [ ] Client is an **exporter** of steel/aluminium goods to the EU (or their supplier).
- [ ] One **installation** and one **reporting period** can be scoped.
- [ ] The client can share documents (PDF/spreadsheet/image) — no ERP access needed.
- [ ] A named contact and a decision-maker are available.
- [ ] Tracker row exists; stage → `Qualified`.

## Phase 1 — Kickoff (30 min, day 0)

- [ ] Confirm installation, reporting period, products/CN codes.
- [ ] Agree the **success metric in the client's words** (e.g., “a SEE our buyer's verifier will
      accept” / “the actual-vs-default saving”).
- [ ] Confirm confidentiality: recipe/energy tariffs not shared with buyers.
- [ ] Send the **data request checklist** (`data-request-checklist.md`) and the return date.
- [ ] Book the independent reviewer (3 hours) for **day 8**.
- [ ] Stage → `Pilot`.

## Phase 2 — Intake (days 1–3)

- [ ] Receive documents; confirm completeness against the checklist.
- [ ] Register each document in the document register (name, type, period, source, hash, status).
- [ ] Convert/scan if needed; keep originals untouched.
- [ ] Flag missing items immediately; agree defaults where necessary.
- [ ] **Gate:** minimum viable set received, or defaults agreed in writing.

## Phase 3 — Map & validate (days 3–5)

Use the Phase 3 templates:
`boundary-worksheet.md` · `source-stream-inventory.md` · `precursor-register.md` ·
`production-by-cn.md` · `unit-period-check.md` · `gap-register.md` (+ `.csv`) · `cn-code-helper.md`.
Full process and worked examples: `phase3-input-validation-guide.md`.

- [ ] Draft the **boundary worksheet** from the process flow and customer facts; customer confirms.
- [ ] Complete the **source-stream inventory**; check route completeness (BF-BOF/EAF/DRI/Al).
- [ ] Complete the **precursor register**; validate against purchases, mill certs and weighbridge.
- [ ] Complete **production by CN**; reconcile production/sales/stock and check mass balance/yield.
- [ ] Run the **unit/period/factor** checks; record factors with source and version.
- [ ] Open the **gap register**; every gap has a fallback + cost + owner + due date.
- [ ] **Gate:** every figure has an evidence-log row (or a documented gap with a fallback).

## Phase 4 — Draft SEE (days 5–7)

- [ ] Calculate **direct** emissions (and indirect where applicable).
- [ ] Add **precursors**: `Σ(Mᵢ × SEEᵢ)`.
- [ ] Apply allocation if multiple products; document the rule.
- [ ] Use **actual** where a valid verification report exists; otherwise **default** and flag it.
- [ ] Calculate **actual vs default** and the **buyer-side saving** (illustrative).
- [ ] Record assumptions in the report.
- [ ] **Gate:** draft SEE + evidence log + assumptions complete.

## Phase 5 — Independent review (day 8)

- [ ] Send the reviewer the **synthetic twin** if the client data is sensitive (no identifying
      details), plus the six stress-test questions (`../outreach/expert-brief.md`).
- [ ] 3-hour review; written critique with severity.
- [ ] Capture findings as rules/checks/test cases
      (`../../knowledge/research/expert-session-template.md`).
- [ ] Fix; produce **v1**.
- [ ] **Gate:** written critique received; v1 produced.

## Phase 6 — Report & evidence (days 9–10)

- [ ] Complete `diagnostic-report-template.md` (placeholders replaced).
- [ ] Complete the evidence log; every report figure maps to a row.
- [ ] Check the boundary line: **“verifier-ready, not verified.”**
- [ ] Remove any overclaim (“verified”, “audit-guaranteed”, “engineers on site”).
- [ ] **Gate:** report, evidence log, assumptions, and gaps are internally consistent.

## Phase 7 — Deliver & walkthrough (day 10)

- [ ] Send v1 + evidence log + 1-page summary.
- [ ] 20-minute walkthrough: SEE, evidence, saving, next steps.
- [ ] Ask for one of: verifier introduction, testimonial, annual plan, or a clear “no” + reason.
- [ ] Log the signal and next action in the tracker.

## Phase 8 — Hand-off / close

- [ ] If proceeding: introduce a **partner verifier**; share the evidence pack (with consent).
- [ ] If proceeding: scope the annual plan (one installation, unlimited EU buyers).
- [ ] If not: record why; offer to stay in touch for the next cycle.
- [ ] Stage → `Paid` or `Lost` (with reason).
- [ ] Capture what changed in the product/spec.

---

## Status board (internal)

| Stage | Meaning |
|---|---|
| `Qualified` | Fit confirmed; pilot offered |
| `Pilot` | Scope agreed; documents in progress |
| `Review` | Expert review booked/in progress |
| `Delivered` | v1 delivered; awaiting decision |
| `Paid` | Converted to annual plan |
| `Lost` | Declined; reason recorded |

## Quality gates (do not deliver without)

- Every figure has an evidence-log row or a documented default.
- Determination (`ACTUAL`/`DEFAULT`) is explicit on every line.
- Assumptions are written down.
- The boundary line is present: **verifier-ready, not verified**.
- No unsupported claims; no invented numbers; no “verified” badge.

## Failure modes → action

| Failure | Action |
|---|---|
| Client cannot find documents | Use the minimum viable set; default + flag; plan next cycle |
| No verified precursor data | Default for that line; quantify the cost |
| Reviewer unavailable | Delay v1; do not ship an unreviewed first report |
| Report contradicts evidence log | Stop; fix the source of truth before sending |
| Client asks for “verification” | Explain the partner verifier; never self-stamp |
| Data too sensitive | Use a synthetic twin for review; keep raw data restricted |

## Do / Don't

- **Do** keep the pack traceable and honest.
- **Do** show the saving in euros, with assumptions.
- **Don't** claim “verified”, “certified”, or “audit-guaranteed”.
- **Don't** promise engine automation that isn't built.
- **Don't** take a second pilot before the first is delivered.
