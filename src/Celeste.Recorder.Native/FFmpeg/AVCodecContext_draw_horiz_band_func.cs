using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecContext_draw_horiz_band_func
    {
        public nint Pointer;

        public static implicit operator AVCodecContext_draw_horiz_band_func(AVCodecContext_draw_horiz_band func)
        {
            return new AVCodecContext_draw_horiz_band_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
