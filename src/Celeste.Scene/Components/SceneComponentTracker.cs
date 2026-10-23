using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Diagnostics;
using Celeste.Core.Mathematics;
using Celeste.Scene.Tracking;

namespace Celeste.Scene.Components
{
    public partial class SceneComponentTracker : ISourceTrackedComponents
    {
        public SceneEntityCatalog Catalog { get; }
        internal SceneTrackerSnapshot TrackingSnapshot { get; set; }
        public Dictionary<string, List<SourceComponentState>> Components { get; }

        public SceneComponentTracker(SceneEntityCatalog catalog)
            : this(catalog, (catalog ?? throw new ArgumentNullException(nameof(catalog))).CaptureTrackingSnapshot())
        {
        }

        internal SceneComponentTracker(SceneEntityCatalog catalog, SceneTrackerSnapshot snapshot)
        {
            TrackingSnapshot = snapshot;
            Catalog = catalog;
            Components = new(
                snapshot.ComponentTypeCount, StringComparer.Ordinal);
            foreach (var name in snapshot.StoredComponentTypes)
                Components.Add(name, []);
        }

        public void Track(SourceComponentState component)
        {
            var metadata = TrackingSnapshot.Find(component.GetType(), Catalog);
            if (metadata == null) return;
            foreach (var name in metadata.TrackedAs) Components[name].Add(component);
        }

        public void Untrack(SourceComponentState component)
        {
            var metadata = TrackingSnapshot.Find(component.GetType(), Catalog);
            if (metadata == null) return;
            foreach (var name in metadata.TrackedAs) Components[name].Remove(component);
        }

        public List<SourceComponentState> GetTrackedComponents(string sourceType)
        {
            return Components[sourceType];
        }

        public List<SourceComponentState> GetTrackedComponentsCopy(string sourceType)
        {
            return CopySourceComponentEnumerable(Components[sourceType]);
        }

        public T GetTrackedComponent<T>(string sourceType) where T : SourceComponentState
        {
            var list = Components[sourceType];
            if (list.Count == 0) return null;
            return list[0] as T;
        }

        public int CountTrackedComponents(string sourceType)
        {
            return Components[sourceType].Count;
        }

        public T GetNearestTrackedComponent<T>(string sourceType, Vector2 nearestTo,
            ISourceVectorArithmetic arithmetic) where T : SourceComponentState
        {
            var components = GetTrackedComponents(sourceType);
            T nearest = null;
            var distance = 0f;
            foreach (T item in components)
            {
                var next = arithmetic.DistanceSquared(nearestTo, ((ISourceEntityPosition)item.Entity).Position);
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
            foreach (var component in Components[sourceType]) yield return component as T;
        }

        public IEnumerable<KeyValuePair<string, List<SourceComponentState>>> EnumerateTrackedComponentTypes()
        {
            return Components;
        }

        public void LogComponents(ISourceObjectLog output)
        {
            foreach (var component in Components)
            {
                var obj = string.Concat(Catalog.GetLogicalTypeName(component.Key), " : ",
                    component.Value.Count);
                output.Log(obj);
            }
        }
    }
}
