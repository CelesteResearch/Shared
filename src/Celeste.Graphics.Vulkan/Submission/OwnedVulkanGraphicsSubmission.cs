using System;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Vulkan.Interop;

namespace Celeste.Graphics.Vulkan.Submission
{
    public sealed unsafe class OwnedVulkanGraphicsSubmission : IVulkanGraphicsSubmission, IDisposable
    {
        private readonly CelesteGraphicsDeviceApi* api;
        private readonly IVulkanGraphicsPresentation presentation;
        private IntPtr device;

        public OwnedVulkanGraphicsSubmission(CelesteVulkanOwnedDeviceInfo info,
            IVulkanGraphicsPresentation presentation)
        {
            this.presentation = presentation ?? throw new ArgumentNullException(nameof(presentation));
            api = VulkanNative.GetDeviceApi();
            VulkanNative.RequireSuccess(VulkanNative.CelesteVulkanCreateOwnedDevice(&info, out device));
        }

        public IntPtr AcquireDevice()
        {
            return device != IntPtr.Zero
                ? device
                : throw new ObjectDisposedException(nameof(OwnedVulkanGraphicsSubmission));
        }

        public void ReleaseDevice(IntPtr actualDevice)
        {
            if (actualDevice != device)
                throw new ArgumentException("The device belongs to a different Vulkan submission.",
                    nameof(actualDevice));
            Dispose();
        }

        public void PrepareDraw()
        {
            presentation.PrepareDraw();
        }

        public void SetPresentationInterval(SourcePresentInterval interval)
        {
            presentation.SetPresentationInterval(interval);
        }

        public IntPtr AcquireOutput(IntPtr actualDevice)
        {
            return presentation.AcquireOutput(actualDevice);
        }

        public void PresentCompleted()
        {
            presentation.PresentCompleted();
        }

        public void Submit(IntPtr packet, bool waitForCompletion)
        {
            IntPtr submitted;
            VulkanNative.RequireSuccess(api->Submit(packet, &submitted));
            try
            {
                if (waitForCompletion) VulkanNative.RequireSuccess(api->Wait(submitted));
            }
            finally
            {
                api->ReleaseSubmission(submitted);
            }
        }

        public void Dispose()
        {
            if (device == IntPtr.Zero) return;
            VulkanNative.RequireSuccess(api->DestroyDevice(device));
            device = IntPtr.Zero;
        }
    }
}
