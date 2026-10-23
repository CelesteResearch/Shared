using System.Numerics;

namespace Celeste.Simulation.Gameplay.Platforms.Moving
{
    public interface IRotatingPlatformWorld
    {
        void MoveTo(Vector2 position);
    }
}
