using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Movement
{
    public interface IMovingSolid
    {
        Vector2 Position { get; }
        Vector2 LiftSpeed { get; }
        bool Collidable { get; }
    }
}
