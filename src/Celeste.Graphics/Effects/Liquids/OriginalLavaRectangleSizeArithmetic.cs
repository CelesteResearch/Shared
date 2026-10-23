using System;

namespace Celeste.Graphics.Effects.Liquids
{
    public sealed class OriginalLavaRectangleSizeArithmetic : ISourceLavaRectangleSizeArithmetic
    {
        public static OriginalLavaRectangleSizeArithmetic Shared { get; } = new OriginalLavaRectangleSizeArithmetic();

        public LavaRectangleBufferSizes Compute(float width, float height, int step)
        {
            float horizontal = (float)((double)width / (float)step);
            horizontal = (float)((double)horizontal * 2f);
            float vertical = (float)((double)height / (float)step);
            vertical = (float)((double)vertical * 2f);
            float perimeter = (float)((double)horizontal + vertical);
            int vertexSegments = (int)(float)((double)perimeter + 4f);
            float area = (float)((double)width * height);
            int bubbles = (int)(float)((double)area * 0.005f);
            float surface = (float)((double)(float)bubbles * 0.25f);
            int surfaceBubbleCount = (int)Math.Max(4f, surface);
            return new LavaRectangleBufferSizes(vertexSegments, bubbles, surfaceBubbleCount);
        }
    }
}
