using System;
using System.Linq;
using RimWorld.Planet;
using Verse;

namespace MealRadius;

internal class WorldComp(World world) : WorldComponent(world)
{
    public override void FinalizeInit(bool fromLoad)
    {
        base.FinalizeInit(fromLoad);
        var searchRadius = LoadedModManager.GetMod<MealRadiusMod>().GetSettings<MealRadiusSettings>().SearchRadius;
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

        Log.Message("MealRadius - Settings loaded");
    }
}