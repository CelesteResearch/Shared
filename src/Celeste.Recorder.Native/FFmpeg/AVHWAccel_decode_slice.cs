using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVHWAccel_decode_slice(AVCodecContext* avctx, byte* buf, uint buf_size);
}
