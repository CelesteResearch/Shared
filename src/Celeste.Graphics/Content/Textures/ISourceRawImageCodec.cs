using System;
using System.IO;

namespace Celeste.Graphics.Content.Textures
{
    public interface ISourceRawImageCodec
    {
        IntPtr ReadImageStream(Stream stream, out int width, out int height, out int byteCount);
        void Free(IntPtr buffer);
    }
}
