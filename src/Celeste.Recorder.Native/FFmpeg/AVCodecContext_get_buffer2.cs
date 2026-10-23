using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecContext_get_buffer2(AVCodecContext* s, AVFrame* frame, int flags);
}
