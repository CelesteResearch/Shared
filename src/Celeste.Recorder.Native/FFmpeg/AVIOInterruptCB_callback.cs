using System.Runtime.InteropServices;

namespace FFmpeg
{
    // ReSharper disable once InconsistentNaming
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVIOInterruptCB_callback(void* p0);
}
