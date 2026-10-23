using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Effects.Backdrops.Blackhole
{
    // Execute in this order in one 320x180 target: clear, background images,
    // translated spiral triangles, translated stream triangles, particle images.
    public sealed class BlackholeRenderPlan
    {
        public readonly Vector4 ClearColor = new(0, 0, 0, 1);

        public readonly List<ImagePlacement> BackgroundImages = [];

        public readonly List<ImagePlacement> ParticleImages = [];

        public BlackholeVertex[] SpiralVertices, StreamVertices;
        public int SpiralVertexCount, StreamVertexCount;
        public Vector2 Center;
        public string AtlasPage;
    }
}
