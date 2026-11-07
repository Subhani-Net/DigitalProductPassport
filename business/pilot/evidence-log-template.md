# Evidence Log — Template

One row per figure used in the report. If a figure has no source row, it is not ready to deliver.

| ID | Data point | Value | Unit | Period | Source document | Source location | Extraction | Determination | Confidence | Notes |
|---|---|---|---|---|---|---|---|---|---|---|
| E1 | Grid electricity consumed | 528,400 | MWh | Jan–Dec 2026 | `electricity-bills-2026.pdf` | p.1–12 | manual | ACTUAL | high | 12 monthly bills |
| E2 | Natural gas consumed | 180,000 | SCM | Jan–Dec 2026 | `gas-invoices-2026.pdf` | p.1–10 | manual | ACTUAL | high | converted to TJ |
| P1 | HRC consumed | 1,050 | tonnes | CY 2026 | `hrc-invoices.xlsx` + weighbridge | rows 2–40 | manual | ACTUAL | high | 95.2% yield |
| P2 | HRC SEE | 1.90 | tCO₂e/t | CY 2026 | `supplier-verification-2026.pdf` | p.2 | manual | ACTUAL | high | verifier report ref |
| P3 | Pig iron SEE | 2.10 | tCO₂e/t | CY 2026 | EU default table | — | default | DEFAULT | n/a | no verified data |
| O1 | Output (CN 7209) | 1,000 | tonnes | CY 2026 | `production-log.xlsx` | rows 2–14 | manual | ACTUAL | high | per CN code |

## Rules

- `Determination` is `ACTUAL` or `DEFAULT` — never leave it blank.
- `Confidence`: high / medium / low, based on source quality.
- Add the **report page/line** that uses the figure in `Notes` if helpful.
- Keep the source document names exactly as received; do not rename originals.
- If a default is used, record why (e.g., “supplier did not provide verified SEE”).
- Never put a figure in the report that is not in this log.
