using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;


namespace MealRadius
{
    public class MealRadiusSettings : ModSettings
    {

        /// <summary>
        /// The three settings our mod has.
        /// </summary>
        public float searchRadius = 128f;

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref searchRadius, "searchRadius", 128f);
            base.ExposeData();
        }

        public void ChangeDef()
        {
            List<ThingDef> list = DefDatabase<ThingDef>.AllDefs.ToList();
            foreach (ThingDef thingDef in list)
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
        }

    }

    public class MealRadiusMod : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        MealRadiusSettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public MealRadiusMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<MealRadiusSettings>();
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("Search-range for meals");
            listingStandard.Label(settings.searchRadius.ToString());
            settings.searchRadius = listingStandard.Slider(settings.searchRadius, 1f, 300f);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
            return "Meal Radius";
        }
    }
}
