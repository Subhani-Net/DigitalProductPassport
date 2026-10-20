# INDEX — Artifacts by Dimension (Learn · Implement · Present)

**Product boundary:** the actual product is **`src/` only**. Everything else in this repository
is supporting material (learning, presentation/GTM, research, governance). Use this index to
separate the product from the work around it.

| Dimension | Where | What it is |
|---|---|---|
| **Implement (PRODUCT)** | `src/` | The software + schemas + fixtures. This is what we build and ship. |
| **Learn** | `learning/`, `research/`, `terminology.md`, `exploration/` | Courses, body of knowledge, regulations, standards, market research, reference notes. |
| **Present** | `business/`, `competition/`, `cleancarbonai/` | Roadmap, sprint/presentation plans, funding, market sizing, competitive intel, customer-facing artifacts. |
| **Governance** | `AGENTS.md`, `SESSION-CONTEXT.md`, `README.md`, `INDEX.md`, `compliance-matrix.md` | Working rules, session state, index, conformance evidence. |
| **External (not ours)** | `reference/`, `scratch/` | Cloned tools + spike artifacts (gitignored). |

---

## 1. IMPLEMENT — the product (`src/`)

| Path | Purpose | Status |
|---|---|---|
| `src/README.md` | Product source overview + build plan pointer | — |
| `src/DppRegistryClient/DppRegistryClient.csproj` | C#/.NET 10 console client project | ✅ |
| `src/DppRegistryClient/Program.cs` | OIDC token → register metadata → fetch proof | ✅ (T1-REG-002) |
| `src/model/calc-inputs.schema.json` | Throwaway canonical calc-input stub (L1) | ✅ stub |
| `src/fixtures/steel-calc-inputs.sample.json` | Sample steel calc inputs (arithmetic verified) | ✅ |
| `src/fixtures/registry-entry.model.sample.json` | Registry metadata entry sample | ✅ |
| `src/fixtures/steel-hrc-batch.md` | Original fixture narrative (placeholder) | placeholder |

> Everything else is **not** the product. New product code goes under `src/` only.

## 2. LEARN

### 2.1 Courses (`learning/`)
| Path | Purpose |
|---|---|
| `learning/README.md` | Course catalogue + SME competency map |
| `learning/cbambok.md` | CBAM Body of Knowledge (legislation, processes, units) |
| `learning/glossary.md` | Terms + course mapping + inbox |
| `learning/cbam-101/` | **Complete** Foundations (7 modules + assessment) |
| `learning/cbam-201/` | **Complete** Practitioner (9 modules + assessment) |
| `learning/cbam-301/README.md` | Planned Expert/SME (stub) |

### 2.2 Reference research (`research/`)
| Path | Purpose |
|---|---|
| `research/regulations.md` | EU laws, CBAM/ESPR timeline, L1 sign-off |
| `research/cbam-registry-workflow.md` | Official CBAM Registry workflow (AMM/O3CI/DRMC) |
| `research/cbam-data-catalogue.md` | Master data-request catalogue (A–H) |
| `research/data-inputs-reference.md` | **What gets submitted to the authority** — field-level (CBAM O3CI/AMM + DPP metadata) |
| `research/data-layer.md` | **Data capture / transfer / transform** — the exporter→importer pipeline nitty-gritty |
| `research/cbam-input-sources.md` | Static/dynamic/real-time data sources |
| `research/tracepass-steel-inventory.md` | TracePass steel: 84 fields / 29 required (required subset + CBAM overlap) |
| `research/tracepass-steel-fields-table.md` | **Full 84-field steel/aluminium table** (English descriptions) |
| `research/standards.md` | CEN/CENELEC, schemas, certification |
| `research/architecture.md` | DPP technical architecture (3-layer) |
| `research/learning-roadmap.md` | Learning plan |
| `research/tools.md` | Open-source repos/platforms |
| `research/sources.md` | Bibliography |
| `research/glossary.md` | Deep glossary (incl. CBAM workflow) |
| `research/goto-market-sizing.md` | Market sizing + **revenue model** |
| `research/cbam-verifier-accreditation.md` | Verifier-agency path + syllabus |

