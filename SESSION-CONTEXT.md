# SESSION-CONTEXT — resume here when you come back

Last update: Sep 2026 (end of planning/research sessions; implementation-prep session next).

## Read this first, then

1. `business/product-roadmap.md` — **§5 Implementation timeline** is the single source of truth
   (dated master); §7 is the 30/60/90 action plan.
2. `business/project-gantt.md` — dated task view (derived from roadmap §5).
3. `compliance-matrix.md` — T2 self-certification evidence + operating model
   (conformance targets, capabilities, learn/hire/validate).
4. `AGENTS.md` — working constraints (holistic, small chunks, iterate before acting,
   no fragility; checklist runs on every action).

## Where we are

- **Phase:** P0 — Foundation & learning (Sep–late Oct 2026). Target exit = **M1**
  (wedge overlap map CBAM ∩ steel DPP approved; decision gates D1–D7 closed).
- **Done so far:** M0 repo bootstrap; S1 registry spike **PASSED** (mock-eu-registry:
  registered MODEL-level steel entry, proof JWT retrieved); L3 mock-registry documented;
  CBAM regulatory research deep-done (workflow, input sources, master data catalogue r2,
  GTM sizing/pricing); full competitive landscape built; all key decisions locked (below).
- **Product:** CBAM-first wedge for steel & aluminium (definitive phase), then DPP
  sell-twice. Business model: self-serve SaaS + Xero-style partner services; three user
  classes (supplier, importer, verifier); SNARK/zero-exposure = target trust layer gated
  by the P2 ZK spike; verification stamp = **partner verifiers only** (arm's-length own
  entity = keep-open option gated on volume).
- **S0 progress (Oct 2026):** E0-HARNESS up (8 services healthy + spike host); **L1 signed
  off** + calc-input stub; **C#/.NET registry client** round-trip (T1-REG-002); **TracePass
  steel inventory** (84 fields / 29 required).
- **Operating model (Oct 2026):** 3 dimensions — **Learn ∥ Implement ∥ Present**. A present
  gate is mandatory at every milestone; **all three segments** (exporter/importer/verifier)
  are targeted. Artifact map: `INDEX.md`. Present detail: `business/presentation-plan.md`.

## Decisions locked (don't re-litigate without new evidence)

1. CBAM wedge first; steel & aluminium engine (~80% shared); textiles = scale play; footwear out.
2. Partner-only verification stamp; we buy the knowledge (external verifier-grade domain
   consultant **engaged after C2–C4 scaffolding validated**, to detail schema/data-capture/
   calculation models for C5), never the stamp.
3. Moat = **encoded validation intelligence** (3-layer view: plumbing = commodity,
   regulated calculation = engineerable, validation intelligence = the moat) — see roadmap §2.
4. Pricing L/B/H: €1–3k / €8–15k / €30–60k per yr (anchors in `research/goto-market-sizing.md`).
5. GTM anchored on in-force wedges (CBAM definitive; textiles disclosure duty), not on DPP
   indicative dates; schemas-as-data everywhere.
6. C#/.NET default for the core (no blockers found); reference-only use of AGPL open-dpp.
7. **JSON = canonical seam (locked Oct 2026).** Adapters/plugins convert every external source
   → JSON; the core works only on JSON. Six guarantees: schema-versioning, provenance,
   determinism/idempotency, identity binding, role/confidentiality, security — see
   `business/system-intricacies.md`.
8. **Product = 4 friction pillars** (Capture, Validation intelligence, Audit room, Trust) built
   in phases on a commodity calc/canonical substrate; competitors' offerings are building blocks
   (adopt, not rebuild) — see `business/product-spec.md` §0 + `competition/friction-gap-analysis.md`.
9. **Spec-first development:** Gherkin scenarios are the executable product spec; `@ignore @stub`
   until implemented. Runnable so far: calc, registry, importer-declaration.
10. **Cold-start (G02, locked Oct 2026): exporter-first wedge.** Primary onboarding = non-EU
    exporters (India/UK beachhead; supplier-side is under-served, SAP is declarant-only).
    **Importers are opportunistic/secondary** — reachable from the London base (UK/EU), not
    excluded. Invite mechanics: exporter invites importer via EORI link (importer may also
    invite suppliers), but the *led* side is the exporter.

