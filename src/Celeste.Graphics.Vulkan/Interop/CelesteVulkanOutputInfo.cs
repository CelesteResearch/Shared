using System;
using System.Runtime.InteropServices;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Vulkan.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CelesteVulkanOutputInfo
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
