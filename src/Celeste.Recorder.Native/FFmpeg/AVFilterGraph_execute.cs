using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int
        AVFilterGraph_execute(AVFilterContext* ctx, func_func func, void* arg, int* ret, int nb_jobs);
}
