using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecContext_get_format_func
    {
        public nint Pointer;

        public static implicit operator AVCodecContext_get_format_func(AVCodecContext_get_format func)
        {
            return new AVCodecContext_get_format_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
