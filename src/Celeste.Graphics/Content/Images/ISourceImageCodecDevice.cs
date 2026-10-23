using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Content.Images
{
    public interface ISourceImageCodecDevice
    {
        void FreeImage(IntPtr pointer);

        IntPtr Load(SourceImageReadCallback read, SourceImageSkipCallback skip,
            SourceImageEofCallback eof, IntPtr context, out int width, out int height,
            out int length, int requestedWidth, int requestedHeight, byte zoom);

        void SavePNG(SourceImageWriteCallback write, IntPtr context, int sourceWidth,
            int sourceHeight, int destinationWidth, int destinationHeight, IntPtr data);

        void SaveJPG(SourceImageWriteCallback write, IntPtr context, int sourceWidth,
            int sourceHeight, int destinationWidth, int destinationHeight, IntPtr data, int quality);
    }
}
