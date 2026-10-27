# Trial Playbook — "We're good for a trial"

When a prospect says *"we're good for a trial"*, **do not hand over free access with no ask.**
Convert it into a **structured pilot** with a defined goal, a time-box, and an exchange. A free
trial with no commitment is how you lose weeks and learn nothing.

## The 4-step response

### 1. Confirm scope
> "Great. To make it a fair test, let's agree what we'll run — your steel [or aluminium] data for
> one installation, one reporting period."

### 2. Agree the success metric (their words, not yours)
> "What would make this a success for you — seeing your **verified SEE** and the **actual-vs-
> default saving** on your own numbers?"

### 3. Time-box + ask for what you need
> "I'll run a **2-week pilot**: you share your current data (logs, tickets, bills, mill
> certificates — S0/S1 is fine), I return the number, the evidence trail, and the saving. In
> exchange, if it works, I'd like a **short reference / case-study line** and a conversation about
> moving to a paid plan (€8–15k/yr)."

### 4. Land a light commitment (a one-pager, not a lawyer)
- A **pilot agreement**: scope, 2 weeks, data you'll receive, success metric, case-study permission,
  and the conversion trigger ("if X is met, we discuss the Base plan").
- **Never** require heavy legal at this stage — a one-page email-confirmed agreement is enough.

## The exchange principle (never free, never empty)

| They give | You give |
|---|---|
| Real (even S0/S1) data | the SEE + evidence + saving on *their* numbers |
| A named champion + time | fast turnaround + hand-holding |
| Permission to reference | early access / discounted pilot-to-paid |
| Feedback (what's wrong) | fixes that become product |

## Outcomes to target from a pilot

1. **Paid conversion** — success metric met → Base plan (€8–15k/yr).
2. **Case study + testimonial** — not ready to pay yet, but willing to be referenced.
3. **LOI / named champion** — signal for the investor deck.
4. **Clear "no" with reason** — still valuable: it's the validation data you're missing.

## Guardrails
- **Time-box hard** (2 weeks). A pilot that drags becomes free consulting.
- **S0/S1 data only at first** — don't promise ERP/OT integration in a trial.
- **Log every signal** in the target list (`target-list.md` status) — it feeds the investor story.

---

## Concierge pilot — what you can honestly deliver *before* the app exists

You do not yet have the full application, nor the verifier-grade consultant. That is fine — the
first pilots are run **manually ("concierge")**, and you must be honest about stage.

**What you already have enough of:**
- The **CBAM methodology** (documented in `../../knowledge/learning/`, `../../knowledge/research/cbam-data-catalogue.md`,
  `../../knowledge/research/data-inputs-reference.md`) — enough to compute a *draft* SEE for a simple BF-BOF/EAF case.
- The **calculator** (`../../product/src/DppCore/CbamCalculator.cs` + `CbamDeclaration.cs`) + the **demo data pack**.
- The **demo** as proof of the method.

**What you honestly deliver in a pilot (manual, 2 weeks):**
1. Draft **SEE** (direct + indirect + precursors) from their S0/S1 data.
2. An **evidence trail** (which inputs → which factor → which figure).
3. The **actual-vs-default saving** on their numbers.
4. A **"verifier-ready, not verified"** note — the accredited **stamp comes from a partner
   verifier**, not us.

**What you do NOT claim:** "verified" · "the app does it automatically" · "accredited in-house".

**The honest customer line when they ask "where's the software?":**
> "We're running a pilot programme — I process your data using the CBAM methodology and deliver
> your draft SEE, evidence trail and saving in ~2 weeks. Final verification is with an accredited
> partner verifier. If the numbers are useful, we move to the product and a paid plan."

**The consultant gap:** the consultant is for *encoding the moat at scale* (route-specific
validation intelligence), **not** for running the first few pilots. You already know enough to
produce a verifier-ready draft for a simple case; engage the consultant (post C2–C4) once you've
validated demand, not before.

**Rule: one pilot at a time.** Each manual pilot also *generates* the app's requirements — it is
the spec, not a distraction. But do not take more pilots than you can deliver by hand.
