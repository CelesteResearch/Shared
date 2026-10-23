using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int
        AVFormatContext_control_message_cb(AVFormatContext* s, int type, void* data, ulong data_size);
}
