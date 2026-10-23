using System.Runtime.CompilerServices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceVertexBufferReader : SourceContentTypeReader<SourceVertexBuffer>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceVertexBuffer Read(SourceContentReader input,
            SourceVertexBuffer existingInstance)
        {
            SourceVertexDeclaration vertexDeclaration = input.ReadRawObject<SourceVertexDeclaration>();
            int num = (int)input.ReadUInt32();
            byte[] data = input.ReadBytes(num * vertexDeclaration.VertexStride);
            SourceVertexBuffer vertexBuffer = new SourceVertexBuffer(input.ContentManager.GetGraphicsDevice(),
                vertexDeclaration, num, SourceBufferUsage.None);
            vertexBuffer.SetData(data);
            return vertexBuffer;
        }
    }
}
