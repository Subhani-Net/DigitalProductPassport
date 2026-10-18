# Work Items Register (Jira-style)

Master index of every work item, grouped by sprint, with **status**, **what was done**, the
**artifact(s)**, and **GitHub commit links**. This is the "index of work done".

- **Commit links:** `https://github.com/Subhani-Net/DigitalProductPassport/commit/<hash>`
- **Status legend:** ✅ Done · 🟡 In Progress · ⬜ To Do · ⏸️ Deferred · ⛔ Blocked
- **Types:** Setup · Research · Planning · Learning · Product · Business · Privacy · Present
- **How to update:** add a row under the current sprint with the commit hash after each chunk.
  Keep notes to one line; link artifacts, don't paste them.

> Dates are frozen per the plan; work executed later is recorded here against its planned sprint.

---

## S0 — Foundation, research, learning (planned 15–26 Sep 2026)

| ID | Type | Work item | Status | What was done / notes | Artifacts | Commit(s) |
|---|---|---|---|---|---|---|
| W0-01 | Setup | Repo bootstrap (M0) | ✅ | git init, layout, .gitignore, reference clones, compliance skeleton | `README.md`, `AGENTS.md`, `compliance-matrix.md` | [466aca9](https://github.com/Subhani-Net/DigitalProductPassport/commit/466aca9) |
| W0-02 | Product | CIRPASS-2 mock registry + S1 spike | ✅ | 8-service env up; registered steel entry; proof JWT retrieved | `compliance-matrix.md` T1-REG-001 | [15696f8](https://github.com/Subhani-Net/DigitalProductPassport/commit/15696f8) |
| W0-03 | Planning | Registry portability (EO-owned URL) | ✅ | design principle recorded | `research/architecture.md` | [07b499c](https://github.com/Subhani-Net/DigitalProductPassport/commit/07b499c) |
| W0-04 | Planning | Dated roadmap §5 + gantt | ✅ | single source of truth established | `business/product-roadmap.md`, `business/project-gantt.md` | [8fd4a69](https://github.com/Subhani-Net/DigitalProductPassport/commit/8fd4a69) · [7fd6dbf](https://github.com/Subhani-Net/DigitalProductPassport/commit/7fd6dbf) |
| W0-05 | Planning | KB reorg into research/exploration | ✅ | history preserved, cross-refs fixed | `research/`, `exploration/` | [e54ba69](https://github.com/Subhani-Net/DigitalProductPassport/commit/e54ba69) |
| W0-06 | Planning | ZK reframed as moat amplifier | ✅ | moat = PCF/mass-balance; ZK optional | `business/product-roadmap.md` | [f2e7220](https://github.com/Subhani-Net/DigitalProductPassport/commit/f2e7220) |
| W0-07 | Planning | Compliance-matrix operating model | ✅ | conformance targets, learn/hire/validate | `compliance-matrix.md` | [129711f](https://github.com/Subhani-Net/DigitalProductPassport/commit/129711f) |
| W0-08 | Research | CleanCarbon.ai competitive KB | ✅ | pipeline, platform, clients | `cleancarbonai/` | [74fc0cd](https://github.com/Subhani-Net/DigitalProductPassport/commit/74fc0cd) |
| W0-09 | Research | Competitive landscape + dossiers | ✅ | matrix, scorecards, 6 dossiers | `competition/` | [23569b7](https://github.com/Subhani-Net/DigitalProductPassport/commit/23569b7) |
| W0-10 | Business | GTM/business model + pricing | ✅ | two-sided, Xero-style, L/B/H | `research/goto-market-sizing.md` | [94b3ffc](https://github.com/Subhani-Net/DigitalProductPassport/commit/94b3ffc) |
| W0-11 | Research | CBAM registry workflow doc | ✅ | AMM/O3CI/DRMC flows | `research/cbam-registry-workflow.md` | [e9886f5](https://github.com/Subhani-Net/DigitalProductPassport/commit/e9886f5) |
| W0-12 | Research | CBAM workflow glossary | ✅ | accreditation vs verification vs validation | `research/glossary.md` | [efbc30b](https://github.com/Subhani-Net/DigitalProductPassport/commit/efbc30b) |
| W0-13 | Planning | Partner-only stamp; verifier 3rd class | ✅ | independence rule recorded | `business/product-roadmap.md` | [7a8b780](https://github.com/Subhani-Net/DigitalProductPassport/commit/7a8b780) |
| W0-14 | Planning | Consultant + 3-layer moat | ✅ | eng​aged post-C4; validation intelligence | `business/product-roadmap.md` | [39ff03c](https://github.com/Subhani-Net/DigitalProductPassport/commit/39ff03c) |
| W0-15 | Research | EC-provided vs build inventory | ✅ | CBAM XSD/XLS; no CBAM ref code | `research/sources.md` | [bba4992](https://github.com/Subhani-Net/DigitalProductPassport/commit/bba4992) |
| W0-16 | Research | CBAM input sources | ✅ | static/dynamic/real-time; S0–S3 | `research/cbam-input-sources.md` | [66d397a](https://github.com/Subhani-Net/DigitalProductPassport/commit/66d397a) |
| W0-17 | Research | CBAM master data catalogue r2 | ✅ | A–H, sides mapping, XSD rules | `research/cbam-data-catalogue.md` | [b4e2bb1](https://github.com/Subhani-Net/DigitalProductPassport/commit/b4e2bb1) · [e5bcf83](https://github.com/Subhani-Net/DigitalProductPassport/commit/e5bcf83) |
| W0-18 | Planning | SESSION-CONTEXT handoff | ✅ | state, decisions, work queue | `SESSION-CONTEXT.md` | [25ea892](https://github.com/Subhani-Net/DigitalProductPassport/commit/25ea892) |
| W0-19 | Learning+Product | L1 sign-off + calc-input stub | ✅ | calc rules + schema + sample (arithmetic verified) | `research/regulations.md`, `src/model/calc-inputs.schema.json`, `src/fixtures/steel-calc-inputs.sample.json` | [5f06840](https://github.com/Subhani-Net/DigitalProductPassport/commit/5f06840) |
| W0-20 | Product | Registry client skeleton (C#/.NET 10) | ✅ | token → register 201 → proof 200 | `src/DppRegistryClient/`, T1-REG-002 | [b2c9edc](https://github.com/Subhani-Net/DigitalProductPassport/commit/b2c9edc) |
| W0-21 | Learning | TracePass steel inventory | ✅ | 84 fields / 29 required; CBAM overlap seed | `research/tracepass-steel-inventory.md` | [52f37af](https://github.com/Subhani-Net/DigitalProductPassport/commit/52f37af) |
| W0-22 | Learning | Full TracePass steel field table (EN) | ✅ | 84-row table, English descriptions | `research/tracepass-steel-fields-table.md` | *uncommitted* |
| W0-23 | Planning | 3-dimension plan + root INDEX | ✅ | Learn ∥ Implement ∥ Present; product boundary | `business/sprint-plan.md`, `business/presentation-plan.md`, `INDEX.md` | [2044a8d](https://github.com/Subhani-Net/DigitalProductPassport/commit/2044a8d) |
| W0-24 | Planning | Align to end-product thesis | ✅ | audit-readiness=core; downstream=P3/P4 | `business/product-roadmap.md`, `research/goto-market-sizing.md` | [890e088](https://github.com/Subhani-Net/DigitalProductPassport/commit/890e088) |
| W0-25 | Business | Consolidated revenue model | ✅ | low/base/high + blue-sky | `research/goto-market-sizing.md` | [2571227](https://github.com/Subhani-Net/DigitalProductPassport/commit/2571227) |
| W0-26 | Privacy | Fundraise right-sized + encrypted | ✅ | ~£1.0–1.25M base; `.enc` tracked, plaintext local | `business/investor/investment-plan.md.enc`, `tools/crypt-docs.ps1` | [3019869](https://github.com/Subhani-Net/DigitalProductPassport/commit/3019869) · [e0a85ff](https://github.com/Subhani-Net/DigitalProductPassport/commit/e0a85ff) · [8ad1a80](https://github.com/Subhani-Net/DigitalProductPassport/commit/8ad1a80) · [f25b2a3](https://github.com/Subhani-Net/DigitalProductPassport/commit/f25b2a3) |
| W0-27 | Learning | Courses 101/201 + CBAMBOK | ✅ | complete + glossary | `learning/` | [554217d](https://github.com/Subhani-Net/DigitalProductPassport/commit/554217d) · [ba7ca78](https://github.com/Subhani-Net/DigitalProductPassport/commit/ba7ca78) · [f63f029](https://github.com/Subhani-Net/DigitalProductPassport/commit/f63f029) · [981e6c7](https://github.com/Subhani-Net/DigitalProductPassport/commit/981e6c7) |
| W0-28 | Planning | Sprint plan + terminology | ✅ | epics/stories/sprints; legend | `business/sprint-plan.md`, `terminology.md` | [6f9c694](https://github.com/Subhani-Net/DigitalProductPassport/commit/6f9c694) · [5649479](https://github.com/Subhani-Net/DigitalProductPassport/commit/5649479) |
| W0-29 | Planning | Execution-modes map | ✅ | desktop/expert/field per chunk | `business/execution-modes.md` | [b63cad9](https://github.com/Subhani-Net/DigitalProductPassport/commit/b63cad9) |
| W0-30 | Learning | Verifier accreditation syllabus | ✅ | role + 4-module self-study | `research/cbam-verifier-accreditation.md` | [0b0005d](https://github.com/Subhani-Net/DigitalProductPassport/commit/0b0005d) |
| W0-31 | Planning | Parallel tracks guardrail | ✅ | build trails learning by one step | `business/sprint-plan.md` | [accf463](https://github.com/Subhani-Net/DigitalProductPassport/commit/accf463) |
| W0-32 | Planning | Capability hierarchy + role/payer model | ✅ | 3 tiers; one substrate / role views | `business/product-roadmap.md` | [58c2ae7](https://github.com/Subhani-Net/DigitalProductPassport/commit/58c2ae7) |
| W0-33 | Planning | Reconcile business/ move | ✅ | cross-refs fixed | repo-wide | [50e74b0](https://github.com/Subhani-Net/DigitalProductPassport/commit/50e74b0) |
| W0-34 | Planning | Verifier accreditation option A/B/C | ✅ | independence conflict recorded | `business/product-roadmap.md` | [5711f4f](https://github.com/Subhani-Net/DigitalProductPassport/commit/5711f4f) |

---

## S1 — Learning core (planned 29 Sep–10 Oct 2026)

| ID | Type | Work item | Status | What was done / notes | Artifacts | Commit(s) |
|---|---|---|---|---|---|---|
| W1-01 | Learning | L2 — EC Registry user guide + **test-env access** | ⬜ | needs user registration (separate EU Login) | `compliance-matrix.md` pending | — |
| W1-02 | Learning | L5 — GS1 Digital Link | ⬜ | pending | — | — |
| W1-03 | Learning | L4 finish — TracePass steel loaded | ✅ | covered by W0-21/W0-22 | `research/tracepass-steel-*` | see W0 |

## S2 — M1 gate + M-A conversation-ready (planned 13–24 Oct 2026)

| ID | Type | Work item | Status | What was done / notes | Artifacts | Commit(s) |
|---|---|---|---|---|---|---|
| W2-01 | Present | M-A: exporter explainer | ⬜ | 1 page | `business/presentation-plan.md` | — |
| W2-02 | Present | M-A: importer explainer | ⬜ | 1 page | `business/presentation-plan.md` | — |
| W2-03 | Present | M-A: verifier explainer | ⬜ | 1 page | `business/presentation-plan.md` | — |
| W2-04 | Present | M-A: 15-name target list (5/5/5) | ⬜ | names + route + why-fit | `business/presentation-plan.md` | — |
| W2-05 | Planning | M1: CBAM ∩ steel-DPP overlap map | 🟡 | seed from TracePass inventory; needs approval | `research/tracepass-steel-inventory.md` | — |
| W2-06 | Planning | Close decision gates D1–D7 | ⬜ | record inputs→choice→rationale | `business/sprint-plan.md` | — |
| W2-07 | Learning | L6 — JSON-LD skeleton | ⬜ | throwaway passport shape | — | — |
| W2-08 | Product | L7 — CI harness (mock + TracePass + fixtures) | ⬜ | reproducible evidence | — | — |

---

## S3 — Data contract (planned 27 Oct–7 Nov 2026)

| ID | Type | Work item | Status | Notes |
|---|---|---|---|---|
| W3-01 | Product | C2a canonical model v0.1 | ⬜ | from calc-stub + 29 required steel fields |
| W3-02 | Product | C2b CBAM↔DPP mapping as data | ⬜ | no hard-coding |
| W3-03 | Present | M-B: demo-v0 script ×3 + one-pager | ⬜ | 10-min walkthrough |
| W3-04 | Present | M-B: sample-data SEE + actual-vs-default saving | ⬜ | demo artifact |

## S4–S12 — planned (see `../business/sprint-plan.md` §5)

| Sprint | Key planned items | Status |
|---|---|---|
| **S4** | C2c schema engine · C3 ingestion v0 · **M-C: 5 conversations + signal log** | ⬜ |
| **S5** | C4 harmonization · E2-VAL scaffolding gate · objection FAQ | ⬜ |
| **S6** | engage domain consultant · C5 design · **M-D: demo v1 + pilot offer** | ⬜ |
| **S7** | C5 actual-values engine · **M-E: pilot conversations** | ⬜ |
| **S8** | C5 default fallback + verifier-ready output → **M2 sellable** | ⬜ |
| **S9** | C6a JSON-LD passport · C6b DPP host/EO URL | ⬜ |
| **S10** | C6c registry client (test env) · C7 T2 start | ⬜ |
| **S11** | C7 T2 finish · C8 lineage/integrity | ⬜ |
| **S12** | C9 sell-twice proof → **M3** | ⬜ |

---

## Gaps backlog (from `business/product-gaps.md`)

| ID | Gap | Priority | Type | Status | Target |
|---|---|---|---|---|---|
| G01 | Customer journey / activation (first-value in 15 min) | **High** | Spec + build | ⬜ | S3–S4 (Pillar 1 capture) |
| G02 | Two-sided cold-start decision (exporter-first) | **High** | Decision | ✅ (exporter-first; importers opportunistic via London/EU) | done |
| G03 | Platform operations minimal (tenancy + billing + reminders) | High | Spec | ⬜ | S4–S5 |
| G04 | Our regulatory obligations (DPP Service Provider DA, GDPR, liability) | High | Watch/plan | ⬜ | ongoing (act on DA) |
| G05 | Engine long tail (CEMS, mass-balance, PFC, heat/CHP, by-products) | Medium | Spec + build | ⬜ | Phase 2–3 (consultant) |
| G06 | Security/compliance posture (TISAX/ISO 27001 as features) | Medium | Spec | ⬜ | Phase 1 posture → P2 cert |
| G07 | Data lifecycle (retention, deletion, schema migration) | Medium | Spec | ⬜ | Phase 2 |
| G08 | Production readiness (async jobs, retries, deployment, residency) | Medium | Spec + build | ⬜ | Phase 1–2 |
| G09 | Explicit non-goals (batteries, fertilisers, cement, hydrogen, downstream) | High | Decision (lock) | ✅ (trivial — already implicit: metals-first) | done |
| G10 | Market validation (willingness-to-pay / payer / verifier) | **Critical** | Validate | ⬜ | solution-led demo path |

**Order to close:** G09 (done) → G02 (cold-start decision) → G01 (activation spec) →
G03 (ops minimal) → G04 (compliance watch) → G05–G08 (phase 2–3) → G10 (continuous via demos).

---

## How to add a work item

```
| W<sprint>-<nn> | <Type> | <title> | <status> | <one-line what/why> | <artifact path> | [<hash>](https://github.com/Subhani-Net/DigitalProductPassport/commit/<hash>) |
```
