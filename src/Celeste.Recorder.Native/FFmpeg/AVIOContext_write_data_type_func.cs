using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVIOContext_write_data_type_func
    {
        public nint Pointer;

        public static implicit operator AVIOContext_write_data_type_func(AVIOContext_write_data_type func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
