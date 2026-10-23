using System;
using System.Runtime.InteropServices;

namespace FFmpeg
{
    public struct AVCodecParser_parser_parse_func
    {
        public nint Pointer;

        public static implicit operator AVCodecParser_parser_parse_func(AVCodecParser_parser_parse func)
        {
            return new AVCodecParser_parser_parse_func
            {
                Pointer = ((func == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func))
            };
        }
    }
}
