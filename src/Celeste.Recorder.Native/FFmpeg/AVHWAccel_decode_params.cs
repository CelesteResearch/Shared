using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_decode_params(AVCodecContext* avctx, int type, byte* buf, uint buf_size);
}
