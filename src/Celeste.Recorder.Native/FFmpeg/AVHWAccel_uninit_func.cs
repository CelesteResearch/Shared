using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWAccel_uninit_func
    {
        public nint Pointer;

        public static implicit operator AVHWAccel_uninit_func(AVHWAccel_uninit func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
