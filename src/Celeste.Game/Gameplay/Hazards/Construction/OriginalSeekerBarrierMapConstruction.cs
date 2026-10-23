using System.Numerics;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Hazards.Construction
{
    public static class OriginalSeekerBarrierMapConstruction
    {
        public static SeekerBarrierState Create(EntityData data, Vector2 offset, ISourceSolidWorld world)
        {
            var barrier = new SeekerBarrierState(data.Position + offset, data.Width, data.Height, world);
            if (((ISourceSeekerBarrierBehaviorEnvironment)world.EngineContext).SeekerBarrierBehavior
                .ReadMapStaticMovers)
                barrier.AllowStaticMovers = EntityAttributeReader.Bool(data.Values, "allowStaticMovers", true);
            return barrier;
        }
    }
}
