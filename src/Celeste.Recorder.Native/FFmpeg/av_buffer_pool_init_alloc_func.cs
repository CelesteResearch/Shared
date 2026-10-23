using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct av_buffer_pool_init_alloc_func
    {
        public nint Pointer;

        public static implicit operator av_buffer_pool_init_alloc_func(av_buffer_pool_init_alloc func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
