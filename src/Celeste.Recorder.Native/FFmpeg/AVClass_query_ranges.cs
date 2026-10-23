using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVClass_query_ranges(AVOptionRanges** p0, void* obj,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
        string key, int flags);
}
