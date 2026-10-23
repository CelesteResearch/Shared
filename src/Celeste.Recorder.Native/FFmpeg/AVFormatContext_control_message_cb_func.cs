using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFormatContext_control_message_cb_func
    {
        public nint Pointer;

        public static implicit operator AVFormatContext_control_message_cb_func(AVFormatContext_control_message_cb func)
        {
            return new AVFormatContext_control_message_cb_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
