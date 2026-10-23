using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVIOContext_seek_func
    {
        public nint Pointer;

        public static implicit operator AVIOContext_seek_func(AVIOContext_seek func)
        {
            return new AVIOContext_seek_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
