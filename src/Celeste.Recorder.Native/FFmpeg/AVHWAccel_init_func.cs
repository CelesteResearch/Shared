using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWAccel_init_func
    {
        public nint Pointer;

        public static implicit operator AVHWAccel_init_func(AVHWAccel_init func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
