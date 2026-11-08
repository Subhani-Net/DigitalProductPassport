# Gap Register — Phase 3

**Purpose:** a single list of every missing, inconsistent or unverified item — with a fallback and
a cost impact. This is how you **find gaps** systematically and turn them into a plan.

## How gaps surface

1. Run the checklists (`boundary-worksheet.md`, `source-stream-inventory.md`,
   `precursor-register.md`, `production-by-cn.md`, `unit-period-check.md`).
2. Compare sources (bill vs meter, invoice vs weighbridge, production vs sales).
3. Look for: blank/zero fields, missing months, unit mismatches, period mismatches, missing
   calibration, missing verification reports, ambiguous CN codes, boundary ambiguity.
4. Check route completeness (expected streams/precursors for BF-BOF/EAF/DRI/Al).
5. Check plausibility (SEE, energy intensity, yield).

## Register

| ID | Data point | Category | Status | Impact | Fallback | Owner | Due | Notes |
|---|---|---|---|---|---|---|---|---|
| G1 | Electricity Jan–Mar | Missing document | Missing | Default / cost | EU default | Client | | bills not provided |
| G2 | HRC SEE | No supplier verification | Partial | Default / cost | EU default | Client | | supplier has no report |
| G3 | Output CN 7209 | CN ambiguity | Inconsistent | Incorrect scope | Confirm with customs | Client + us | | description vs code |
| G4 | Natural gas units | Unit mismatch | Inconsistent | Calculation risk | Convert with density | Us | | SCM vs Nm³ |
| G5 | Meter calibration | No calibration | Partial | Verifier challenge | Flag, use best available | Client | | expired cert |

## Categories

`Missing document` · `Unreadable` · `Period mismatch` · `Unit mismatch` · `No meter` ·
`No calibration` · `No supplier verification` · `CN ambiguity` · `Boundary ambiguity` ·
`Plausibility outlier`

## Status values

`Missing` · `Partial` · `Inconsistent` · `Resolved`

## Impact values

`Default fallback` (we use the legal default and flag it) · `Calculation risk` (may change the
number) · `Verifier challenge` (likely to be questioned) · `Scope risk` (CN/boundary).

## Closure rules

- Every gap has an **owner** and a **due date**.
- Every gap has a **fallback** so the pilot can still deliver.
- When resolved, record the evidence that closed it.
- Never silently replace a gap with an assumption.
