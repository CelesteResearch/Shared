using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFilter_activate_func
    {
        public nint Pointer;

        public static implicit operator AVFilter_activate_func(AVFilter_activate func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
