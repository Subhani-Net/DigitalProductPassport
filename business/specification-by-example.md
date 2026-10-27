# Specification by Example — Playbook

How we define and build the product, sprint at a time, with Gherkin scenarios as the
**executable specification**. Companion to `sprint-plan.md` (the date/backlog master) and
`presentation-plan.md` (the Present dimension).

## Principle

A story is not "done" until its acceptance criteria exist as Gherkin scenarios and the customer
outcome is named. Scenarios are the contract between us and the customer; the Reqnroll test
report is the living documentation of that contract.

## The per-sprint loop

1. **Select** the sprint's stories from `sprint-plan.md`.
2. **Example Mapping** (20–40 min/story): produce `rule → examples → questions` cards.
3. **Write** the feature/scenario files (acceptance criteria in business language).
4. **Implement** step definitions + code, red → green.
5. **Trace + document**: add a work-item row (commit links) and let the report be the spec.

## Specification hierarchy

| Level | Gherkin | Purpose |
|---|---|---|
| Customer outcome | Epic | "As an importer, I want X so that Y" — the business value |
| Business rule | `Feature` | one distinct rule |
| Example | `Scenario` | one acceptance criterion (happy / boundary / error / alternate role) |
| Data variation | `Scenario Outline` + `Examples` | the *same* rule across datasets |

## Rules of thumb (anti-redundancy)

- **One business rule = one `Feature`.** A new dataset is *data*, not a new rule — put it in the
  `Examples` table, never as a new scenario.
- **One behaviour = one `Scenario`.** Write the *distinct* behaviours: valid, boundary,
  error/invalid, alternate role/route, fallback. Don't enumerate permutations.
- **Unknowns = `@ignore @stub`.** Questions raised in Example Mapping that we can't answer yet
  become stubs to promote in a later sprint.
- **Tags:** `@integration` = needs the running registry env; `@ignore @stub` = not implemented.

## Customer-outcome backbone (the product, in spec form)

| Segment | Outcome (epic) |
|---|---|
| Exporter | "I submit verifier-ready data **once** and EU importers use it" |
| Importer | "I get declaration-ready data and lower certificate cost" |
| Verifier | "I audit faster via a read-only evidence room" |

Each outcome → a handful of rules → a few scenarios each.

## Worked example (current sprint — CBAM embedded-emissions calculation)

**Example Mapping card:**

| Rule | Examples (scenarios) | Questions (→ stubs) |
|---|---|---|
| Calculate SEE from a source stream | mass / energy / volume (Scenario Outline ×3) | Nm³ gas beyond steel? (PFC, CEMS) |
| Roll up precursor emissions | complex good (pig iron) | multi-tier precursors |
| Reject invalid input | zero production, missing electricity | missing NCV/factor; wrong unit |
| Compare actual vs default cost | 3 routes (Scenario Outline) | real IR 2025/2621 defaults |

**Result:** one `Feature` with ~5 scenario blocks (not one per fuel). See
`../product/tests/DppCore.Tests/Features/cbam-calculation.feature`.

## Traceability

| Story | Scenarios | Step defs | Code |
|---|---|---|---|
| E3-C5 CBAM engine | `cbam-calculation.feature` | `../product/tests/DppCore.Tests/Steps/CbamCalculationSteps.cs` | `../product/src/DppCore/CbamCalculator.cs`, `CbamEconomics.cs` |

Keep this table in `workitems/README.md` as stories are promoted.
