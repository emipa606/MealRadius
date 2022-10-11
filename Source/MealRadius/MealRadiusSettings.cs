using System;
using System.Linq;
using Verse;

namespace MealRadius;

public class MealRadiusSettings : ModSettings
{
    /// <summary>
    ///     The three settings our mod has.
    /// </summary>
    public float searchRadius = 128f;

    /// <summary>
    ///     The part that writes our settings to file. Note that saving is by ref.
    /// </summary>
    public override void ExposeData()
    {
        Scribe_Values.Look(ref searchRadius, "searchRadius", 128f);
        base.ExposeData();
    }

    public void ChangeDef()
    {
        var list = DefDatabase<ThingDef>.AllDefs.ToList();
        foreach (var thingDef in list)
        {
            try
            {
                if (thingDef.HasModExtension<IsMealBase>())
                {
                    thingDef.ingestible.chairSearchRadius = searchRadius;
                }
            }
            catch (Exception exception)
            {
                Log.Message($"Failed to set range for {thingDef.defName} {exception}");
            }
        }
    }
}