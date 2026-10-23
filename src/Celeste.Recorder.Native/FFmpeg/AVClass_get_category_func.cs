using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVClass_get_category_func
    {
        public nint Pointer;

        public static implicit operator AVClass_get_category_func(AVClass_get_category func)
        {
            return new AVClass_get_category_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
