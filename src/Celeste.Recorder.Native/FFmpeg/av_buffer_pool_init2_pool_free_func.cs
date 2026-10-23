using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct av_buffer_pool_init2_pool_free_func
    {
        public nint Pointer;

        public static implicit operator av_buffer_pool_init2_pool_free_func(av_buffer_pool_init2_pool_free func)
        {
            return new av_buffer_pool_init2_pool_free_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
