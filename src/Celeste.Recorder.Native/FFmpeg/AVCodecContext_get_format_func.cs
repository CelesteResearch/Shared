using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecContext_get_format_func
    {
        public nint Pointer;

        public static implicit operator AVCodecContext_get_format_func(AVCodecContext_get_format func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
