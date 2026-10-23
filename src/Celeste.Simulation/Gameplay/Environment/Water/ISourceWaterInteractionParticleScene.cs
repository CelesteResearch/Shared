using System.Numerics;

namespace Celeste.Simulation.Gameplay.Environment.Water
{
    public interface ISourceWaterInteractionParticleScene
    {
        void EmitWaterDrip(Vector2 position);
    }
}
