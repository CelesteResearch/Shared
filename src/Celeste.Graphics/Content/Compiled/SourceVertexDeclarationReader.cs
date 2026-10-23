using System.Runtime.CompilerServices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVertexDeclarationReader : SourceContentTypeReader<SourceVertexDeclaration>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceVertexDeclaration Read(SourceContentReader reader,
            SourceVertexDeclaration existingInstance)
        {
            var vertexStride = reader.ReadInt32();
            var num = reader.ReadInt32();
            var array = new SourceVertexElement[num];
            for (var i = 0; i < num; i++)
            {
                var offset = reader.ReadInt32();
                var elementFormat = (SourceVertexElementFormat)reader.ReadInt32();
                var elementUsage = (SourceVertexElementUsage)reader.ReadInt32();
                var usageIndex = reader.ReadInt32();
                array[i] = new(offset, elementFormat, elementUsage, usageIndex);
            }

            return new(vertexStride, array);
        }
    }
}
