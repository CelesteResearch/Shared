using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Celeste.Graphics.Rendering.Models
{
    public sealed class SourceModelMeshCollection : ReadOnlyCollection<SourceModelMesh>
    {
        public struct Enumerator : IEnumerator<SourceModelMesh>, IDisposable, IEnumerator
        {
            private readonly SourceModelMeshCollection collection;

            private int position;

            public SourceModelMesh Current => collection[position];

            object IEnumerator.Current => collection[position];

            internal Enumerator(SourceModelMeshCollection collection)
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

        public SourceModelMesh this[string meshName]
        {
            get
            {
                if (!TryGetValue(meshName, out var value)) throw new KeyNotFoundException();

                return value;
            }
        }

        internal SourceModelMeshCollection(IList<SourceModelMesh> list)
            : base(list)
        {
        }

        public bool TryGetValue(string meshName, out SourceModelMesh value)
        {
            if (string.IsNullOrEmpty(meshName)) throw new ArgumentNullException("meshName");

            using (var enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (string.Compare(current.Name, meshName, StringComparison.Ordinal) == 0)
                    {
                        value = current;
                        return true;
                    }
                }
            }

            value = null;
            return false;
        }

        public new Enumerator GetEnumerator()
        {
            return new(this);
        }
    }
}
