using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWAccel_end_frame_func
    {
        public nint Pointer;

        public static implicit operator AVHWAccel_end_frame_func(AVHWAccel_end_frame func)
        {
            return new AVHWAccel_end_frame_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
