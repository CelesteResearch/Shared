using System;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Content.Images;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Vulkan.Submission;

namespace Celeste.Graphics.Vulkan.Devices
{
    public sealed class VulkanGraphicsDeviceIOFactory(IVulkanGraphicsSubmission submission, IntPtr hostWindow)
        : ISourceGraphicsDeviceIOFactory, ISourceHostDrawTransportIO
    {
        private readonly IVulkanGraphicsSubmission submission =
            submission ?? throw new ArgumentNullException(nameof(submission));

        private readonly IntPtr hostWindow = hostWindow;
        private VulkanGraphicsDeviceIO actualDevice;

        public ISourceGraphicsDeviceIO CreateGraphicsDevice(SourceImageStreamProcess imageStreams)
        {
            if (actualDevice != null)
                throw new InvalidOperationException("The Vulkan device IO already exists.");
            var created = new VulkanGraphicsDeviceIO(imageStreams, submission, hostWindow);
            created.InitializeHostDevice();
            actualDevice = created;
            return created;
        }

        public void AbortUnsubmittedDraws()
        {
            actualDevice?.AbortUnsubmittedPhysicalPrefix();
        }

        public void BeginAcceptedSourceDraw()
        {
            if (actualDevice == null)
                throw new InvalidOperationException("The Vulkan device IO does not exist.");
            submission.PrepareDraw();
            actualDevice.BeforeDraw();
        }
    }
}
