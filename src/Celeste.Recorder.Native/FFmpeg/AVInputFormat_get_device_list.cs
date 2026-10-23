using System.Runtime.InteropServices;

namespace FFmpeg
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int AVInputFormat_get_device_list(AVFormatContext* s, AVDeviceInfoList* device_list);
}
