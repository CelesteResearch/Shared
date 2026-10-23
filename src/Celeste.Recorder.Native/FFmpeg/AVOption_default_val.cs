using System.Runtime.InteropServices;

namespace FFmpeg
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AVOption_default_val
    {
        [FieldOffset(0)] public long i64;

        [FieldOffset(0)] public double dbl;

        [FieldOffset(0)] public unsafe byte* str;

        [FieldOffset(0)] public AVRational q;
    }
}
