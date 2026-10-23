using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public sealed class EntityBloomVisual
    {
        public Vector2 Position;
        public float Alpha = 1, Radius;
        public bool Visible = true;
    }
}
