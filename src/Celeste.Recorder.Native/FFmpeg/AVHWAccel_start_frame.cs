using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_start_frame(AVCodecContext* avctx, byte* buf, uint buf_size);
}
