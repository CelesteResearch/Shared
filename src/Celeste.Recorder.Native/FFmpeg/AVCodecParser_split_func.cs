using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecParser_split_func
    {
        public nint Pointer;

        public static implicit operator AVCodecParser_split_func(AVCodecParser_split func)
        {
            return new AVCodecParser_split_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
