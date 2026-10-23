using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CelesteVulkanOwnedDeviceInfo
    {
        public uint apiVersion, physicalDeviceIndex, instanceExtensionCount;
        public byte** instanceExtensions;
        public uint deviceExtensionCount;
        public byte** deviceExtensions;
        public void* deviceFeatures;
        public void* deviceCreateNext;
        public void* instanceCreateNext;
    }
}
