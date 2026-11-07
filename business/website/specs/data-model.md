# Data Model — Application Shell

Enhanced from `1. The Database Architecture (Schema Spec).txt`. The shell stores **who** the user
is, **which installation (tenant)** they belong to, **what they are allowed to do**, **which
documents** they uploaded, and the **reports/evidence** they display. It does **not** compute SEE;
the engine does that manually and in phases.

## 1. Design rules

1. **Tenant boundary = `Installation`.** Every tenant-owned row carries `installationId`.
2. **Authorization is permission-based.** A member gets a **permission group** per installation,
   plus optional **per-permission overrides**. Roles are just system group templates.
3. **Server-side authorization only.** The UI may hide actions; the API enforces permissions.
4. **RLS + application checks.** PostgreSQL row-level security is the backstop; handlers still
   check permission keys.
5. **Soft delete + audit.** Never hard-delete documents/reports silently; record `deletedAt` and
   an `AuditEvent`.
6. **Decimal, not float**, for emissions/money.
7. **Engine outputs are stored snapshots**, not recomputed in the shell.
8. **Auth is a stub now**; production auth is a separate story. The data model does not assume a
   specific provider.

## 2. Permission catalog

| Key | Activity |
|---|---|
| `installation.read` | View the installation and dashboard |
| `installation.update` | Edit company/country/sector |
| `member.read` | View members |
| `member.invite` | Invite members |
| `member.manage` | Revoke members, change groups/overrides |
| `permission_group.read` | View permission groups |
| `permission_group.manage` | Create/edit/delete custom groups |
| `document.read` | List/view document metadata |
| `document.upload` | Request upload intent / complete upload |
| `document.delete` | Soft-delete documents |
| `report.read` | View reports and goods lines |
| `report.create` | Create a draft report record |
| `report.publish` | Attach engine output / publish a report |
| `report.download` | Download the dossier |
| `evidence.read` | Open the evidence room |
| `audit.read` | View audit events |
| `settings.read` | View settings |
| `settings.manage` | Change settings, sessions |

### System group templates (`installationId = null`, `isSystem = true`)

| Group | Permissions |
|---|---|
| **Exporter Owner** | all of the above |
| **Exporter Member** | `installation.read`, `member.read`, `document.read/upload/delete`, `report.read/create/download`, `evidence.read`, `settings.read` |
| **Consultant** | `installation.read`, `document.read/upload`, `report.read/download`, `evidence.read` |
| **Verifier** | `installation.read`, `report.read/download`, `evidence.read` — **read-only for now** |

> Custom groups are created **per installation**; a group from installation A can never be
> assigned in installation B.

**Effective permissions** = `group permissions ∪ ALLOW overrides − DENY overrides`.

## 3. Entities

### User
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `email` | citext, unique | login identity |
| `passwordHash` | string? | null if managed/SSO auth; stub uses a dev hash |
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

### Permission (global catalog)
| Field | Type | Notes |
|---|---|---|
| `key` | string | PK, e.g. `document.upload` |
| `category` | string | `documents`, `reports`, `team`, … |
| `description` | string | human label |

### PermissionGroup
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `installationId` | uuid? | **null** for system templates; set for custom groups |
| `name` | string | |
| `description` | string? | |
| `isSystem` | boolean | system groups are read-only |
| `createdBy` | uuid? | |
| `createdAt`, `updatedAt` | datetime | |
| — | unique | `(installationId, name)` |

### PermissionGroupItem
| Field | Type | Notes |
|---|---|---|
| `groupId` | uuid | FK PermissionGroup |
| `permissionKey` | string | FK Permission |
| — | PK | `(groupId, permissionKey)` |

### Membership (user ↔ installation ↔ group)
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `userId` | uuid | FK User |
| `installationId` | uuid | FK Installation |
| `permissionGroupId` | uuid | FK PermissionGroup (must belong to this installation or be system) |
| `status` | `INVITED` \| `ACTIVE` \| `REVOKED` | |
| `invitedBy` | uuid? | FK User |
| `createdAt`, `updatedAt` | datetime | |
| — | unique | `(userId, installationId)` |

