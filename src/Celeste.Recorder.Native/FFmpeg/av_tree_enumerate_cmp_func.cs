using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct av_tree_enumerate_cmp_func
    {
        public nint Pointer;

        public static implicit operator av_tree_enumerate_cmp_func(av_tree_enumerate_cmp func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
