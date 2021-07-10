using System;
using System.Linq;
using RimWorld.Planet;
using Verse;

namespace MealRadius
{
    // Token: 0x0200000F RID: 15
    internal class WorldComp : WorldComponent
    {
        public WorldComp(World world) : base(world)
        {
        }

        public override void FinalizeInit()
        {
            base.FinalizeInit();
            var searchRadius = LoadedModManager.GetMod<MealRadiusMod>().GetSettings<MealRadiusSettings>().searchRadius;
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
                    Log.Message($"Failed to set range for {thingDef.defName} " + exception);
                }
            }

            Log.Message("MealRadius - Settings loaded");
        }
    }
}