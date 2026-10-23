using System;
using System.Runtime.InteropServices;
using Celeste.Graphics.Vulkan.Interop;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Vulkan.Offscreen;

public sealed unsafe class VulkanOffscreenGraphicsBackend : NativeOffscreenGraphicsBackend
{
    public VulkanOffscreenGraphicsBackend(GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation)
        : base(VulkanNative.GetDeviceApi(), "spirv", dispatcher, presentation)
    {
    }

    protected override IntPtr CreateOwnedDevice()
    {
        var info = new CelesteVulkanOwnedDeviceInfo();
        VulkanNative.RequireSuccess(VulkanNative.CelesteVulkanCreateOwnedDevice(&info, out IntPtr device));
        return device;
    }

    protected override IntPtr AcquireTextureOutput(IntPtr actualDevice, IntPtr outputTexture)
    {
        VulkanNative.RequireSuccess(CelesteVulkanAcquireTextureOutput(actualDevice, outputTexture, out IntPtr output));
        return output;
    }

    [DllImport("CelesteGraphicsVulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    private static extern int CelesteVulkanAcquireTextureOutput(IntPtr device, IntPtr texture, out IntPtr output);
}
