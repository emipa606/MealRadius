using Verse;

namespace MealRadius.Settings;

internal class MealRadius_ModSettings : ModSettings
{
    private static float mealRadius = 128f;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref mealRadius, "MealRadius");
    }
}