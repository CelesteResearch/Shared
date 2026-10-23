using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecContext_get_encode_buffer_func
    {
        public nint Pointer;

        public static implicit operator AVCodecContext_get_encode_buffer_func(AVCodecContext_get_encode_buffer func)
        {
            return new AVCodecContext_get_encode_buffer_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
