using System;
using System.Linq;
using Verse;

namespace MealRadius.Settings;

internal class MealRadius_ModSettings : ModSettings
{
    internal static float MealRadius = 128f;

    public void ChangeDef()
    {
        var list = DefDatabase<ThingDef>.AllDefs.ToList();
        foreach (var thingDef in list)
        {
            try
            {
                if (thingDef.HasModExtension<IsMealBase>())
                {
                    thingDef.ingestible.chairSearchRadius = MealRadius;
                }
            }
            catch (Exception exception)
            {
                Log.Message($"Failed to set range for {thingDef.defName} {exception}");
            }
        }
    }

    public static void ChangeDefPost()
    {
        var list = DefDatabase<ThingDef>.AllDefs.ToList();
        foreach (var thingDef in list)
        {
            try
            {
                if (thingDef.HasModExtension<IsMealBase>())
                {
                    thingDef.ingestible.chairSearchRadius = MealRadius;
                }
            }
            catch (Exception exception)
            {
                Log.Message($"Failed to set range for {thingDef.defName} {exception}");
            }
        }
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref MealRadius, "MealRadius");
    }
}