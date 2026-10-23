using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectPassCollection : IEnumerable<SourceEffectPass>, IEnumerable
    {
        private List<SourceEffectPass> elements;

        private readonly SourceEffectPass singleItem;

        public int Count
        {
            get
            {
                if (elements == null) return singleItem != null ? 1 : 0;

                return elements.Count;
            }
        }

        public SourceEffectPass this[int index]
        {
            get
            {
                if (elements != null) return elements[index];

                if (index != 0) throw new ArgumentOutOfRangeException("index");

                return singleItem;
            }
        }

        public SourceEffectPass this[string name]
        {
            get
            {
                if (elements == null)
                {
                    if (singleItem.Name.Equals(name)) return singleItem;

                    return null;
                }

                foreach (var element in elements)
                    if (name.Equals(element.Name))
                        return element;

                return null;
            }
        }

        internal SourceEffectPassCollection(List<SourceEffectPass> value)
        {
            elements = value;
        }

        internal SourceEffectPassCollection(SourceEffectPass pass)
        {
            singleItem = pass;
        }

        internal List<SourceEffectPass> GetList()
        {
            if (elements == null)
            {
                elements = /* ReSharper disable once UseCollectionExpression */ new(1);
                elements.Add(singleItem);
            }

            return elements;
        }

        public List<SourceEffectPass>.Enumerator GetEnumerator()
        {
            return GetList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetList().GetEnumerator();
        }

        IEnumerator<SourceEffectPass> IEnumerable<SourceEffectPass>.GetEnumerator()
        {
            return GetList().GetEnumerator();
        }
    }
}
