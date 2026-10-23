using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVBufferRef* av_buffer_pool_init_alloc(ulong size);
}
