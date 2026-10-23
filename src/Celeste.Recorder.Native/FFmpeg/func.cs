using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int func(AVFilterContext* ctx, void* arg, int jobnr, int nb_jobs);
}
