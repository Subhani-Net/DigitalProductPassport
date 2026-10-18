# Demo Data Pack & End-to-End Journey

Seedable synthetic data to run the whole CBAM journey **end-to-end**, before the application
code exists. Values are **illustrative**, anchored to public references: EC default values
(IR 2025/2621) and worldsteel / IAI intensity benchmarks. Secondary aluminium deferred.

## The journey (what the demo drives)

1. **Capture** — exporters ingest S0/S1 data → auto-map → unit-normalize (Pillar 1).
2. **Validate** — SEE per route, actual-vs-default, precursor roll-up (Pillar 2).
3. **Transfer** — upload once → registry (Pillar 4).
4. **Consume** — importer EORI-link → retrieve verified data → assemble declaration → settle (Pillar 2/4).
5. **Assure** — verifier read-only drill-down → evidence dossier → report (Pillar 3).
6. **Sell-twice** — same steel data → DPP passport (Pillar 4 p3).
7. **The wedge** — actual-vs-default saving (€) in one run.

## Fixtures

| File | What | SEE (tCO₂e/t) | Anchor |
|---|---|---|---|
| `exporter-bf-bof.json` | steel, blast furnace–basic oxygen | **2.04** | EC BF default ~2.10; worldsteel ~2.0–2.3 |
| `exporter-eaf.json` | steel, electric arc furnace | **0.47** | EC EAF default ~0.45 |
| `exporter-dri.json` | steel, direct-reduced iron (gas) | **1.22** | gas DRI ~1.0–1.4 |
| `exporter-aluminium-primary.json` | primary aluminium (electricity-dominant) | **14.98** | IAI global ~16.5 (PFC deferred to p3) |
| `precursor-chain.json` | complex good: crude steel → galvanised strip | **3.28** | precursor-dominated |
| `importer-declaration.json` | EU importer: EORI, import lines, settlement | — | Art-35 fields |
| `edge-cases.json` | missing OF, missing electricity, implausible EF, default fallback | — | Pillar 2 p1/p2 |
| `expected-outputs.json` | the test oracle: expected SEE / declaration / savings | — | hand-computed |

## Notes

- Shape is the **calc-inputs stub** (`src/model/calc-inputs.schema.json`); the full A–F model
  lands with C2.
- **Deferred:** secondary aluminium, aluminium PFC (slope method), multi-tier precursors.
- **Spec:** the journey is captured as Gherkin in
  `../tests/DppCore.Tests/Features/pillars/end-to-end.feature`.
- **Run (later, build phase):** a `seed`/`run-demo` command loads these fixtures and emits the
  declaration, evidence dossier, passport and proof — the demo artifacts.
