using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVCodecParser_parser_close(AVCodecParserContext* s);
}
