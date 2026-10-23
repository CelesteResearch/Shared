using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public interface ISourceSolidTilesEntity : ISourceEntityCollider
    {
        GridColliderGeometry Grid { get; }
    }
}
