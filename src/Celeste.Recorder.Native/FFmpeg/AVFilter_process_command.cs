using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFilter_process_command(AVFilterContext* p0,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
        string cmd,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
        string arg, byte* res,
        int res_len, int flags);
}
