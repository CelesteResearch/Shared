using System;
using System.Collections.Generic;
using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking.Initialization
{
    public class SourceTrackerInitialization
    {
        protected readonly ISourceTrackerTypeUniverse Universe;
        public ISourceTrackerTypeUniverse TypeUniverse => Universe;
        public Dictionary<Type, List<Type>> TrackedEntityTypes { get; protected set; }
        public Dictionary<Type, List<Type>> TrackedComponentTypes { get; protected set; }
        public HashSet<Type> StoredEntityTypes { get; protected set; }
        public HashSet<Type> StoredComponentTypes { get; protected set; }

        public SourceTrackerInitialization(ISourceTrackerTypeUniverse universe)
        {
            Universe = universe ?? throw new ArgumentNullException(nameof(universe));
        }

        public virtual void Initialize()
        {
            TrackedEntityTypes = new();
            TrackedComponentTypes = new();
            StoredEntityTypes = [];
            StoredComponentTypes = [];
            var types = Universe.GetTypes();
            foreach (var type in types)
            {
                var customAttributes = type.ReadDeclaredTrackedAttributes();
                if (customAttributes.Length == 0) continue;

                var inherited = customAttributes[0];
                if (Universe.EntityType.IsAssignableFrom(type))
                {
                    if (!type.IsAbstract)
                    {
                        if (!TrackedEntityTypes.ContainsKey(type.RequireActualType()))
                            TrackedEntityTypes.Add(type.RequireActualType(), []);

                        TrackedEntityTypes[type.RequireActualType()].Add(type.RequireActualType());
                    }

                    StoredEntityTypes.Add(type.RequireActualType());
                    if (!inherited) continue;

                    foreach (var subclass in GetSubclasses(type))
                        if (!subclass.IsAbstract)
                        {
                            if (!TrackedEntityTypes.ContainsKey(subclass.RequireActualType()))
                                TrackedEntityTypes.Add(subclass.RequireActualType(), []);

                            TrackedEntityTypes[subclass.RequireActualType()].Add(type.RequireActualType());
                        }

                    continue;
                }

                if (Universe.ComponentType.IsAssignableFrom(type))
                {
                    if (!type.IsAbstract)
                    {
                        if (!TrackedComponentTypes.ContainsKey(type.RequireActualType()))
                            TrackedComponentTypes.Add(type.RequireActualType(), []);

                        TrackedComponentTypes[type.RequireActualType()].Add(type.RequireActualType());
                    }

                    StoredComponentTypes.Add(type.RequireActualType());
                    if (!inherited) continue;

                    foreach (var subclass2 in GetSubclasses(type))
                        if (!subclass2.IsAbstract)
                        {
                            if (!TrackedComponentTypes.ContainsKey(subclass2.RequireActualType()))
                                TrackedComponentTypes.Add(subclass2.RequireActualType(), []);

                            TrackedComponentTypes[subclass2.RequireActualType()].Add(type.RequireActualType());
                        }

                    continue;
                }

                throw new("Type '" + type.TypeName +
                          "' cannot be Tracked because it does not derive from Entity or Component");
            }
        }

        protected virtual List<ISourceTypeMetadata> GetSubclasses(ISourceTypeMetadata type)
        {
            var list = new List<ISourceTypeMetadata>();
            var types = Universe.GetTypes();
            foreach (var type2 in types)
                if (type != type2 && type.IsAssignableFrom(type2))
                    list.Add(type2);

            return list;
        }
    }
}
