using System;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectTechnique
    {
        public string Name { get; private set; }

        public SourceEffectPassCollection Passes { get; private set; }

        public SourceEffectAnnotationCollection Annotations { get; private set; }

        internal IntPtr TechniquePointer { get; private set; }

        internal SourceEffectTechnique(string name, IntPtr pointer, SourceEffectPassCollection passes,
            SourceEffectAnnotationCollection annotations)
        {
            Name = name;
            Passes = passes;
            Annotations = annotations;
            TechniquePointer = pointer;
        }
    }
}
