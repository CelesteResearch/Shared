using System;

namespace Celeste.Graphics.Effects.Liquids
{
    public sealed class InstalledLavaRectangleSizeArithmetic : ISourceLavaRectangleSizeArithmetic
    {
        public static InstalledLavaRectangleSizeArithmetic Shared { get; } = new();

        public LavaRectangleBufferSizes Compute(float width, float height, int step)
        {
            var vertexSegments = (int)((double)width / step * 2d + (double)height / step * 2d + 4d);
            var bubbles = (int)((double)width * height * 0.005f);
            var surfaceBubbleCount = (int)Math.Max(4d, bubbles * 0.25d);
            return new(vertexSegments, bubbles, surfaceBubbleCount);
        }
    }
}
