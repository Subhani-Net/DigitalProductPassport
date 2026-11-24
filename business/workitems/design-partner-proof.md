# Design-Partner Proof & Acquisition — Work Items (Nov 2026)

**Objective:** acquire **2–3 free design partners** and publish transparent **pre-client proof**
(regulatory alignment + a synthetic reference dossier), while deferring any review/verifier claim
until clients and work are complete.

**Status legend:** `To Do` · `In Progress` · `Done` · `Blocked` · `Deferred`
**Rule:** no public claim without evidence (see `../website/specs/claims-register.md`).

## Work items

| ID | Work item | Acceptance | Depends | Status | Evidence |
|---|---|---|---|---|---|
| DP-01 | Claims audit + register | Every public claim has an evidence row; prohibited claims listed | — | **Done** | `../website/specs/claims-register.md` |
| DP-02 | Fix website claims | Remove unearned “reviewed by specialists”; cite Reg 2023/956 + IR 2025/2547; label sample | DP-01 | **Done** | `business/website/index.html` |
| DP-03 | Build synthetic reference dossier | Complete HTML + PDF; Rajkot re-rolling mill, CN 7214; synthetic watermark | — | **Done** | `business/pilot/sample-dossier/` + `business/website/assets/samples/` |
| DP-04 | Email-gated sample download | Form + validation; server stores email; returns download URL; consent | DP-03 | **Done** | `business/website/sample-dossier.html`, `api/sample-dossier/` |
| DP-05 | Privacy update for email capture | Privacy notice covers sample-request emails, purpose, retention, processors | DP-04 | **Done** | `business/website/privacy.html` |
| DP-06 | Design-partner programme | Offer, exchange, guardrails, selection, metrics documented | — | **Done** | `../outreach/design-partner-programme.md` |
| DP-07 | Design-partner target list (10) | 10 Tier-1 leads with why-fit and first-touch angle | DP-06 | **Done** | `../outreach/design-partner-programme.md` §5 |
| DP-08 | Outreach sequence + tracking | Call-first sequence; log in `tracker.md`; design-partner flag | DP-06 | **Done** | `../outreach/trial-playbook.md` |
| DP-09 | Review claim (independent specialist) | Written review obtained; claim added only then | DP-03 + clients | **Deferred** | — |
| DP-10 | Accredited verifier partnership | Named partner body; independence documented | DP-09 | **Deferred** | — |
| DP-11 | Publish sample + trust page | Sample download page live; claims evidence visible | DP-02/03/04 | **Done** | `business/website/sample-dossier.html` |
| DP-12 | Claims-register maintenance | Register reviewed on every website change | DP-01 | **Ongoing** | `../website/specs/claims-register.md` |
| DP-13 | First design-partner pilot | 1 completed pilot; feedback captured | DP-07 | **To Do** | `tracker.md` |
| DP-14 | Case study / reference | Written permission + 1-page case study | DP-13 | **To Do** | — |
| DP-15 | Convert to paid plan | 1 design partner converts | DP-13 | **To Do** | `tracker.md` |

## Progress log

| Date | ID | Note |
|---|---|---|
| 2026-11-07 | DP-01 | Claims register created; prohibited/earned claims separated |
| 2026-11-07 | DP-02 | Website tag replaced with correct legal baseline; sample labelled |
| 2026-11-07 | DP-03 | Synthetic Rajkot re-rolling dossier built (HTML → PDF) |
| 2026-11-07 | DP-04 | Email-gated sample page + Azure Function with validation |
| 2026-11-07 | DP-05 | Privacy notice updated for sample-request emails |
| 2026-11-07 | DP-06 | Design-partner programme + free variant in trial playbook |
| 2026-11-07 | DP-07 | 10 Tier-1 design-partner targets selected |
| 2026-11-07 | DP-08 | Call-first sequence + tracker flag defined |
| 2026-11-07 | DP-11 | Sample page linked from the site |

## Notes

- The **review claim** stays off the site until DP-09 is genuinely completed (after clients/work).
- The **verification stamp** stays with an accredited partner (DP-10), never us.
- The sample dossier is **synthetic** — no client logos, names or data.
