using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Environment.Water
{
    public interface ISourceWaterCollisionInteraction
    {
        Vector2 AbsoluteCenter { get; }
        IntRect Bounds { get; }
        bool Check(ISourceEntityCollider water);
    }
}
