# Digital Product Passport — Knowledge Base

Living reference on the EU Digital Product Passport (DPP): regulations, standards,
companies in scope, key people, consultancies, tools/repositories, and every source
gathered from browsing, seminars, and webcasts.

## How to add information (capture flow)

1. Paste raw notes, links, seminar/webcast takeaways into a message and ask the assistant
   to file them.
2. The item gets sorted into the right topic file (under `research/`), tagged with a
   citation (`Source: name — URL — type — date`).
3. Unverified material is marked `[Unverified]` until you confirm it.

## How to ask questions

Ask anything in natural language, e.g. "Which companies must submit by Feb 2027?",
"What is the Battery Pass consortium?", "Who are the key people in DPP?".
The assistant searches these files and answers with references.

## Citation convention

Every entry ends with a source line:

```
> Source: <Name> — <URL> — <type: article | gov | press | seminar | webcast | meeting | github> — <date>
```

## Entry template

```
## <Name>
- **Type:** Regulation | Standard | Company | Person | Consultancy | Tool | Project | Consortium
- **Category:** <sector bucket, e.g. EV OEM / Battery maker / LMT / ESS / Second-life / Standards body>
- **Summary:** what it is
- **Relevance to DPP:** why it matters
- **Notes:** details, open questions
> Source: ...
```

## Files

### Root — operational docs
| File | Contents |
|------|----------|
| `README.md` | This index (Map of Content) |
| `INDEX.md` | **Artifacts by dimension** (Learn · Implement/Product · Present) — product boundary |
| `SESSION-CONTEXT.md` | **Start here when resuming** — state, decisions, work queue, environment |
| `AGENTS.md` | Working principles & constraints (assessed for every action) |
| `terminology.md` | Shortcut legend: P/M/L/C/S/D/T/E keys, other recurring terms |
| `workitems/README.md` | **Jira-style work-item register** (status, what was done, commit links) |
| `compliance-matrix.md` | Self-certification evidence (Tier 2) |

### `business/` — business track
| File | Contents |
|------|----------|
| `business/product-roadmap.md` | Top-level product map: vision, targets, phases, milestones, risks |
| `business/project-gantt.md` | Gantt project plan (derived from roadmap §5) |
| `business/sprint-plan.md` | Epics, stories (incl. learning), sprint schedule, 3-dimension milestone view |
| `business/specification-by-example.md` | **BDD/SpecFlow playbook** (Example Mapping, hierarchy, loop) |
| `business/product-spec.md` | **Product specification** — outcomes → rules → scenarios per role |
| `business/presentation-plan.md` | **Present dimension**: explainers, demo scripts, signal rubric, target list |
| `business/execution-modes.md` | Desktop/Expert/Field mapping of each chunk (additive view) |
| `business/fundraise-plan.md.enc` | Encrypted fundraise plan (plaintext kept local-only) |
| `business/README.md` | Org-setup + business-planning activity tracker |

### Competitive research
| Folder | Contents |
|------|----------|
| `cleancarbonai/` | Competitive research KB on CleanCarbon.ai (CBAM pipeline) |
| `competition/` | Competitive landscape: matrix, threat scorecards, dossiers, **friction-gap analysis** |

### `demo/` — seedable end-to-end demo data
| Path | Contents |
|------|----------|
| `demo/README.md` | The end-to-end journey + anchors |
| `demo/*.json` | Seed fixtures (routes, precursor chain, importer, edge cases, expected outputs) |

### `learning/` — taught CBAM courses (101 → 201 → 301)
| Path | Contents |
|------|----------|
| `learning/README.md` | Course catalogue + SME competency map |
| `learning/cbambok.md` | **CBAM Body of Knowledge** — article-anchored terms, processes, units |
| `learning/glossary.md` | Learning glossary: terms + course mapping + inbox |
| `learning/cbam-101/` | **Complete** — Foundations (7 modules + self-assessment) |
| `learning/cbam-201/` | **Complete** — Practitioner (9 modules + self-assessment) |
| `learning/cbam-301/` | Planned — Expert / SME (stub) |

### `research/` — definitive & high-value reference
| File | Contents |
|------|----------|
| `research/regulations.md` | EU laws, deadlines, obligations |
| `research/cbam-registry-workflow.md` | Official CBAM Registry workflow (AMM/O3CI/verifiers) + design implications |
| `research/cbam-data-catalogue.md` | Master data-request catalogue (A–H) |
| `research/data-inputs-reference.md` | **Field-level: what gets submitted to the authority** (CBAM O3CI/AMM + DPP) |
| `research/data-layer.md` | **Data capture / transfer / transform** (exporter→importer pipeline) |
| `research/cbam-input-sources.md` | Static/dynamic/real-time CBAM data sources |
| `research/tracepass-steel-fields-table.md` | **Full TracePass steel/aluminium field table** (84 fields, English) |
| `research/tracepass-steel-inventory.md` | Required fields + CBAM ∩ DPP overlap seed |
| `research/goto-market-sizing.md` | Business model, segments, sizing, pricing L/B/H |
| `research/cbam-verifier-accreditation.md` | Verifier-agency Operations SME path + self-study syllabus |
| `research/standards.md` | CEN/CENELEC, schemas, data models |
| `research/architecture.md` | DPP technical architecture: learning path + 3-layer framework |
| `research/learning-roadmap.md` | Structured curriculum: commodity layers → complex logic → your system |
| `research/tools.md` | Open-source repos, platforms, registries |
| `research/sources.md` | Full bibliography of all sources collected |
| `research/glossary.md` | DPP terminology |

### `exploration/` — initial/exploratory notes (lower priority, still searchable)
| File | Contents |
|------|----------|
| `exploration/DPP_Initial_Brainstorm.md` | Original raw brainstorm material |
| `exploration/saas-opportunity.md` | Early market analysis of DPP enabling-SaaS opportunity |
| `exploration/adjacent-opportunities.md` | Other business ideas (fly ash / construction materials), CAMBEX |
| `exploration/companies.md` | Early company lists (many entries [Unverified]) |
| `exploration/people.md` | Early people notes |
| `exploration/consultancies.md` | Early consultancies/consortia notes |
