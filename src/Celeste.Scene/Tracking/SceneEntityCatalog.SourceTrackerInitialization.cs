using System;
using System.Collections.Generic;
using Celeste.Core.Reflection;
using Celeste.Scene.Tracking.Initialization;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityCatalog
    {
        private SourceTrackerInitialization sourceTrackerInitialization;

        public SourceTrackerInitialization SourceTrackerInitialization => sourceTrackerInitialization ??
                                                                          throw new InvalidOperationException(
                                                                              "The source tracker initialization phase has not completed.");

        public void InitializeSourceTracker(SourceTrackerInitialization initialization)
        {
            if (sourceTrackerInitialization != null)
                throw new InvalidOperationException("The source tracker initialization phase is already published.");
            if (initialization == null) throw new ArgumentNullException(nameof(initialization));
            initialization.Initialize();
            sourceTrackerInitialization = initialization;
            PublishSourceTrackerOutputs();
        }

        public void PublishSourceTrackerOutputs()
        {
            var source = SourceTrackerInitialization;
            var nextTypes = new Dictionary<string, SceneEntityType>(StringComparer.Ordinal);
            foreach (var definition in types.Values)
                nextTypes.Add(definition.Name, definition.WithTrackingMetadata((string[])[]));
            var nextTracked = new HashSet<string>(StringComparer.Ordinal);
            var nextEntities = new HashSet<string>(StringComparer.Ordinal);
            var nextComponents = new HashSet<string>(StringComparer.Ordinal);
            foreach (var sourceType in source.StoredEntityTypes)
            {
                var definition = RequireSourceDefinition(sourceType);
                nextEntities.Add(definition.Name);
                nextTracked.Add(definition.Name);
            }

            foreach (var sourceType in source.StoredComponentTypes)
            {
                var definition = RequireSourceDefinition(sourceType);
                nextComponents.Add(definition.Name);
                nextTracked.Add(definition.Name);
            }

            PublishTrackedAs(source.TrackedEntityTypes, nextTypes);
            PublishTrackedAs(source.TrackedComponentTypes, nextTypes);
            var nextSnapshot = CreateTrackingSnapshot(nextTypes, nextTracked, nextEntities, nextComponents,
                source.TrackedEntityTypes.Count, source.TrackedComponentTypes.Count);
            // These remain private mutable builder inputs, never published scene data.
            trackedTypes.Clear();
            trackedTypes.UnionWith(nextTracked);
            storedEntityTypes.Clear();
            storedEntityTypes.UnionWith(nextEntities);
            storedComponentTypes.Clear();
            storedComponentTypes.UnionWith(nextComponents);
            trackedEntityTypeCount = source.TrackedEntityTypes.Count;
            trackedComponentTypeCount = source.TrackedComponentTypes.Count;
            trackingSnapshot = nextSnapshot;
        }

        private void RepublishTrackingSnapshot()
        {
            if (sourceTrackerInitialization != null) PublishSourceTrackerOutputs();
        }

        private SceneTrackerSnapshot CreateTrackingSnapshot(Dictionary<string, SceneEntityType> definitions,
            IEnumerable<string> tracked, IEnumerable<string> entities, IEnumerable<string> components,
            int entityCount, int componentCount)
        {
            var actualTypes = new Dictionary<Type, SceneEntityType>();
            foreach (var registration in runtimeTypes.Values)
                if (registration.ActualType != null &&
                    definitions.TryGetValue(registration.SourceType, out var definition))
                    actualTypes[registration.ActualType] = definition;
            foreach (var registration in ownedRuntimeTypes)
                if (definitions.TryGetValue(registration.Value.Name, out var definition))
                    actualTypes[registration.Key] = definition;
            return new(definitions, actualTypes, tracked, entities, components,
                entityCount, componentCount, sourceTrackerInitialization is
                    ISourceDynamicTrackerTypeRegistration dynamicTracker
                    ? dynamicTracker.TrackedTypeVersion
                    : 0);
        }

        private SceneEntityType RequireSourceDefinition(Type actualType)
        {
            return (ownedRuntimeTypes.TryGetValue(actualType, out var external)
                       ? external
                       : runtimeTypes.TryGetValue(actualType.FullName, out var registration) &&
                         (registration.ActualType == null || registration.ActualType == actualType) &&
                         types.TryGetValue(registration.SourceType, out var definition)
                           ? definition
                           : null) ??
                   throw new InvalidOperationException("Tracker output type is not bound in the source catalog.");
        }

        private void PublishTrackedAs(Dictionary<Type, List<Type>> sourceMappings,
            Dictionary<string, SceneEntityType> nextTypes)
        {
            foreach (var mapping in sourceMappings)
            {
                var definition = RequireSourceDefinition(mapping.Key);
                var sourceNames = new string[mapping.Value.Count];
                for (var index = 0; index < sourceNames.Length; index++)
                    sourceNames[index] = RequireSourceDefinition(mapping.Value[index]).Name;
                nextTypes[definition.Name] = definition.WithTrackingMetadata(sourceNames);
            }
        }
    }
}
