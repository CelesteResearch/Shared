using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVHWFramesContext_free_func
    {
        public nint Pointer;

        public static implicit operator AVHWFramesContext_free_func(AVHWFramesContext_free func)
        {
            return new AVHWFramesContext_free_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
