using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld.Planet;
using Verse;

namespace MealRadius
{
    public class IsMealBase : DefModExtension
    {
    }

    // Token: 0x0200000F RID: 15
    internal class WorldComp : WorldComponent
    {
        public WorldComp(World world) : base(world)
        {
        }

        public override void FinalizeInit()
        {
            base.FinalizeInit();
            float searchRadius = LoadedModManager.GetMod<MealRadiusMod>().GetSettings<MealRadiusSettings>().searchRadius;
            List<ThingDef> list = DefDatabase<ThingDef>.AllDefs.ToList();
            foreach (ThingDef thingDef in list)
            {
                try
                {
                    if (thingDef.HasModExtension<IsMealBase>())
                    {
                        thingDef.ingestible.chairSearchRadius =  searchRadius;
                    }
                }
                catch (System.Exception exception)
                {
                    Log.Message($"Failed to set range for {thingDef.defName} " + exception);
                }
            }
            Log.Message("MealRadius - Settings loaded", false);
        }
    }
}
