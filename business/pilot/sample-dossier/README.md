# Synthetic Reference Dossier — Rajkot Alloy & Bright Bar Works

**What:** a complete, illustrative CBAM evidence pack for a **scrap-based induction furnace +
hot/cold rolling mill** producing **bright bars and fasteners**. It shows the boundary, the SEE
summary, and a 14-document audit trail — **not** a real client.

- HTML source: `rajkot-reference-dossier.html`
- PDF: `rajkot-reference-dossier.pdf` (6 pages)
- Published copy: `business/website/assets/samples/rajkot-reference-dossier.pdf`
- Download page: `business/website/sample-dossier.html` (email-gated)

## Numbers (illustrative)

| Item | Value |
|---|---|
| Operator | Rajkot Alloy & Bright Bar Works Pvt. Ltd. (Synthetic) |
| Route | Scrap-based Induction Furnace + Hot/Cold Rolling |
| CN codes | 7214 20 00 (Bars/Rods) & 7318 15 90 (Fasteners) |
| Direct Process Emissions (gas, LDO, electrodes) | **0.47 tCO₂e/t** |
| Upstream Precursor Emissions (billets / wire rod) | **1.28 tCO₂e/t** (verified supplier data) |
| Total Actual Direct SEE | **1.75 tCO₂e/t** |
| EU India Default (2026, +10% markup) | **2.50 tCO₂e/t** |
| Net reduction | **−0.75 tCO₂e/t (−30.0%)** |
| Financial advantage | **€61.74/t** at €82.32/tCO₂e (Q3 2026) |
| Annual saving (500 t / 1,000 t) | **€30,870 / €61,740** |

**Scope note:** for iron & steel, only direct emissions are counted initially; electricity is
shown/reported separately and excluded from the direct SEE. Verify against Annex II / IR 2025/2547.

## Voice & persona

Written as a **trusted CBAM advisor**: plain, precise, commercial — addresses the reader as "you",
states the boundary honestly ("verifier-ready, not verified"), and treats the number as a **pricing
asset**, not a compliance chore. No hype; every claim traces to the evidence log.

## Why these choices

- A scrap-based induction furnace + hot/cold rolling is a realistic Indian SME route.
- Bright bars (7214 20 00) and fasteners (7318 15 90) are CBAM-covered goods; scrap (CN 7204) is excluded.
- The purchased billets / wire rod are the dominant (precursor) term — the point of upstream data.
- Defaults use the IR (EU) 2025/2621 framing (country default + annual markup).

## Regenerate the PDF

```
& 'C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe' `
  --headless=new --disable-gpu --no-pdf-header-footer `
  --print-to-pdf="business\pilot\sample-dossier\rajkot-reference-dossier.pdf" `
  "file:///D:/DigitalProductPassport/business/pilot/sample-dossier/rajkot-reference-dossier.html"
```

Then copy to `business/website/assets/samples/`.

## Rules

- Keep the **SAMPLE** watermark and “illustrative, not a client”.
- No real client names, logos or data.
- Keep **“verifier-ready, not verified”** and “Prepared for Accredited Verification (O3CI Ready)”.
- Do not add a review/verifier claim until genuinely earned.
