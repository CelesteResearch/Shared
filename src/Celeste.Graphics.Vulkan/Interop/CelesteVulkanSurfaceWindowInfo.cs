using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct CelesteVulkanSurfaceWindowInfo
    {
        public uint surfaceKind, reserved;
        public IntPtr windowHandle, displayHandle;
        public uint apiVersion, physicalDeviceIndex, width, height, synchronized;
    }
}
