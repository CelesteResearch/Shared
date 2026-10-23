using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Simulation.Gameplay.Interaction.Talking
{
    public interface ITalkPlayer
    {
        Vector2 Position { get; }
        float Bottom { get; }
        int State { get; }
        int Facing { get; }
        bool CollideRect(IntRect rectangle);
        bool OnGround();
    }
}
