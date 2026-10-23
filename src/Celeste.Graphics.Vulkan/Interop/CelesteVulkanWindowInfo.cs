using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop;

[StructLayout(LayoutKind.Sequential)]
public struct CelesteVulkanWindowInfo
{
    public IntPtr windowHandle, instanceHandle;
    public uint apiVersion, physicalDeviceIndex, width, height, synchronized;
}
