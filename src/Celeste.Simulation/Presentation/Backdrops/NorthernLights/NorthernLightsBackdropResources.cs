using System;
using System.Numerics;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Simulation.Presentation.Backdrops.NorthernLights
{
    public sealed class NorthernLightsBackdropResources
    {
        public TileRegion Noise { get; }
        public TileRegion Pixel { get; }
        public Vector4[] Colors { get; }
        public Vector4 GradientTop { get; }
        public Vector4 GradientBottom { get; }
        public int Width { get; }
        public int Height { get; }
        public int StrandCount { get; }
        public int ParticleCount { get; }
        public int NodeCount { get; }

        public NorthernLightsBackdropResources(TileRegion noise, TileRegion pixel, Vector4[] colors,
            Vector4 gradientTop, Vector4 gradientBottom, int width, int height,
            int strandCount, int particleCount, int nodeCount)
        {
            Noise = noise;
            Pixel = pixel;
            Colors = colors ?? throw new ArgumentNullException(nameof(colors));
            if (colors.Length == 0 || width <= 0 || height <= 0 || strandCount < 0 || particleCount < 0 ||
                nodeCount < 2)
                throw new ArgumentException("Backdrop dimensions, colors, and node count must be usable.");
            GradientTop = gradientTop;
            GradientBottom = gradientBottom;
            Width = width;
            Height = height;
            StrandCount = strandCount;
            ParticleCount = particleCount;
            NodeCount = nodeCount;
        }
    }
}
