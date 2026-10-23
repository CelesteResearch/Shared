using System.Numerics;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ISourceLightningScene
    {
        bool Invincible { get; }
        void EmitLightningShatter(Vector2 position, Vector2 range);
    }
}
