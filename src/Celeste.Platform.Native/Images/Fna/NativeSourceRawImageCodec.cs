using System;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Graphics.Content.Textures;

namespace Celeste.Platform.Native.Images.Fna
{
    public sealed class NativeSourceRawImageCodec : ISourceRawImageCodec
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int ReadCallback(IntPtr userData, IntPtr destination, int size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SkipCallback(IntPtr userData, int count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int EofCallback(IntPtr userData);

        private static readonly ReadCallback Read = ReadStream;
        private static readonly SkipCallback Skip = SkipStream;
        private static readonly EofCallback Eof = EndOfStream;

        [DllImport("FNA3D", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr FNA3D_Image_Load(ReadCallback read, SkipCallback skip,
            EofCallback eof, IntPtr userData, out int width, out int height, out int byteCount,
            int forceWidth, int forceHeight, byte zoom);

        [DllImport("FNA3D", CallingConvention = CallingConvention.Cdecl)]
        private static extern void FNA3D_Image_Free(IntPtr buffer);

        public IntPtr ReadImageStream(Stream stream, out int width, out int height, out int byteCount)
        {
            var handle = GCHandle.Alloc(stream);
            try
            {
                return FNA3D_Image_Load(Read, Skip, Eof, GCHandle.ToIntPtr(handle),
                    out width, out height, out byteCount, -1, -1, 0);
            }
            finally
            {
                handle.Free();
            }
        }

        public void Free(IntPtr buffer)
        {
            FNA3D_Image_Free(buffer);
        }

        private static Stream GetStream(IntPtr userData)
        {
            return (Stream)GCHandle.FromIntPtr(userData).Target;
        }

        private static int ReadStream(IntPtr userData, IntPtr destination, int size)
        {
            var buffer = new byte[size];
            var read = GetStream(userData).Read(buffer, 0, size);
            Marshal.Copy(buffer, 0, destination, read);
            return read;
        }

        private static void SkipStream(IntPtr userData, int count)
        {
            GetStream(userData).Seek(count, SeekOrigin.Current);
        }

        private static int EndOfStream(IntPtr userData)
        {
            var stream = GetStream(userData);
            return stream.Position == stream.Length ? 1 : 0;
        }
    }
}
