using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectPassCollection : IEnumerable<SourceEffectPass>, IEnumerable
    {
        private List<SourceEffectPass> elements;

        private SourceEffectPass singleItem;

        public int Count
        {
            get
            {
                if (elements == null)
                {
                    return (singleItem != null) ? 1 : 0;
                }

                return elements.Count;
            }
        }

        public SourceEffectPass this[int index]
        {
            get
            {
                if (elements != null)
                {
                    return elements[index];
                }

                if (index != 0)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                return singleItem;
            }
        }

        public SourceEffectPass this[string name]
        {
            get
            {
                if (elements == null)
                {
                    if (singleItem.Name.Equals(name))
                    {
                        return singleItem;
                    }

                    return null;
                }

                foreach (SourceEffectPass element in elements)
                {
                    if (name.Equals(element.Name))
                    {
                        return element;
                    }
                }

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
                elements = new List<SourceEffectPass>(1);
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
