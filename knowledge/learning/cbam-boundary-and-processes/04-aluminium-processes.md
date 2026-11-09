# Module 4 — Aluminium Processes (Primary, Secondary, Extrusion)

## 1. The chain

```
bauxite → alumina (Bayer) → primary electrolysis (Hall-Héroult) → ingot/billet
                                                              │
secondary: scrap → remelt furnace → ingot ────────────────────┤
                                                              ▼
                                                   extrusion → profiles → anodising
```

> Alumina is a key input. Whether its upstream emissions are treated as a CBAM precursor depends
> on the rules — **verify the Annex I precursor list** before assuming. **[verify]**

## 2. Process steps

### 2.1 Alumina (Bayer process — often off-site)
| | |
|---|---|
| Purpose | refine bauxite to alumina |
| Inputs | bauxite, caustic soda, lime, energy |
| Outputs | alumina; red mud |
| Ask | is alumina produced on-site or purchased? supplier and mass |
| Note | if purchased, it is an input; its emissions may sit upstream |

### 2.2 Primary electrolysis (Hall-Héroult)
| | |
|---|---|
| Purpose | reduce alumina to aluminium metal |
| Inputs | **alumina, cryolite, anodes (carbon), DC electricity** |
| Outputs | **primary aluminium**, **CO₂ from anode consumption**, **PFCs (CF₄/C₂F₆)**, bath materials |
| Ask | potline MWh, anode consumption, **anode-effect count/frequency/duration**, cell technology class |
| Meters | potline electricity (DC), gas/analysis, anode tracking |

**PFCs** are high-GWP and come from **anode effects**. The **slope method** uses anode-effect
minutes and cell technology to estimate CF₄/C₂F₆. Cell technologies (CWPB/PFPB/SWPB/HSS/VSS)
select the factors. **[verify factor set]**

### 2.3 Casting
| | |
|---|---|
| Purpose | cast metal into ingots/billets |
| Inputs | molten aluminium, fuel/electricity, flux |
| Outputs | **ingots/billets**; dross |
| Ask | input/output mass, fuel, dross |

### 2.4 Extrusion
| | |
|---|---|
| Purpose | shape billets into profiles |
| Inputs | **billets**, electricity, **fuel (reheat)**, dies, lubricants |
| Outputs | **profiles**, scrap/butt ends |
| Ask | billet input, profile output, yield, electricity, furnace fuel |

### 2.5 Anodising / surface treatment
| | |
|---|---|
| Purpose | surface finish / corrosion resistance |
| Inputs | profiles, **electricity, acids/chemicals, water**, heat |
| Outputs | anodised profiles; wastewater; chemical waste |
| Ask | electricity, chemicals, water, throughput |

### 2.6 Secondary aluminium (remelt)
| | |
|---|---|
| Purpose | recycle scrap into ingot |
| Inputs | **scrap mix**, remelt fuel, electricity, flux |
| Outputs | **secondary ingot**, dross, off-gas |
| Ask | scrap mix/chemistry, fuel, electricity, yield |
| Note | secondary aluminium has much lower electricity intensity than primary |

## 3. Why aluminium is different

- **Electricity dominates** primary aluminium (often 13–15 MWh/t).
- **PFCs** are a separate, high-GWP stream from anode effects.
- **Cell technology** changes the PFC factor.
- **Secondary** is remelting — fuel and scrap mix matter more than potline electricity.

## 4. What to ask (facts)

- Is alumina produced on-site or purchased? Show invoices/contracts.
- Potline electricity: MWh and meter (DC).
- Anode consumption and anode-effect records.
- Cell technology and PFC factor source.
- Casting throughput and dross.
- Extrusion: billet input, profile output, yield, electricity, furnace fuel.
- Anodising: electricity, chemicals, water.
- Secondary: scrap mix, fuel, electricity, yield.

## 5. Common mistakes

- Treating alumina as automatically a CBAM precursor. **[verify]**
- Ignoring PFCs.
- Mixing primary and secondary routes.
- Using grid electricity for a captive/PPA supply without evidence.
- Missing anode-effect records (the PFC driver).
