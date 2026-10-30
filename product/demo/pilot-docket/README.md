# Pilot Docket — Shree Balaji Steel & Alloys Pvt Ltd (synthetic)

A realistic, **synthetic** document docket for a mythical SME exporter — built to learn what real
documents look like, how to read them, and which fields feed CBAM. Delivered **one document at a
time**, concierge-style (the data is extracted, normalised, and calculated manually/scripted,
then the same steps become the product).

> **All documents are synthetic samples. Not real bills, not real companies, no real PII.**

## The client

| Field | Value |
|---|---|
| Company | Shree Balaji Steel & Alloys Pvt Ltd |
| Location | Plot 14, Industrial Area, Urla, Raipur, Chhattisgarh 493221, India |
| Business | EAF steel re-roller → TMT bars, exporting to the EU |
| Connection | HT Industrial (33 kV) |
| CBAM route | EAF (electric arc furnace) |

## How each step works

1. Read the document (facsimile + plain text).
2. Read the **reading guide** — what it is, how to read it, which fields matter for CBAM.
3. Compare with the **extracted-fields** answer key.
4. Run the **concierge step** (`run.md`) — extracted → canonical → the number it feeds.
5. Move to the next document.

## Steps (one at a time)

| Step | Document | Status |
|---|---|---|
| **01** | Electricity bill | **ready** |
| **02** | Fuel invoice (natural gas) | **ready** |
| 03 | Weighbridge ticket | pending |
| 04 | Mill Test Certificate (EN 10204 3.1) | pending |
| 05 | Heat/batch production log | pending |
| 06 | Monthly fuel register | pending |
| 07 | Company identity pack | pending |
| 08 | Route & product declaration | pending |
| 09 | Extraction sheet (all docs) | pending |
| 10 | Pilot report (SEE + evidence + saving) | pending |

## Folder layout

```
pilot-docket/
  README.md
  01-electricity-bill/   (step 01 - ready)
  02-fuel-invoice/       (step 02 - ready)
  practice-multi-product/  (one installation -> 3 CN codes -> allocation -> report -> declaration -> verifier)
  practice-many-to-many/   (2 installations x 2 importers -> per-installation SEE mapping -> declarations)
  practice-submission-reports/ (3 exporters x 3 importers -> WHOLE submission reports per importer)
```

## Practices

- `practice-multi-product/` — one installation, **3 CN codes**: allocation → per-good SEE → report →
  importer declaration → verifier dossier.
- `practice-many-to-many/` — **2 installations × 2 importers**: same CN code from different
  installations with different SEE → per-line mapping → aggregated declarations.
- `practice-submission-reports/` — **3 exporters × 3 importers × multiple products**: the **whole
  submission report** per importer (lines → per-CN aggregation → certificates → evidence → attestation).
