namespace Celeste.Graphics.Effects.Liquids
{
    public readonly struct LavaRectangleBufferSizes(int vertexSegments, int bubbles, int surfaceBubbleCount)
    {
        public readonly int VertexSegments = vertexSegments;
        public readonly int BubbleCount = bubbles;
        public readonly int SurfaceBubbleCount = surfaceBubbleCount;
    }
}
