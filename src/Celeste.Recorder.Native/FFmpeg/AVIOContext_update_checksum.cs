using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate ulong AVIOContext_update_checksum(ulong checksum, byte* buf, uint size);
}
