# CBAM Registry Workflow (Definitive Phase)

Official, operational workflow of the EU CBAM Registry (definitive phase since 1 Jan 2026).
All content fact-based from the European Commission (DG TAXUD) CBAM Registry page and linked
manuals, retrieved 7 Sep 2026. This is the authoritative reference for the CBAM wedge
(our C5/C6 design).

## The registry: one platform, three user classes

The CBAM Registry is the single electronic platform where CBAM obligations are performed
and reported. Functionalities: authorisations, reporting obligations, submissions of
emissions data, and CBAM modules. Access classes:

1. **Importers of CBAM goods / indirect customs representatives** → apply for **Authorised
   CBAM Declarant** status (AMM module).
2. **Non-EU installation operators** → **O3CI** module (Operators of Third-Country
   Installations) — upload/share installation + emissions data.
3. **Accredited verifiers** → same O3CI portal — review data, issue verification reports.
   Plus **National Competent Authorities (NCAs)** who grant/oversee authorisations.

All users: EU Login with two-factor authentication.

## The data flow

```
[Non-EU supplier] ──▶ O3CI portal: registers as "Registered Operator",
  uploads installations + emissions data (confidential treatment)
        │
        ▼
[Accredited verifier]  same O3CI portal: reviews operator data + supporting
        │              evidence, issues VERIFICATION REPORT (Art. 8, mandatory 2026+)
        ▼
[EU importer = authorised CBAM declarant]  AMM: authorisation + guarantee;
  declarant shares EORI with supplier → retrieves data via Emissions tab
  → "Search in Third Country Installations registry" → declaration auto-populated
        │
        ▼
Declarant files the ANNUAL CBAM DECLARATION + buys/surrenders certificates
(first certificate surrender 30 Sep 2027). NCA + DRMC module monitor/control.
```

## Supplier path (O3CI) — details required

Registration steps: EU Login + 2FA → access request via O3CI portal:
- Company details and registration number/identifiers; company email and website
- User role (Admin Operator or Simple Operator)
- Single PDF: company registration certificate, proof of representation
  (power of attorney), ID of the authorised representative

Then: installation and emissions data (activity data, direct + indirect emissions per CBAM
methodology) + supporting evidence — reviewed by the verifier.

Key property: operators upload **once**, "instead of submitting it to each declarant
separately"; registry gives **confidential treatment of business-sensitive data**.

## Importer path (AMM) — details required

Authorisation application across three tabs: Stakeholder details, Activity details,
Financial & operational details (incl. **guarantee**). Annual CBAM declaration
(Art. 35 Reg 2023/956):
- total quantity of each type of CBAM good
- actual total embedded emissions
- total indirect emissions
- carbon price due in the country of origin for the embedded emissions (deductible)
- quantity of CBAM certificates surrendered

Fallback: where **verified actual values are not available**, the declarant may use the
**EC default values** (IR (EU) 2025/2621) — which are punitive (~20–25% higher cost at
€75.36/t), so actual verified data is commercially preferable. This is the core incentive
that pulls suppliers into providing verifier-backed data.

DRMC (Data Reconciliation for Monitoring and Control) reconciles imported goods,
emissions, certificates and penalties; monitors the 50%-rule and thresholds.
De minimis: importers ≤ 50 t/year of CBAM goods exempt (Omnibus, Oct 2025).

## Verifier path (O3CI) — details required

Accredited verifiers register through the same O3CI portal: accreditation country +
accreditation number, accreditation certificate upload, company documents, proof of
representation → application submitted to the NCA of the accreditation country. Then they
connect with installation operators, review emissions data and supporting documentation,
and issue the verification report that enables declarants to use actual verified values.

## Official manuals & sources (authoritative L2 references)

- CBAM Registry page (DG TAXUD) — https://taxation-customs.ec.europa.eu/carbon-border-adjustment-mechanism/cbam-registry_en (7 Sep 2026)
- CBAM Registry – User manual – Declarants portal, v6.00, 21 Aug 2026 (PDF)
- CBAM Registry – User manual – Accredited verifiers and Installation operators portal (O3CI), v4.00, 27 Aug 2026 (PDF)
- CBAM Registration Guide for non-EU Operators (O3CI) — 24 Feb 2026 (PDF)
- Guidance on access and registration request procedures for Accredited Verifiers — 28 Aug 2026 (PDF)
- Technical user manual – CBAM Registry access for non-EU installation operators, v3.00 (PDF)
- CBAM Regulation (EU) 2023/956 (Art. 8 verification; Art. 35 declaration content)
- Certificate prices: Q1 2026 €75.36/t; Q2 2026 €75.28/t (EC quarterly publication)

## DPP Registry contrast (our 2028–29 product)

- **Workflow defined:** economic operator registers DPP **metadata** in the EU DPP Registry
  (live 20 Jul 2026); Registry issues unique URI; full DPP data hosted **decentralised** at
  the operator's live URL; customs verifies registration at import.
- **Per-product data fields NOT yet defined** for our verticals — they arrive via delegated
  acts: steel Q4 2026, textiles/aluminium Q3–Q4 2027.

## Design implications for our product

1. **C5 outputs should be O3CI-compatible** — the supplier-side emissions data we produce
   must fit the registered-operator upload + verifier review (evidence-backed, unit
   consistent), not just look like a report.
2. **Importer side consumes the declarant path** — importers auto-populate declarations
   from registry data via EORI linking; our importer tooling formats/manages that flow.
3. **Zero-exposure fits the official ethos** — the registry already mandates confidential
   treatment of business-sensitive supplier data; our SNARK/zero-exposure direction
   extends the same principle to the importer-facing layer.
4. **Verifier interop is part of the core flow** — the verifier lives in the same portal;
   our "verifier-ready evidence" must be aligned to the verification-report mechanics.
5. **Operating model (locked Sep 2026): workhorse vs stamp.** We do all the workhorse
   activity — capture, calculation, submission, validation intelligence on both sides. The
   verification stamp comes from **partner accredited verifiers only**; our own arm's-length
   accredited verification entity stays a keep-open option gated on volume (see
   `../compliance-matrix.md` §3). Independence rule: a verifier cannot review work done by
   its own affiliated company (self-review threat, ISO 17029/14065 impartiality), so the
   stamp remains third-party (or firewalled) until volume justifies otherwise.
