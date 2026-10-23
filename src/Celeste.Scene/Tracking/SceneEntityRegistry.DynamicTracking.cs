using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Core.Components;
using Celeste.Core.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry
    {
        private SceneUpdateScheduler trackerScene;
        public object ActualSceneIdentity => trackerScene.ActualSceneIdentity;
        private int currentTrackedTypeVersion;

        private int TrackedTypeVersion =>
            catalog.SourceTrackerInitialization is ISourceDynamicTrackerTypeRegistration dynamicTracker
                ? dynamicTracker.TrackedTypeVersion
                : 0;

        internal void BindSourceTrackerScene(SceneUpdateScheduler scene)
        {
            if (trackerScene != null || !ReferenceEquals(scene.Entities, this))
                throw new InvalidOperationException("Tracker must belong to its actual source Scene.");
            trackerScene = scene;
            currentTrackedTypeVersion = TrackingSnapshot.TrackedTypeVersion;
        }

        public void AddTypeToTracker(Type actualType, Type trackedAs = null, bool inheritAll = false)
        {
            catalog.AddTypeToTracker(actualType, trackedAs, inheritAll);
        }

        public bool IsEntityTracked<T>()
        {
            var type = catalog.Find(typeof(T)) ??
                       throw new InvalidOperationException(
                           "Tracker query source type is not bound in the source catalog.");
            return tracker.ContainsKey(type.Name);
        }

        public void Refresh(bool force = false)
        {
            var engine = ((ISourceEngineContextScene)trackerScene.ActualSceneIdentity).EngineContext;
            var current = ((ISourceTrackerRefreshSceneEnvironment)engine).TrackerRefreshCurrentScene;
            Refresh(current.SourceScene, force);
        }

        public static void Refresh(SceneUpdateScheduler scene, bool force = false)
        {
            var registry = scene.Entities;
            if (registry.currentTrackedTypeVersion >= registry.TrackedTypeVersion && !force) return;
            var trackingSnapshot = scene.Catalog.CaptureTrackingSnapshot();
            registry.currentTrackedTypeVersion = trackingSnapshot.TrackedTypeVersion;
            var oldEntities = registry.tracker.ToDictionary(entry => entry.Key,
                entry => registry.CopySourceEntityEnumerable(entry.Value));
            var components = scene.Components;
            var oldComponents = components.Components.ToDictionary(entry => entry.Key,
                entry => components.CopySourceComponentEnumerable(entry.Value));
            foreach (var key in trackingSnapshot.StoredEntityTypes)
            {
                if (!registry.tracker.TryGetValue(key, out var list))
                {
                    list = [];
                    registry.RegisterSourceEntityEnumerable(list);
                    registry.tracker.Add(key, list);
                }

                list.Clear();
            }

            foreach (var key in trackingSnapshot.StoredComponentTypes)
            {
                if (!components.Components.TryGetValue(key, out var list))
                {
                    list = [];
                    components.RegisterSourceComponentEnumerable(list);
                    components.Components.Add(key, list);
                }

                list.Clear();
            }

            foreach (var key in oldEntities.Keys)
                if (!trackingSnapshot.TrackedTypes.Contains(key))
                    registry.tracker.Remove(key);
            foreach (var key in oldComponents.Keys)
                if (!trackingSnapshot.TrackedTypes.Contains(key))
                    components.Components.Remove(key);
            registry.TrackingSnapshot = trackingSnapshot;
            components.TrackingSnapshot = trackingSnapshot;
            foreach (var entity in registry.entities)
            {
                foreach (var component in ((ISourceOwnedComponentList)entity).OwnedComponents)
                    components.Track(component);
                registry.Track(entity);
            }

            foreach (var key in trackingSnapshot.StoredEntityTypes)
                if (oldEntities.TryGetValue(key, out var oldList))
                    registry.tracker[key].Sort((lhs, rhs) => CompareOldIndices(oldList, lhs, rhs));
            foreach (var key in trackingSnapshot.StoredComponentTypes)
                if (oldComponents.TryGetValue(key, out var oldList))
                    components.Components[key].Sort((lhs, rhs) => CompareOldIndices(oldList, lhs, rhs));
        }

        private static int CompareOldIndices<T>(List<T> oldList, T lhs, T rhs)
        {
            var left = oldList.IndexOf(lhs);
            var right = oldList.IndexOf(rhs);
            if (left == right) return 0;
            if (left == -1) return 1;
            return right == -1 ? -1 : left - right;
        }

        public List<object> GetEntitiesTrackIfNeeded<T>()
        {
            return GetEntitiesTrackIfNeeded(typeof(T));
        }

        public List<object> GetEntitiesTrackIfNeeded(Type actualType)
        {
            var type = catalog.Find(actualType) ??
                       throw new InvalidOperationException(
                           "Tracker query source type is not bound in the source catalog.");
            if (tracker.TryGetValue(type.Name, out var value)) return value;
            if (!catalog.SourceTrackerInitialization.TypeUniverse.EntityType.IsAssignableFrom(type))
                throw new($"Type '{actualType}' does not derive from Entity.");
            AddTypeToTracker(actualType);
            Refresh();
            if (tracker.TryGetValue(type.Name, out value)) return value;
            throw new InvalidOperationException($"Tracking type '{actualType}' failed for an unknown reason!");
        }

        public List<SourceComponentState> GetComponentsTrackIfNeeded<T>() where T : SourceComponentState
        {
            return GetComponentsTrackIfNeeded(typeof(T));
        }

        public List<SourceComponentState> GetComponentsTrackIfNeeded(Type actualType)
        {
            var type = catalog.Find(actualType) ??
                       throw new InvalidOperationException(
                           "Tracker query source type is not bound in the source catalog.");
            var components = trackerScene.Components.Components;
            if (components.TryGetValue(type.Name, out var value)) return value;
            if (!catalog.SourceTrackerInitialization.TypeUniverse.ComponentType.IsAssignableFrom(type))
                throw new($"Type '{actualType}' does not derive from Component.");
            AddTypeToTracker(actualType);
            Refresh();
            if (components.TryGetValue(type.Name, out value)) return value;
            throw new InvalidOperationException($"Tracking type '{actualType}' failed for an unknown reason!");
        }
    }
}
