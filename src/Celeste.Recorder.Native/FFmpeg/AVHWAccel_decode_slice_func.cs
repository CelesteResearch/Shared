using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWAccel_decode_slice_func
    {
        public nint Pointer;

        public static implicit operator AVHWAccel_decode_slice_func(AVHWAccel_decode_slice func)
        {
            return new AVHWAccel_decode_slice_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
