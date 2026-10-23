using System;
using System.Collections.Generic;
using Celeste.Core.Maps;
using Celeste.Simulation.Content;

namespace Celeste.Simulation
{
    // This registry owns load-time source selection and the live player dispatch order.
    // It does not replace the family states' collision, Triggered or OnLeave logic.
    public sealed class RoomTriggerLoadPlan
    {
        public readonly MapElement Room;

        public readonly List<MapElement> LoadedSources = [];

        private readonly ISet<MapEntityId> doNotLoad;
        private readonly ITriggerSourceIdentity identity;
        private bool constructionStarted;

        public RoomTriggerLoadPlan(MapElement room,
            ISet<MapEntityId> doNotLoad, ITriggerSourceIdentity identity)
        {
            Room = room ?? throw new ArgumentNullException(nameof(room));
            this.doNotLoad = doNotLoad;
            this.identity = identity ?? throw new ArgumentNullException(nameof(identity));
        }

        // Check each source only when the constructor loop reaches it. An earlier
        // source's custom factory may change Session.DoNotLoad for a later source.
        public IEnumerable<MapElement> ConstructSources()
        {
            if (constructionStarted) throw new InvalidOperationException("A room trigger plan constructs only once.");
            constructionStarted = true;
            var triggers = Room.Child("triggers")?.Children;
            if (triggers == null) yield break;
            foreach (var source in triggers)
                if (identity.ShouldLoad(Room, source, doNotLoad))
                {
                    LoadedSources.Add(source);
                    yield return source;
                }
        }
    }
}
