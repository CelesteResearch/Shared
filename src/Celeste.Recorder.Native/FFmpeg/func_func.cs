using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct func_func
    {
        public nint Pointer;

        public static implicit operator func_func(func func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
