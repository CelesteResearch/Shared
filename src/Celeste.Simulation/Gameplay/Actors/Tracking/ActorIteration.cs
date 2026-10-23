using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Actors.Tracking
{
    // The production Actor tracker is a concrete List, as in Monocle. Preserve
    // its struct enumerator (including live/version checks) rather than boxing it
    // through IEnumerable for every solid/jumpthru movement. Custom enumerable
    // implementations, including List subclasses, retain their original enumerator.
    internal readonly struct ActorIteration
    {
        private readonly IEnumerable<global::Celeste.Simulation.Gameplay.Actors.CassetteActor> source;

        public ActorIteration(IEnumerable<global::Celeste.Simulation.Gameplay.Actors.CassetteActor> source)
        {
            this.source = source;
        }

        public Enumerator GetEnumerator() =>
            source.GetType() == typeof(List<global::Celeste.Simulation.Gameplay.Actors.CassetteActor>)
                ? new Enumerator((List<global::Celeste.Simulation.Gameplay.Actors.CassetteActor>)source)
                : new Enumerator(source.GetEnumerator());

        internal struct Enumerator : IDisposable
        {
            private List<global::Celeste.Simulation.Gameplay.Actors.CassetteActor>.Enumerator list;
            private readonly IEnumerator<global::Celeste.Simulation.Gameplay.Actors.CassetteActor> other;
            private readonly bool useList;

            public Enumerator(List<global::Celeste.Simulation.Gameplay.Actors.CassetteActor> source)
            {
                list = source.GetEnumerator();
                other = null;
                useList = true;
            }

            public Enumerator(IEnumerator<global::Celeste.Simulation.Gameplay.Actors.CassetteActor> source)
            {
                list = default;
                other = source;
                useList = false;
            }

            public global::Celeste.Simulation.Gameplay.Actors.CassetteActor Current =>
                useList ? list.Current : other.Current;

            public bool MoveNext() => useList ? list.MoveNext() : other.MoveNext();

            public void Dispose()
            {
                if (useList) list.Dispose();
                else other?.Dispose();
            }
        }
    }
}
