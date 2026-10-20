# Investor / Pitch / Business — folder index

One folder for everything an investor or prospect needs.

| File | What it is |
|---|---|
| `investor-deck.md` | The 16-slide deck (numbers pulled from the deep docs) |
| `pitch.md` | The story at 30s / 3min / per-audience lengths |
| `business-plan.md` | Consolidated single-page business plan |
| `investment-plan.md` | The funding ladder, costing, use-of-funds, MVP iterations *(encrypted)* |
| `website/` | Designed presentation: `index.html` (marketing), `deck.html` (deck), `investor.html` (unlisted) |
| `brand/` | Working brand identity (`identity.md`) |

Deep reference (outside this folder): `../product-spec.md` (the product), `../jobs-to-be-done.md`
(the beyond-processing core), `../system-intricacies.md` (the how), `../product-gaps.md`,
`../product-roadmap.md` (dates/milestones), `../research/goto-market-sizing.md` (market/pricing),
`../competition/friction-gap-analysis.md` (why us).

> Note: `investment-plan.md` is the right-sized fundraise plan (encrypted at rest in git;
> plaintext local-only). Decrypt: `powershell -File tools/crypt-docs.ps1 -Unlock`.
