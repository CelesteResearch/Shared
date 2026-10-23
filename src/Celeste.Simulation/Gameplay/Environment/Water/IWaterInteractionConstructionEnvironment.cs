using System;

namespace Celeste.Simulation.Gameplay.Environment.Water
{
    public interface IWaterInteractionConstructionPolicy
    {
        WaterInteractionState Create(Func<bool> isDashing);
    }

    public interface IWaterInteractionConstructionEnvironment
    {
        IWaterInteractionConstructionPolicy WaterInteractions { get; }
    }
}
