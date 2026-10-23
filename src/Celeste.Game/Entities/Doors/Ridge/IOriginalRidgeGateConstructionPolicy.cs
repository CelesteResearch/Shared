using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.Doors.Ridge
{
    public interface IOriginalRidgeGateConstructionPolicy
    {
        OriginalRidgeGateState Create(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world);
    }
}
