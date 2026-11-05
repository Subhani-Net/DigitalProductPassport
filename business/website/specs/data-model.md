# Data Model — Application Shell

Enhanced from `1. The Database Architecture (Schema Spec).txt`. The shell stores **who** the user
is, **which installation (tenant)** they belong to, **which documents** they uploaded, and the
**reports/evidence** they display. It does **not** compute SEE; the engine does that manually and
in phases.

## 1. Design rules

1. **Tenant boundary = `Installation`.** Every tenant-owned row carries `installationId`.
2. **No global role on the user.** A user's rights come from **`Membership`** per installation,
   so a consultant or verifier can serve many installations.
3. **Server-side authorization only.** The UI may hide actions, but the API enforces them.
4. **Soft delete + audit.** Never hard-delete documents/reports silently; record `deletedAt` and
   an `AuditEvent`.
5. **Decimal, not float**, for emissions/money.
6. **Engine outputs are stored snapshots**, not recomputed in the shell. Every report keeps the
   assumptions/version it was produced with.

## 2. Entities

### User
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `email` | citext, unique | login identity |
| `passwordHash` | string? | null if managed/SSO auth |
| `displayName` | string? | |
| `status` | `ACTIVE` \| `INVITED` \| `SUSPENDED` | |
| `emailVerifiedAt` | datetime? | |
| `lastLoginAt` | datetime? | |
| `createdAt`, `updatedAt` | datetime | |

### Installation (tenant)
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `companyName` | string | |
| `country` | string | default `IN` |
| `sector` | `IRON_STEEL` \| `ALUMINIUM` | |
| `status` | `ACTIVE` \| `SUSPENDED` \| `ARCHIVED` | |
| `createdAt`, `updatedAt` | datetime | |

### Membership (user ↔ installation ↔ role)
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `userId` | uuid | FK User |
| `installationId` | uuid | FK Installation |
| `role` | `EXPORTER_OWNER` \| `EXPORTER_MEMBER` \| `CONSULTANT` \| `VERIFIER` | |
| `status` | `INVITED` \| `ACTIVE` \| `REVOKED` | |
| `invitedBy` | uuid? | FK User |
| `createdAt`, `updatedAt` | datetime | |
| — | unique | `(userId, installationId)` |

### Invitation
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `installationId` | uuid | FK Installation |
| `email` | citext | invitee |
| `role` | membership role | |
| `tokenHash` | string | never store the raw token |
| `expiresAt` | datetime | e.g. 7 days |
| `acceptedAt` | datetime? | |
| `invitedBy` | uuid | FK User |
| `createdAt` | datetime | |

### Document
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `installationId` | uuid | FK Installation (tenant) |
| `uploadedBy` | uuid | FK User |
| `fileName` | string | display only, sanitised |
| `storageKey` | string | **key**, not a public URL |
| `mimeType` | string | allowlist |
| `sizeBytes` | int | max enforced |
| `sha256` | string | integrity / dedupe |
| `docType` | `UTILITY_BILL` \| `FUEL_LOG` \| `PRECURSOR_INVOICE` \| `MILL_CERTIFICATE` \| `PRODUCTION_LOG` | |
| `status` | `UPLOADED` \| `PROCESSING` \| `READY_FOR_AUDIT` \| `REJECTED` \| `QUARANTINED` | |
| `scanStatus` | `PENDING` \| `CLEAN` \| `INFECTED` \| `FAILED` | malware scan |
| `uploadedAt` | datetime | |
| `processedAt` | datetime? | |
| `deletedAt` | datetime? | soft delete |

### EmissionReport
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `installationId` | uuid | FK Installation |
| `periodStart`, `periodEnd` | date | reporting period |
| `status` | `DRAFT` \| `IN_REVIEW` \| `VERIFIED` \| `PUBLISHED` \| `ARCHIVED` | |
| `calculatedSEE` | decimal(12,6) | tCO₂e/t — **engine output snapshot** |
| `defaultSEE` | decimal(12,6) | EU default reference |
| `estimatedSavings` | decimal(14,2) | snapshot, with `currency` |
| `currency` | string(3) | default `EUR` |
| `carbonPricePaid` | decimal(14,2)? | Art. 9 origin carbon price |
| `carbonPriceEvidence` | string? | reference to evidence |
| `reportKey` | string? | storage key for the generated dossier |
| `version` | int | increments on re-issue |
| `createdBy` | uuid | FK User |
| `verifiedBy` | uuid? | external/partner reference |
| `verifiedAt` | datetime? | |
| `createdAt`, `updatedAt` | datetime | |

### GoodsLine (display/record; not a calculator)
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `reportId` | uuid | FK EmissionReport |
| `cnCode` | string(8) | |
| `description` | string? | |
| `netMassTonnes` | decimal(14,3) | |
| `see` | decimal(12,6) | engine output |
| `determination` | `ACTUAL` \| `DEFAULT` | flag per line |
| `embeddedTCO2e` | decimal(16,3) | snapshot |

### EvidenceLink
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `reportId` | uuid | FK |
| `documentId` | uuid | FK Document |
| `dataPoint` | string | e.g. `electricity_mwh`, `SEE` |
| `note` | string? | |

