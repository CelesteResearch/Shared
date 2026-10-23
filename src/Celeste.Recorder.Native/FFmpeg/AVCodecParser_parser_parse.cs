using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecParser_parser_parse(AVCodecParserContext* s, AVCodecContext* avctx,
        byte** poutbuf,
        int* poutbuf_size, byte* buf, int buf_size);
}
