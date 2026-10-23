using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVClass_child_class_iterate_func
    {
        public nint Pointer;

        public static implicit operator AVClass_child_class_iterate_func(AVClass_child_class_iterate func)
        {
            return new AVClass_child_class_iterate_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
