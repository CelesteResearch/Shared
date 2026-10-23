using System;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Vulkan.Submission;

public sealed class Win32VulkanGraphicsSubmission : IVulkanGraphicsSubmission, IDisposable
{
    private readonly VulkanWindowGraphicsSubmission submission;

    public Win32VulkanGraphicsSubmission(ISourceHostWindowIO hostWindow, IntPtr nativeWindowHandle,
        uint physicalDeviceIndex = uint.MaxValue, uint apiVersion = 0)
    {
        submission = new VulkanWindowGraphicsSubmission(hostWindow, VulkanWindowSurfaceKind.Win32,
            nativeWindowHandle, physicalDeviceIndex: physicalDeviceIndex, apiVersion: apiVersion);
    }

    public ISourceGraphicsDeviceIOFactory DeviceFactory => submission.DeviceFactory;
    public ISourceHostDrawTransportIO DrawTransport => submission.DrawTransport;
    public void Pump() => submission.Pump();
    public IntPtr AcquireDevice() => submission.AcquireDevice();
    public void ReleaseDevice(IntPtr device) => submission.ReleaseDevice(device);
    public void PrepareDraw() => submission.PrepareDraw();
    public void SetPresentationInterval(SourcePresentInterval interval) => submission.SetPresentationInterval(interval);
    public IntPtr AcquireOutput(IntPtr device) => submission.AcquireOutput(device);
    public void Submit(IntPtr packet, bool waitForCompletion) => submission.Submit(packet, waitForCompletion);
    public void PresentCompleted() => submission.PresentCompleted();
    public void Dispose() => submission.Dispose();
}
