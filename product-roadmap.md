# Product Roadmap — DPP Enabling-Software Platform

Top-level product map and the path we take. Strategy references: `exploration/saas-opportunity.md`
(commodity vs complex layers), `research/architecture.md` (3-layer stack), `research/standards.md`
(certification blueprints), `research/learning-roadmap.md` (how we learn the landscape),
`research/regulations.md` (the legal driver).

> **Single source of truth:** the dated, milestone-based master is **§5 Implementation
> timeline**. Every dated statement in §3 (Targets), §4 (Phases) and §7 (Action plan), and the
> derived `project-gantt.md`, must agree with §5. **Update §5 first, then propagate** — never
> change a date only in one section.
> Status anchor: **today = 6 Sept 2026**.

---

## 1. Vision (north star)

A DPP **enabling-software platform** that turns raw, multi-tier supplier data into
CELEX-traceable, cryptographically verifiable Digital Product Passports for **Iron & Steel,
Aluminium, and Textiles** — built by *adopting* the commodity open layers (EDC/AAS, GS1
Digital Link, EU Registry APIs) and *building* the complex logic layers (PCF/mass-balance
computation, lineage, harmonization, verification) that are defensible IP. **Monetised from
day one through the in-force wedge legislation (CBAM for metals; unsold-textiles disclosure
for textiles) whose data pipelines the DPP reuses — "sell the compliance need now, DPP later".**

## 2. Top-level product map

One core engine, multiple vertical modules ("build once, swap schemas").

```
                         ┌── [ Steel & Aluminium module ]  PCF / energy-mix / mass-balance
[CORE ENGINE]            ├── [ Textiles module ]           fiber composition / sustainability certs
  ingestion → harmonize ─┤── [ future: batteries, etc. ]
  → compliance math ─────┴── (each vertical = TracePass field set + its complex logic)
  → passport generation
  → verification & trust
  → submission (EU Registry) + data-space interop (EDC)

ADOPT (commodity):        GS1 Digital Link + Resolver · Keycloak (IAM/OID4VC) · EDC/AAS ·
                          CIRPASS-2 mock registry · open-dpp base platform (optional) · CEN/CENELEC
BUILD (complex/defensible): PCF & recycled-content/mass-balance engines · data lineage/lifecycle ·
                          verification & authenticity (VC/eIDAS) · **zero-exposure attestation
                          (SNARK target trust layer, gated by the P2 ZK spike)** · AI harmonization
                          from legacy ERP
```

Customer targets:
- **Primary:** EU-placed Economic Operators (manufacturers/importers) in steel, aluminium, textiles.
- **Secondary:** Tier-N suppliers + exporters (India, UK, etc.) pulled in by trickle-down
  compliance who need cheap plug-and-play data adapters.

### Product & business model (decided Sept 2026)