### MembershipPermissionOverride
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `membershipId` | uuid | FK Membership |
| `permissionKey` | string | FK Permission |
| `effect` | `ALLOW` \| `DENY` | |
| `createdBy` | uuid | FK User |
| `createdAt` | datetime | |
| — | unique | `(membershipId, permissionKey)` |

### Invitation
| Field | Type | Notes |
|---|---|---|
| `id` | uuid | PK |
| `installationId` | uuid | FK Installation |
| `email` | citext | invitee |
| `permissionGroupId` | uuid | FK PermissionGroup |
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
| `isSynthetic` | boolean | **true for the pilot/engine stub** |
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
| `action` | string | e.g. `permission_group.updated`, `document.uploaded` |
| `entityType`, `entityId` | string | |
| `metadata` | json | no secrets/PII |
| `ipHash` | string? | hashed |
| `createdAt` | datetime | |

## 4. Status transitions

- **Document:** `UPLOADED → PROCESSING → READY_FOR_AUDIT` or `REJECTED`; any → `QUARANTINED`.
- **Report:** `DRAFT → IN_REVIEW → VERIFIED → PUBLISHED → ARCHIVED`.
- **Membership:** `INVITED → ACTIVE → REVOKED`.
- **Installation:** `ACTIVE → SUSPENDED → ARCHIVED`.

## 5. Prisma-style schema (reference — EF Core mirrors it)

```prisma
enum MembershipStatus { INVITED ACTIVE REVOKED }
enum Sector           { IRON_STEEL ALUMINIUM }
enum DocType          { UTILITY_BILL FUEL_LOG PRECURSOR_INVOICE MILL_CERTIFICATE PRODUCTION_LOG }
enum DocStatus        { UPLOADED PROCESSING READY_FOR_AUDIT REJECTED QUARANTINED }
enum ScanStatus       { PENDING CLEAN INFECTED FAILED }
enum ReportStatus     { DRAFT IN_REVIEW VERIFIED PUBLISHED ARCHIVED }
enum Determination    { ACTUAL DEFAULT }
enum OverrideEffect   { ALLOW DENY }

model Permission {
  key         String @id
  category    String
  description String
}

model PermissionGroup {
  id             String   @id @default(uuid())
  installationId String?
  name           String
  description    String?
  isSystem       Boolean  @default(false)
  createdAt      DateTime @default(now())
  updatedAt      DateTime @updatedAt
  items          PermissionGroupItem[]
  @@unique([installationId, name])
}

model PermissionGroupItem {
  groupId       String
  permissionKey String
  @@id([groupId, permissionKey])
}

model Membership {
  id                String   @id @default(uuid())
  userId            String
  installationId    String
  permissionGroupId String
  status            MembershipStatus @default(ACTIVE)
  invitedBy         String?
  createdAt         DateTime @default(now())
  updatedAt         DateTime @updatedAt
  overrides         MembershipPermissionOverride[]
  @@unique([userId, installationId])
}

model MembershipPermissionOverride {
  id            String @id @default(uuid())
  membershipId  String
  permissionKey String
  effect        OverrideEffect
  createdBy     String
  createdAt     DateTime @default(now())
  @@unique([membershipId, permissionKey])
}
```

## 6. RLS and tenancy

- PostgreSQL session variable `app.current_installation_id` is set per request.
- Policies on `Document`, `EmissionReport`, `GoodsLine`, `EvidenceLink`, `Membership`,
  `MembershipPermissionOverride`, `Invitation`, `AuditEvent`, and custom `PermissionGroup`.
- `Permission` and system `PermissionGroup` rows are global read-only.
- A custom group is valid in an installation **only if** `group.installationId` matches.
- Tests must prove cross-tenant reads/writes return 403/404, not data.

## 7. Open questions for review

1. Consultant default group: upload or read-only?
2. Can `EXPORTER_MEMBER` delete their own documents without an explicit permission? (Proposed:
   `document.delete` is a permission; the Member template includes it, scoped to own uploads.)
3. Retention period (proposed 24 months after last activity).
4. Internal `ADMIN` role outside tenant permissions? (Proposed: yes, separate.)
5. Verifier capabilities beyond read-only — **deferred** (explicitly).
