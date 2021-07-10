using UnityEngine;
using Verse;

namespace MealRadius
{
    public class MealRadiusMod : Mod
    {
        /// <summary>
        ///     A reference to our settings.
        /// </summary>
        private readonly MealRadiusSettings settings;

        /// <summary>
        ///     A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public MealRadiusMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<MealRadiusSettings>();
        }

        /// <summary>
        ///     The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            var listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("Search-range for meals");
            listingStandard.Label(settings.searchRadius.ToString());
            settings.searchRadius = listingStandard.Slider(settings.searchRadius, 1f, 300f);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        ///     Override SettingsCategory to show up in the list of settings.
        ///     Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
            return "Meal Radius";
        }
    }
}