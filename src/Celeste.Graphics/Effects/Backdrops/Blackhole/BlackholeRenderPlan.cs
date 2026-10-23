using System;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Graphics.Effects.Backdrops.Blackhole
{
    // Execute in this order in one 320x180 target: clear, background images,
    // translated spiral triangles, translated stream triangles, particle images.
    public sealed class BlackholeRenderPlan
    {
        public readonly Vector4 ClearColor = new Vector4(0, 0, 0, 1);

        public readonly List<global::Celeste.Graphics.Display.ImagePlacement> BackgroundImages =
            new List<global::Celeste.Graphics.Display.ImagePlacement>();

        public readonly List<global::Celeste.Graphics.Display.ImagePlacement> ParticleImages =
            new List<global::Celeste.Graphics.Display.ImagePlacement>();

        public global::Celeste.Graphics.Effects.Backdrops.Blackhole.BlackholeVertex[] SpiralVertices, StreamVertices;
        public int SpiralVertexCount, StreamVertexCount;
        public Vector2 Center;
        public string AtlasPage;
    }
}
