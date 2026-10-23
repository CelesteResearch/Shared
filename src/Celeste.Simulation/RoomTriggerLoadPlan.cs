using System;
using System.Collections.Generic;
using Celeste.Simulation.Rendering;
using Celeste.Simulation.Content;

namespace Celeste.Simulation
{
    // This registry owns load-time source selection and the live player dispatch order.
    // It does not replace the family states' collision, Triggered or OnLeave logic.
    public sealed class RoomTriggerLoadPlan
    {
        public readonly global::Celeste.Core.Maps.MapElement Room;

        public readonly List<global::Celeste.Core.Maps.MapElement> LoadedSources =
            new List<global::Celeste.Core.Maps.MapElement>();

        private readonly ISet<global::Celeste.Core.Maps.MapEntityId> doNotLoad;
        private readonly ITriggerSourceIdentity identity;
        private bool constructionStarted;

        public RoomTriggerLoadPlan(global::Celeste.Core.Maps.MapElement room,
            ISet<global::Celeste.Core.Maps.MapEntityId> doNotLoad, ITriggerSourceIdentity identity)
        {
            Room = room ?? throw new ArgumentNullException(nameof(room));
            this.doNotLoad = doNotLoad;
            this.identity = identity ?? throw new ArgumentNullException(nameof(identity));
        }

        // Check each source only when the constructor loop reaches it. An earlier
        // source's custom factory may change Session.DoNotLoad for a later source.
        public IEnumerable<global::Celeste.Core.Maps.MapElement> ConstructSources()
        {
            if (constructionStarted) throw new InvalidOperationException("A room trigger plan constructs only once.");
            constructionStarted = true;
            var triggers = Room.Child("triggers")?.Children;
            if (triggers == null) yield break;
            foreach (global::Celeste.Core.Maps.MapElement source in triggers)
                if (identity.ShouldLoad(Room, source, doNotLoad))
                {
                    LoadedSources.Add(source);
                    yield return source;
                }
        }
    }
}
