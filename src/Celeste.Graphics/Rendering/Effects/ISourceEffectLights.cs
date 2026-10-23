using System;
using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Graphics.Rendering.Effects
{
    public interface ISourceEffectLights
    {
        Vector3 AmbientLightColor { get; set; }

        SourceDirectionalLight DirectionalLight0 { get; }

        SourceDirectionalLight DirectionalLight1 { get; }

        SourceDirectionalLight DirectionalLight2 { get; }

        bool LightingEnabled { get; set; }

        void EnableDefaultLighting();
    }
}
