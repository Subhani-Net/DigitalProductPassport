# Module 2 — Monitoring Plans & Data Quality

## 2.1 The monitoring plan
A **monitoring plan** is the installation's blueprint: which **source streams** exist, the
**system boundary**, measuring equipment, methods (calc/CEMS/mass-balance), and data management.
It is the first thing a verifier reads, *before* any site visit. **Fact** (ETS-style MRV, adopted
for CBAM).

A good plan answers: *what is measured, how, with what instrument, how often, and by whom.*

## 2.2 Source streams
A **source stream** (IR 2025/2547 Art. 1(8)) is a specific fuel/raw material/product:
(a) giving rise to emissions when consumed/produced, or (b) carrying carbon in a mass-balance.
You enumerate them per installation. **Fact**.

Examples: natural gas, coke, coal/PCI, blast-furnace gas, limestone, electrodes/anodes.

## 2.3 Data quality — tiers & uncertainty
MRV uses **tiers** to express data quality/uncertainty; higher tier = more accurate (measured
and calibrated) data. **Fact**.
- Uncertainty thresholds referenced in the CBAM data catalogue: **≤1.5%** for installations
  **>500 ktCO₂/y**; **<7.5%** below **10 ktCO₂/y**. **Fact**
  (`../../research/cbam-data-catalogue.md` G5 — verify against IR 2025/2546/2547).

Practical implication: **calibration records, meter class, and lab accreditation** are the
evidence a verifier checks. Weak metrology = default fallback risk.

## 2.4 Metrology & labs
- Measurement instruments should be calibrated; **MID** (Measuring Instruments Directive)
  meters for electricity; weighbridges to OIML classes. **Fact/Claim**.
- Calculation factors (NCV, carbon content, composition) should come from **ISO/IEC 17025
  accredited laboratories**, or standard values where permitted. **Fact**.

## 2.5 Documentation you must keep
- Monitoring plan + versions
- Meter/calibration records
- Lab certificates (CoA), mill test certificates (EN 10204)
- Production and mass records
- Methodology documentation for verification. **Fact**.

## 2.6 Common failure modes
- Boundary errors (missing a stream, double-counting a precursor).
- Uncalibrated meters / out-of-date calibration.
- Mixing actual and default inconsistently across periods.
- Missing transferred gases (BF gas, COG) or flaring/venting streams. **Claim**
  (`../../research/cbam-data-catalogue.md` B8/B9, C7/C8).

## Outcome check
1. What belongs in a monitoring plan?
2. What is a source stream, and give three examples.
3. Which evidence proves data quality to a verifier?
