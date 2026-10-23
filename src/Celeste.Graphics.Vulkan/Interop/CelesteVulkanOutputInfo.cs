using System.Runtime.InteropServices;

namespace Celeste.Graphics.Vulkan.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteVulkanOutputInfo
    {
        public ulong image;
        public int format;
        public uint width, height;
        public int incomingLayout, outgoingLayout;

        public uint incomingStage,
            incomingAccess,
            outgoingStage,
            outgoingAccess,
            incomingQueueFamily,
            outgoingQueueFamily;

        public ulong readySemaphore, completeSemaphore;
    }
}
