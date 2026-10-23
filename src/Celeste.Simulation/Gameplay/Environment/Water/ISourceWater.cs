using System.Numerics;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Environment.Water
{
    public interface ISourceWater : ISourceEntityCollider
    {
        Vector2 Center { get; }
        ISourceWaterSurface TopSurface { get; }
    }

    public interface ISourceWaterSurface
    {
        void DoRipple(Vector2 position, float multiplier);
    }
}
