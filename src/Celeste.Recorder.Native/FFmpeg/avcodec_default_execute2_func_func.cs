using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct avcodec_default_execute2_func_func
    {
        public nint Pointer;

        public static implicit operator avcodec_default_execute2_func_func(avcodec_default_execute2_func func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
