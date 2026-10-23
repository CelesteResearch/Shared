using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct av_log_set_callback_callback_func
    {
        public nint Pointer;

        public static implicit operator av_log_set_callback_callback_func(av_log_set_callback_callback func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
