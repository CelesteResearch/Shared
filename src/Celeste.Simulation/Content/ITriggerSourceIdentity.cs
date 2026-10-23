using System.Collections.Generic;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Content
{
    // Source key policy is bound once with a chapter's content profile.
    public interface ITriggerSourceIdentity
    {
        MapEntityId EntityId(MapElement room, MapElement source);
        MapEntityId IncreasedEntityId(MapElement room, MapElement source);
        string PersistentFlagName(MapEntityId identity);
        string Key(MapElement room, MapElement source);
        string IncreasedKey(MapElement room, MapElement source);
        bool ShouldLoad(MapElement room, MapElement source, ISet<MapEntityId> doNotLoad);
    }
}
