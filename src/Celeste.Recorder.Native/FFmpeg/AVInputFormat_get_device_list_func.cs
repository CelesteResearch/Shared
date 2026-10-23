using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVInputFormat_get_device_list_func
    {
        public nint Pointer;

        public static implicit operator AVInputFormat_get_device_list_func(AVInputFormat_get_device_list func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
