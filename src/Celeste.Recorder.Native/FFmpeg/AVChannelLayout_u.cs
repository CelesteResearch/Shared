using System.Runtime.InteropServices;

namespace FFmpeg
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AVChannelLayout_u
    {
        [FieldOffset(0)] public ulong mask;

        [FieldOffset(0)] public unsafe AVChannelCustom* map;
    }
}
