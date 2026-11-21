# Customer Website (Veriflow)

A static, dependency-free, customer-facing site for the **exporter-first CBAM evidence**
offer. Separate from the investor site in `../investor/website/`.

- No front-end frameworks, no external fonts, no trackers.
- Shared design tokens with the brand identity (`../investor/brand/identity.md`).
- Contact form posts to an **Azure Static Web Apps managed function**, which stores the enquiry
  in **Azure Table Storage**. **No email is sent at this stage** (by design).

## Configuration — single source of truth

All shared values live in **`site.config.json`**: `brand`, `domain`, `email`, `phone`,
`phoneHref`, `address`. Change a value once, rebuild, and every page (plus `robots.txt`,
`sitemap.xml`, canonical/og tags and the JS form fallback) updates.

- The HTML pages keep **placeholder literals** (`Veriflow`, `veriflow.example`,
  `hello@veriflow.example`, the phone and address). **Do not edit those in the pages** —
  edit `site.config.json` instead.
- **`build.mjs`** (plain Node, no dependencies) stamps the config into a `dist/` folder and
  copies `assets/` and `staticwebapp.config.json`. `api/` is deployed separately (excluded
  from `dist/`).
- `dist/` is generated and git-ignored. Build locally with `node business/website/build.mjs`.

## Pages

| File | Purpose |
|---|---|
| `index.html` | Landing page: offer, problem, pillars, pricing, FAQ, CTA |
| `how-it-works.html` | Process, precursors, monitoring plan, annual clock, boundaries |
| `pilot.html` | 2-week pilot: what you give/get, timeline, guardrails |
| `contact.html` | Contact details (placeholder) + enquiry form |
| `privacy.html` | Privacy notice (working draft) |
| `terms.html` | Website terms (working draft) |
| `thank-you.html` | Form success page |
| `404.html` | Not-found page |
| `assets/styles.css` | The design system |
| `assets/site.js` | Mobile nav, footer year, contact-form `fetch` |
| `assets/favicon.svg` | Brand mark / favicon |
| `api/` | Azure Function: `POST /api/contact` → Table Storage |
| `staticwebapp.config.json` | Routing, headers, `X-Robots-Tag: noindex` |
| `robots.txt` · `sitemap.xml` | Crawl hints (placeholder domain) |

Deployment workflow: `.github/workflows/azure-static-web-apps.yml`.

## Application shell spec

The logged-in web app (auth, tenants, uploads, dashboard, security) is specified separately in
[`specs/`](specs/README.md). It is **not** part of this marketing site and does **not** include
the CBAM engine, which stays in `product/` and is delivered manually in phases.

## Preview locally

Build the stamped site, then serve `dist/` (form POST will fail locally, as expected):

```
node business/website/build.mjs
python -m http.server 8080 --directory business/website/dist
# http://localhost:8080/
```

Full local run with the API (needs Azure Functions Core Tools + Azurite):

```
npm i -g @azure/static-web-apps-cli azure-functions-core-tools@4
azurite --silent &
swa start business/website --api-location business/website/api
```

Add `api/local.settings.json` (gitignored) with:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "STORAGE_CONNECTION_STRING": "UseDevelopmentStorage=true",
    "CONTACT_TABLE_NAME": "ContactSubmissions"
  }
}
```

## Deploy to Azure Static Web Apps

1. Create a **Static Web App** in Azure (Free tier). Source: GitHub, this repo, branch `main`.
2. Build details:
   - **App location:** `business/website/dist` *(the workflow runs `node business/website/build.mjs` first)*
   - **API location:** `business/website/api`
   - **Output location:** *(empty)*
3. Copy the **deployment token** into GitHub → Settings → Secrets → Actions as
   `AZURE_STATIC_WEB_APPS_API_TOKEN`.
4. Create a Storage account; add its connection string to the SWA **Configuration** as
   `STORAGE_CONNECTION_STRING` (and optionally `CONTACT_TABLE_NAME`).
5. Push to `main` (or run the workflow). The site goes live at
   `https://<name>.azurestaticapps.net`.
6. Test: pages, 404, form submit → row in the table, `X-Robots-Tag: noindex`.

**No email is sent.** To add it later, extend `api/contact/index.js` (ACS Email/SendGrid) and
update `privacy.html`.

## Contact form

- Client: `assets/site.js` posts JSON to `/api/contact`.
- Server: `api/contact/index.js` validates, rejects honeypot hits, and writes to Table Storage.
- Required fields: `name`, `company`, `email`; `consent` must be checked.
- Honeypot: hidden `website` field.
- No IP address is stored.

## Privacy and terms

`privacy.html` and `terms.html` are **working drafts**. Controller identity is
“Veriflow (working name), London, United Kingdom” with a placeholder email. Review before launch.

## Placeholders to replace before launch

| Placeholder | Where |
|---|---|
| **Brand name “Veriflow”** (working name) | `site.config.json` → `brand` |
| **Domain `veriflow.example`** | `site.config.json` → `domain` |
| **Email `hello@veriflow.example`** | `site.config.json` → `email` |
| **Phone `+44 (0) 0000 000 000`** | `site.config.json` → `phone` / `phoneHref` |
| **Address “London, United Kingdom”** | `site.config.json` → `address` |
| **Azure Storage connection string** | SWA app settings (secret) — never in the repo |
| **Privacy/terms legal review** | `privacy.html`, `terms.html` |
| **Pricing “from €8,000/year”** | `index.html` — reconciled to Base tier (€8–15k) in `goto-market-sizing.md` |

## Content and claims policy

- **Never claim “verified.”** The site says **“verifier-ready, not verified.”**
- **No invented logos, testimonials or customer counts.**
- **Mark illustrative numbers** (2.04/2.10 example, € saving).
- **No full-suite claims** — we explicitly say we do not do LCA/EPD/ESG.
- Keep the “working name” and placeholder contacts visible until replaced.

## Research basis

Messaging follows the repo's competitive review (`../competition/`, `../positioning.md`,
`../jobs-to-be-done.md`) and the CBAM facts in `../../knowledge/research/`. No third-party copy
is reused.

## Next steps

1. Create the Azure SWA + Storage account and set the secrets/settings.
2. Replace brand/domain/contact placeholders; remove `noindex` at go-live.
3. Add email notification (later).
4. Add a real pilot case study (with consent).
5. Optional: privacy-friendly analytics + OG image.
