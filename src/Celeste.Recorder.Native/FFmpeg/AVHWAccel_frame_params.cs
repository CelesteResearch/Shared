using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_frame_params(AVCodecContext* avctx, AVBufferRef* hw_frames_ctx);
}
