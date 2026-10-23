using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_read_seek2(AVFormatContext* s, int stream_index, long min_ts, long ts,
        long max_ts, int flags);
}
