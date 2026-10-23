using System;
using System.Collections.Generic;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog : Celeste.Core.Reflection.ISourceLogicalTypeNameMetadata,
        Celeste.Core.Reflection.ISourceActualTypeCatalog
    {
        public Celeste.Scene.Collections.ISceneCollectionMetadata CollectionMetadata { get; }

        public SceneEntityCatalog(Celeste.Scene.Collections.ISceneCollectionMetadata collectionMetadata)
        {
            CollectionMetadata = collectionMetadata ?? throw new ArgumentNullException(nameof(collectionMetadata));
        }

        public IEnumerable<SceneEntityType> Types => (trackingSnapshot?.Types ?? types).Values;
        public string GetLogicalTypeName(string identity) => Find(identity).LogicalTypeName;

        private readonly Dictionary<string, SceneEntityType> types =
            new Dictionary<string, SceneEntityType>(StringComparer.Ordinal);

        private volatile SceneTrackerSnapshot trackingSnapshot;

        internal SceneTrackerSnapshot CaptureTrackingSnapshot()
        {
            RequireTrackerKinds();
            var published = trackingSnapshot;
            if (published != null) return published;
            var definitions = new Dictionary<string, SceneEntityType>(StringComparer.Ordinal);
            foreach (var definition in types.Values)
                definitions.Add(definition.Name, definition.WithTrackingMetadata(definition.TrackedAs));
            return CreateTrackingSnapshot(definitions, trackedTypes, storedEntityTypes,
                storedComponentTypes, trackedEntityTypeCount, trackedComponentTypeCount);
        }

        private readonly Dictionary<string, SceneRuntimeTypeRegistration> runtimeTypes =
            new Dictionary<string, SceneRuntimeTypeRegistration>(StringComparer.Ordinal);

        private readonly HashSet<string> trackedTypes = new HashSet<string>(StringComparer.Ordinal);
        public IEnumerable<string> TrackedTypes => trackingSnapshot?.TrackedTypes ?? trackedTypes;
        private readonly HashSet<string> storedEntityTypes = new HashSet<string>(StringComparer.Ordinal);
        private readonly HashSet<string> storedComponentTypes = new HashSet<string>(StringComparer.Ordinal);
        private string entityBaseType, componentBaseType;
        private int trackedEntityTypeCount, trackedComponentTypeCount;

        public int TrackedEntityTypeCount
        {
            get
            {
                RequireTrackerKinds();
                return trackingSnapshot?.EntityTypeCount ?? trackedEntityTypeCount;
            }
        }

        public int TrackedComponentTypeCount
        {
            get
            {
                RequireTrackerKinds();
                return trackingSnapshot?.ComponentTypeCount ?? trackedComponentTypeCount;
            }
        }

        public IEnumerable<string> StoredEntityTypes
        {
            get
            {
                RequireTrackerKinds();
                return trackingSnapshot?.StoredEntityTypes ?? (IEnumerable<string>)storedEntityTypes;
            }
        }

        public IEnumerable<string> StoredComponentTypes
        {
            get
            {
                RequireTrackerKinds();
                return trackingSnapshot?.StoredComponentTypes ?? (IEnumerable<string>)storedComponentTypes;
            }
        }

        public void ClassifySourceTrackerTypes(string entityRootType, string componentRootType)
        {
            entityBaseType = entityRootType ?? throw new ArgumentNullException(nameof(entityRootType));
            componentBaseType = componentRootType ?? throw new ArgumentNullException(nameof(componentRootType));
            RebuildStoredTrackerTypes();
        }

        private void RequireTrackerKinds()
        {
            if (sourceTrackerInitialization != null) return;
            if (entityBaseType == null || componentBaseType == null)
                throw new InvalidOperationException("The source tracker type kinds are not configured.");
        }

        private void RebuildStoredTrackerTypes()
        {
            if (sourceTrackerInitialization != null)
            {
                PublishSourceTrackerOutputs();
                return;
            }

            if (entityBaseType == null || componentBaseType == null) return;
            storedEntityTypes.Clear();
            storedComponentTypes.Clear();
            foreach (var name in trackedTypes)
            {
                var type = types[name];
                if (type.Is(entityBaseType)) storedEntityTypes.Add(name);
                else if (type.Is(componentBaseType)) storedComponentTypes.Add(name);
            }

            RebuildActualTrackedTypeCounts();
        }

        private void RebuildActualTrackedTypeCounts()
        {
            if (sourceTrackerInitialization != null)
            {
                trackedEntityTypeCount = sourceTrackerInitialization.TrackedEntityTypes.Count;
                trackedComponentTypeCount = sourceTrackerInitialization.TrackedComponentTypes.Count;
                return;
            }

            if (entityBaseType == null || componentBaseType == null) return;
            trackedEntityTypeCount = trackedComponentTypeCount = 0;
            foreach (var originalType in runtimeTypes.Values)
            {
                if (!types.TryGetValue(originalType.SourceType, out var type) || type.TrackedAs.Length == 0) continue;
                if (type.Is(entityBaseType)) trackedEntityTypeCount++;
                else if (type.Is(componentBaseType)) trackedComponentTypeCount++;
            }
        }


        public void Register(SceneEntityType type, bool tracked = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            types[type.Name] = type;
            actualSourceBindingsRevision++;
            if (tracked) trackedTypes.Add(type.Name);
            RebuildStoredTrackerTypes();
        }

        // Preserve the previous type/tracker layer when a temporary code module
        // overrides a map entity type in a reused managed process.
        public IDisposable RegisterScoped(SceneEntityType type, bool tracked = false)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            types.TryGetValue(type.Name, out var previous);
            bool previouslyTracked = trackedTypes.Contains(type.Name);
            Register(type, tracked);
            return new ScopedType(this, type, previous, previouslyTracked);
        }

        private sealed class ScopedType : IDisposable
        {
            private readonly SceneEntityCatalog owner;
            private readonly SceneEntityType current, previous;
            private readonly bool tracked;

            public ScopedType(SceneEntityCatalog owner, SceneEntityType current, SceneEntityType previous, bool tracked)
            {
                this.owner = owner;
                this.current = current;
                this.previous = previous;
                this.tracked = tracked;
            }

            public void Dispose()
            {
                if (!owner.types.TryGetValue(current.Name, out var active) || !ReferenceEquals(active, current)) return;
                if (previous == null) owner.types.Remove(current.Name);
                else owner.types[current.Name] = previous;
                if (!tracked) owner.trackedTypes.Remove(current.Name);
                owner.actualSourceBindingsRevision++;
                owner.RebuildStoredTrackerTypes();
            }
        }

        public void RemoveDefinitions(IEnumerable<string> identities)
        {
            foreach (var identity in identities)
            {
                types.Remove(identity);
                trackedTypes.Remove(identity);
            }

            var inactiveMappings = new List<string>();
            foreach (var mapping in runtimeTypes)
                if (!types.ContainsKey(mapping.Value.SourceType))
                    inactiveMappings.Add(mapping.Key);
            foreach (var runtimeType in inactiveMappings) runtimeTypes.Remove(runtimeType);
            actualSourceBindingsRevision++;
            RebuildStoredTrackerTypes();
        }

        public void RegisterActualType(string sourceIdentity, string logicalTypeName,
            string logicalAssemblyIdentity, string logicalAssemblySimpleName, Type actualType)
        {
            var definition = new SceneEntityType(sourceIdentity, Array.Empty<string>(), Array.Empty<string>());
            definition.ConfigureLogicalTypeName(logicalTypeName);
            definition.ConfigureLogicalAssemblyIdentity(logicalAssemblyIdentity, logicalAssemblySimpleName);
            Register(definition, false);
            RegisterRuntimeType(actualType, sourceIdentity);
        }

        public Type ResolveRegisteredSourceType(string preparedSourceTypeName)
        {
            // CLR parses the serialized generic/array grammar. Both name resolvers
            // are restricted to this catalog's actual bindings; neither loads an assembly.
            return Type.GetType(preparedSourceTypeName,
                requestedAssembly =>
                {
                    foreach (var registration in runtimeTypes.Values)
                    {
                        if (registration.ActualType == null) continue;
                        if (!types.TryGetValue(registration.SourceType, out var definition)) continue;
                        if (definition.LogicalAssemblyIdentity == null) continue;
                        var actualAssembly = registration.ActualType.Assembly;
                        if (requestedAssembly.FullName == definition.LogicalAssemblyIdentity ||
                            requestedAssembly.FullName == definition.LogicalAssemblySimpleName ||
                            requestedAssembly.FullName == actualAssembly.FullName ||
                            requestedAssembly.FullName == actualAssembly.GetName().Name)
                            return actualAssembly;
                    }

                    return null;
                },
                (assembly, typeName, ignoreCase) =>
                {
                    foreach (var registration in runtimeTypes.Values)
                    {
                        if (registration.ActualType == null) continue;
                        if (!types.TryGetValue(registration.SourceType, out var definition)) continue;
                        if (definition.LogicalAssemblyIdentity == null) continue;
                        if (typeName != registration.SourceType && typeName != definition.Identity &&
                            typeName != registration.ActualType.FullName)
                            continue;
                        // Original source names resolve to the unique genuine profile selection.
                        // An explicit physical CLR name still refers to that exact registered CLR type.
                        bool originalName = typeName != registration.ActualType.FullName &&
                                            (typeName == registration.SourceType || typeName == definition.Identity);
                        if (assembly == null || registration.ActualType.Assembly == assembly)
                            return originalName
                                ? RequireActualTypeForLogicalIdentity(definition.RegistryKey)
                                : registration.ActualType;
                        // One logical FNA assembly has actual supported definitions
                        // in more than one port library. Resolve only the same explicit
                        // logical assembly group, not arbitrary physical assembly names.
                        foreach (var scopeRegistration in runtimeTypes.Values)
                        {
                            if (scopeRegistration.ActualType == null ||
                                scopeRegistration.ActualType.Assembly != assembly)
                                continue;
                            if (!types.TryGetValue(scopeRegistration.SourceType, out var scopeDefinition)) continue;
                            if (scopeDefinition.LogicalAssemblyIdentity == definition.LogicalAssemblyIdentity)
                                return originalName
                                    ? RequireActualTypeForLogicalIdentity(definition.RegistryKey)
                                    : registration.ActualType;
                        }
                    }

                    return null;
                }, throwOnError: false, ignoreCase: false);
        }

        public void RegisterRuntimeType(string runtimeType, string originalType)
        {
            if (!types.ContainsKey(originalType))
                throw new ArgumentException("Unknown original entity/component type: " + originalType);
            Type actualType = null;
            if (runtimeTypes.TryGetValue(runtimeType, out var existing))
            {
                if (existing.SourceType != originalType)
                    throw new InvalidOperationException("Runtime type cannot acquire a different original identity: " +
                                                        runtimeType);
                actualType = existing.ActualType;
            }

            runtimeTypes[runtimeType] = new SceneRuntimeTypeRegistration(runtimeType, originalType, actualType);
            actualSourceBindingsRevision++;
            RebuildActualTrackedTypeCounts();
            RepublishTrackingSnapshot();
        }

        public void RegisterRuntimeType(Type actualType, string originalType)
        {
            if (actualType == null) throw new ArgumentNullException(nameof(actualType));
            if (!types.ContainsKey(originalType))
                throw new ArgumentException("Unknown original entity/component type: " + originalType);
            if (runtimeTypes.TryGetValue(actualType.FullName, out var existing)
                && (existing.SourceType != originalType ||
                    existing.ActualType != null && existing.ActualType != actualType))
                throw new InvalidOperationException(
                    "Runtime full name is already bound to a different actual type or original identity: " +
                    actualType.FullName);
            runtimeTypes[actualType.FullName] =
                new SceneRuntimeTypeRegistration(actualType.FullName, originalType, actualType);
            actualSourceBindingsRevision++;
            RebuildActualTrackedTypeCounts();
            RepublishTrackingSnapshot();
        }

        public IEnumerable<SceneRuntimeTypeRegistration> RuntimeRegistrations => runtimeTypes.Values;

        public Type RequireRegisteredRuntimeType(string runtimeFullName)
            => runtimeTypes[runtimeFullName].RequireActualType();

        public void SetTrackingMetadata(string originalType, bool tracked, IEnumerable<string> trackedAs)
        {
            var current = types[originalType];
            types[originalType] = current.WithTrackingMetadata(trackedAs);
            actualSourceBindingsRevision++;
            if (tracked) trackedTypes.Add(originalType);
            else trackedTypes.Remove(originalType);
            RebuildStoredTrackerTypes();
        }

        public SceneEntityType Find(string originalType) =>
            (trackingSnapshot?.Types ?? types).TryGetValue(originalType, out var value) ? value : null;

        public SceneEntityType Find(Type runtimeType)
        {
            if (runtimeType == null) return null;
            if (ownedRuntimeTypes.TryGetValue(runtimeType, out var external)) return Find(external.Name);
            return runtimeTypes.TryGetValue(runtimeType.FullName, out var registration)
                   && (registration.ActualType == null || registration.ActualType == runtimeType)
                ? Find(registration.SourceType)
                : null;
        }

        public void Initialize(SceneEntityRegistry registry)
        {
            foreach (var name in registry.TrackingSnapshot.StoredEntityTypes) registry.RegisterTrackedType(name);
        }
    }
}
