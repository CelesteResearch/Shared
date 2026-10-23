using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void av_log_set_callback_callback(void* p0, int p1,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
        string p2, byte* p3);
}
