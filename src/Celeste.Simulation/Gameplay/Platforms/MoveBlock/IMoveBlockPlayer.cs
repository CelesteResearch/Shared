using System.Numerics;

namespace Celeste.Simulation.Gameplay.Platforms.MoveBlock
{
    public interface IMoveBlockPlayer
    {
        Vector2 Position { get; }
        bool CollideSolidAt(Vector2 position);
    }
}
