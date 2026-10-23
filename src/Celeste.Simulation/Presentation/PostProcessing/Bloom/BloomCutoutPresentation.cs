using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Simulation.Presentation.PostProcessing.Bloom
{
    public sealed class BloomCutoutPresentation : IBloomCutout
    {
        public global::Celeste.Core.Geometry.Bounds Bounds;
        public float Alpha = 1;
        public bool Visible = true, EntityVisible = true;
        bool IBloomCutout.Visible => Visible;
        float IBloomCutout.Alpha => Alpha;

        public global::Celeste.Core.Geometry.IntRect DrawBounds => new global::Celeste.Core.Geometry.IntRect(
            (int)Bounds.X, (int)Bounds.Y, (int)Bounds.Right - (int)Bounds.X,
            (int)Bounds.Bottom - (int)Bounds.Y);
    }
}
