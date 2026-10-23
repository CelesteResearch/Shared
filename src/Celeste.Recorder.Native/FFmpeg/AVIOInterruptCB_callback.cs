using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOInterruptCB_callback(void* p0);
}
