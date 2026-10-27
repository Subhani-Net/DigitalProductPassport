# Module 3 — Actors & the CBAM Registry

## 3.1 The actors and what each must do

| Actor | Role | Key obligation |
|---|---|---|
| **EU importer / Authorised CBAM Declarant** | Legally liable party | Get authorisation, gather emissions data, file the annual declaration, buy & surrender certificates |
| **Indirect customs representative** | May act on the importer's behalf | Same as declarant where they lodge the customs declaration |
| **Non-EU installation operator** | Produces the goods; **origin of the data** | Register in the Registry, upload installation + emissions data (confidential) |
| **Accredited verifier** | Independent assurance | Review operator data + evidence, issue the **verification report** |
| **National Competent Authority (NCA)** | National regulator | Grant/oversee authorisations; accreditation oversight |
| **Customs authorities** | Border control | Enforce that goods are covered/declared |
| **European Commission (DG TAXUD)** | System owner | Operates the CBAM Registry; publishes guidance + default values; DRMC monitoring |

**Fact** (`../../research/cbam-registry-workflow.md`). The verifier is a distinct party — the importer
does **not** self-declare verified values; verification is third-party.

## 3.2 The CBAM Registry — one platform, three access classes

The **CBAM Registry** is the single electronic platform where CBAM obligations are performed.
Access via **EU Login + two-factor authentication**. **Fact**.

| Module / class | Who uses it | Purpose |
|---|---|---|
| **AMM** (Authorised declarant) | Importers / customs reps | Apply for authorisation, submit declarations, manage certificates |
| **O3CI** (Operators of Third-Country Installations) | Non-EU operators **and** accredited verifiers | Operators upload installations + emissions; verifiers review + issue reports |
| **DRMC** | Commission/NCA | Reconciliation, monitoring & control (goods, emissions, certificates, penalties) |

## 3.3 The end-to-end flow (memorise this)

```
[Non-EU supplier]
  registers in O3CI → uploads installation + emissions data (confidential)
        │
        ▼
[Accredited verifier]  (same O3CI portal)
  reviews data + supporting evidence → issues VERIFICATION REPORT
        │
        ▼
[CBAM Registry]
  holds the verified emissions data
        │
        ▼
[EU importer = Authorised CBAM Declarant]  (AMM)
  shares EORI with supplier → retrieves the emissions data
  → annual declaration auto-populated
        │
        ▼
  files ANNUAL CBAM DECLARATION + buys/surrenders certificates
  (NCA + DRMC monitor)
```

**Fact** (`../../research/cbam-registry-workflow.md`, DG TAXUD manuals).

## 3.4 Two facts people get wrong
1. **Data is not sent exporter → importer directly.** It flows through the **Registry**, which
   gives **confidential treatment** to business-sensitive data. **Fact**.
2. **Only an accredited verifier's report** lets the importer use actual verified values.
   An unaccredited review does not count. **Fact**.

## Outcome check
1. Name the three Registry access classes.
2. Who validates the emissions data, and who consumes it?
3. What role does the EORI link play?
