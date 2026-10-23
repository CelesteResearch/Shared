using System;
using System.Collections.Generic;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed class RoomTriggerRegistration<TPlayer>
    {
        public sealed class Entry
        {
            public readonly global::Celeste.Core.Maps.MapElement Room;
            public readonly global::Celeste.Core.Maps.MapElement Source;
            public readonly object LoadIdentity;
            public readonly Action<TPlayer> UpdatePlayer;
            public readonly Func<bool> IsPersistent;
            public readonly Action<bool> Removed;
            public readonly Action<TPlayer> LeaveIfEntered;

            internal Entry(global::Celeste.Core.Maps.MapElement room, global::Celeste.Core.Maps.MapElement source,
                Action<TPlayer> updatePlayer,
                Func<bool> isPersistent, Action<bool> removed, Action<TPlayer> leaveIfEntered,
                object loadIdentity)
            {
                Room = room;
                Source = source;
                LoadIdentity = loadIdentity;
                UpdatePlayer = updatePlayer;
                IsPersistent = isPersistent;
                Removed = removed;
                LeaveIfEntered = leaveIfEntered;
            }
        }

        private readonly List<Entry> live = new List<Entry>();
        private readonly HashSet<Entry> pendingRemovals = new HashSet<Entry>();
        private bool updating, flushing, pendingClear, pendingClearSceneEnd;
        private TPlayer pendingClearPlayer;
        public IReadOnlyList<Entry> Live => live;

        // Call this while committing trigger Added in map source order. Preserve each family's
        // instance in updatePlayer; do not capture a mutable host field replaced at next room.
        public Entry Add(global::Celeste.Core.Maps.MapElement room, global::Celeste.Core.Maps.MapElement source,
            Action<TPlayer> updatePlayer,
            Func<bool> isPersistent = null, Action<bool> removed = null,
            Action<TPlayer> leaveIfEntered = null, object loadIdentity = null)
        {
            if (room == null) throw new ArgumentNullException(nameof(room));
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (updatePlayer == null) throw new ArgumentNullException(nameof(updatePlayer));
            var entry = new Entry(room, source, updatePlayer, isPersistent, removed, leaveIfEntered,
                loadIdentity);
            live.Add(entry);
            return entry;
        }

        // Original Player.Update loops Tracker<Trigger> in its current order. When a new room
        // loads before old nonpersistent entities are removed, both rooms must stay here.
        public void UpdatePlayer(TPlayer player)
        {
            if (updating) throw new InvalidOperationException("Trigger player dispatch cannot reenter.");
            updating = true;
            try
            {
                int count = live.Count;
                for (int i = 0; i < count; i++) live[i].UpdatePlayer(player);
            }
            finally
            {
                updating = false;
                FlushPendingRemovals();
                if (pendingClear)
                {
                    pendingClear = false;
                    Clear(pendingClearSceneEnd, pendingClearPlayer);
                    pendingClearPlayer = default;
                }
            }
        }

        // Call before LoadLevelTransition, beside the host's existing toRemove snapshot.
        // This freezes tag membership: a later change in Persistent does not change removal.
        public Entry[] CaptureTransitionRemovals()
        {
            var captured = new List<Entry>();
            foreach (var entry in live)
                if (entry.IsPersistent?.Invoke() != true)
                    captured.Add(entry);
            return captured.ToArray();
        }

        // Call only at the original UnloadEntities boundary. The player's transition
        // CleanUpTriggers already invoked OnLeave before incoming room construction.
        public void UnloadCaptured(IReadOnlyCollection<Entry> captured)
        {
            if (captured == null || captured.Count == 0) return;
            var removals = new HashSet<Entry>(captured);
            RemoveWhere(removals.Contains);
        }

        public void RemoveWhere(Predicate<Entry> shouldRemove)
        {
            if (shouldRemove == null) throw new ArgumentNullException(nameof(shouldRemove));
            foreach (var entry in live)
                if (shouldRemove(entry))
                    pendingRemovals.Add(entry);
            if (!updating && !flushing) FlushPendingRemovals();
        }

        private void FlushPendingRemovals()
        {
            if (pendingRemovals.Count == 0 || flushing) return;
            flushing = true;
            try
            {
                while (pendingRemovals.Count != 0)
                {
                    var removing = new HashSet<Entry>(pendingRemovals);
                    pendingRemovals.Clear();
                    foreach (var entry in live)
                        if (removing.Contains(entry))
                            entry.Removed?.Invoke(false);
                    live.RemoveAll(removing.Contains);
                }
            }
            finally
            {
                flushing = false;
            }
        }

        // Only hosts without a family-owned cleanup path should use this. In particular,
        // RoomStateTriggers.CleanUpTriggers already owns its HashSet<Trigger> leave order;
        // do not register duplicate LeaveIfEntered callbacks for those entries.
        public void LeaveHostOwnedTriggers(TPlayer player)
        {
            foreach (var entry in live) entry.LeaveIfEntered?.Invoke(player);
        }

        public void Clear(bool sceneEnd, TPlayer player)
        {
            if (updating)
            {
                pendingClear = true;
                pendingClearSceneEnd = sceneEnd;
                pendingClearPlayer = player;
                return;
            }

            if (!sceneEnd) LeaveHostOwnedTriggers(player);
            foreach (var entry in live) entry.Removed?.Invoke(sceneEnd);
            live.Clear();
            pendingRemovals.Clear();
        }
    }
}
