using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVPixelFormat AVCodecContext_get_format(AVCodecContext* s, AVPixelFormat* fmt);
}
