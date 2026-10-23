using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFilterGraph_execute_func
    {
        public nint Pointer;

        public static implicit operator AVFilterGraph_execute_func(AVFilterGraph_execute func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
