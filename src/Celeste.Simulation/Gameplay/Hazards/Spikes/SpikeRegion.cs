using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Spikes
{
    public sealed class SpikeRegion
    {
        public global::Celeste.Core.Maps.MapElement Source;

        // Entity.Position is distinct from Bounds for up/left collider offsets.
        public Vector2 Position;
        public global::Celeste.Core.Geometry.Bounds Bounds;
        public global::Celeste.Simulation.Gameplay.Hazards.Spikes.SpikeDirection Direction;
        public bool Collidable = true;
    }
}