### 2.3 Other learning
| Path | Purpose |
|---|---|
| `terminology.md` | Shortcut legend (P/M/L/C/S/D/T/E keys) |
| `exploration/` | Initial/exploratory notes (brainstorm, early SaaS read, adjacent ideas, company/people lists) |

## 3. PRESENT

### 3.1 Business & planning (`business/`)
| Path | Purpose |
|---|---|
| `business/product-roadmap.md` | Product map, phases, funding pointer, risks |
| `business/sprint-plan.md` | Epics, stories, sprints, **3-dimension milestone view** |
| `business/specification-by-example.md` | **BDD/SpecFlow playbook** (Example Mapping, hierarchy, loop) |
| `business/product-spec.md` | **Product specification** — outcomes → rules → scenarios per role |
| `business/jobs-to-be-done.md` | **The beyond-processing core** — Extract/Judge/Prove/Coordinate/Advise/Complete + improvement loop |
| `business/system-intricacies.md` | **How the system works** — JSON seam, guarantees, challenges→fixes, mandatory vs good-to-have |
| `business/product-gaps.md` | **Gaps & uncovered scope** — activation, cold-start, ops, our own compliance, engine long tail, non-goals |
| `business/presentation-plan.md` | **Present dimension**: explainers, scripts, signal rubric, target list |
| `business/outreach/` | **Outreach pack**: target list, exporter one-pager, scripts, trial playbook |
| `business/project-gantt.md` | Dated task view (roadmap §5) |
| `business/investor/` | **Investor pack**: deck · pitch · business plan · investment plan (encrypted) |
| `business/README.md` | Business-track activity tracker |

### 3.2 Competitive & GTM
| Path | Purpose |
|---|---|
| `competition/landscape.md` | Competitor matrix + threat scorecards |
| `competition/friction-gap-analysis.md` | **4-pillar friction map** — where incumbents are weak + what we adopt |
| `competition/mapping-to-roadmap.md` | Competitors vs our roadmap |
| `competition/dossiers/` | Per-player dossiers (CarbonChain, SAP, Minespider…) |
| `cleancarbonai/` | CleanCarbon.ai competitive KD |

### 3.3 Demo (seedable end-to-end data)
| Path | Purpose |
|---|---|
| `demo/README.md` | Demo journey (capture → validate → transfer → consume → assure → sell-twice → wedge) |
| `demo/*.json` | Seed fixtures (BF-BOF, EAF, DRI, primary Al, precursor chain, importer, edge cases, expected outputs) |

### 3.4 Website & brand
| Path | Purpose |
|---|---|
| `brand/identity.md` | Working brand (name, colour, type, voice) |
| `website/index.html` | Public marketing site |
| `website/deck.html` | 16-slide investor deck (navigable) |
| `website/investor.html` | Investor page (unlisted) |
| `website/assets/styles.css` | The shared design system |

## 4. GOVERNANCE

| Path | Purpose |
|---|---|
| `AGENTS.md` | Working principles & constraint checklist |
| `SESSION-CONTEXT.md` | Resume state, decisions, work queue, environment |
| `README.md` | Project index / map of content |
| `INDEX.md` | This file — 3-dimension artifact index |
| `compliance-matrix.md` | T1/T2 conformance evidence (product evidence) |
| `workitems/README.md` | **Jira-style work-item register** — status, notes, artifacts, commit links |
| `.gitignore` / `.gitattributes` | Repo hygiene |

## 5. EXTERNAL (gitignored, not ours)

| Path | Purpose |
|---|---|
| `reference/mock-eu-registry` | CIRPASS-2 T1 target |
| `reference/deploy-resources` | Full test-environment compose |
| `reference/tracepass-dpp-schemas` | Field schemas |
| `reference/freeDPP` | C# reference server |
| `scratch/spike-host` | Static DPP host (:9090) |
