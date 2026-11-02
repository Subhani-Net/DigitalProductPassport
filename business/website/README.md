# Customer Website (Veriflow)

A static, dependency-free, customer-facing site for the **exporter-first CBAM evidence**
offer. Separate from the investor site in `../investor/website/`.

- No frameworks, no external fonts, no trackers.
- Shared design tokens with the brand identity (`../investor/brand/identity.md`).
- Domain and contact details are **placeholders** — replace before launch.

## Pages

| File | Purpose |
|---|---|
| `index.html` | Landing page: problem, offer, the four pillars, how it works, deliverable, why us, who it's for, pricing, FAQ, CTA |
| `how-it-works.html` | Detailed process: capture → validate → prove → reuse; precursors; monitoring plan; annual clock; boundaries |
| `pilot.html` | The 2-week pilot: what you give/get, timeline, guardrails, success metrics |
| `contact.html` | Contact details (placeholder) + enquiry form |
| `404.html` | Not-found page |
| `assets/styles.css` | The design system |
| `assets/site.js` | Mobile nav close + footer year |
| `assets/favicon.svg` | Brand mark / favicon |
| `robots.txt` · `sitemap.xml` | Crawl hints (placeholder domain) |

## Preview locally

```
python -m http.server 8080 --directory business/website
# open http://localhost:8080/
```

Or open `business/website/index.html` directly in a browser (all links are relative).

## Deploy (free)

**GitHub Pages:** repo → Settings → Pages → branch `main`, folder `/business/website`.
**Netlify / Vercel / Cloudflare Pages:** set the publish directory to `business/website`.

Then add the custom domain and update the placeholders below.

## Placeholders to replace before launch

| Placeholder | Where |
|---|---|
| **Brand name “Veriflow”** (working name) | every page (`brand-name`, titles, footer) |
| **Domain `veriflow.example`** | `canonical`, `og:url`, `robots.txt`, `sitemap.xml`, `README` |
| **Email `hello@veriflow.example`** | footers, contact page |
| **Phone `+44 (0) 0000 000 000`** | footers, contact page |
| **Address “London, United Kingdom”** | footers, contact page |
| **Form action** (`mailto:` by default) | `contact.html` — replace with a form endpoint (Formspree/Netlify Forms/your API) |
| **Privacy / Terms links** | footer “Company” column (not yet present) |
| **Social links** | not present — add if/when accounts exist |
| **Pricing “from €4,000/year”** | `index.html` pricing card — see reconciliation note |

## Content and claims policy

- **Never claim “verified.”** The site says **“verifier-ready, not verified”**; the stamp is an
  accredited partner's.
- **No invented logos, testimonials or customer counts.** Add a real case study only when a
  pilot consents.
- **Mark illustrative numbers.** The 2.04/2.10 example and the € saving are illustrative; the
  certificate price is Q1 2026 (€75.36/t) and moves quarterly.
- **No full-suite claims.** We explicitly say we do **not** do LCA/EPD/ESG reporting.
- **Honest stage.** The site describes a pilot programme; it does not claim a finished platform.

## Pricing reconciliation

The site shows **Pilot: fixed fee**, **Core: from €4,000/year**, **Enterprise: custom** as
customer-facing packaging. Reconcile with the internal tiers in
`../../knowledge/research/goto-market-sizing.md` (L €1–3k / B €8–15k / H €30–60k) before
publishing; the exporter wedge WTP analysis suggests a €4–8k base.

## Research basis

The information architecture and messaging follow the repo's recorded competitive review
(`../competition/`, `../positioning.md`, `../jobs-to-be-done.md`) and the CBAM facts in
`../../knowledge/research/`. Competitor pages reviewed for patterns (not copied): CarbonChain,
ClimeUp, Sentra, CleanCarbon (see `../competition/dossiers/`). No third-party copy is reused.

## Next steps

1. Replace the brand/domain/contact placeholders.
2. Connect the contact form to a real endpoint.
3. Add Privacy and Terms pages (needed before collecting personal data).
4. Add a real pilot case study (with consent) once available.
5. Optional: analytics (privacy-friendly) and an OG image.
