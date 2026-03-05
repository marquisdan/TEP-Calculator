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

Probabilities are computed using **exact PMF convolution** — no simulation, no approximation.

#### Warmachine Special Rules

- **Snake eyes (all 1s) always miss**, regardless of RAT vs DEF.
- **Boxcars (all 6s) always hit**, regardless of RAT vs DEF.

Both rules are applied before any other probability calculation. Even if the target is so easy that any roll would normally hit, rolling all 1s still misses. Even if the target is so hard that no normal roll could reach, rolling all 6s still hits.

#### How the Probability Engine Works

**Step 1 — Build a dice probability table (`DicePmf`)**

A lookup table is built where each entry holds the probability of rolling exactly that total on N dice.

1. Start with one die: each face (1–6) has a 1-in-6 chance.
2. For each additional die, *convolve* — spread every existing probability across all six new face values. This is the mathematically exact way to combine independent dice.
3. The result is a complete probability distribution covering every possible sum from N (all ones) to 6N (all sixes).

**Step 2 — Calculate hit chance (`HitProbability`)**

In Warmachine, an attack hits if `RAT + roll ≥ DEF`, so the required roll is `DEF − RAT`. The hit probability is the sum of all table entries at or above that threshold, with special-case handling:

- If the target is so easy that even all-1s would normally hit → `P(hit) = 1 − P(all ones)`
- If the target is so hard that even all-6s can't reach it → `P(hit) = P(all sixes)`
- Otherwise → sum the PMF table from the threshold upward

**Step 3 — Calculate expected damage per hit (`ExpectedDamagePerHit`)**

For every possible damage roll total, multiply its probability by `max(roll + POW − ARM, 0)`. The `max(..., 0)` floor means a roll can never deal negative damage. Summing all of these gives the true average damage on a hit.

**Step 4 — Expected Total Damage**

$$\text{Expected Total} = \text{Attacks} \times P(\text{hit}) \times E[\text{damage} \mid \text{hit}]$$

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
