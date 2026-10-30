# Practice — Whole submission reports (3 exporters × 3 importers)

The **full** CBAM submission report per importer — not a slice. Three exporters/installations,
three importers, multiple products, every combination, so you can see the entire report assembled.

## The matrix (importer × installation → goods)
| Importer | E1 — Shree Balaji (EAF, IN) | E2 — Bharat Integrated (BF-BOF, IN) | E3 — Anadolu Steel (EAF, TR) |
|---|---|---|---|
| **X (DE)** | 7214 · 1,200 t | 7214 · 800 t; 7208 · 300 t | 7213 · 400 t |
| **Y (NL)** | 7214 · 500 t; 7213 · 200 t; 7208 · 100 t | — | 7214 · 600 t |
| **Z (FR)** | 7214 · 300 t | 7208 · 700 t | 7213 · 800 t |

## Installation SEE (tCO₂/t)
| Installation | Route | 7214 | 7213 | 7208 |
|---|---|---|---|---|
| E1 | EAF (IN) | 0.374538 | 0.40 | 0.446304 |
| E2 | BF-BOF (IN) | 2.03754 | — | 1.95 |
| E3 | EAF (TR) | 0.52 | 0.55 | — |

## Files
| File | Shows |
|---|---|
| `installations.json` | 3 exporters' per-CN SEE |
| `import-records.json` | the full importer × installation × CN × quantity matrix |
| `submissions.json` | all three submissions (lines, per-CN, totals, certificates, default comparison) |
| `submission-importer-X.md` | **whole report** — Importer X |
| `submission-importer-Y.md` | **whole report** — Importer Y |
| `submission-importer-Z.md` | **whole report** — Importer Z |
| `report-template.md` | the full report structure (all 10 sections) |
| `assumptions.md` | assumptions register |

## Results at a glance
| Importer | Total qty (t) | Embedded (tCO₂e) | 2026 certs (2.5%) | Saving vs default |
|---|---|---|---|---|
| **X** | 2,700 | 2,884.4776 | 72.1119 | 2,785.52 |
| **Y** | 1,400 | 623.8994 | 15.5975 | 2,316.10 |
| **Z** | 1,800 | 1,917.3614 | 47.9340 | 1,862.64 |

## Why this is the "whole" report
Each importer's report contains: declarant details → scope → **lines per (installation, CN)** →
**aggregation by CN** → embedded summary → **certificate obligation** → actual-vs-default →
evidence links → assumptions → attestation. That is the complete submission, not a section.

## Lessons
1. A submission is a set of **lines**, each tied to a specific installation; totals aggregate per CN.
2. The same installation (E1) appears in all three importers' reports — uploaded once, reused.
3. The same CN (7214) sourced from EAF vs BF-BOF carries **very different** SEE — mapping matters.
4. The report is always produced; gaps/estimates sit in the **assumptions register**.
5. **Verifier-ready, not verified** — the stamp is the partner verifier's.

> All datasets illustrative; defaults shown at 2.10/t for comparison (real defaults are CN+country).
