using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;

namespace Celeste.Everest.Entities.Mechanisms.RumbleWalls
{
    public class EverestRumbleTriggerConstruction : IOriginalRumbleTriggerConstruction
    {
        public OriginalRumbleTriggerState Create(EntityData data, Vector2 offset, MapEntityId id,
            ISourceEngineContext engine)
        {
            return new EverestRumbleTriggerState(data, offset, id, engine);
        }
    }
}
