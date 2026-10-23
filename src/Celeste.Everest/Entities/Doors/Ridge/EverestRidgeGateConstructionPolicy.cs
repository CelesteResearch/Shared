using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Doors.Ridge;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Everest.Entities.Doors.Ridge
{
    public sealed class EverestRidgeGateConstructionPolicy : IOriginalRidgeGateConstructionPolicy
    {
        public static readonly EverestRidgeGateConstructionPolicy Instance = new();

        private EverestRidgeGateConstructionPolicy()
        {
        }

        public OriginalRidgeGateState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            => new EverestRidgeGateState(engine, data, offset, world);
    }
}
