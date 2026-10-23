using System.Runtime.InteropServices;

namespace FFmpeg
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AVFilter_formats
    {
        [FieldOffset(0)] public _query_func_func query_func;

        [FieldOffset(0)] public unsafe AVPixelFormat* pixels_list;

        [FieldOffset(0)] public unsafe AVSampleFormat* samples_list;

        [FieldOffset(0)] public AVPixelFormat pix_fmt;

        [FieldOffset(0)] public AVSampleFormat sample_fmt;
    }
}
