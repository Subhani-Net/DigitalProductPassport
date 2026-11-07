# UI Flows — Application Shell

The shell is what the customer *sees and does*: sign in, manage their installation, upload
documents, watch status, and read the report the engine produced. It is deliberately **not** a
calculator.

## 1. Permissions (groups + granular)

Authorization is **permission-based**. Every member is assigned a **permission group per
installation**; the owner can add per-permission **ALLOW/DENY overrides**. The named roles below
are the built-in group templates — they can be copied and customised per installation.

### Permission keys (all activities)

| Activity | Permission key |
|---|---|
| View installation / dashboard | `installation.read` |
| Edit installation profile | `installation.update` |
| View members | `member.read` |
| Invite members | `member.invite` |
| Revoke members / change groups or overrides | `member.manage` |
| View permission groups | `permission_group.read` |
| Create / edit custom groups | `permission_group.manage` |
| View documents | `document.read` |
| Upload documents | `document.upload` |
| Delete documents | `document.delete` |
| View reports | `report.read` |
| Create draft report | `report.create` |
| Publish report / attach engine output | `report.publish` |
| Download dossier | `report.download` |
| Open evidence room | `evidence.read` |
| View audit events | `audit.read` |
| View settings | `settings.read` |
| Change settings / sessions | `settings.manage` |

### Default group templates

| Permission | Owner | Member | Consultant | Verifier |
|---|---|---|---|---|
| `installation.read` | ✅ | ✅ | ✅ | ✅ |
| `installation.update` | ✅ | — | — | — |
| `member.read` | ✅ | ✅ | — | — |
| `member.invite` | ✅ | — | — | — |
| `member.manage` | ✅ | — | — | — |
| `permission_group.read` | ✅ | — | — | — |
| `permission_group.manage` | ✅ | — | — | — |
| `document.read` | ✅ | ✅ | ✅ | — |
| `document.upload` | ✅ | ✅ | ✅ | — |
| `document.delete` | ✅ | ✅ (own) | — | — |
| `report.read` | ✅ | ✅ | ✅ | ✅ |
| `report.create` | ✅ | ✅ | — | — |
| `report.publish` | ✅ | — | — | — |
| `report.download` | ✅ | ✅ | ✅ | ✅ |
| `evidence.read` | ✅ | ✅ | ✅ | ✅ |
| `audit.read` | ✅ | — | — | — |
| `settings.read` | ✅ | ✅ | ✅ | ✅ |
| `settings.manage` | ✅ | — | — | — |

**Effective permissions** = group permissions ∪ ALLOW overrides − DENY overrides.

> The UI hides what a member cannot do; the **API enforces every permission key**. Custom groups
> are scoped to one installation. Verifier is **read-only for now**; its future capabilities are
> deferred.

## 2. Screens

### 2.1 Auth
- **Sign up** — email, password, name, company, sector.
- **Verify email** — token link; resend.
- **Log in** — email + password; optional MFA later.
- **Forgot / reset password** — no account enumeration.
- **Accept invitation** — token; create account if new; activates membership.
- States: idle, submitting, error (inline, field-level), locked-out, expired token.

### 2.2 Onboarding
- Create the first **installation** (tenant): company, country (default IN), sector
  (IRON_STEEL / ALUMINIUM).
- Explain: *"This is the plant whose documents and reports you will manage."*
- States: empty, saving, success, validation error.

### 2.3 App shell
- Top bar: brand, **installation switcher**, user menu (profile, security, sign out).
- Sidebar/nav: Dashboard · Documents · Reports · Team · Settings.
- Verifier/consultant see only the installations assigned to them.
- Empty state when the user has no membership: "Ask your administrator for an invitation."

### 2.4 Dashboard
Cards, not calculations:
- **Documents**: total, pending, rejected.
- **Latest report**: period, status, SEE (actual), default, **saving** (illustrative, with assumptions).
- **Audit status**: "x of y documents ready".
- Empty state: "Upload your first document to start."
- If a report is `DRAFT`/`IN_REVIEW`, show **"Pending engine review"** — never fake an instant SEE.

### 2.5 Documents
- **List**: name, type, status chip, uploaded by, date; filter by type/status; pagination.
- **Upload** (drag-and-drop or picker):
  1. Validate type (PDF/JPEG/PNG/CSV/XLSX) and size (≤25 MB) in the browser.
  2. `POST upload-intent` → get `documentId` + short-lived `uploadUrl`.
  3. `PUT` the file directly to storage (progress bar; cancel).
  4. `POST complete` → starts scan/processing.
  5. Poll/list status: `UPLOADED → PROCESSING → READY_FOR_AUDIT` or `REJECTED`/`QUARANTINED`.
- **Detail**: metadata, preview (if safe), status timeline, delete (with confirm), audit note.
- Errors: expired URL (re-intent), virus/quarantine, duplicate, wrong type, too large.

### 2.6 Reports
- **List**: period, status, SEE actual, default, saving, version.
- **Detail**:
  - Header: period, status, version, "verifier-ready, not verified".
  - Figures: calculated SEE, default SEE, difference, estimated saving (**with assumptions/currency**).
  - **Goods lines** table: CN code, net mass, SEE, determination (Actual/Default), embedded tCO₂e.
  - **Evidence**: links from data points to documents (drill-down).
  - **Download**: short-lived URL.
  - Status timeline: Draft → In review → Verified → Published.
- If no report: "No report yet — the engine runs in phases. Upload documents to prepare."

### 2.7 Permission groups
- List system templates (read-only) and custom groups (per installation).
- Create/copy/edit a custom group; choose permission keys; preview effective access.
- Assign a group to a member; add **ALLOW/DENY overrides** per permission key.
- Only holders of `permission_group.manage` / `member.manage` can change this; every change writes
  an `AuditEvent`.

### 2.8 Team
- Members with their permission group; invite by email; pending invitations; resend/revoke;
  remove member.
- Owner assigns/changes the group and overrides; every change writes an `AuditEvent`.

### 2.9 Verifier evidence room
- Read-only: installation, report, goods lines, evidence links, download.
- No upload/delete/publish.
- Clearly labelled: **"Evidence room — verification is issued by an accredited partner."**

### 2.10 Settings
- Profile (name, email), password change, active sessions (revoke), notification preferences.
- Danger zone: request account/installation deletion (retention rules apply).

## 3. Interaction states (every screen)

| State | Requirement |
|---|---|
| Empty | Explain what to do next; no dead ends |
| Loading | Skeletons/spinners; never block the whole app |
| Success | Confirm the action; update the view |
| Error | Plain language; retry; support path; no stack traces |
| Permission denied | Explain the role requirement; offer "ask your owner" |
| Offline | Show a banner; queue nothing silently |
| Rate-limited | Show `Retry-After`; disable the action temporarily |

## 4. Accessibility (WCAG 2.2 AA)

- Semantic headings, landmarks, labels, and table headers.
- Full keyboard access; visible focus; skip link.
- Error messages announced (`role="status"`/`aria-live`) and tied to fields.
- Colour is never the only signal (status chips include text).
- Respect `prefers-reduced-motion`.
- Minimum contrast; zoom to 200% without loss.

## 5. Copy rules

- **"Verifier-ready, not verified."**
- No "audit-guaranteed", "certified", "instant calculation", or "AI computes your SEE".
- Figures are **snapshots** with period/version; savings are **illustrative** with assumptions.
- Say "pending engine review" when the engine has not produced the output.

## 6. Non-goals

- No SEE calculation, precursor maths, or default lookup in the browser.
- No LCA/EPD/ESG modules.
- No verification stamp.
- No cross-tenant views.
