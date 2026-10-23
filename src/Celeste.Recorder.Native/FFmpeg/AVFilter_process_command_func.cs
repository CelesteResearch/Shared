using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVFilter_process_command_func
    {
        public nint Pointer;

        public static implicit operator AVFilter_process_command_func(AVFilter_process_command func)
        {
            return new AVFilter_process_command_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
