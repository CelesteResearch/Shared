using System;
using System.Collections.Generic;
using Celeste.Physics.Collision.Riding;

namespace Celeste.Simulation.Gameplay.Platforms.Movement
{
    public sealed class SourceSolidRiderScope : IDisposable
    {
        private static readonly Stack<SourceSolidRiderScope> available = new();
        private readonly HashSet<ISourcePlatformActor> backup = [];
        public readonly List<ISourcePlatformActor> CarriedRiders = [];
        private HashSet<ISourcePlatformActor> source;

        internal static SourceSolidRiderScope Capture(HashSet<ISourcePlatformActor> riders)
        {
            var scope = available.Count == 0 ? new() : available.Pop();
            scope.source = riders;
            foreach (var actor in riders) scope.backup.Add(actor);
            riders.Clear();
            return scope;
        }

        public void Dispose()
        {
            if (source == null) return;
            source.Clear();
            foreach (var actor in backup)
                if (!CarriedRiders.Contains(actor))
                    source.Add(actor);
            backup.Clear();
            CarriedRiders.Clear();
            source = null;
            available.Push(this);
        }
    }
}
