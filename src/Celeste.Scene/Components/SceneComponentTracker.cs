using System;
using System.Collections.Generic;
using Celeste.Core.Components;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Components
{
    public partial class SceneComponentTracker : ISourceTrackedComponents
    {
        public SceneEntityCatalog Catalog { get; }
        internal SceneTrackerSnapshot TrackingSnapshot { get; set; }
        private readonly Dictionary<string, List<SourceComponentState>> tracker;
        public Dictionary<string, List<SourceComponentState>> Components => tracker;

        public SceneComponentTracker(SceneEntityCatalog catalog)
            : this(catalog, (catalog ?? throw new ArgumentNullException(nameof(catalog))).CaptureTrackingSnapshot())
        {
        }

        internal SceneComponentTracker(SceneEntityCatalog catalog, SceneTrackerSnapshot snapshot)
        {
            TrackingSnapshot = snapshot;
            Catalog = catalog;
            tracker = new Dictionary<string, List<SourceComponentState>>(
                snapshot.ComponentTypeCount, StringComparer.Ordinal);
            foreach (var name in snapshot.StoredComponentTypes)
                tracker.Add(name, new List<SourceComponentState>());
        }

        public void Track(SourceComponentState component)
        {
            var metadata = TrackingSnapshot.Find(component.GetType(), Catalog);
            if (metadata == null) return;
            foreach (var name in metadata.TrackedAs) tracker[name].Add(component);
        }

        public void Untrack(SourceComponentState component)
        {
            var metadata = TrackingSnapshot.Find(component.GetType(), Catalog);
            if (metadata == null) return;
            foreach (var name in metadata.TrackedAs) tracker[name].Remove(component);
        }

        public List<SourceComponentState> GetTrackedComponents(string sourceType) => tracker[sourceType];

        public List<SourceComponentState> GetTrackedComponentsCopy(string sourceType)
            => CopySourceComponentEnumerable(tracker[sourceType]);

        public T GetTrackedComponent<T>(string sourceType) where T : SourceComponentState
        {
            var list = tracker[sourceType];
            if (list.Count == 0) return null;
            return list[0] as T;
        }

        public int CountTrackedComponents(string sourceType) => tracker[sourceType].Count;

        public T GetNearestTrackedComponent<T>(string sourceType, System.Numerics.Vector2 nearestTo,
            Celeste.Core.Mathematics.ISourceVectorArithmetic arithmetic) where T : SourceComponentState
        {
            var components = GetTrackedComponents(sourceType);
            T nearest = null;
            float distance = 0f;
            foreach (T item in components)
            {
                float next = arithmetic.DistanceSquared(nearestTo, ((ISourceEntityPosition)item.Entity).Position);
                if (nearest == null || next < distance)
                {
                    nearest = item;
                    distance = next;
                }
            }

            return nearest;
        }

        public IEnumerator<T> EnumerateTrackedComponents<T>(string sourceType) where T : SourceComponentState
        {
            foreach (var component in tracker[sourceType]) yield return component as T;
        }

        public IEnumerable<KeyValuePair<string, List<SourceComponentState>>> EnumerateTrackedComponentTypes() =>
            tracker;

        public void LogComponents(Celeste.Core.Diagnostics.ISourceObjectLog output)
        {
            foreach (var component in tracker)
            {
                string obj = string.Concat((object)Catalog.GetLogicalTypeName(component.Key), (object)" : ",
                    (object)component.Value.Count);
                output.Log(obj);
            }
        }
    }
}
