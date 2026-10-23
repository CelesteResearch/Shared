using System;
using System.Collections.Generic;
using Celeste.Physics.Collision.Riding;

namespace Celeste.Simulation.Gameplay.Platforms.Movement
{
    public sealed class SourceSolidRiderScope : IDisposable
    {
        private static readonly Stack<SourceSolidRiderScope> available = new Stack<SourceSolidRiderScope>();
        private readonly HashSet<ISourcePlatformActor> backup = new HashSet<ISourcePlatformActor>();
        public readonly List<ISourcePlatformActor> CarriedRiders = new List<ISourcePlatformActor>();
        private HashSet<ISourcePlatformActor> source;

        internal static SourceSolidRiderScope Capture(HashSet<ISourcePlatformActor> riders)
        {
            SourceSolidRiderScope scope = available.Count == 0 ? new SourceSolidRiderScope() : available.Pop();
            scope.source = riders;
            foreach (ISourcePlatformActor actor in riders) scope.backup.Add(actor);
            riders.Clear();
            return scope;
        }

        public void Dispose()
        {
            if (source == null) return;
            source.Clear();
            foreach (ISourcePlatformActor actor in backup)
                if (!CarriedRiders.Contains(actor))
                    source.Add(actor);
            backup.Clear();
            CarriedRiders.Clear();
            source = null;
            available.Push(this);
        }
    }
}
