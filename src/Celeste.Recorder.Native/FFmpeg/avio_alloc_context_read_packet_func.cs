using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct avio_alloc_context_read_packet_func
    {
        public nint Pointer;

        public static implicit operator avio_alloc_context_read_packet_func(avio_alloc_context_read_packet func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
