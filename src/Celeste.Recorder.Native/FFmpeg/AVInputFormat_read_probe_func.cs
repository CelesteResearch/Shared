using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVInputFormat_read_probe_func
    {
        public nint Pointer;

        public static implicit operator AVInputFormat_read_probe_func(AVInputFormat_read_probe func)
        {
            return new AVInputFormat_read_probe_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
