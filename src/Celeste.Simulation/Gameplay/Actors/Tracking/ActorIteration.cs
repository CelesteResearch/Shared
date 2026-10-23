using System;
using System.Collections.Generic;

namespace Celeste.Simulation.Gameplay.Actors.Tracking
{
    // The production Actor tracker is a concrete List, as in Monocle. Preserve
    // its struct enumerator (including live/version checks) rather than boxing it
    // through IEnumerable for every solid/jumpthru movement. Custom enumerable
    // implementations, including List subclasses, retain their original enumerator.
    internal readonly struct ActorIteration
    {
        private readonly IEnumerable<CassetteActor> source;

        public ActorIteration(IEnumerable<CassetteActor> source)
        {
            this.source = source;
        }

        public Enumerator GetEnumerator()
        {
            return source.GetType() == typeof(List<CassetteActor>)
                ? new((List<CassetteActor>)source)
                : new Enumerator(source.GetEnumerator());
        }

        internal struct Enumerator : IDisposable
        {
            private List<CassetteActor>.Enumerator list;
            private readonly IEnumerator<CassetteActor> other;
            private readonly bool useList;

            public Enumerator(List<CassetteActor> source)
            {
                list = source.GetEnumerator();
                other = null;
                useList = true;
            }

            public Enumerator(IEnumerator<CassetteActor> source)
            {
                list = default;
                other = source;
                useList = false;
            }

            public CassetteActor Current =>
                useList ? list.Current : other.Current;

            public bool MoveNext()
            {
                return useList ? list.MoveNext() : other.MoveNext();
            }

            public void Dispose()
            {
                if (useList) list.Dispose();
                else other?.Dispose();
            }
        }
    }
}
