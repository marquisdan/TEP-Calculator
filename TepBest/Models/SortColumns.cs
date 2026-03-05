namespace TepBest.Models;

public static class SortColumns
{
    public const string AvgDmg     = "Average Total Damage";
    public const string IfAllHit   = "If All Hit";
    public const string HitChance  = "Hit Chance";
    public const string KillChance = "Kill Chance";
    public const string AttackDice = "Attack Dice";
    public const string DamageDice = "Damage Dice";
    public const string NumAttacks = "Number of Attacks";
    public const string None       = "None";

    public static readonly string[] Sort1Options =
        [AvgDmg, KillChance, HitChance, IfAllHit, AttackDice, DamageDice, NumAttacks];

    public static readonly string[] Sort2Options =
        [None, AvgDmg, KillChance, HitChance, IfAllHit, AttackDice, DamageDice, NumAttacks];
}
