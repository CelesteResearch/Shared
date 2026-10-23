using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelMeshPartCollection : ReadOnlyCollection<SourceModelMeshPart>
    {
        public struct Enumerator : IEnumerator<SourceModelMeshPart>, IDisposable, IEnumerator
        {
            private readonly SourceModelMeshPartCollection collection;

            private int position;

            public SourceModelMeshPart Current => collection[position];

            object IEnumerator.Current => collection[position];

            internal Enumerator(SourceModelMeshPartCollection collection)
            {
                this.collection = collection;
                position = -1;
            }

            public bool MoveNext()
            {
                position++;
                return position < collection.Count;
            }

            public void Dispose()
            {
            }

            void IEnumerator.Reset()
            {
                position = -1;
            }
        }

        internal SourceModelMeshPartCollection(IList<SourceModelMeshPart> list)
            : base(list)
        {
        }

        public new Enumerator GetEnumerator()
        {
            return new(this);
        }
    }
}
