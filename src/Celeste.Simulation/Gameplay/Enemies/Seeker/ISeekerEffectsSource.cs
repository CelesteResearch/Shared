using System.Numerics;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public interface ISeekerEffectsSource
    {
        Vector2 Center { get; }
        bool Regenerating { get; }
        bool Attacking { get; }
    }
}
