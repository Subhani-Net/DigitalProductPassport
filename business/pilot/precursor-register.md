# Precursor Register — Phase 3

**Purpose:** identify every **CBAM-covered input** (precursor) the installation consumes, its mass,
and the source of its SEE. The covered-input list is defined by **Annex I of Reg. (EU) 2023/956**,
not by us or the customer.

> Only **CBAM-covered** inputs are precursors. Ore, limestone, coal, packaging, etc. are not
> precursors. Use this as a checklist, then validate against purchase records.

## Register

| # | Input material | CN code | Used? | Mass consumed (t) | Period | SEE (tCO₂e/t) | SEE source | Supplier | Document | Notes |
|---|---|---|---|---|---|---|---|---|---|---|
| 1 | e.g. hot-rolled coil | 7208 | Y | 1,050 | CY 2026 | 1.90 | Actual (verified report ref) | | invoice + MTC + verification | |
| 2 | e.g. pig iron | 7201 | Y | 80 | CY 2026 | 2.10 | Default | | purchase invoice | no verified data |
| 3 | e.g. scrap | 7204 | N | — | — | — | — | — | — | excluded from CBAM scope |
| 4 | e.g. aluminium ingot | 7601 | | | | | | | | |

**SEE source values:** `Actual (verified report ref)` · `Actual (unverified)` · `Default substituted`.

## Expected precursors by route (our check)

| Route | Typical covered inputs |
|---|---|
| Re-roller / cold-rolling | HRC (7208), CRC (7209), coated (7210) |
| Casting / forging | pig iron (7201), crude steel (7206/7207), scrap (7204 — excluded), billets (7207) |
| Wire / bars / sections | wire rod (7213), bars (7214), sections (7216) |
| Pipes / tubes | strip/coil, skelp (7208/7209), tube (7303–7306) |
| Fasteners | wire rod/bars (7213/7214), finished fasteners (7318) |
| Aluminium extrusion | unwrought aluminium (7601), billets (7601), profiles (7604) |
| Aluminium downstream | sheet/plate (7606), foil (7607), tubes (7608) |

> If they buy a covered input that is not in the register, flag it. Missing precursors understate
> SEE and fail verification.

## Validation against source documents

- [ ] Every register row has a **purchase invoice** (mass, supplier, period).
- [ ] Mass is supported by **weighbridge tickets** where available.
- [ ] Mill certificates / supplier data sheets are attached.
- [ ] `Actual (verified)` rows have a **verification report covering the right period**.
- [ ] `Default` rows record **why** (no verified data) and the applicable default reference.
- [ ] No non-covered input is treated as a precursor.
- [ ] Recursive: if a precursor is itself complex, its SEE already includes its own precursors.

## Customer confirmation

| Name | Role | Date | Confirmation |
|---|---|---|---|
| | | | |
