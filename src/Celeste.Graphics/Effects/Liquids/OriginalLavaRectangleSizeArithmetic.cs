using System;

namespace Celeste.Graphics.Effects.Liquids
{
    public sealed class OriginalLavaRectangleSizeArithmetic : ISourceLavaRectangleSizeArithmetic
    {
        public static OriginalLavaRectangleSizeArithmetic Shared { get; } = new();

        public LavaRectangleBufferSizes Compute(float width, float height, int step)
        {
            var horizontal = (float)((double)width / (float)step);
            horizontal = (float)((double)horizontal * 2f);
            var vertical = (float)((double)height / (float)step);
            vertical = (float)((double)vertical * 2f);
            var perimeter = (float)((double)horizontal + vertical);
            var vertexSegments = (int)(float)((double)perimeter + 4f);
            var area = (float)((double)width * height);
            var bubbles = (int)(float)((double)area * 0.005f);
            var surface = (float)((double)(float)bubbles * 0.25f);
            var surfaceBubbleCount = (int)Math.Max(4f, surface);
            return new(vertexSegments, bubbles, surfaceBubbleCount);
        }
    }
}
