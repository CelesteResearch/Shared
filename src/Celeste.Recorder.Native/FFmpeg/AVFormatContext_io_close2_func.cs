using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFormatContext_io_close2_func
    {
        public nint Pointer;

        public static implicit operator AVFormatContext_io_close2_func(AVFormatContext_io_close2 func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
