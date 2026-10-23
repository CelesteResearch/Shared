using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVClass_item_name_func
    {
        public nint Pointer;

        public static implicit operator AVClass_item_name_func(AVClass_item_name func)
        {
            return new AVClass_item_name_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
