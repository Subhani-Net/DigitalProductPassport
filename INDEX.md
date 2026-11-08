# INDEX — Artifacts by Dimension (Product · Knowledge · Business)

Clean tree: **4 tracked top-level folders** — `product/` (software), `knowledge/` (what we've
learned), `business/` (strategy, GTM, investor), `tools/`; plus gitignored `reference/` and
`scratch/`.

| Top folder | What it is |
|---|---|
| **`product/`** | The software: `src/` (code + schemas + fixtures), `tests/`, `demo/` (seedable data). **This is the product.** |
| **`knowledge/`** | `learning/` (courses), `research/` (reference), `exploration/` (early notes). |
| **`business/`** | Roadmap/spec/planning, `investor/` (deck + website + brand), `website/` (customer), `outreach/`, `competition/`, `cleancarbonai/`, `workitems/`. |
| **`tools/`** | Scripts (e.g. `crypt-docs.ps1`). |
| Root docs | `README.md`, `INDEX.md`, `AGENTS.md`, `SESSION-CONTEXT.md`, `terminology.md`, `compliance-matrix.md`. |
| Gitignored | `reference/` (cloned tools), `scratch/` (spike host). |

---

## 1. PRODUCT (`product/`)

### 1.1 Source (`product/src/`)
| Path | Purpose | Status |
|---|---|---|
| `product/src/README.md` | Product source overview | — |
| `product/src/DppCore/` | Calculator, declaration/settlement, economics, registry client | ✅ |
| `product/src/DppRegistryClient/` | C#/.NET 10 console client | ✅ (T1-REG-002) |
| `product/src/model/calc-inputs.schema.json` | Canonical calc-input stub | ✅ stub |
| `product/src/fixtures/` | Sample calc inputs + registry entry + batch narrative | ✅ |

### 1.2 Tests (`product/tests/`)
| Path | Purpose |
|---|---|
| `product/tests/DppCore.Tests/` | xUnit + Reqnroll (BDD) suite — 44 green, 86 spec stubs |
| `product/tests/DppCore.Tests/Features/` | Gherkin: calc, registry, data-layer, pillars, roles |

### 1.3 Demo (`product/demo/`)
| Path | Purpose |
|---|---|
| `product/demo/README.md` | End-to-end journey + anchors |
| `product/demo/*.json` | Seed fixtures (BF-BOF/EAF/DRI/Al, precursor chain, importer, edge cases, expected outputs) |
| `product/demo/pilot-docket/` | **Synthetic source documents** (step 01: electricity bill) + reading guides + concierge runs |

## 2. KNOWLEDGE (`knowledge/`)

