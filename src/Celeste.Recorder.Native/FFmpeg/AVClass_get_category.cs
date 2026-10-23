using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate AVClassCategory AVClass_get_category(void* ctx);
}
