using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVClass_query_ranges_func
    {
        public nint Pointer;

        public static implicit operator AVClass_query_ranges_func(AVClass_query_ranges func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
