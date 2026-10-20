# Website (Veriflow)

Minimal/editorial presentation system — one `assets/styles.css` powers the deck, the marketing
site, and the investor page. Working brand; see `../brand/identity.md`.

| File | Purpose | Visibility |
|---|---|---|
| `index.html` | Public marketing site | public |
| `deck.html` | The 16-slide investor deck (arrow keys / click to navigate) | public (or unlisted) |
| `investor.html` | Investor page (ask, revenue, milestones, contact) | **unlisted — share directly** |
| `assets/styles.css` | The design system | — |

## Preview locally

```
python -m http.server 8080 --directory website
# open http://localhost:8080/deck.html
```

## Deploy (free — GitHub Pages)

1. GitHub → repo **Settings → Pages**.
2. Source: **Deploy from a branch** → branch `main`, folder `/website`.
3. Site lives at `https://<user>.github.io/DigitalProductPassport/`.

## Content guard

- **Never** put the raise amount, pricing, or the encrypted plan on the *public* part.
- `investor.html` is "gated" by being unlisted — upgrade to a real password if/when you add a
  backend or a static-auth service.
