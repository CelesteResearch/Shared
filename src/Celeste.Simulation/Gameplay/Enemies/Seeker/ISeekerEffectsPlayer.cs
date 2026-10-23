using System.Numerics;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public interface ISeekerEffectsPlayer
    {
        Vector2 Center { get; }
        bool Dead { get; }
    }
}
