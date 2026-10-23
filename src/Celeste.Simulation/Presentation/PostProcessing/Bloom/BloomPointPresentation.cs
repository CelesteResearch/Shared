using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public class BloomPointPresentation : global::Celeste.Core.Components.SourceComponentState
    {
        public Vector2 Position, WorldPosition;
        public float Alpha = 1, Radius = 8;

        public BloomPointPresentation() : base(false, true)
        {
        }

        public bool EntityVisible = true;
    }
}
