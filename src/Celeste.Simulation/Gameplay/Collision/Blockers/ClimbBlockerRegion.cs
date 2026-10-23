using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Collision.Blockers
{
    public sealed class ClimbBlockerRegion
    {
        public global::Celeste.Core.Geometry.Bounds Bounds;
        public bool Blocking = true, Edge, Collidable = true;
    }
}
