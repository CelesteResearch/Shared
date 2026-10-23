using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWDeviceContext_free_func
    {
        public nint Pointer;

        public static implicit operator AVHWDeviceContext_free_func(AVHWDeviceContext_free func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
