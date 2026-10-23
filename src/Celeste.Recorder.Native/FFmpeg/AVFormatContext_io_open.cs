using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVFormatContext_io_open(AVFormatContext* s, AVIOContext** pb,
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "FFmpeg.Util.UTF8Marshaler")]
        string url, int flags,
        AVDictionary** options);
}
