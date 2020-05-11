using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace MealRadius.Settings
{
    // Token: 0x0200000D RID: 13
    internal class MealRadius_ModSettings : ModSettings
    {
        internal static float MealRadius = 128f;

        public void ChangeDef()
        {
            List<ThingDef> list = DefDatabase<ThingDef>.AllDefs.ToList();
            foreach (ThingDef thingDef in list)
            {
                try
                {
                    if (thingDef.HasModExtension<IsMealBase>())
                    {
                        thingDef.ingestible.chairSearchRadius = MealRadius;
                    }
                }
                catch (System.Exception exception)
                {
                    Log.Message($"Failed to set range for {thingDef.defName} " + exception);
                }
            }
        }

        public static void ChangeDefPost()
        {
            List<ThingDef> list = DefDatabase<ThingDef>.AllDefs.ToList();
            foreach (ThingDef thingDef in list)
            {
                try
                {
                    if (thingDef.HasModExtension<IsMealBase>())
                    {
                        thingDef.ingestible.chairSearchRadius = MealRadius;
                    }
                }
                catch (System.Exception exception)
                {
                    Log.Message($"Failed to set range for {thingDef.defName} " + exception);
                }
            }
        }

        // Token: 0x06000024 RID: 36 RVA: 0x0000345C File Offset: 0x0000165C
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref MealRadius, "MealRadius", 0.0f, false);
        }


    }
}
