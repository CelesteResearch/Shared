namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    // AreaData.OnLevelBegin and Everest's map-meta callback select this once per Level.
    public static class SeekerEffectsEligibility
    {
        public static bool ShouldCreate(int? vanillaAreaId, bool? mapSeekerSlowdown)
        {
            return vanillaAreaId.HasValue ? vanillaAreaId.Value == 5 : mapSeekerSlowdown == true;
        }
    }
}
