namespace Celeste.Graphics.Rendering.Vertices
{
    internal static class SourceVertexDeclarationCache<T> where T : struct, ISourceVertexType
    {
        private static SourceVertexDeclaration cached;

        public static SourceVertexDeclaration VertexDeclaration
        {
            get
            {
                if (cached == null) cached = SourceVertexDeclaration.FromType(typeof(T));

                return cached;
            }
        }
    }
}
