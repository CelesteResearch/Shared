using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Mechanisms.RumbleWalls
{
    public class OriginalRumbleTriggerConstruction : IOriginalRumbleTriggerConstruction
    {
        public OriginalRumbleTriggerState Create(EntityData data, Vector2 offset, MapEntityId id,
            ISourceEngineContext engine) => new OriginalRumbleTriggerState(data, offset, id, engine);
    }
}
