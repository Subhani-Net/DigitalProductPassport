# INDEX — Artifacts by Dimension (Product · Knowledge · Business)

Clean tree: **4 tracked top-level folders** — `product/` (software), `knowledge/` (what we've
learned), `business/` (strategy, GTM, investor), `tools/`; plus gitignored `reference/` and
`scratch/`.

| Top folder | What it is |
|---|---|
| **`product/`** | The software: `src/` (code + schemas + fixtures), `tests/`, `demo/` (seedable data). **This is the product.** |
| **`knowledge/`** | `learning/` (courses), `research/` (reference), `exploration/` (early notes). |
| **`business/`** | Roadmap/spec/planning, `investor/` (deck + website + brand), `outreach/`, `competition/`, `cleancarbonai/`, `workitems/`. |
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
| `knowledge/learning/cbam-301/README.md` | Planned Expert/SME |

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
| `knowledge/research/cbam-verifier-accreditation.md` | Verifier-agency path |

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
| `business/specification-by-example.md` | BDD playbook |
| `business/presentation-plan.md` | Present dimension |
| `business/project-gantt.md` | Dated task view |
| `business/README.md` | Business activity tracker |

### 3.2 Investor / outreach / competition / work items
| Path | Purpose |
|---|---|
| `business/investor/` | Deck · pitch · business plan · investment plan (encrypted) · `website/` · `brand/` |
| `business/outreach/` | Target list · exporter one-pager · scripts · trial playbook · consultant channel |
| `business/competition/` | Landscape, friction-gap analysis, dossiers |
| `business/cleancarbonai/` | CleanCarbon.ai competitive KD |
| `business/workitems/` | Jira-style work-item register + gaps backlog |

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
