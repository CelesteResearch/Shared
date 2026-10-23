namespace Celeste.Graphics.Display
{
    public sealed class ColoredGeometry(int depth, ColoredVertex[] vertices)
    {
        public int Depth = depth;
        public ColoredVertex[] Vertices = vertices;
    }
}
