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
            int vertexStride = reader.ReadInt32();
            int num = reader.ReadInt32();
            SourceVertexElement[] array = new SourceVertexElement[num];
            for (int i = 0; i < num; i++)
            {
                int offset = reader.ReadInt32();
                SourceVertexElementFormat elementFormat = (SourceVertexElementFormat)reader.ReadInt32();
                SourceVertexElementUsage elementUsage = (SourceVertexElementUsage)reader.ReadInt32();
                int usageIndex = reader.ReadInt32();
                array[i] = new SourceVertexElement(offset, elementFormat, elementUsage, usageIndex);
            }

            return new SourceVertexDeclaration(vertexStride, array);
        }
    }
}
