#nullable enable
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Celeste.Scene.Scheduling
{
// Draft: pure Monocle EntityList commit/order kernel for Overworld slots.
// The host owns scene objects, callback dispatch, update, and rendering.
    public sealed class MenuEntityList<TOwner> where TOwner : class
    {
        private sealed class OwnerComparer : IEqualityComparer<TOwner>
        {
            public static readonly OwnerComparer Instance = new OwnerComparer();
            public bool Equals(TOwner? x, TOwner? y) => ReferenceEquals(x, y);
            public int GetHashCode(TOwner obj) => RuntimeHelpers.GetHashCode(obj);
        }

        public sealed class Entry
        {
            internal Entry(TOwner owner, int depth, Action<TOwner>? added,
                Action<TOwner>? awake, Action<TOwner>? removed, Action<TOwner>? discarded)
            {
                Owner = owner;
                fallbackDepth = depth;
                Added = added;
                Awake = awake;
                Removed = removed;
                Discarded = discarded;
            }

            public TOwner Owner { get; }
            private int fallbackDepth;
            private double fallbackActualDepth;

            public int Depth
            {
                get => Fields?.RawDepth ?? fallbackDepth;
                internal set
                {
                    if (Fields != null) Fields.RawDepth = value;
                    else fallbackDepth = value;
                }
            }

            public double ActualDepth
            {
                get => Fields?.ActualDepth ?? fallbackActualDepth;
                internal set
                {
                    if (Fields != null) Fields.ActualDepth = value;
                    else fallbackActualDepth = value;
                }
            }

            internal global::Celeste.Scene.Tracking.SceneEntityDepthState? Fields =>
                (Owner as global::Celeste.Scene.Tracking.ISceneEntityDepth)?.DepthState;

            internal object? Scene;
            internal Action<TOwner, Action>? AddedOverride;
            internal Action? ComponentEntityAdded;

            internal Action<TOwner>? Added { get; }
            internal Action<TOwner>? Awake { get; }
            internal Action<TOwner>? Removed { get; }
            internal Action<TOwner>? Discarded { get; }
            internal Action<int>? DepthHandler { get; set; }
        }

        private readonly Dictionary<TOwner, Entry> live = new(OwnerComparer.Instance);
        private readonly HashSet<TOwner> adding = new(OwnerComparer.Instance);
        private readonly HashSet<TOwner> removing = new(OwnerComparer.Instance);
        private readonly HashSet<TOwner> tracked = new(OwnerComparer.Instance);
        private readonly List<Entry> toAdd = new();
        private readonly List<Entry> toAwake = new();
        private readonly List<Entry> toRemove = new();
        private readonly List<Entry> ordered = new();
        private readonly Dictionary<int, double> depthOffsets = new();
        private readonly IReadOnlyList<Entry> committed;
        private bool unsorted;

        public MenuEntityList()
        {
            committed = ordered.AsReadOnly();
        }

        public IReadOnlyList<Entry> CommittedOrder => committed;

        public bool Contains(TOwner owner) => live.ContainsKey(owner);

        // Equivalent to Tracker visibility during Added/Removed callbacks.
        public bool IsTracked(TOwner owner) => tracked.Contains(owner);

        public void QueueAdd(TOwner owner, int depth, Action<TOwner>? added = null,
            Action<TOwner>? awake = null, Action<TOwner>? removed = null,
            Action<TOwner>? discarded = null, object? scene = null,
            Action<TOwner, Action>? addedOverride = null, Action? componentEntityAdded = null)
        {
            if (live.ContainsKey(owner) || !adding.Add(owner)) return;
            var entry = new Entry(owner, depth, added, awake, removed, discarded)
            {
                Scene = scene, AddedOverride = addedOverride, ComponentEntityAdded = componentEntityAdded
            };
            if (owner is global::Celeste.Scene.Scheduling.IMenuDepthSource source)
            {
                entry.DepthHandler = value => SetDepth(owner, value);
                source.DepthChanged += entry.DepthHandler;
            }

            toAdd.Add(entry);
        }

        public void QueueRemove(TOwner owner)
        {
            if (!live.TryGetValue(owner, out Entry? entry) || !removing.Add(owner)) return;
            toRemove.Add(entry);
        }

        public void SetDepth(TOwner owner, int depth)
        {
            if (live.TryGetValue(owner, out Entry? entry))
            {
                if (entry.Fields != null)
                {
                    var scene = (owner as global::Celeste.Scene.Tracking.ISceneEntityAssociation)?.Scene;
                    entry.Fields.SetDepth(depth, scene, owner);
                    return;
                }

                if (entry.Depth == depth) return;
                entry.Depth = depth;
                AssignActualDepth(entry);
                return;
            }

            // An entity waiting for Added has no Scene; its raw Depth may change,
            // but actualDepth is assigned only when UpdateLists publishes it.
            foreach (Entry pending in toAdd)
                if (ReferenceEquals(pending.Owner, owner))
                {
                    pending.Depth = depth;
                    return;
                }
        }

        public void Commit(Action? flushQueuedAdds = null)
        {
            // Index loop intentionally sees additions queued by Added callbacks.
            for (int i = 0; i < toAdd.Count; i++)
            {
                Entry entry = toAdd[i];
                if (live.TryAdd(entry.Owner, entry))
                {
                    ordered.Add(entry);
                    tracked.Add(entry.Owner);
                    Action baseAdded = () => CommitEntityAdded(entry);
                    if (entry.AddedOverride != null) entry.AddedOverride(entry.Owner, baseAdded);
                    else
                    {
                        baseAdded();
                        entry.Added?.Invoke(entry.Owner);
                    }

                    flushQueuedAdds?.Invoke();
                }
            }

            int processedAdds = toAdd.Count;
            if (processedAdds > 0) unsorted = true;

            for (int i = 0; i < toRemove.Count; i++)
            {
                Entry entry = toRemove[i];
                if (!live.Remove(entry.Owner)) continue;
                ordered.Remove(entry);
                entry.Removed?.Invoke(entry.Owner);
                tracked.Remove(entry.Owner);
                if (entry.Owner is global::Celeste.Scene.Scheduling.IMenuDepthSource source &&
                    entry.DepthHandler != null)
                    source.DepthChanged -= entry.DepthHandler;
                flushQueuedAdds?.Invoke();
            }

            toRemove.Clear();
            removing.Clear();

            if (unsorted)
            {
                unsorted = false;
                ordered.Sort(static (a, b) => Math.Sign(b.ActualDepth - a.ActualDepth));
            }

            if (toAdd.Count == 0) return;
            // Original EntityList adds the entire current queue to toAwake here.
            // Adds made by Removed were never published and are discarded below;
            // adds made later by Awake remain queued for the next Commit.
            toAwake.AddRange(toAdd);
            for (int i = processedAdds; i < toAdd.Count; i++)
            {
                Entry discarded = toAdd[i];
                if (discarded.Owner is global::Celeste.Scene.Scheduling.IMenuDepthSource source &&
                    discarded.DepthHandler != null)
                    source.DepthChanged -= discarded.DepthHandler;
                discarded.Discarded?.Invoke(discarded.Owner);
            }

            toAdd.Clear();
            adding.Clear();
            foreach (Entry entry in toAwake)
                if (live.ContainsKey(entry.Owner))
                    entry.Awake?.Invoke(entry.Owner);
            toAwake.Clear();
        }

        private void CommitEntityAdded(Entry entry)
        {
            if (entry.Owner is global::Celeste.Scene.Tracking.ISceneEntityAssociation association)
            {
                if (entry.Scene == null)
                    throw new InvalidOperationException("Actual menu Entity.Added requires its actual source Scene.");
                association.Scene = entry.Scene;
            }

            entry.ComponentEntityAdded?.Invoke();
            AssignActualDepth(entry);
        }

        public void SetEntityActualDepth(object identity, global::Celeste.Scene.Tracking.SceneEntityDepthState fields)
        {
            if (!(identity is global::Celeste.Scene.Tracking.ISceneEntityDepth actual) ||
                !ReferenceEquals(actual.DepthState, fields))
                throw new InvalidOperationException("Depth allocation requires the actual Entity field object.");
            depthOffsets.TryGetValue(fields.RawDepth, out double offset);
            depthOffsets[fields.RawDepth] = offset + 9.999999974752427E-07;
            fields.ActualDepth = fields.RawDepth - offset;
            unsorted = true;
        }

        private void AssignActualDepth(Entry entry)
        {
            if (entry.Fields != null)
            {
                SetEntityActualDepth(entry.Owner, entry.Fields);
                return;
            }

            depthOffsets.TryGetValue(entry.Depth, out double offset);
            depthOffsets[entry.Depth] = offset + 9.999999974752427E-07;
            entry.ActualDepth = entry.Depth - offset;
            unsorted = true;
        }

        public void Clear()
        {
            foreach (Entry entry in ordered)
                if (entry.Owner is global::Celeste.Scene.Scheduling.IMenuDepthSource source &&
                    entry.DepthHandler != null)
                    source.DepthChanged -= entry.DepthHandler;
            foreach (Entry entry in toAdd)
                if (entry.Owner is global::Celeste.Scene.Scheduling.IMenuDepthSource source &&
                    entry.DepthHandler != null)
                    source.DepthChanged -= entry.DepthHandler;
            live.Clear();
            adding.Clear();
            removing.Clear();
            tracked.Clear();
            toAdd.Clear();
            toAwake.Clear();
            toRemove.Clear();
            ordered.Clear();
            depthOffsets.Clear();
            unsorted = false;
        }
    }
}
