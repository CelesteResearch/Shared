using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVInputFormat_read_seek2_func
    {
        public nint Pointer;

        public static implicit operator AVInputFormat_read_seek2_func(AVInputFormat_read_seek2 func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
