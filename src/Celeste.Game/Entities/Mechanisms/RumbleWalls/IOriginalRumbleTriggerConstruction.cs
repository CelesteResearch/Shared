using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Mechanisms.RumbleWalls
{
    public interface IOriginalRumbleTriggerConstruction
    {
        OriginalRumbleTriggerState Create(EntityData data, Vector2 offset, MapEntityId id,
            ISourceEngineContext engine);
    }
}
