using System.Threading;

namespace Celeste.Everest.Content.Textures
{
    public sealed class EverestTextureDataBuffers
    {
        private readonly ThreadLocal<byte[]> bytes = new();
        internal readonly object BufferLock;
        internal byte[] Buffer;
        internal byte[] Bytes => bytes.Value ?? (bytes.Value = new byte[524288]);

        public EverestTextureDataBuffers()
        {
            Buffer = new byte[67108864];
            bytes.Value = new byte[524288];
            BufferLock = new object();
        }
    }
}
