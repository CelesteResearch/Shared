using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVIOContext_read_packet_func
    {
        public nint Pointer;

        public static implicit operator AVIOContext_read_packet_func(AVIOContext_read_packet func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
