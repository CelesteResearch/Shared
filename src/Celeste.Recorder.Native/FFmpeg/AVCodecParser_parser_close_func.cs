using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecParser_parser_close_func
    {
        public nint Pointer;

        public static implicit operator AVCodecParser_parser_close_func(AVCodecParser_parser_close func)
        {
            return new()
            {
                Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func),
            };
        }
    }
}
