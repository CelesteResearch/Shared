using System.Runtime.CompilerServices;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceIndexBufferReader : SourceContentTypeReader<SourceIndexBuffer>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceIndexBuffer Read(SourceContentReader input,
            SourceIndexBuffer existingInstance)
        {
            SourceIndexBuffer indexBuffer = existingInstance;
            bool flag = input.ReadBoolean();
            int num = input.ReadInt32();
            byte[] data = input.ReadBytes(num);
            if (indexBuffer == null)
            {
                indexBuffer = ((!flag)
                    ? new SourceIndexBuffer(input.ContentManager.GetGraphicsDevice(),
                        SourceIndexElementSize.ThirtyTwoBits,
                        num / 4, SourceBufferUsage.None)
                    : new SourceIndexBuffer(input.ContentManager.GetGraphicsDevice(),
                        SourceIndexElementSize.SixteenBits,
                        num / 2, SourceBufferUsage.None));
            }

            indexBuffer.SetData(data);
            return indexBuffer;
        }
    }
}
