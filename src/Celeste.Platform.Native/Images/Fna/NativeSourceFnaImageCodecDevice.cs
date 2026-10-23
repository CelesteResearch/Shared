using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Content.Images;

namespace Celeste.Platform.Native.Images.Fna
{
    public sealed class NativeSourceFnaImageCodecDevice : ISourceImageCodecDevice
    {
        public IntPtr Load(SourceImageReadCallback read, SourceImageSkipCallback skip, SourceImageEofCallback eof,
            IntPtr context, out int width, out int height, out int length, int requestedWidth, int requestedHeight,
            byte zoom)
        {
            return FNA3D_Image_Load(read, skip, eof, context, out width, out height, out length, requestedWidth,
                requestedHeight, zoom);
        }

        public void FreeImage(IntPtr pointer)
        {
            FNA3D_Image_Free(pointer);
        }

        public void SavePNG(SourceImageWriteCallback write, IntPtr context, int sourceWidth, int sourceHeight,
            int destinationWidth, int destinationHeight, IntPtr data)
        {
            FNA3D_Image_SavePNG(write, context, sourceWidth, sourceHeight, destinationWidth, destinationHeight,
                data);
        }

        public void SaveJPG(SourceImageWriteCallback write, IntPtr context, int sourceWidth, int sourceHeight,
            int destinationWidth, int destinationHeight, IntPtr data, int quality)
        {
            FNA3D_Image_SaveJPG(write, context, sourceWidth, sourceHeight, destinationWidth, destinationHeight, data,
                quality);
        }

        [DllImport("FNA3D", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr FNA3D_Image_Load(SourceImageReadCallback read, SourceImageSkipCallback skip,
            SourceImageEofCallback eof, IntPtr context, out int width, out int height, out int length, int forceWidth,
            int forceHeight, byte zoom);

        [DllImport("FNA3D", CallingConvention = CallingConvention.Cdecl)]
        private static extern void FNA3D_Image_Free(IntPtr pointer);

        [DllImport("FNA3D", CallingConvention = CallingConvention.Cdecl)]
        private static extern void FNA3D_Image_SavePNG(SourceImageWriteCallback write, IntPtr context, int sourceWidth,
            int sourceHeight, int destinationWidth, int destinationHeight, IntPtr data);

        [DllImport("FNA3D", CallingConvention = CallingConvention.Cdecl)]
        private static extern void FNA3D_Image_SaveJPG(SourceImageWriteCallback write, IntPtr context, int sourceWidth,
            int sourceHeight, int destinationWidth, int destinationHeight, IntPtr data, int quality);
    }
}
