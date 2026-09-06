# Digital Product Passport — Knowledge Base

Living reference on the EU Digital Product Passport (DPP): regulations, standards,
companies in scope, key people, consultancies, tools/repositories, and every source
gathered from browsing, seminars, and webcasts.

## How to add information (capture flow)

1. Paste raw notes, links, seminar/webcast takeaways into `Inbox.md`.
2. Ask the assistant to file it: the item gets sorted into the right topic file,
   tagged with a citation (`Source: name — URL — type — date`).
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
| `AGENTS.md` | Working principles & constraints (assessed for every action) |
| `product-roadmap.md` | Top-level product map: vision, targets, phases, milestones, risks |
| `project-gantt.md` | Gantt project plan (derived from roadmap §5) |
| `compliance-matrix.md` | Self-certification evidence (Tier 2) |

### `research/` — knowledge base (initial research & reference)
| File | Contents |
|------|----------|
| `research/DPP_Initial_Brainstorm.md` | Original raw brainstorm material |
| `research/regulations.md` | EU laws, deadlines, obligations |
| `research/standards.md` | CEN/CENELEC, schemas, data models |
| `research/companies.md` | Companies in scope (OEMs, battery makers, LMT, ESS, second-life, suppliers) |
| `research/people.md` | Key people, speakers, experts |
| `research/consultancies.md` | Consultancies, advisors, consortia & projects |
| `research/tools.md` | Open-source repos, platforms, registries |
| `research/saas-opportunity.md` | Market analysis of DPP enabling-SaaS opportunity |
| `research/adjacent-opportunities.md` | Other business opportunities (fly ash / construction materials), CAMBEX |
| `research/architecture.md` | DPP technical architecture: learning path + 3-layer framework |
| `research/learning-roadmap.md` | Structured curriculum: commodity layers → complex logic → your system |
| `research/sources.md` | Full bibliography of all sources collected |
| `research/glossary.md` | DPP terminology |
