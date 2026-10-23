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
    public class SourceModelBoneCollection : ReadOnlyCollection<SourceModelBone>
    {
        public struct Enumerator : IEnumerator<SourceModelBone>, IDisposable, IEnumerator
        {
            private readonly SourceModelBoneCollection collection;

            private int position;

            public SourceModelBone Current => collection[position];

            object IEnumerator.Current => collection[position];

            internal Enumerator(SourceModelBoneCollection collection)
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

        public SourceModelBone this[string boneName]
        {
            get
            {
                if (TryGetValue(boneName, out var value))
                {
                    return value;
                }

                throw new KeyNotFoundException();
            }
        }

        internal SourceModelBoneCollection(IList<SourceModelBone> list)
            : base(list)
        {
        }

        public bool TryGetValue(string boneName, out SourceModelBone value)
        {
            foreach (SourceModelBone item in base.Items)
            {
                if (item.Name == boneName)
                {
                    value = item;
                    return true;
                }
            }

            value = null;
            return false;
        }

        public new Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
