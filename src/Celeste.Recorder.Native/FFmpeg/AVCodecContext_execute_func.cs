using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecContext_execute_func
    {
        public nint Pointer;

        public static implicit operator AVCodecContext_execute_func(AVCodecContext_execute func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
