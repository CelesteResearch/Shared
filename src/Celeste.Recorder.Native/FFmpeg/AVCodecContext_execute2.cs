using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVCodecContext_execute2(AVCodecContext* c, func_func func, void* arg2, int* ret,
        int count);
}
