# Engine Stub — Interface & Synthetic Output

**Purpose:** the shell must show a credible report while the real CBAM engine is built manually
and in phases. The stub returns a **synthetic snapshot**, clearly labelled, so customers can
interact without the shell pretending to calculate.

## Interface (C#)

```csharp
public interface IEmissionEngine
{
    Task<EngineReportSnapshot> GenerateAsync(EngineRequest request, CancellationToken ct);
}

public sealed record EngineRequest(
    Guid InstallationId,
    DateOnly PeriodStart,
    DateOnly PeriodEnd,
    IReadOnlyList<Guid> DocumentIds);

public sealed record EngineReportSnapshot(
    decimal CalculatedSee,        // tCO2e/t
    decimal DefaultSee,           // tCO2e/t
    decimal EstimatedSavings,
    string Currency,              // EUR
    IReadOnlyList<EngineGoodsLine> Goods,
    IReadOnlyList<string> Assumptions,
    int Version,
    bool IsSynthetic,
    DateTimeOffset GeneratedAt);

public sealed record EngineGoodsLine(
    string CnCode,
    string Description,
    decimal NetMassTonnes,
    decimal See,
    string Determination,        // ACTUAL | DEFAULT
    decimal EmbeddedTco2e);
```

## Stub behaviour

- Returns a **fixed synthetic snapshot** for a known period (e.g. CY 2026), anchored to the
  existing demo fixtures (BF-BOF 2.04 vs default 2.10).
- `IsSynthetic = true`; the UI must display **"Pilot sample — engine pending."**
- No document parsing, no precursor maths, no defaults lookup.
- The snapshot is stored on `EmissionReport`; the shell never computes SEE.

## Rules

1. The shell calls `IEmissionEngine` only from a background/manual action (`report.publish`).
2. If no snapshot exists, the report status is `DRAFT` and the UI shows **"Pending engine review."**
3. Synthetic reports are never presented as verified; the boundary line stays
   **"verifier-ready, not verified."**
4. Replacing the stub with the real engine must not change the API or UI — only the implementation.

## Acceptance criteria (stub story)

- [ ] `IEmissionEngine` is resolved via DI; the stub is used in dev.
- [ ] Generating a report returns a snapshot with `IsSynthetic=true`.
- [ ] The UI labels the snapshot and never shows a final-looking SEE while pending.
- [ ] Goods lines carry `ACTUAL`/`DEFAULT` flags and evidence links.
- [ ] No calculation logic exists in the shell/API.

## Production engine — separate story (not now)

- Real SEE pipeline (direct, indirect where applicable, precursors, allocation).
- Evidence dossier + verifier hand-off.
- Validation intelligence and tests (see `product/` and `business/product-spec.md`).
- The engine remains **C#/.NET**, separate from the shell.