- **Self-serve SaaS is the product; services are an offering or third-party — on the Xero
  model.** Software open to all customers on both sides. Hand-holding services come from us
  (optional managed line) or a **partner ecosystem** (verifiers, consultants, customs
  agents = Xero's accountants) running on our platform.
- **Two-sided product flow:** supplier side — ingestion + **validation of input** → suppliers
  hold verifier-ready, proprietary-safe data; importer side — **validated input + formatting**
  → CBAM XML/Excel, declaration-ready, audit-evidenced.
- **Verification stamp: partner accredited verifiers only (locked Sep 2026).** We build
  capability across the whole ecosystem except the stamp itself; an own arm's-length
  verification entity is a keep-open option gated on volume (independence rule: verifiers
  cannot assure their own affiliates' work). The verifier is our **third user class** —
  validation intelligence (evidence dossiers, audit trails, recalculation support) is built
  for them in C7/C8.
- **Trust direction: aiming at SNARK / zero-exposed data.** Suppliers' proprietary detail is
  never exposed to consumer/importer counterparties — proof by zero-knowledge attestation,
  not data sharing. Feasibility/timing still gated by the P2 ZK spike (§4).
- Full sizing + pricing model: `research/goto-market-sizing.md`.

### Focus decision (verified against ESPR Working Plan, Sept 2026)

- **Steel & Aluminium — validated as the first engine.** Iron & steel is the *first* ESPR
  delegated act (Q4 2026 → ~2028); aluminium follows (Q3–Q4 2027 → ~2029). Both are
  intermediate products sharing the PCF / recycled-content / CBAM-ETS-overlap engine
  (~80% module reuse). Few, large B2B accounts; high value per account; low competition.
- **Textiles — confirmed for the scale play.** DA Q3–Q4 2027 → ~2029; large fragmented
  buyer base, heavy competition. Same core engine, different module.
- **Footwear — OUT of active scope.** Explicitly excluded from the first textiles DA
  (separate study pending; possible 2028 mid-term-review / later DA). Track as watch item
  only; do not build capability now.
- **Regulatory-drift risk is real and current:** no ESPR DA adopted as of Sept 2026 and the
  steel DA has already slipped vs. original plans. Anchor GTM on buyer *preparation* demand,
  not on the indicative ~2028 compliance date. See Risks table.

### Near-term revenue wedges (CBAM-first strategy, endorsed Sept 2026)

**Recommended path for both metals and textiles: sell the compliance-data need that is
in force NOW; deliver DPP when its act lands (~2028–29).** Buyers buy enabling software
18–30 months before an obligation — the wedge legislation forces the identical data pipeline
today.

- **Metals wedge = CBAM (live 1 Jan 2026).** Steel & aluminium importers must already report
  **verified embedded emissions** (certificates from 2027). Build the **PCF/carbon engine
  CBAM-first**: same per-tonne carbon + supplier data feeds CBAM today and the steel/aluminium
  DPP later (~2028–29). Revenue now, DPP-ready data.
- **Textiles wedge = unsold-products disclosure + destruction ban (live 19 Jul 2026, large
  enterprises; Reg 2026/2).** Large apparel/fashion brands must disclose unsold volumes now.
  Footwear is in scope of this duty (but not the DPP act). Opens the same buyer base and gets
  our ingestion/harmonization installed years ahead of the textiles DPP.
- **Engine design consequence:** the harmonization + verified-data pipeline is built once and
  sold twice — first for the wedge (CBAM / unsold disclosure), then extended to the DPP
  module. See Phase P1 exit criteria below.

### Platform design principle — EO-owned URL namespace (no registry lock-in)

Registry metadata points to the **customer's own stable domain**, not to our host. We operate
behind that domain (DNS/CNAME). Consequence for customers: joining/leaving us is a DNS change,
never a mass re-registration of historical DPPs; printed QRs/registry URIs never break. This
is a required engineering capability (C6: stable redirect layer / customer domains + optional
bulk re-registration client for migrations) and a sales argument. See
`research/architecture.md` "Registry portability & provider migration". Watch: **DPP Service
Provider Delegated Act (Q2–Q3 2027)** may formalise portability duties for us.

## 3. Targets (top-level goals)

Milestone keys used here and in §5: **M1** = overlap map + decisions (late Oct 2026);
**M2** = CBAM engine sellable (~Jan 2027); **M3** = P1 exit / sell-twice proof (~Mar 2027).

1. **T1 — Vertical 1 live (Steel & Aluminium).** Compliance product with PCF computation,
   certified-grade, submitted to EU Registry. Path: **M2** → CBAM/emissions data revenue from
   Q1–Q2 2027 (wedge); steel DPP production-ready H2 2027; live registry submission by the
   ~2028 obligation; aluminium (~2029) rides the same engine.
2. **T2 — Vertical 2 live (Textiles).** Textile module (fiber composition, GOTS/OEKO-TEX
   alignment); wedge-in via unsold-disclosure duty from 2027; DPP module matured ahead of the
   ~2029 obligation (DA Q3–Q4 2027).
3. **T3 — Cross-vertical engine:** one core, N verticals; new vertical = schema + logic module.
4. **T4 — Defensible moat:** the **mass-balance/PCF + verification engine** proven in
   production (delivered **M2 ~Jan 2027**, sold from P2). **ZK is an optional moat
   *amplifier*, not the moat and not a prerequisite** — validated by the P2 ZK spike, adopted
   only on customer pull.

## 4. Phases & milestones

Windows and exits are the master in §5. Status: P0 in progress (Sept 2026).

- **P0 — Foundation (Sep → late Oct 2026).** Complete `research/learning-roadmap.md` Phase
  0–1
  (guided blocks L1–L7); verify Catena-X specifics; sandbox stood up (done Sept: CIRPASS-2
  env + S1 registry spike passed). *Exit = **M1** (late Oct):* wedge overlap map
  (CBAM ∩ steel DPP fields) approved; decision gates D1–D7 closed and recorded.
- **P1 — Core engine MVP (CBAM-first) (Nov 2026 → Mar 2027).** Ingestion + harmonization
  pipeline; **PCF / embedded-emissions engine built to serve CBAM (verified embedded
  emissions) first**, then extended to the steel/aluminium DPP fields; EDC + credential/
  verification core; passport generator + lineage store. **Cert Tier 1 (legal-function
  conformance)** is a hard acceptance criterion on every chunk (test against CIRPASS-2 mock
  registry + TracePass schema validation).
  *Exit = **M3** (Mar 2027):* a CBAM-verified embedded-emissions output *and* a verifiable,
  CELEX-traceable steel passport end-to-end from the same fabricated supplier dataset —
  proving the sell-twice engine. Includes the EO-owned URL namespace capability (stable
  redirect layer / customer domains) per the platform design principle. **M2 (~Jan 2027)**
  marks the CBAM engine sellable (first revenue point).
- **P2 — Vertical 1 GTM (Steel & Aluminium) (Q2 2027 → 2028).** **Cert Tier 2 self-assurance**
  completed and recorded in the compliance matrix; security baseline (TISAX/ISO 27001
  readiness); pilot customer. Two revenue streams: (a) **CBAM/emissions data service (from
  M2)**; (b) **EU Registry submission flow** live by the ~2028 obligation. **Cert Tier 3
  (third-party CAB) is a trigger** — only pursued when a customer/market requires it.
  **ZK opportunity spike (H2 2027, ~2–3 wks, research-only):** toy SNARK proving a PCF value
  without revealing the underlying recipe/energy mix, tested against one pilot-customer
  conversation → decision gate: adopt into P2.5 on pull, else defer to P4.
  *Exit:* paying pilot on the CBAM wedge with a DPP-ready path.
- **P3 — Vertical 2 (Textiles) (2027 → 2029).** Textile module (fiber composition,
  sustainability certs); multi-tenant; scale the harmonization layer. Wedge-in-first: extend
  to the textiles customer base via the **unsold-products disclosure duty (in force)** before
  the textiles DA (Q3–Q4 2027) and obligation ~2029. Footwear excluded from DPP (separate
  study) — watch item only (in scope for the disclosure duty now).
- **P4 — Moat & scale (2029+).** Lifecycle services (repair/reuse/secondary-market),
  self-serve vertical builder. **ZK here only as the amplifier it is** — adopted on the
  evidence of the P2 spike, never treated as the moat itself (the moat is the
  mass-balance/PCF + verification engine, live since M2/P2).

## 5. Implementation timeline

Dated view of the phases (anchor: today = Sept 2026). Every DPP deadline is indicative —
no ESPR delegated act is adopted yet — so GTM is anchored on the in-force wedges (CBAM,
unsold-textiles disclosure) whose data pipelines the DPP reuses.

### Phase 0 — Foundation: Sep → late Oct 2026
- Sep (done): M0 bootstrap; S1 registry spike passed; L3 mock-registry recorded.
- Sep–Oct: guided learning L1 (CBAM rules), L2 (registry user guide), L4 (TracePass steel),
  L6 (CEN/CENELEC), L5 (GS1 Digital Link), L7 (Tractus-X harness).
- late Oct — **M1:** wedge overlap map (CBAM ∩ steel DPP fields) approved; decision gates
  D1–D7 closed and recorded.

### Phase 1 — Core engine (CBAM-first): Nov 2026 → Mar 2027
| Chunk | Est. effort | Milestone |
|---|---|---|
| C2 data contract (schemas-as-data, keystone) | 1–2 wks | |
| C3 ingestion + C4 harmonization | 3–4 wks | |
| C5 CBAM/embedded-emissions engine | 3–4 wks | **M2 ~Jan 2027 — first sellable capability (CBAM wedge revenue can start)** |
| C6 passport generator + registry submit + DPP host | 2–3 wks | T1 gate |
| C7 T2 self-assurance run | 1 wk | |
| C8 lineage + integrity | 2 wks | |
| C9 sell-twice proof (one dataset → CBAM + steel passport) | 1–2 wks | **M3 ~Mar 2027 — P1 exit** |

### Phase 2 — V1 GTM (Steel & Aluminium): Q2 2027 → 2028
- Q1–Q2 2027: pilot CBAM data customers (revenue now, DPP-ready data).
- H2 2027: steel DPP module production-ready (ahead of ~2028 obligation); TISAX/ISO security
  posture; T2 completed; T3 only on customer demand. **ZK opportunity spike (research-only,
  2–3 wks):** toy SNARK proof over C5 output, tested with one pilot customer → decision gate
  (adopt into P2.5 vs defer to P4).
- 2028: steel obligation (~2028) → live EU Registry submission flow; aluminium prep (DA
  Q3–Q4 2027 → ~2029) rides the same engine.

### Phase 3 — Vertical 2 (Textiles): 2027 → 2029
- 2027: wedge-in via unsold-products disclosure duty (in force 19 Jul 2026) — engage large
  brands before the textiles DA lands (Q3–Q4 2027).
- 2028–2029: textile DPP module matured ahead of the ~2029 obligation.

### Phase 4 — Moat & scale: 2029+
- Lifecycle services, self-serve vertical builder. **ZK = optional amplifier only** (adopted
  per the P2 spike evidence); the moat itself is already live since M2/P2.

### Timeline logic
- **Earliest revenue point ~Jan–Feb 2027** (C5 CBAM engine) — the wedge decouples cashflow
  from DPP regulatory drift.
- **Battery 18 Feb 2027** is not our target but publicly validates live registry operation —
  a confidence signal ahead of our steel launch.
- Deliverables stay **schemas-as-data**: indicative dates shift, the data contract adapts.

## 6. Certification & compliance model (tiered)

**Principle:** certification is for *our own assurance* that we follow the guidelines.
Third-party certification is **not mandatory** to provide DPP services — only interoperability
with the EU Registry is functionally required. Paid certification is bought only on demand.

| Tier | What | Free tooling | Cost | Applied |
|------|------|--------------|------|---------|
| **T1 — Legal-function conformance** (non-negotiable) | Payloads/APIs actually work against the registry | CIRPASS-2 mock registry, TracePass schemas as validator, freeDPP as reference | $0 | Every build chunk (P1+) |
| **T2 — Self-assurance** (the goal) | Prove to ourselves we follow the guidelines | Tractus-X DPP Verification add-on, SAMM/BAM semantic validator, EDC interop testbed → recorded in an internal **compliance matrix** | $0 | Continuous (P1+); completed for V1 by P2 |
| **T3 — Third-party certification** (optional) | Credential to sell on demand | CAB assessment (e.g. TÜV Rheinland); TISAX / ISO 27001 if a customer/RFP requires it | Paid | Triggered by customer/market demand (P2+) |
| **T4 — Vertical data-space alignment** (optional) | Access vertical communities + credibility | Material-X / Base Metals (PCF), Tex-X specs | $0/low | As verticals mature (P2–P3) |

- **Compliance matrix:** a living doc mapping each guideline/standard → our implementation →
  the test evidence (which harness, when run, result). This IS our self-certification evidence.
- **Distinction:** data-space certification (T3/T4) is a go-to-market asset and is **not** the
  same as the legal EU-Registry compliance obligation of our customers.
- **Security:** TISAX/ISO 27001 readiness starts early (P1) regardless — enterprise customers
  routinely demand security credentials independent of DPP.

## 7. Action plan (next 30 / 60 / 90 days)

Dated slices of §5 from the status anchor **6 Sept 2026**. Rolled status on the left.

- **0–30 (6 Sep → ~6 Oct) — P0 learning:**
  - ✅ Done Sept: M0 bootstrap; CIRPASS-2 env up (all 8 services); S1 registry spike passed
    (evidence: compliance matrix `T1-REG-001`); L3 mock-registry recorded; git history
    baseline (`8fd4a69`).
  - 🔲 To do: L1 CBAM embedded-emissions rules (wedge spec); L2 EC Registry "User Guide for
    Economic Operators"; L4 TracePass iron & steel fields (start). Compliance matrix rows for
    each harness as it comes up.
- **30–60 (~Oct → early Nov) — M1 gate:** finish L4, L5 (GS1 Digital Link), L6 (CEN/CENELEC),
  L7 (Tractus-X); **M1:** wedge overlap map (CBAM ∩ steel DPP) approved; close decision gates
  D1–D7 with recorded notes. Optional C2 data-contract kickoff.
- **60–90 (Nov → Dec) — P1 chunks open:** C2 data contract (schemas-as-data, keystone);
  C3 ingestion; C4 harmonization begin. Every chunk passes T1 (mock-registry-format payload)
  and the fixture regression suite.

Full dated view: §5. Gantt view: `project-gantt.md`.

## 8. Challenges

1. **Regulatory drift:** exact field sets and deadlines shift (343 in-force vs 187 anticipated
   fields today). System must treat schemas as data, not hard-coded.
2. **Tier-2/3/4 data availability:** suppliers run on spreadsheets; harmonization is the
   hard volume problem.
3. **Commodity competition:** full DPP platforms are free (AGPL) — price pressure on
   transport layer; value must sit in accuracy, verification, and services.
4. **Multi-vertical complexity:** one engine, many schemas + domain math; over-engineering
   is the risk. Mitigated by module boundaries and per-vertical milestones.
5. **Certification effort:** CAB/TISAX audits are time + cost — mitigated by the tiered model
   (T1/T2 are free and continuous; T3 only on customer demand).

## 9. Risks & mitigations

| Risk | Likelihood | Impact | Mitigation |
|------|-----------|--------|------------|
| ESPR delegated acts / deadlines shift (no DA adopted as of Sept 2026; steel DA already slipped) | High | High | Schema-as-data design; track CELEX & EC work plan; anchor GTM on buyer preparation demand, not the indicative ~2028 date; 2028 mid-term review monitored |
| Free open-source platforms commoditize the core | High | Medium | Moat in PCF/mass-balance accuracy, verification, harmonization, services |
| Data-quality failures → compliance liability | Medium | High | Verification layer, audit trail, eIDAS sealing, clear disclaimers |
| Certification delays (CAB/TISAX) | Medium | Medium | Tiered model: T1/T2 free & continuous; T3 triggered by demand; start security posture in P1 |
| Vendor/data-space lock-in | Medium | Low | Standards-only (EDC, AAS, JSON-LD); portable modules |
| Fragile codebase (fix-one-break-another) | Medium | High | AGENTS.md discipline: small chunks, dependency maps, verification per chunk |
| Single vertical too small a market | Low-Medium | Medium | Phased vertical expansion off one core engine |
| Funding/burn during long regulatory windows | Medium | High | CBAM-first wedge delivers wedge revenue during the DPP wait (metals now, textiles via disclosure); sandbox-first MVP; pilot revenue before scaling |
| P1 slips past Q1 2027 (miss M2 CBAM revenue / M3 exit) | Medium | High | M2 (CBAM engine) is the first revenue point and is de-prioritised ahead of DPP-only features; per-chunk T1 regression gates; cut scope in C8/C9, not C5 |

## 10. Working cadence (how we build)

Per `AGENTS.md`: iterate before acting → small chunks of working functionality → verify each
chunk against dependent scenarios → keep EU Registry as the compliance target → build only
defensible IP on top of adopted commodity layers.

**Status:** P0 — analysis and planning. No product code written yet by design.
