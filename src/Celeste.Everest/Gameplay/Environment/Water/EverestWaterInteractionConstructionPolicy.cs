using System;
using Celeste.Simulation.Gameplay.Environment.Water;

namespace Celeste.Everest.Gameplay.Environment.Water
{
    public sealed class EverestWaterInteractionConstructionPolicy : IWaterInteractionConstructionPolicy
    {
        public static readonly EverestWaterInteractionConstructionPolicy Instance = new();

        private EverestWaterInteractionConstructionPolicy()
        {
        }

        public WaterInteractionState Create(Func<bool> isDashing)
        {
            return new EverestWaterInteractionState(isDashing);
        }
    }
}
