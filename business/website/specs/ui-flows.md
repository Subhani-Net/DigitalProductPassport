# UI Flows — Application Shell

The shell is what the customer *sees and does*: sign in, manage their installation, upload
documents, watch status, and read the report the engine produced. It is deliberately **not** a
calculator.

## 1. Roles and permissions

| Action | Owner | Member | Consultant | Verifier |
|---|---|---|---|---|
| View installation / dashboard | ✅ | ✅ | ✅ (assigned) | ✅ (assigned) |
| Upload document | ✅ | ✅ | ✅ | ❌ |
| Delete document | ✅ | own uploads only | ❌ | ❌ |
| Create draft report | ✅ | ✅ | ❌ | ❌ |
| Attach engine output / publish report | ✅ | ❌ | ❌ | ❌ |
| View report + evidence | ✅ | ✅ | ✅ | ✅ |
| Download dossier | ✅ | ✅ | ✅ | ✅ |
| Invite / revoke members | ✅ | ❌ | ❌ | ❌ |
| Change installation profile | ✅ | ❌ | ❌ | ❌ |

> The UI hides what a role cannot do; the **API enforces it**. Verifier = read-only evidence room;
> the formal verification remains external.

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

### 2.7 Team
- Members with roles; invite by email (Consultant / Verifier / Member); pending invitations;
  resend/revoke; remove member.
- Role changes are owner-only; every change writes an `AuditEvent`.

### 2.8 Verifier evidence room
- Read-only: installation, report, goods lines, evidence links, download.
- No upload/delete/publish.
- Clearly labelled: **"Evidence room — verification is issued by an accredited partner."**

### 2.9 Settings
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
