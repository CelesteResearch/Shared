using System.Collections;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectTechniqueCollection : IEnumerable<SourceEffectTechnique>, IEnumerable
    {
        private readonly List<SourceEffectTechnique> elements;

        public int Count => elements.Count;

        public SourceEffectTechnique this[int index] => elements[index];

        public SourceEffectTechnique this[string name]
        {
            get
            {
                foreach (var element in elements)
                    if (name.Equals(element.Name))
                        return element;

                return null;
            }
        }

        internal SourceEffectTechniqueCollection(List<SourceEffectTechnique> value)
        {
            elements = value;
        }

        public List<SourceEffectTechnique>.Enumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator<SourceEffectTechnique> IEnumerable<SourceEffectTechnique>.GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
