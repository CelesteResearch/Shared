using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Core.Reflection;

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

        private ISourceTypeMetadata[] GetAllTypesUncached() => installedUniverse.GetTypesSafe();

        public override void Initialize()
        {
            bool rebuilding = TrackedEntityTypes != null;
            _temporaryAllTypes = GetAllTypesUncached();
            base.Initialize();
            int trackedTypeVersion = TrackedTypeVersion;
            ISourceTypeMetadata[] temporaryAllTypes = _temporaryAllTypes;
            foreach (ISourceTypeMetadata type in temporaryAllTypes)
            {
                foreach (SourceTrackedAsMetadata item in installedUniverse.ReadDeclaredTrackedAsAttributes(type))
                {
                    AddTypeToTracker(type, item.TrackedAsType, item.Inherited);
                }
            }

            TrackedTypeVersion = rebuilding ? trackedTypeVersion + 1 : trackedTypeVersion;
            _temporaryAllTypes = null;
        }

        protected override List<ISourceTypeMetadata> GetSubclasses(ISourceTypeMetadata type)
        {
            bool flag = _temporaryAllTypes == null;
            if (_temporaryAllTypes == null)
            {
                _temporaryAllTypes = GetAllTypesUncached();
            }

            List<ISourceTypeMetadata> list = new List<ISourceTypeMetadata>();
            ISourceTypeMetadata[] temporaryAllTypes = _temporaryAllTypes;
            foreach (ISourceTypeMetadata type2 in temporaryAllTypes)
            {
                if (type != type2 && type.IsAssignableFrom(type2))
                {
                    list.Add(type2);
                }
            }

            if (flag)
            {
                _temporaryAllTypes = null;
            }

            return list;
        }

        public void AddTypeToTracker(ISourceTypeMetadata type, ISourceTypeMetadata trackedAs = null,
            bool inheritAll = false)
        {
            AddTypeToTracker(type, trackedAs,
                inheritAll ? GetSubclasses(type).ToArray() : Array.Empty<ISourceTypeMetadata>());
        }

        public void AddTypeToTracker(ISourceTypeMetadata type, ISourceTypeMetadata trackedAs = null,
            params ISourceTypeMetadata[] subtypes)
        {
            ISourceTypeMetadata type2 = ((trackedAs != null && trackedAs.IsAssignableFrom(type)) ? trackedAs : type);
            bool flag =
                (Universe.EntityType.IsAssignableFrom(type)
                    ? new bool?(true)
                    : (Universe.ComponentType.IsAssignableFrom(type) ? new bool?(false) : ((bool?)null))) ??
                throw new Exception("Type '" + type.TypeName + "' cannot be Tracked" + ((type2 != type) ? "As" : "") +
                                    " because it does not derive from Entity or Component");
            bool flag2 = (flag ? StoredEntityTypes : StoredComponentTypes).Add(type2.RequireActualType());
            Dictionary<Type, List<Type>> tracked = (flag ? TrackedEntityTypes : TrackedComponentTypes);
            if (AddSpecificType(type, type2, tracked))
            {
                flag2 = true;
            }

            foreach (ISourceTypeMetadata type3 in subtypes)
            {
                if (type2.IsAssignableFrom(type3) && AddSpecificType(type3, type2, tracked))
                {
                    flag2 = true;
                }
            }

            if (flag2)
            {
                TrackedTypeVersion++;
            }
        }

        private static bool AddSpecificType(ISourceTypeMetadata type, ISourceTypeMetadata trackedAsType,
            Dictionary<Type, List<Type>> tracked)
        {
            if (type.IsAbstract)
            {
                return false;
            }

            if (!tracked.TryGetValue(type.RequireActualType(), out var value))
            {
                value = new List<Type>();
                tracked.Add(type.RequireActualType(), value);
            }

            int count = value.Count;
            value.Add(trackedAsType.RequireActualType());
            value.AddRange(tracked.TryGetValue(trackedAsType.RequireActualType(), out var value2)
                ? value2
                : new List<Type>());
            List<Type> list = (tracked[type.RequireActualType()] = value.Distinct().ToList());
            List<Type> list3 = list;
            return count != list3.Count;
        }
    }
}
