using System.Numerics;

namespace Celeste.Simulation.Gameplay.Walls.Breakable
{
    public interface IBreakableWallEntity
    {
        void RemoveSelf();
        void Break(Vector2 from, Vector2 direction, bool playSound, bool playDebrisSound);
    }
}
