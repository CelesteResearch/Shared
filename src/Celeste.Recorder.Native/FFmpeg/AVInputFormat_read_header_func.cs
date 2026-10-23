using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVInputFormat_read_header_func
    {
        public nint Pointer;

        public static implicit operator AVInputFormat_read_header_func(AVInputFormat_read_header func)
        {
            return new AVInputFormat_read_header_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
