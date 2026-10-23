using System;
using System.Numerics;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Effects
{
    public class SourceEffectMaterial : SourceEffect
    {
        public SourceEffectMaterial(SourceEffect cloneSource)
            : base(cloneSource)
        {
        }
    }
}
