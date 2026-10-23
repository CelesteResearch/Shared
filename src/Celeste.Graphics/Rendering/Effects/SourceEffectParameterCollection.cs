using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectParameterCollection : IEnumerable<SourceEffectParameter>, IEnumerable
    {
        private List<SourceEffectParameter> elements;

        public int Count => elements.Count;

        public SourceEffectParameter this[int index] => elements[index];

        public SourceEffectParameter this[string name]
        {
            get
            {
                foreach (SourceEffectParameter element in elements)
                {
                    if (name.Equals(element.Name))
                    {
                        return element;
                    }
                }

                return null;
            }
        }

        internal SourceEffectParameterCollection(List<SourceEffectParameter> value)
        {
            elements = value;
        }

        public List<SourceEffectParameter>.Enumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        public SourceEffectParameter GetParameterBySemantic(string semantic)
        {
            foreach (SourceEffectParameter element in elements)
            {
                if (semantic.Equals(element.Semantic))
                {
                    return element;
                }
            }

            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator<SourceEffectParameter> IEnumerable<SourceEffectParameter>.GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
