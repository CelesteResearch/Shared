using System;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteVulkanHostRecording
    {
        public IntPtr commandBuffer;
        public ulong submissionSerial;
    }
}
