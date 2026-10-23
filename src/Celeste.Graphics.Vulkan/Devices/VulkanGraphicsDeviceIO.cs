using System;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Devices.Native;
using Celeste.Graphics.Vulkan.Interop;
using Celeste.Graphics.Vulkan.Submission;

namespace Celeste.Graphics.Vulkan.Devices
{
    public sealed unsafe class VulkanGraphicsDeviceIO(
        SourceImageStreamProcess imageStreams,
        IVulkanGraphicsSubmission submission,
        IntPtr hostWindow)
        : NativeGraphicsDeviceIO(imageStreams, submission, hostWindow, VulkanNative.GetDeviceApi(), "spirv")
    {
    }
}
