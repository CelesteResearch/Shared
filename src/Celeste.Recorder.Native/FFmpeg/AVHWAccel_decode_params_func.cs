using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWAccel_decode_params_func
    {
        public nint Pointer;

        public static implicit operator AVHWAccel_decode_params_func(AVHWAccel_decode_params func)
        {
            return new AVHWAccel_decode_params_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
