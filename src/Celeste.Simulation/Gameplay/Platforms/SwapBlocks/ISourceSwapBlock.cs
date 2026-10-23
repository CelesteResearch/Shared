using System.Numerics;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Platforms.SwapBlocks
{
    public interface ISourceSwapBlock : ISourceEntityCollider
    {
        Vector2 Direction { get; }
        bool Swapping { get; }
    }
}
