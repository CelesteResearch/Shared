using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;
using Celeste.Graphics.Vulkan.Interop;

namespace Celeste.Graphics.Vulkan.Offscreen
{
    public sealed unsafe class VulkanOffscreenGraphicsBackend(
        GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation)
        : NativeOffscreenGraphicsBackend(VulkanNative.GetDeviceApi(), "spirv", dispatcher, presentation)
    {
        protected override IntPtr CreateOwnedDevice()
        {
            var info = new CelesteVulkanOwnedDeviceInfo();
            VulkanNative.RequireSuccess(VulkanNative.CelesteVulkanCreateOwnedDevice(&info, out var device));
            return device;
        }

        protected override IntPtr AcquireTextureOutput(IntPtr actualDevice, IntPtr outputTexture)
        {
            VulkanNative.RequireSuccess(CelesteVulkanAcquireTextureOutput(actualDevice, outputTexture, out var output));
            return output;
        }

        [DllImport("CelesteGraphicsVulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        private static extern int CelesteVulkanAcquireTextureOutput(IntPtr device, IntPtr texture, out IntPtr output);
    }
}
