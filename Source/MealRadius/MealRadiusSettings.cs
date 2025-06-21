using Verse;

namespace MealRadius;

public class MealRadiusSettings : ModSettings
{
    /// <summary>
    ///     The three settings our mod has.
    /// </summary>
    public float SearchRadius = 128f;

    /// <summary>
    ///     The part that writes our settings to file. Note that saving is by ref.
    /// </summary>
    public override void ExposeData()
    {
        Scribe_Values.Look(ref SearchRadius, "searchRadius", 128f);
        base.ExposeData();
    }
}