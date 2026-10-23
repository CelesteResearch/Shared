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
    public unsafe struct CelesteVulkanHostRecording
    {
        public IntPtr commandBuffer;
        public ulong submissionSerial;
    }
}
