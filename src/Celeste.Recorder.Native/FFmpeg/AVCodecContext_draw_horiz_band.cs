using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void AVCodecContext_draw_horiz_band(AVCodecContext* s, AVFrame* src, ref int8 offset, int y,
        int type, int height);
}
