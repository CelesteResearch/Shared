using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CelesteVulkanNativeDevice
    {
        public IntPtr instance, physicalDevice, device, graphicsQueue;
        public uint graphicsQueueFamily, apiVersion;
        public fixed uint enabledFeatures[55];
        public IntPtr getInstanceProcAddr, getDeviceProcAddr;
        public VulkanPortabilityFeatures portabilityFeatures;
    }
}
