using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using System.Collections;
using System.Collections.Generic;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectAnnotationCollection : IEnumerable<SourceEffectAnnotation>, IEnumerable
    {
        internal static readonly SourceEffectAnnotationCollection Empty =
            new SourceEffectAnnotationCollection(new List<SourceEffectAnnotation>());

        private List<SourceEffectAnnotation> elements;

        public int Count => elements.Count;

        public SourceEffectAnnotation this[int index] => elements[index];

        public SourceEffectAnnotation this[string name]
        {
            get
            {
                foreach (SourceEffectAnnotation element in elements)
                {
                    if (name.Equals(element.Name))
                    {
                        return element;
                    }
                }

                return null;
            }
        }

        internal SourceEffectAnnotationCollection(List<SourceEffectAnnotation> value)
        {
            elements = value;
        }

        public List<SourceEffectAnnotation>.Enumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator<SourceEffectAnnotation> IEnumerable<SourceEffectAnnotation>.GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
