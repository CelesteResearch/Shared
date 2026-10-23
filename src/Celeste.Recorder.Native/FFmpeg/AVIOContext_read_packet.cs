using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOContext_read_packet(void* opaque, byte* buf, int buf_size);
}
