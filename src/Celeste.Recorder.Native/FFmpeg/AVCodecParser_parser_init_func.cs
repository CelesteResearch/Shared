using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecParser_parser_init_func
    {
        public nint Pointer;

        public static implicit operator AVCodecParser_parser_init_func(AVCodecParser_parser_init func)
        {
            return new AVCodecParser_parser_init_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
