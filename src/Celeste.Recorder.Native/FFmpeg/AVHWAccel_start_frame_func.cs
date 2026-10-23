using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWAccel_start_frame_func
    {
        public nint Pointer;

        public static implicit operator AVHWAccel_start_frame_func(AVHWAccel_start_frame func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
