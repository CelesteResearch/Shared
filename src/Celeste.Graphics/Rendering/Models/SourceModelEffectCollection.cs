using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Celeste.Graphics.Rendering.Effects;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelEffectCollection : ReadOnlyCollection<SourceEffect>
    {
        public struct Enumerator : IEnumerator<SourceEffect>, IDisposable, IEnumerator
        {
            private List<SourceEffect>.Enumerator enumerator;

            private bool disposed;

            public SourceEffect Current => enumerator.Current;

            object IEnumerator.Current => Current;

            internal Enumerator(List<SourceEffect> list)
            {
                enumerator = list.GetEnumerator();
                disposed = false;
            }

            public void Dispose()
            {
                if (!disposed)
                {
                    enumerator.Dispose();
                    disposed = true;
                }
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }

            void IEnumerator.Reset()
            {
                IEnumerator enumerator = this.enumerator;
                enumerator.Reset();
                this.enumerator = (List<SourceEffect>.Enumerator)enumerator;
            }
        }

        internal SourceModelEffectCollection(IList<SourceEffect> list)
            : base(list)
        {
        }

        internal SourceModelEffectCollection()
            : base(new List<SourceEffect>())
        {
        }

        public new Enumerator GetEnumerator()
        {
            return new((List<SourceEffect>)Items);
        }

        internal void Add(SourceEffect item)
        {
            Items.Add(item);
        }

        internal void Remove(SourceEffect item)
        {
            Items.Remove(item);
        }
    }
}
