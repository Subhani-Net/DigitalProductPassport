# Brand Identity (working)

A minimal/editorial identity for investor + customer presentation. **Working name — finalize
before any public release.**

## Name
**Veriflow** — "verified data, flowing once, reused everywhere." *(working name)*

## Tagline
> Verified carbon data, once — reused by every EU buyer.

## Colour system

| Token | Hex | Use |
|---|---|---|
| `--ink` | `#101418` | text, headings |
| `--paper` | `#FBFBF9` | background |
| `--accent` | `#14634A` | brand green (credibility, carbon) |
| `--accent-ink` | `#0B3B2E` | hover / dark green |
| `--signal` | `#B3261E` | penalty / urgency |
| `--muted` | `#5F6B6A` | secondary text |
| `--hairline` | `#E4E6E3` | borders |

## Typography

- **Display (headlines):** serif — `Georgia, "Times New Roman", serif`.
- **Body:** sans — `Inter, system-ui, -apple-system, "Segoe UI", Roboto, sans-serif`.
- **Numbers:** sans, tabular, large, semi-bold (`font-variant-numeric: tabular-nums`).

## Layout rules

- One idea per slide/block; headline = a **takeaway**, not a label.
- Generous whitespace; max content width ~1100px; `kicker` (small-caps grey label) above each
  headline.
- Big numbers > big sentences. Hairline rules, no heavy boxes.

## Voice

Direct, plain, numbers-first, no hype adjectives. "The friction is the product."

## Files

- `../website/assets/styles.css` — the executable design system (CSS variables = the tokens above).
- `../website/index.html` · `deck.html` · `investor.html` — all consume the same system.
