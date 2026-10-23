using System;

namespace Celeste.Simulation.Gameplay.Environment.Water
{
    public sealed class OriginalWaterInteractionConstructionPolicy : IWaterInteractionConstructionPolicy
    {
        public static readonly OriginalWaterInteractionConstructionPolicy Instance = new();

        private OriginalWaterInteractionConstructionPolicy()
        {
        }

        public WaterInteractionState Create(Func<bool> isDashing) => new(isDashing);
    }
}
