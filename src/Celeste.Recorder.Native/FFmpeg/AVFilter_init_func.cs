using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFilter_init_func
    {
        public nint Pointer;

        public static implicit operator AVFilter_init_func(AVFilter_init func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
