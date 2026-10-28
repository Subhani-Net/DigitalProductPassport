# Digital Product Passport — Knowledge Base & Product

Living working repository for a CBAM/DPP product: the knowledge base, the product spec, the
working code, the business/investor material, and everything gathered from browsing, seminars,
and webcasts.

**Clean tree — 4 tracked top-level folders:** `product/` · `knowledge/` · `business/` · `tools/`.
See `INDEX.md` for the full artifact map.

## How to add information

1. Paste raw notes/links/takeaways into a message and ask the assistant to file them.
2. The item is sorted into the right file (under `knowledge/`), cited
   (`Source: name — URL — type — date`), and marked `[Unverified]` until confirmed.

## How to ask questions

Ask in natural language, e.g. "Which companies must submit by Feb 2027?", "What is the Battery
Pass consortium?", "Who are the key people in DPP?". The assistant searches these files and
answers with references.

## Citation convention

```
> Source: <Name> — <URL> — <type: article | gov | press | seminar | webcast | meeting | github> — <date>
```

## Entry template

```
## <Name>
- **Type:** Regulation | Standard | Company | Person | Consultancy | Tool | Project | Consortium
- **Category:** <sector bucket>
- **Summary:** what it is
- **Relevance to DPP:** why it matters
- **Notes:** details, open questions
> Source: ...
```

## Files

### Root — operational docs
| File | Contents |
|------|----------|
| `README.md` | This map of content |
| `SYLLABUS.md` | **Overall picture** — the 4 rails + syllabus of next steps (status) |
| `INDEX.md` | **Artifact map** (Product · Knowledge · Business) |
| `SESSION-CONTEXT.md` | **Start here when resuming** — state, decisions, work queue |
| `AGENTS.md` | Working principles & constraints |
| `terminology.md` | Shortcut legend (P/M/L/C/S/D/T/E keys) |
| `compliance-matrix.md` | T1/T2 conformance evidence |

### `product/` — the software (IS the product)
| Path | Contents |
|------|----------|
| `product/src/` | `DppCore` (calculator, declaration, economics, registry client), `DppRegistryClient`, schemas, fixtures |
| `product/tests/` | xUnit + Reqnroll BDD suite (44 green, 86 spec stubs) |
| `product/demo/` | Seedable end-to-end demo data pack |

### `knowledge/` — what we've learned
| Path | Contents |
|------|----------|
| `knowledge/learning/` | CBAM 101 / 201 (complete), 301 (planned), CBAMBOK, glossary |
| `knowledge/research/` | Regulations, CBAM workflow, data catalogue, data-inputs reference, data layer, **submission cadence & importer risk**, TracePass, standards, architecture, market sizing, verifier path, sources |
| `knowledge/exploration/` | Initial/exploratory notes |

### `business/` — strategy, GTM, investor
| Path | Contents |
|------|----------|
| `business/product-roadmap.md` | Product map, phases, milestones, risks |
| `business/sprint-plan.md` | Epics/stories/sprints + milestone view |
| `business/product-spec.md` | Specification — outcomes → rules → scenarios |
| `business/jobs-to-be-done.md` | Beyond-processing core (6 jobs) |
| `business/system-intricacies.md` | JSON seam, guarantees, challenges→fixes |
| `business/product-gaps.md` | Gaps & uncovered scope |
| `business/specification-by-example.md` | BDD playbook |
| `business/presentation-plan.md` | Present dimension |
| `business/project-gantt.md` | Dated task view |
| `business/execution-modes.md` | Desktop/Expert/Field chunk map |
| `business/investor/` | Deck · pitch · business plan · investment plan (encrypted) · `website/` · `brand/` |
| `business/outreach/` | Target list · one-pager · scripts · trial playbook · consultant channel |
| `business/competition/` | Landscape, friction-gap analysis, dossiers |
| `business/cleancarbonai/` | CleanCarbon.ai competitive KD |
| `business/workitems/` | Jira-style work-item register + gaps backlog |
| `business/README.md` | Business activity tracker |

### `tools/`
| Path | Contents |
|------|----------|
| `tools/crypt-docs.ps1` | Lock/unlock local-only docs (AES-256) |

### Gitignored
`reference/` (cloned tools), `scratch/` (spike host).
