using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVIOContext_read_pause_func
    {
        public nint Pointer;

        public static implicit operator AVIOContext_read_pause_func(AVIOContext_read_pause func)
        {
            return new AVIOContext_read_pause_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
