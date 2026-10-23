using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_alloc_frame(AVCodecContext* avctx, AVFrame* frame);
}