### 2.1 Courses (`knowledge/learning/`)
| Path | Purpose |
|---|---|
| `knowledge/learning/README.md` | Course catalogue + SME competency map |
| `knowledge/learning/cbambok.md` | CBAM Body of Knowledge |
| `knowledge/learning/glossary.md` | Terms + course mapping |
| `knowledge/learning/cbam-101/` | **Complete** Foundations |
| `knowledge/learning/cbam-201/` | **Complete** Practitioner |
| `knowledge/learning/cbam-precursors/` | **Focused course** — precursors, calculation, data request, timeline/scenarios |
| `knowledge/learning/cbam-301/README.md` | Planned Expert/SME |
| `knowledge/learning/lca-epd-primer.md` | **Deep LCA/PCF/EPD primer** + CBAM bridge (what an EPD is/isn't) |

### 2.2 Reference research (`knowledge/research/`)
| Path | Purpose |
|---|---|
| `knowledge/research/regulations.md` | EU laws, CBAM/ESPR timeline |
| `knowledge/research/cbam-registry-workflow.md` | CBAM Registry workflow (AMM/O3CI/DRMC) |
| `knowledge/research/cbam-data-catalogue.md` | Master data-request catalogue (A–H) |
| `knowledge/research/data-inputs-reference.md` | What is submitted to the authority (field-level) |
| `knowledge/research/data-layer.md` | Capture / transfer / transform pipeline |
| `knowledge/research/submission-cadence-and-risk.md` | Submission frequency (annual, retrospective) + importer risk |
| `knowledge/research/declaration-and-mapping.md` | Importer declaration & installation mapping (many-to-many) |
| `knowledge/research/understanding-check.md` | **Reusable CBAM FAQ / understanding check** (precise clauses, right-vs-wrong, accounting analogy) |
| `knowledge/research/cbam-input-sources.md` | Static/dynamic/real-time sources |
| `knowledge/research/tracepass-steel-inventory.md` | Steel field inventory (84 / 29 required) |
| `knowledge/research/tracepass-steel-fields-table.md` | Full 84-field table |
| `knowledge/research/standards.md` | CEN/CENELEC, schemas |
| `knowledge/research/architecture.md` | Technical architecture (3-layer) |
| `knowledge/research/learning-roadmap.md` | Learning plan |
| `knowledge/research/tools.md` | Open-source repos/platforms |
| `knowledge/research/sources.md` | Bibliography |
| `knowledge/research/glossary.md` | Deep glossary |
| `knowledge/research/goto-market-sizing.md` | Market sizing + revenue model |
| `knowledge/research/europe-carbon-accounting-market.md` | **Source note** — Europe carbon accounting market (whole vs product-specific; accuracy flags) |
| `knowledge/research/cbam-verifier-accreditation.md` | Verifier-agency path |
| `knowledge/research/expert-session-template.md` | **Knowledge-capture template** for advisor sessions (findings → rules/checks/test cases) |
| `knowledge/research/cbam-pilot-toolkit.md` | **Source digest** — CBAM pilot toolkit PDF; accuracy flags; operational actions |

### 2.3 Other
| Path | Purpose |
|---|---|
| `knowledge/exploration/` | Initial/exploratory notes |
| `terminology.md` | Shortcut legend |

## 3. BUSINESS (`business/`)

### 3.1 Planning & spec
| Path | Purpose |
|---|---|
| `business/product-roadmap.md` | Phases, milestones, risks |
| `business/sprint-plan.md` | Epics/stories/sprints + milestone view |
| `business/product-spec.md` | Specification — outcomes → rules → scenarios |
| `business/jobs-to-be-done.md` | Beyond-processing core (6 jobs) |
| `business/system-intricacies.md` | JSON seam, guarantees, challenges→fixes |
| `business/product-gaps.md` | Gaps & uncovered scope |
| `business/capability-map.md` | **Honest deep/partial/thin/absent map** + 90-day gap plan |
| `business/positioning.md` | **Positioning** — CBAM evidence layer; claims, objections, vs Sentra/CleanCarbon |
| `business/specification-by-example.md` | BDD playbook |
| `business/presentation-plan.md` | Present dimension |
| `business/project-gantt.md` | Dated task view |
| `business/README.md` | Business activity tracker |

### 3.2 Investor / outreach / competition / work items
| Path | Purpose |
|---|---|
| `business/investor/` | Deck · pitch · business plan · investment plan (encrypted) · `website/` · `brand/` |
| `business/outreach/` | Funnel · 43 leads · tracker · one-pager · scripts · trial playbook · consultant channel · **expert brief + bench** |
| `business/competition/` | Landscape, friction-gap analysis, dossiers (incl. `sentra.md`, `climeup.md`) |
| `business/cleancarbonai/` | CleanCarbon.ai competitive KD |
| `business/workitems/` | Jira-style work-item register + gaps backlog |

### 3.3 Outreach pack (`business/outreach/`)
| File | Purpose | Status |
|---|---|---|
| `funnel.md` | Customer funnel — 8 stages, targets, channels, cadence | ✅ |
| `leads-india-exporters.md` | 51 real Indian SME exporter leads (5 segments) | ✅ |
| `tracker.md` | Master pipeline table — 51 rows, contact/stage/next action | ✅ active |
| `leads-priority.md` | Contact-ready call sheet — Tier 1/2, angles, weekly sheet | ✅ active |
| `expert-brief.md` | 1-page advisor brief — ask, 6 questions, offer, terms, £500 | ✅ |
| `expert-bench.md` | Advisor longlist + pipeline + engagement log (India + EU) | ✅ active |
| `consultant-channel.md` | Expert channel — amended sequencing | ✅ |
| `exporter-one-pager.md` | Customer-facing one-pager | ✅ |
| `outreach-scripts.md` | Email/LinkedIn scripts (per-customer call pack to be built) | ✅ (evolve) |
| `trial-playbook.md` | Concierge pilot playbook | ✅ |
| `target-list.md` | Persona + sourcing-channel template | ✅ |

### 3.4 Customer website (`business/website/`)
| File | Purpose |
|---|---|
| `business/website/index.html` | **Landing page** — offer, problem, pillars, pricing, FAQ |
| `business/website/how-it-works.html` | Process, precursors, monitoring plan, annual clock, boundaries |
| `business/website/pilot.html` | 2-week pilot, timeline, guardrails |
| `business/website/contact.html` | Contact (placeholders) + enquiry form |
| `business/website/privacy.html` · `terms.html` | Legal pages (working drafts) |
| `business/website/thank-you.html` · `404.html` | Form success / not-found |
| `business/website/assets/` | `styles.css`, `site.js`, `favicon.svg` |
| `business/website/api/` | Azure Function — `POST /api/contact` → Table Storage |
| `business/website/staticwebapp.config.json` | SWA routing, headers, temp-domain `noindex` |
| `business/website/README.md` | Local run, Azure deploy, form, placeholders, claims policy |
| `business/website/specs/README.md` | **App shell spec** — scope, separation from engine |
| `business/website/specs/data-model.md` | Enhanced entities, tenancy, statuses, constraints |
| `business/website/specs/openapi.yaml` | API contract — auth, tenants, documents, reports |
| `business/website/specs/ui-flows.md` | Screens, roles/permissions, states, accessibility |
| `business/website/specs/security.md` | AuthN/AuthZ, tenant isolation, upload, privacy, audit |
| `business/website/specs/auth-stub.md` | Auth interface + dev stub (production auth separate) |
| `business/website/specs/engine-stub.md` | `IEmissionEngine` + synthetic snapshot (real engine separate) |
| `business/website/specs/implementation-stories.md` | **Build plan** — epics, stories, sequence |
| `business/website/specs/features/` | App-shell Gherkin (`@ignore @stub`) — separate from engine BDDs |
| `business/website/specs/decisions/ADR-001-stack-storage-auth.md` | Stack/storage/auth decision (proposed) |
| `business/website/specs/*.txt` | Original raw schema/API inputs (kept for traceability) |
| `business/website/robots.txt` · `sitemap.xml` | Crawl hints (placeholder domain) |
| `.github/workflows/azure-static-web-apps.yml` | Deploy workflow (SWA) |

### 3.5 Pilot toolkit (`business/pilot/`)
| File | Purpose |
|---|---|
| `business/pilot/README.md` | Overview, roles, action checklist |
| `business/pilot/data-request-checklist.md` | Client intake (send on day 0) |
| `business/pilot/diagnostic-report-template.md` | The deliverable template |
| `business/pilot/evidence-log-template.md` · `.csv` | Figure-to-source ledger |
| `business/pilot/runbook.md` | Step-by-step 2-week pilot procedure |
| `business/pilot/phase3-input-validation-guide.md` | **Full Phase 3 process guide** — responsibility, boundary, streams, precursors, outputs, units, gaps |
| `business/pilot/boundary-worksheet.md` | Phase 3 — draft/confirm the system boundary |
| `business/pilot/source-stream-inventory.md` | Phase 3 — structured source-stream checklist |
| `business/pilot/precursor-register.md` | Phase 3 — covered inputs, mass, SEE source |
| `business/pilot/production-by-cn.md` | Phase 3 — outputs by CN, reconciliation, mass balance |
| `business/pilot/unit-period-check.md` | Phase 3 — units, periods, factors, plausibility |
| `business/pilot/gap-register.md` · `.csv` | Phase 3 — gaps + fallback/impact/owner |
| `business/pilot/cn-code-helper.md` | Common steel/aluminium CN codes |
| `business/pilot/HANDOFF-cbam-input-validation.md` | **Fork handoff** — DPP CBAM input validation (Phase 3 scope) |

## 4. TOOLS
| Path | Purpose |
|---|---|
| `tools/crypt-docs.ps1` | Lock/unlock local-only docs (AES-256) |

## 5. GOVERNANCE (root)
| Path | Purpose |
|---|---|
| `AGENTS.md` | Working principles & checklist |
| `SYLLABUS.md` | Overall picture — 4 rails + ordered next steps |
| `SESSION-CONTEXT.md` | Resume state, decisions, work queue |
| `README.md` | Map of content |
| `INDEX.md` | This file |
| `compliance-matrix.md` | T1/T2 conformance evidence |
| `terminology.md` | Shortcut legend |

## 6. EXTERNAL (gitignored)
| Path | Purpose |
|---|---|
| `reference/mock-eu-registry` · `deploy-resources` · `tracepass-dpp-schemas` · `freeDPP` | Cloned tools |
| `scratch/spike-host` | Static DPP host (:9090) |
