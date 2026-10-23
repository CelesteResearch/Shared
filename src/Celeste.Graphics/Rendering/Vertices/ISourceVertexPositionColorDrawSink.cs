namespace Celeste.Graphics.Rendering.Vertices
{
    public interface ISourceVertexPositionColorDrawSink
    {
        void DrawUserTriangleList(SourceVertexPositionColor[] vertices, int vertexOffset, int primitiveCount);
    }
}
