using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFilter_preinit_func
    {
        public nint Pointer;

        public static implicit operator AVFilter_preinit_func(AVFilter_preinit func)
        {
            return new AVFilter_preinit_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
