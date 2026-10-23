using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVIOInterruptCB_callback_func
    {
        public nint Pointer;

        public static implicit operator AVIOInterruptCB_callback_func(AVIOInterruptCB_callback func)
        {
            return new AVIOInterruptCB_callback_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
