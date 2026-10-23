using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate long AVIOContext_read_seek(void* opaque, int stream_index, long timestamp, int flags);
}
