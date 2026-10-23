using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVIOContext_update_checksum_func
    {
        public nint Pointer;

        public static implicit operator AVIOContext_update_checksum_func(AVIOContext_update_checksum func)
        {
            return new AVIOContext_update_checksum_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
