using System;
using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Graphics.Rendering.Effects
{
    public interface ISourceEffectFog
    {
        Vector3 FogColor { get; set; }

        bool FogEnabled { get; set; }

        float FogEnd { get; set; }

        float FogStart { get; set; }
    }
}
