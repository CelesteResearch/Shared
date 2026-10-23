using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVIOContext_write_packet_func
    {
        public nint Pointer;

        public static implicit operator AVIOContext_write_packet_func(AVIOContext_write_packet func)
        {
            return new AVIOContext_write_packet_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
