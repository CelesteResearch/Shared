using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate long avio_alloc_context_seek(void* opaque, long offset, int whence);
}
