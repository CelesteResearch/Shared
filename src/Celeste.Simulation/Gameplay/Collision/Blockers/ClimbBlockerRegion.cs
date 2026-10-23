using Celeste.Core.Geometry;

namespace Celeste.Simulation.Gameplay.Collision.Blockers
{
    public sealed class ClimbBlockerRegion
    {
        public Bounds Bounds;
        public bool Blocking = true, Edge, Collidable = true;
    }
}
