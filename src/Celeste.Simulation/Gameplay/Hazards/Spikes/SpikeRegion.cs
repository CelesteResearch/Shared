using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Gameplay.Hazards.Spikes
{
    public sealed class SpikeRegion
    {
        public MapElement Source;

        // Entity.Position is distinct from Bounds for up/left collider offsets.
        public Vector2 Position;
        public Bounds Bounds;
        public SpikeDirection Direction;
        public bool Collidable = true;
    }
}
