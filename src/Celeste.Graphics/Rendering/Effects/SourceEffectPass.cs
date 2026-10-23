using System.Numerics;
using Celeste.Core.Rendering.Resources;
using Celeste.Core.Rendering.States;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using System;

namespace Celeste.Graphics.Rendering.Effects
{
    public sealed class SourceEffectPass
    {
        private SourceEffect parentEffect;

        private IntPtr parentTechnique;

        private uint pass;

        public string Name { get; private set; }

        public SourceEffectAnnotationCollection Annotations { get; private set; }

        internal SourceEffectPass(string name, SourceEffectAnnotationCollection annotations, SourceEffect parent,
            IntPtr technique, uint passIndex)
        {
            Name = name;
            Annotations = annotations;
            parentEffect = parent;
            parentTechnique = technique;
            pass = passIndex;
        }

        public void Apply()
        {
            if (parentTechnique != parentEffect.CurrentTechnique.TechniquePointer)
            {
                throw new InvalidOperationException("Applied a pass not in the current technique!");
            }

            parentEffect.OnApply();
            parentEffect.INTERNAL_applyEffect(pass);
        }
    }
}
