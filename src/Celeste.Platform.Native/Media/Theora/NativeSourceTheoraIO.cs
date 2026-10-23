using System;
using System.Runtime.InteropServices;
using System.Text;
using Celeste.Audio.IO;

namespace Celeste.Platform.Native.Media.Theora
{
    public sealed unsafe class NativeSourceTheoraIO : ISourceTheoraIO
    {
        private static IntPtr AllocateDecoder()
        {
            var platform = Environment.OSVersion.Platform;
            if (IntPtr.Size == 4) return Marshal.AllocHGlobal(1160);
            if (IntPtr.Size == 8)
            {
                if (platform == PlatformID.Unix) return Marshal.AllocHGlobal(1472);
                if (platform == PlatformID.Win32NT) return Marshal.AllocHGlobal(1328);
                throw new NotSupportedException("Unhandled platform!");
            }

            throw new NotSupportedException("Unhandled architecture!");
        }

        [DllImport("libtheorafile", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tf_fopen")]
        private static extern int OpenAnsi([MarshalAs(UnmanagedType.LPStr)] string fileName, IntPtr decoder);

        [DllImport("libtheorafile", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tf_fopen")]
        private static extern int OpenUtf8(byte* fileName, IntPtr decoder);

        public int tf_fopen(string fileName, out IntPtr decoder)
        {
            decoder = AllocateDecoder();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) return OpenAnsi(fileName, decoder);
            var size = fileName.Length * 4 + 1;
            var utf8 = (byte*)Marshal.AllocHGlobal(size);
            fixed (char* chars = fileName)
            {
                Encoding.UTF8.GetBytes(chars, fileName.Length + 1, utf8, size);
            }

            var result = OpenUtf8(utf8, decoder);
            Marshal.FreeHGlobal((IntPtr)utf8);
            return result;
        }

        [DllImport("libtheorafile", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tf_close")]
        private static extern int Close(IntPtr decoder);

        public int tf_close(ref IntPtr decoder)
        {
            var result = Close(decoder);
            Marshal.FreeHGlobal(decoder);
            decoder = IntPtr.Zero;
            return result;
        }

        [DllImport("libtheorafile", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tf_videoinfo")]
        private static extern void Native_tf_videoinfo(IntPtr decoder, out int width, out int height, out double fps,
            out SourceTheoraPixelFormat format);

        public void tf_videoinfo(IntPtr decoder, out int width, out int height, out double fps,
            out SourceTheoraPixelFormat format)
        {
            Native_tf_videoinfo(decoder, out width, out height, out fps, out format);
        }

        [DllImport("libtheorafile", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tf_setvideotrack")]
        private static extern int Native_tf_setvideotrack(IntPtr decoder, int track);

        public int tf_setvideotrack(IntPtr decoder, int track)
        {
            return Native_tf_setvideotrack(decoder, track);
        }

        [DllImport("libtheorafile", CallingConvention = CallingConvention.Cdecl, EntryPoint = "tf_setaudiotrack")]
        private static extern int Native_tf_setaudiotrack(IntPtr decoder, int track);

        public int tf_setaudiotrack(IntPtr decoder, int track)
        {
            return Native_tf_setaudiotrack(decoder, track);
        }
    }
}
