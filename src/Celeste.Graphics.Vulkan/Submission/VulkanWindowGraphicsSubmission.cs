using System;
using System.Threading;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Threading;
using Celeste.Graphics.Vulkan.Devices;
using Celeste.Graphics.Vulkan.Interop;

namespace Celeste.Graphics.Vulkan.Submission;

// The host owns its native window, input and lifecycle. Presentation remains on the GPU.
public sealed unsafe class VulkanWindowGraphicsSubmission : IVulkanGraphicsSubmission, IDisposable
{
    private readonly ISourceHostWindowIO hostWindow;
    private readonly GraphicsOwnerDispatcher dispatcher;
    private readonly VulkanGraphicsDeviceIOFactory graphics;
    private IntPtr window;
    private IntPtr device;
    private uint synchronized = 1;
    private bool disposed;

    public VulkanWindowGraphicsSubmission(ISourceHostWindowIO hostWindow, VulkanWindowSurfaceKind surfaceKind,
        IntPtr nativeWindowHandle, IntPtr nativeDisplayHandle = default,
        uint physicalDeviceIndex = uint.MaxValue, uint apiVersion = 0)
    {
        this.hostWindow = hostWindow ?? throw new ArgumentNullException(nameof(hostWindow));
        if (nativeWindowHandle == IntPtr.Zero)
            throw new ArgumentException("A real native window is required.", nameof(nativeWindowHandle));
        dispatcher = new GraphicsOwnerDispatcher(Thread.CurrentThread.ManagedThreadId);
        VulkanNative.GetDeviceApi();
        hostWindow.GetDrawableSize(out int width, out int height);
        var info = new CelesteVulkanSurfaceWindowInfo
        {
            surfaceKind = (uint)surfaceKind,
            reserved = 0,
            windowHandle = nativeWindowHandle,
            displayHandle = nativeDisplayHandle,
            apiVersion = apiVersion,
            physicalDeviceIndex = physicalDeviceIndex,
            width = checked((uint)width),
            height = checked((uint)height),
            synchronized = synchronized
        };
        VulkanNative.RequireSuccess(VulkanWindowNative.CelesteVulkanCreateSurfaceWindow(&info, out window, out device));
        graphics = new VulkanGraphicsDeviceIOFactory(this, hostWindow.Handle);
    }

    public ISourceGraphicsDeviceIOFactory DeviceFactory => graphics;
    public ISourceHostDrawTransportIO DrawTransport => graphics;
    public void Pump() => dispatcher.Pump();

    public IntPtr AcquireDevice() => device != IntPtr.Zero
        ? device
        : throw new ObjectDisposedException(nameof(VulkanWindowGraphicsSubmission));

    public void ReleaseDevice(IntPtr actualDevice)
    {
        if (actualDevice != device)
            throw new ArgumentException("This device belongs to a different window.", nameof(actualDevice));
        if (dispatcher.IsOwnerThread) ReleaseOnOwner();
        else dispatcher.Invoke(ReleaseOnOwner);
    }

    private void ReleaseOnOwner()
    {
        dispatcher.RequireOwnerThread();
        if (window == IntPtr.Zero) return;
        VulkanNative.RequireSuccess(VulkanWindowNative.CelesteVulkanDestroyWindow(window));
        window = device = IntPtr.Zero;
    }

    public void PrepareDraw()
    {
        dispatcher.RequireOwnerThread();
        hostWindow.GetDrawableSize(out int width, out int height);
        VulkanNative.RequireSuccess(VulkanWindowNative.CelesteVulkanResizeWindow(window,
            checked((uint)width), checked((uint)height), synchronized));
    }

    public void SetPresentationInterval(SourcePresentInterval interval)
    {
        // FIFO implements one refresh; silently treating Two as One would change
        // the source timing contract. Display-timing support can add Two later.
        if (interval == SourcePresentInterval.Two)
            throw new NotSupportedException("Two-refresh Vulkan presentation is not implemented.");
        if (interval != SourcePresentInterval.Default && interval != SourcePresentInterval.One &&
            interval != SourcePresentInterval.Immediate)
            throw new ArgumentOutOfRangeException(nameof(interval));
        synchronized = interval == SourcePresentInterval.Immediate ? 0u : 1u;
    }

    public IntPtr AcquireOutput(IntPtr actualDevice)
    {
        if (actualDevice != device)
            throw new ArgumentException("This device belongs to a different window.", nameof(actualDevice));
        if (dispatcher.IsOwnerThread) return AcquireOnOwner();
        IntPtr output = IntPtr.Zero;
        dispatcher.Invoke(() => output = AcquireOnOwner());
        return output;
    }

    private IntPtr AcquireOnOwner()
    {
        VulkanNative.RequireSuccess(VulkanWindowNative.CelesteVulkanAcquireWindowOutput(window, out IntPtr output));
        return output;
    }

    public void Submit(IntPtr packet, bool waitForCompletion)
    {
        if (dispatcher.IsOwnerThread) SubmitOnOwner(packet, waitForCompletion);
        else dispatcher.Invoke(() => SubmitOnOwner(packet, waitForCompletion));
    }

    private void SubmitOnOwner(IntPtr packet, bool waitForCompletion)
        => VulkanNative.RequireSuccess(
            VulkanWindowNative.CelesteVulkanSubmitWindowPacket(window, packet, waitForCompletion ? 1u : 0u));

    public void PresentCompleted()
    {
        if (dispatcher.IsOwnerThread) PresentOnOwner();
        else dispatcher.Invoke(PresentOnOwner);
    }

    private void PresentOnOwner()
        => VulkanNative.RequireSuccess(VulkanWindowNative.CelesteVulkanPresentWindow(window));

    public void Dispose()
    {
        if (disposed) return;
        ReleaseOnOwner();
        dispatcher.Dispose();
        disposed = true;
    }
}
