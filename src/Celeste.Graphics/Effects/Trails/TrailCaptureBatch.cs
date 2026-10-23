using System.Collections.Generic;
using Celeste.Core.Geometry;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Effects.Trails
{
    // GPU contract: clear every listed 64x64 cell first, draw Images in order using
    // premultiplied alpha + point sampling, then replace RGB and A with destination A
    // across the entire 512x512 buffer. Captures are NOT scissored to individual cells.
    public sealed class TrailCaptureBatch
    {
        public readonly List<IntRect> ClearRects = [];

        public readonly List<ImagePlacement> Images = [];

        public readonly List<int> Slots = [];
        public bool CreateBuffer;
    }
}