## File map

```
root:  README.md · AGENTS.md · compliance-matrix.md · terminology.md · SESSION-CONTEXT.md (this file)
business/: product-roadmap.md (§5 = single source of truth) · project-gantt.md · sprint-plan.md ·
       product-spec.md · jobs-to-be-done.md · system-intricacies.md · product-gaps.md ·
       specification-by-example.md · presentation-plan.md · execution-modes.md · README.md
business/investor/: investor-deck.md · pitch.md · business-plan.md · investment-plan.md(.enc)
research/ (definitive & high-value): regulations.md · cbam-registry-workflow.md ·
       cbam-data-catalogue.md (r2) · cbam-input-sources.md · goto-market-sizing.md ·
       standards.md · architecture.md · learning-roadmap.md · tools.md · sources.md · glossary.md
exploration/ (lower priority): DPP_Initial_Brainstorm · saas-opportunity ·
       adjacent-opportunities · companies · people · consultancies
competition/: landscape.md (+threat scorecards) · dossiers/ (carbonchain, sap, minespider,
       circularise, circlor, verifiers) · mapping-to-roadmap.md
cleancarbonai/: CleanCarbon.ai dossier
learning/ (taught courses): README (catalogue) · cbam-101/ (COMPLETE) · cbam-201/ (COMPLETE) ·
       cbam-301/ (planned) · cbambok.md · glossary.md
src/: fixtures/steel-hrc-batch.md (placeholder) — code goes here from C2 onward
reference/ (gitignored): mock-eu-registry · deploy-resources · tracepass-dpp-schemas · freeDPP
scratch/ (gitignored): spike-host (python static DPP host, port 9090)
```

## Environment state

- **CIRPASS-2 test environment still running** (docker compose project
  `dpp_live_test_environment`; 8 services healthy as of handoff). Registry :8082,
  Keycloak :8180 (realm `cirpass-2`, admin/admin), validator :8083, postgres :5434.
  EO client: `eo-EO-529900T8BM49AURSDO10` (secret in
  `reference/deploy-resources/keycloak/realm/cirpass-2-realm.json`; roles in token).
  Restart command: `docker compose -p dpp_live_test_environment -f ./test_environment/docker-compose.yaml up --pull always -d`
  (from `reference/deploy-resources`). Spike host: python http.server on :9090
  (scratch/spike-host) — may need restart.
- **Git:** branch `main`, clean tree at handoff. Latest commits: `e5bcf83` (catalogue r2),
  `b4e2bb1` (catalogue), `66d397a` (input sources), `bba4992` (EC-provided vs build)…
- S1 spike evidence: compliance-matrix row `T1-REG-001` (registryId `e3eb36a2-…`).

## Work queue (next session, in order) — 3-dimension milestone view

1. **M-A — Conversation-ready (by S2, 24 Oct):** draft **explainers ×3**
   (exporter/importer/verifier) + **15-name target list** (`business/presentation-plan.md`);
   close **M1** (overlap map + D1–D7). *Discovery interviews deferred/superseded by the
   solution-led M-C conversations.*
2. **M-B — Demo v0 (by S3, 7 Nov):** C2 thin data contract → sample steel → **C5 SEE calc** →
   actual-vs-default saving + evidence summary; demo script ×3 + one-pager.
3. **M-C — Signal (by S4, 21 Nov):** **5 mixed conversations** + signal log; objection FAQ.
4. **M-D — Demo v1 (S5–S6):** + JSON-LD passport/host/registry; demo-v1 script + pilot offer.
5. **M-E — Pilot (S7+, aligns M2):** pilot conversations; harden ingestion; LOI/case study.
6. **Ongoing:** L2 (EC DPP Registry **test-env access** — user action), L5, L7; each chunk
   T1 conformance + fixture regression + compliance-matrix row.

## Rules of engagement (from AGENTS.md)

- Iterate before acting; small verified chunks; root-cause not symptoms; git as rollback.
- Update roadmap §5 first, then propagate to §7/gantt — single source of truth.
- Every external claim cited + tagged (Fact/Claim/Verbatim/[Unverified]); no hallucinated filler.
- EU DPP Registry stays the compliance target; CBAM definitive registry the wedge target.
