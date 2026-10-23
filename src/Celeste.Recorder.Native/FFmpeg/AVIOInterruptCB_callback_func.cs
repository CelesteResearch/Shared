using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    // ReSharper disable once InconsistentNaming
    public struct AVIOInterruptCB_callback_func
    {
        public nint Pointer;

        public static implicit operator AVIOInterruptCB_callback_func(AVIOInterruptCB_callback func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