### Session / RefreshToken
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `userId` | uuid | FK User |
| `tokenHash` | string | rotate on refresh |
| `expiresAt` | datetime | |
| `revokedAt` | datetime? | |
| `createdAt`, `lastUsedAt` | datetime | |
| `ipHash`, `userAgentHash` | string? | hashed, not raw |

### AuditEvent
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `installationId` | uuid | tenant |
| `actorUserId` | uuid? | |
| `action` | string | e.g. `document.uploaded`, `report.published` |
| `entityType`, `entityId` | string | |
| `metadata` | json | no secrets/PII |
| `ipHash` | string? | hashed |
| `createdAt` | datetime | |

## 3. Status transitions

- **Document:** `UPLOADED → PROCESSING → READY_FOR_AUDIT` or `REJECTED`; any → `QUARANTINED`
  on a failed scan.
- **Report:** `DRAFT → IN_REVIEW → VERIFIED → PUBLISHED → ARCHIVED`.
- **Membership:** `INVITED → ACTIVE → REVOKED`.
- **Installation:** `ACTIVE → SUSPENDED → ARCHIVED`.

## 4. Prisma-style schema (reference)

```prisma
enum Role                { EXPORTER_OWNER EXPORTER_MEMBER CONSULTANT VERIFIER }
enum Sector              { IRON_STEEL ALUMINIUM }
enum DocType             { UTILITY_BILL FUEL_LOG PRECURSOR_INVOICE MILL_CERTIFICATE PRODUCTION_LOG }
enum DocStatus           { UPLOADED PROCESSING READY_FOR_AUDIT REJECTED QUARANTINED }
enum ScanStatus          { PENDING CLEAN INFECTED FAILED }
enum ReportStatus        { DRAFT IN_REVIEW VERIFIED PUBLISHED ARCHIVED }
enum Determination       { ACTUAL DEFAULT }

model User {
  id              String   @id @default(uuid())
  email           String   @unique
  passwordHash    String?
  displayName     String?
  status          String   @default("ACTIVE")
  emailVerifiedAt DateTime?
  lastLoginAt     DateTime?
  createdAt       DateTime @default(now())
  updatedAt       DateTime @updatedAt
  memberships     Membership[]
}

model Installation {
  id          String   @id @default(uuid())
  companyName String
  country     String   @default("IN")
  sector      Sector
  status      String   @default("ACTIVE")
  createdAt   DateTime @default(now())
  updatedAt   DateTime @updatedAt
  memberships Membership[]
  documents   Document[]
  reports     EmissionReport[]
}

model Membership {
  id             String   @id @default(uuid())
  userId         String
  installationId String
  role           Role
  status         String   @default("ACTIVE")
  invitedBy      String?
  createdAt      DateTime @default(now())
  updatedAt      DateTime @updatedAt
  user           User         @relation(fields: [userId], references: [id])
  installation   Installation @relation(fields: [installationId], references: [id])
  @@unique([userId, installationId])
}

model Document {
  id             String     @id @default(uuid())
  installationId String
  uploadedBy     String
  fileName       String
  storageKey     String
  mimeType       String
  sizeBytes      Int
  sha256         String
  docType        DocType
  status         DocStatus  @default(UPLOADED)
  scanStatus     ScanStatus @default(PENDING)
  uploadedAt     DateTime   @default(now())
  processedAt    DateTime?
  deletedAt      DateTime?
  installation   Installation @relation(fields: [installationId], references: [id])
}

model EmissionReport {
  id                  String       @id @default(uuid())
  installationId      String
  periodStart         DateTime
  periodEnd           DateTime
  status              ReportStatus @default(DRAFT)
  calculatedSEE       Decimal      @db.Decimal(12, 6)
  defaultSEE          Decimal      @db.Decimal(12, 6)
  estimatedSavings    Decimal      @db.Decimal(14, 2)
  currency            String       @default("EUR")
  carbonPricePaid     Decimal?     @db.Decimal(14, 2)
  carbonPriceEvidence String?
  reportKey           String?
  version             Int          @default(1)
  createdBy           String
  verifiedBy          String?
  verifiedAt          DateTime?
  createdAt           DateTime     @default(now())
  updatedAt           DateTime     @updatedAt
  installation        Installation @relation(fields: [installationId], references: [id])
}
```

> If the backend is **C#/.NET + EF Core**, map the same fields/enums; keep the OpenAPI contract
> identical. Do not fork the API shape per stack.

## 5. Open questions for review

1. Do consultants sit inside an installation (membership) or have a separate agency scope?
2. Can `EXPORTER_MEMBER` delete documents, or only the owner?
3. Is `VERIFIER` a read-only evidence room in-app, with the formal verification external? (Proposed: yes.)
4. Do we need an internal `ADMIN` role for support? (Proposed: yes, separate from tenant roles.)
5. Retention period for documents/reports (proposed: 24 months after last activity, configurable).
6. Storage: Azure Blob (SAS) or S3 (pre-signed) — see ADR.
