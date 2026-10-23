using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Effects.Trails
{
    // GPU contract: clear every listed 64x64 cell first, draw Images in order using
    // premultiplied alpha + point sampling, then replace RGB and A with destination A
    // across the entire 512x512 buffer. Captures are NOT scissored to individual cells.
    public sealed class TrailCaptureBatch
    {
        public readonly List<global::Celeste.Core.Geometry.IntRect> ClearRects =
            new List<global::Celeste.Core.Geometry.IntRect>();

        public readonly List<global::Celeste.Graphics.Display.ImagePlacement> Images =
            new List<global::Celeste.Graphics.Display.ImagePlacement>();

        public readonly List<int> Slots = new List<int>();
        public bool CreateBuffer;
    }
}
