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
| `SESSION-CONTEXT.md` | **Start here when resuming** — state, decisions, work queue, environment |
| `AGENTS.md` | Working principles & constraints (assessed for every action) |
| `product-roadmap.md` | Top-level product map: vision, targets, phases, milestones, risks |
| `project-gantt.md` | Gantt project plan (derived from roadmap §5) |
| `compliance-matrix.md` | Self-certification evidence (Tier 2) |
| `cleancarbonai/` | Competitive research KB on CleanCarbon.ai (CBAM pipeline) |
| `competition/` | Competitive landscape: matrix, threat scorecards, dossiers |

### `research/` — definitive & high-value reference
| File | Contents |
|------|----------|
| `research/regulations.md` | EU laws, deadlines, obligations |
| `research/cbam-registry-workflow.md` | Official CBAM Registry workflow (AMM/O3CI/verifiers) + design implications |
| `research/goto-market-sizing.md` | Business model, segments, sizing, pricing L/B/H |
| `research/standards.md` | CEN/CENELEC, schemas, data models |
| `research/architecture.md` | DPP technical architecture: learning path + 3-layer framework |
| `research/learning-roadmap.md` | Structured curriculum: commodity layers → complex logic → your system |
| `research/tools.md` | Open-source repos, platforms, registries |
| `research/sources.md` | Full bibliography of all sources collected |

### `exploration/` — initial/exploratory notes (lower priority, still searchable)
| File | Contents |
|------|----------|
| `exploration/DPP_Initial_Brainstorm.md` | Original raw brainstorm material |
| `exploration/saas-opportunity.md` | Early market analysis of DPP enabling-SaaS opportunity |
| `exploration/adjacent-opportunities.md` | Other business ideas (fly ash / construction materials), CAMBEX |
| `exploration/companies.md` | Early company lists (many entries [Unverified]) |
| `exploration/people.md` | Early people notes |
| `exploration/consultancies.md` | Early consultancies/consortia notes |
| `research/glossary.md` | DPP terminology |
