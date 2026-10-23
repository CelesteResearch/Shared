using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.Doors.Ridge
{
    public sealed class OriginalRidgeGateConstructionPolicy : IOriginalRidgeGateConstructionPolicy
    {
        public static readonly OriginalRidgeGateConstructionPolicy Instance = new();

        private OriginalRidgeGateConstructionPolicy()
        {
        }

        public OriginalRidgeGateState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
        {
            return new(engine, data, offset, world);
        }
    }
}
