using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecContext_get_encode_buffer(AVCodecContext* s, AVPacket* pkt, int flags);
}
