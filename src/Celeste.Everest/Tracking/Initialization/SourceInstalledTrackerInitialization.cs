using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking.Initialization;

namespace Celeste.Everest.Tracking.Initialization
{
    public class SourceInstalledTrackerInitialization : SourceTrackerInitialization,
        ISourceDynamicTrackerTypeRegistration
    {
        private readonly ISourceInstalledTrackerTypeUniverse installedUniverse;
        private ISourceTypeMetadata[] _temporaryAllTypes;
        public int TrackedTypeVersion { get; private set; }

        public SourceInstalledTrackerInitialization(ISourceInstalledTrackerTypeUniverse universe) : base(universe)
        {
            installedUniverse = universe;
        }

        private ISourceTypeMetadata[] GetAllTypesUncached()
        {
            return installedUniverse.GetTypesSafe();
        }

        public override void Initialize()
        {
            var rebuilding = TrackedEntityTypes != null;
            _temporaryAllTypes = GetAllTypesUncached();
            base.Initialize();
            var trackedTypeVersion = TrackedTypeVersion;
            var temporaryAllTypes = _temporaryAllTypes;
            foreach (var type in temporaryAllTypes)
            foreach (var item in installedUniverse.ReadDeclaredTrackedAsAttributes(type))
                AddTypeToTracker(type, item.TrackedAsType, item.Inherited);

            TrackedTypeVersion = rebuilding ? trackedTypeVersion + 1 : trackedTypeVersion;
            _temporaryAllTypes = null;
        }

        protected override List<ISourceTypeMetadata> GetSubclasses(ISourceTypeMetadata type)
        {
            var flag = _temporaryAllTypes == null;
            if (_temporaryAllTypes == null) _temporaryAllTypes = GetAllTypesUncached();

            var list = new List<ISourceTypeMetadata>();
            var temporaryAllTypes = _temporaryAllTypes;
            foreach (var type2 in temporaryAllTypes)
                if (type != type2 && type.IsAssignableFrom(type2))
                    list.Add(type2);

            if (flag) _temporaryAllTypes = null;

            return list;
        }

        public void AddTypeToTracker(ISourceTypeMetadata type, ISourceTypeMetadata trackedAs = null,
            bool inheritAll = false)
        {
            AddTypeToTracker(type, trackedAs,
                inheritAll ? [.. GetSubclasses(type)] : []);
        }

        public void AddTypeToTracker(ISourceTypeMetadata type, ISourceTypeMetadata trackedAs = null,
            params ISourceTypeMetadata[] subtypes)
        {
            var type2 = trackedAs != null && trackedAs.IsAssignableFrom(type) ? trackedAs : type;
            var flag =
                (Universe.EntityType.IsAssignableFrom(type)
                    ? true
                    : Universe.ComponentType.IsAssignableFrom(type)
                        ? false
                        : (bool?)null) ??
                throw new("Type '" + type.TypeName + "' cannot be Tracked" + (type2 != type ? "As" : "") +
                          " because it does not derive from Entity or Component");
            var flag2 = (flag ? StoredEntityTypes : StoredComponentTypes).Add(type2.RequireActualType());
            var tracked = flag ? TrackedEntityTypes : TrackedComponentTypes;
            if (AddSpecificType(type, type2, tracked)) flag2 = true;

            foreach (var type3 in subtypes)
                if (type2.IsAssignableFrom(type3) && AddSpecificType(type3, type2, tracked))
                    flag2 = true;

            if (flag2) TrackedTypeVersion++;
        }

        private static bool AddSpecificType(ISourceTypeMetadata type, ISourceTypeMetadata trackedAsType,
            Dictionary<Type, List<Type>> tracked)
        {
            if (type.IsAbstract) return false;

            if (!tracked.TryGetValue(type.RequireActualType(), out var value))
            {
                value = [];
                tracked.Add(type.RequireActualType(), value);
            }

            var count = value.Count;
            value.Add(trackedAsType.RequireActualType());
            value.AddRange(tracked.TryGetValue(trackedAsType.RequireActualType(), out var value2)
                ? value2
                : []);
            var list = tracked[type.RequireActualType()] = [.. value.Distinct()];
            var list3 = list;
            return count != list3.Count;
        }
    }
}
