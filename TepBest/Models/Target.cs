namespace TepBest.Models;

public class Target
{
    public string Label    { get; set; } = "";
    public int    Def      { get; set; } = 10;
    public int    Arm      { get; set; } = 18;
    public int    Boxes    { get; set; } = 1;
    public bool   IsPriority { get; set; } = false;
}
