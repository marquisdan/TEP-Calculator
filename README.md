# TEP Calculator

## HAIL CYRISS!

Have you ever struggled to figure out how to best allocate your servitors when attacking with the **Transfinite Emergence Projector (TEP)** ? This tool will help you with your calculations! 


## What It Does

The TEP starts each activation by allocating **3 buffs** (servitors) that can be distributed freely across three stats:

| Buff | Effect |
|---|---|
| Attack Dice | Adds dice to the attack roll (base 2d6) |
| Damage Dice | Adds dice to the damage roll (base 2d6) |
| Extra Attacks | Adds attacks to the unit (base 2) |

TEP Calculator evaluates all 10 valid allocations (every combination of a+b+c=3) and tells you which one maximises **expected total damage** against a given target.

### Inputs

- **RAT** — Ranged Attack Target of the firing model
- **POW** — Power stat of the weapon
- **Target DEF** — Defence of the target model
- **Target ARM** — Armour of the target model

### Outputs

- **Best Allocation** — The single optimal split of the 3 buff tokens, showing:
  - Attack Dice / Damage Dice / Number of Attacks
  - Hit Chance (%)
  - Expected Total Damage
  - If All Hit (upper-bound damage assuming every shot lands)
- **All Allocations Table** — All 10 combinations ranked and sortable by any column

### Math

Probabilities are computed using **exact PMF convolution** — no simulation, no approximation. The probability mass function of rolling N d6s is built iteratively, giving precise hit chance and expected damage values for any dice count.

Expected Total Damage is calculated as:

$$\text{Expected Total} = \text{Attacks} \times P(\text{hit}) \times E[\text{damage} \mid \text{hit}]$$

Damage is floored at 0 (a roll can never deal negative damage).

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | [Blazor WebAssembly](https://learn.microsoft.com/en-us/aspnet/core/blazor/) (.NET 10) |
| UI Components | [MudBlazor](https://mudblazor.com/) |
| Language | C# |
| Hosting | Static files — no server required |
| PWA | Web app manifest + service worker included |

Runs entirely client-side in the browser via WebAssembly — no backend, no API calls.

## Credits

UI components provided by **[MudBlazor](https://mudblazor.com/)** — a Material Design component library for Blazor.

## Getting Started

```bash
dotnet run --project TepBest
```

Or open `TepBest.slnx` in Visual Studio / VS Code and press F5.
