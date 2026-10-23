using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Effects;
using BoundingSphere = Celeste.Core.Geometry.Intersections.BoundingSphere;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
                this.enumerator = (List<SourceEffect>.Enumerator)(object)enumerator;
            }
        }

        internal SourceModelEffectCollection(IList<SourceEffect> list)
            : base(list)
        {
        }

        internal SourceModelEffectCollection()
            : base((IList<SourceEffect>)new List<SourceEffect>())
        {
        }

        public new Enumerator GetEnumerator()
        {
            return new Enumerator((List<SourceEffect>)base.Items);
        }

        internal void Add(SourceEffect item)
        {
            base.Items.Add(item);
        }

        internal void Remove(SourceEffect item)
        {
            base.Items.Remove(item);
        }
    }
}
