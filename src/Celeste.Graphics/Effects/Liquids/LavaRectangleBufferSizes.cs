namespace Celeste.Graphics.Effects.Liquids
{
    public readonly struct LavaRectangleBufferSizes
    {
        public readonly int VertexSegments;
        public readonly int BubbleCount;
        public readonly int SurfaceBubbleCount;

        public LavaRectangleBufferSizes(int vertexSegments, int bubbles, int surfaceBubbleCount)
        {
            VertexSegments = vertexSegments;
            BubbleCount = bubbles;
            SurfaceBubbleCount = surfaceBubbleCount;
        }
    }
}
