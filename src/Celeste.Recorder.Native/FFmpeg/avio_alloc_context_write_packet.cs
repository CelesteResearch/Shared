using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int avio_alloc_context_write_packet(void* opaque, byte* buf, int buf_size);
}
