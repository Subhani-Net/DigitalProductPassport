# Pillars — the acceptance criteria

The four friction-reduction pillars (see `../../../business/product-spec.md` §0) are the
**primary acceptance criteria** for the product. Each pillar has a feature file, scenarios
tagged by phase (`@p1`/`@p2`/`@p3`) and `@ignore @stub` until built.

| Pillar | Feature | Scenarios | Phase coverage |
|---|---|---|---|
| 1. Capture | `pillar-1-capture.feature` | 8 | p1×4 · p2×2 · p3×2 |
| 2. Validation intelligence | `pillar-2-validation.feature` | 12 | p1×5 · p2×3 · p3×3 |
| 3. Audit room | `pillar-3-audit-room.feature` | 6 | p1×2 · p2×2 · p3×2 |
| 4. Trust & hand-off | `pillar-4-trust.feature` | 7 | p1×3 · p2×1 · p3×2 |

**Relation to the role files (`../roles/*`):** the roles are the *customer-outcome* lens; the
pillars are the *capability* lens. Same product, two views — promote a scenario in either, and
it lands in the same code.

**Relation to already-runnable features:** `cbam-calculation.feature` (runnable) already covers
part of Pillar 2 p1; `cbam-importer-declaration.feature` (runnable) covers part of Pillar 2/4 p1.
New work promotes the remaining `@ignore` scenarios.

---

## Example Mapping — Pillar 1 (Capture)

| Rule (Feature) | Examples (scenarios) | Questions (→ stubs / decisions) |
|---|---|---|
| Ingest a file | upload CSV/XLSX → auto-map columns · unmapped surfaced | which formats first? XLSX then CSV then PDF? |
| Detect units | auto-detect t/TJ/Nm³/MWh | ambiguous units (t vs tonne label)? |
| Validate rows | reject missing quantity/unit · report to exporter | which fields are "required" at S0 vs S1? |
| Give feedback | exporter sees issues before verifier | inline vs batch feedback UX? |
| Connect systems (p2) | ERP/MES/LIMS adapter | which ERP first (SAP/Tally)? |
| Portal (p2) | multi-tenant isolation | tenant model / auth? |
| Telemetry (p3) | OPC UA/historian/CEMS | which historian first? |
| Doc extraction (p3) | MTC/CoA PDF → grade/chemistry/factors | which doc standard first (EN 10204)? |

**Phase-1 buildable now (pure logic, no OT/ERP):** ingest a file → map columns → detect units →
validate required fields → feedback. The first promotion target is the **ingest + unit-normalize
slice** (already partly proven by `cbam-calculation.feature`).

**Capture is the wedge because SAP has no supplier product and CleanCarbon is manual** — a
self-serve S0/S1 capture is the cheapest path to the non-EU mill.
