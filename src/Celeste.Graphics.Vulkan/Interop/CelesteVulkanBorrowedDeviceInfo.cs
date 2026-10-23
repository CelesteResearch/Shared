using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CelesteVulkanBorrowedDeviceInfo
    {
        public CelesteVulkanNativeDevice nativeDevice;
        public IntPtr queueContext;
        public delegate* unmanaged[Cdecl]<IntPtr, void> EnterQueue;
        public delegate* unmanaged[Cdecl]<IntPtr, void> LeaveQueue;
    }
}
