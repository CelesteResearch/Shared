using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Scene.Tracking
{
    internal sealed class SceneTrackerSnapshot
    {
        internal Dictionary<string, SceneEntityType> Types { get; }
        private readonly Dictionary<Type, SceneEntityType> actualTypes;
        internal HashSet<string> TrackedTypes { get; }
        internal string[] StoredEntityTypes { get; }
        internal string[] StoredComponentTypes { get; }
        internal int EntityTypeCount { get; }
        internal int ComponentTypeCount { get; }
        internal int TrackedTypeVersion { get; }

        internal SceneTrackerSnapshot(Dictionary<string, SceneEntityType> types,
            Dictionary<Type, SceneEntityType> actualTypes, IEnumerable<string> tracked,
            IEnumerable<string> entities, IEnumerable<string> components, int entityCount, int componentCount,
            int trackedTypeVersion)
        {
            Types = types;
            this.actualTypes = actualTypes;
            TrackedTypes = new HashSet<string>(tracked, StringComparer.Ordinal);
            StoredEntityTypes = entities.ToArray();
            StoredComponentTypes = components.ToArray();
            EntityTypeCount = entityCount;
            ComponentTypeCount = componentCount;
            TrackedTypeVersion = trackedTypeVersion;
        }

        internal SceneEntityType Find(Type actualType, SceneEntityCatalog catalog)
        {
            if (actualTypes.TryGetValue(actualType, out var definition)) return definition;
            // A late runtime alias can use this scene's existing logical bucket. Its
            // tracking metadata still comes from this scene's immutable snapshot.
            var registered = catalog.Find(actualType);
            return registered != null && Types.TryGetValue(registered.Name, out var existing)
                ? existing
                : null;
        }
    }
}
