using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFilter_uninit_func
    {
        public nint Pointer;

        public static implicit operator AVFilter_uninit_func(AVFilter_uninit func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
