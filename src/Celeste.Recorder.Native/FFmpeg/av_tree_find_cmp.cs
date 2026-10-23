using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int av_tree_find_cmp(void* key, void* b);
}
