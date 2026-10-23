using System;

namespace Celeste.Graphics.Effects.Liquids
{
    public sealed class InstalledLavaRectangleSizeArithmetic : ISourceLavaRectangleSizeArithmetic
    {
        public static InstalledLavaRectangleSizeArithmetic Shared { get; } = new InstalledLavaRectangleSizeArithmetic();

        public LavaRectangleBufferSizes Compute(float width, float height, int step)
        {
            int vertexSegments = (int)((double)width / step * 2d + (double)height / step * 2d + 4d);
            int bubbles = (int)((double)width * height * 0.005f);
            int surfaceBubbleCount = (int)Math.Max(4d, (double)bubbles * 0.25d);
            return new LavaRectangleBufferSizes(vertexSegments, bubbles, surfaceBubbleCount);
        }
    }
}
