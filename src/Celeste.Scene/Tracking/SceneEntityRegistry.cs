using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Celeste.Scene.Scheduling;

namespace Celeste.Scene.Tracking
{
    public sealed partial class SceneEntityRegistry : IEnumerable<object>
    {
        private readonly SceneEntityCatalog catalog;
        internal SceneTrackerSnapshot TrackingSnapshot { get; set; }
        private readonly SourceEntityListProcessState entityListProcess;
        private readonly HashSet<object> current = new HashSet<object>();
        private readonly List<object> entities = new List<object>();
        private readonly Dictionary<string, List<object>> tracker;
        private readonly Dictionary<int, double> depthOffsets = new Dictionary<int, double>();
        private bool unsorted;

        public SceneEntityRegistry(SceneEntityCatalog catalog, SourceEntityListProcessState entityListProcess)
            : this(catalog, entityListProcess, catalog.CaptureTrackingSnapshot())
        {
        }

        internal SceneEntityRegistry(SceneEntityCatalog catalog, SourceEntityListProcessState entityListProcess,
            SceneTrackerSnapshot snapshot)
        {
            this.catalog = catalog;
            this.entityListProcess = entityListProcess;
            TrackingSnapshot = snapshot;
            tracker = new Dictionary<string, List<object>>(snapshot.EntityTypeCount, StringComparer.Ordinal);
        }

        public IReadOnlyList<object> Entities => entities;
        public int Count => entities.Count;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= entities.Count) throw new IndexOutOfRangeException();
                return entities[index];
            }
        }

        public bool Contains(object entity) => current.Contains(entity);

        internal void AddCommitted(object entity)
        {
            current.Add(entity);
            InvalidateCommittedRenderIndices();
            entities.Add(entity);
        }

        internal bool RemoveCommitted(object entity)
        {
            if (!current.Remove(entity)) return false;
            RemoveCommittedRenderIndex(entity);
            entities.Remove(entity);
            return true;
        }

        internal void Track(object entity)
        {
            var metadata = TrackingSnapshot.Find(entity.GetType(), catalog);
            if (metadata == null) return;
            foreach (var key in metadata.TrackedAs)
                tracker[key].Add(entity);
        }

        internal void Untrack(object entity)
        {
            var metadata = TrackingSnapshot.Find(entity.GetType(), catalog);
            if (metadata == null) return;
            foreach (var key in metadata.TrackedAs)
                tracker[key].Remove(entity);
        }

        public void RegisterTrackedType(string key)
        {
            var list = new List<object>();
            if (collectionMetadata != null) RegisterSourceEntityEnumerable(list);
            tracker.Add(key, list);
        }

        public List<object> GetTrackedEntities(string key) => tracker[key];
        public IEnumerable<KeyValuePair<string, List<object>>> EnumerateTrackedEntityTypes() => tracker;
        public bool IsTracked(string key) => tracker.ContainsKey(key);

        internal void ClearCommittedListAfterSceneEnd()
        {
            ClearCommittedRenderIndices();
            entities.Clear();
        }

        public void MarkUnsorted() => unsorted = true;

        internal void AllocateSourceActualDepth(SceneEntityDepthState fields)
        {
            double offset = 0;
            if (depthOffsets.TryGetValue(fields.RawDepth, out offset))
                depthOffsets[fields.RawDepth] += 9.999999974752427E-07;
            else
                depthOffsets.Add(fields.RawDepth, 9.999999974752427E-07);
            fields.ActualDepth = fields.RawDepth - offset;
        }

        public void UpdateLists()
        {
            if (!unsorted) return;
            unsorted = false;
            BeginCommittedRenderIndexSort();
            try
            {
                entities.Sort(entityListProcess.CompareDepth);
            }
            finally
            {
                EndCommittedRenderIndexSort();
            }
        }

        public int AmountOf<T>() where T : class
        {
            int count = 0;
            foreach (var entity in entities)
                if (entity is T)
                    count++;
            return count;
        }

        public T FindFirst<T>() where T : class
        {
            foreach (var entity in entities)
                if (entity is T)
                    return entity as T;
            return null;
        }

        public List<T> FindAll<T>() where T : class
        {
            var result = new List<T>();
            collectionMetadata.RegisterTyped(result, typeof(T));
            foreach (var entity in entities)
                if (entity is T)
                    result.Add(entity as T);
            return result;
        }

        public void With<T>(Action<T> action) where T : class
        {
            foreach (var entity in entities)
                if (entity is T)
                    action(entity as T);
        }

        public IEnumerator<object> GetEnumerator() => entities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public object[] ToArray()
        {
            var result = Enumerable.ToArray(entities);
            RegisterSourceEntityEnumerable(result);
            return result;
        }

        public List<object> GetEntitiesExcludingTagMask(Celeste.Scene.Scheduling.SceneTagSet mask)
        {
            var result = new List<object>();
            RegisterSourceEntityEnumerable(result);
            foreach (var entity in entities)
                if ((((ISceneEntityTags)entity).Tags & mask).Bits == 0)
                    result.Add(entity);
            return result;
        }
    }
}
