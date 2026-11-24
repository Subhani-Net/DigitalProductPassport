# Synthetic Reference Dossier — Rajkot Reference Plant

**What:** a complete, illustrative CBAM dossier for a **re-rolling mill** producing **CN 7214
bars** from purchased **billets (CN 7207)**. It exists to show the method, the evidence trail and
the determination flags — **not** a real client.

- HTML source: `rajkot-reference-dossier.html`
- PDF: `rajkot-reference-dossier.pdf` (10 pages)
- Published copy: `business/website/assets/samples/rajkot-reference-dossier.pdf`
- Download page: `business/website/sample-dossier.html` (email-gated)

## Numbers (illustrative)

| Item | Value |
|---|---|
| Output | 1,000 t bars, CN 7214 |
| Billets consumed | 1,050 t, CN 7207 |
| Billet SEE | 1.60 tCO₂e/t (synthetic verification ref SYN-2026-001) |
| Precursor contribution | 1,050 × 1.60 = **1,680.00 tCO₂e** |
| Direct — natural gas | 6.39 TJ × 56 tCO₂/TJ = **357.84 tCO₂** |
| Total embedded | **2,037.84 tCO₂e** |
| SEE | 2,037.84 ÷ 1,000 = **2.04 tCO₂e/t** (rounded) |
| EU default reference | 2.10 tCO₂e/t (illustrative) |
| Difference | 0.06 tCO₂e/t |
| Buyer-side saving | €4.52/t at €75.36/t · €4,520 per 1,000 t |
| Indirect electricity (reported separately) | 528.4 MWh × 0.71 = **375.16 tCO₂** |

**Scope note:** for iron & steel, only direct emissions are counted initially; the electricity
figure is shown separately and excluded from the direct SEE in this example. Verify against
Annex II / IR 2025/2547.

## Why these choices

- A re-rolling mill is a realistic Indian SME case and demonstrates **precursor handling**.
- Billets are a CBAM-covered input (CN 7207); scrap (CN 7204) is excluded.
- The precursor dominates the number — the commercial point of upstream verified data.
- The numbers reuse the pilot docket quantities (gas 180,000 SCM; electricity 528,400 kWh).

## Regenerate the PDF

```
& 'C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe' `
  --headless=new --disable-gpu --no-pdf-header-footer `
  --print-to-pdf="business\pilot\sample-dossier\rajkot-reference-dossier.pdf" `
  "file:///D:/DigitalProductPassport/business/pilot/sample-dossier/rajkot-reference-dossier.html"
```

Then copy to `business/website/assets/samples/`.

## Rules

- Keep the **SYNTHETIC** watermark and “illustrative, not a client”.
- No real client names, logos or data.
- Keep **“verifier-ready, not verified”**.
- Do not add a review/verifier claim to this dossier until genuinely earned.
