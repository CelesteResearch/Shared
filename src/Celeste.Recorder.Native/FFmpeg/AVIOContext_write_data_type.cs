using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOContext_write_data_type(void* opaque, byte* buf, int buf_size,
        AVIODataMarkerType type,
        long time);
}
