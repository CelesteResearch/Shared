using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int
        AVInputFormat_read_seek(AVFormatContext* p0, int stream_index, long timestamp, int flags);
}
