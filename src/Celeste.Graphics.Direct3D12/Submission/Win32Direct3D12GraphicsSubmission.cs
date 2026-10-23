using System;
using System.Threading;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Direct3D12.Devices;
using Celeste.Graphics.Direct3D12.Interop;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Devices.Native.Submission;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Direct3D12.Submission;

/// <summary>Owns shared rendering and a swapchain attached to a caller-owned HWND.</summary>
public sealed unsafe class Win32Direct3D12GraphicsSubmission : INativeGraphicsSubmission, IDisposable
{
    private readonly ISourceHostWindowIO hostWindow;
    private readonly GraphicsOwnerDispatcher dispatcher;
    private readonly Direct3D12GraphicsDeviceIOFactory graphics;
    private IntPtr window;
    private IntPtr device;
    private uint interval = 1;
    private bool stopped;
    private bool drawable;
    private bool firstFrameReady;
    private bool disposed;

    public Win32Direct3D12GraphicsSubmission(ISourceHostWindowIO hostWindow, IntPtr nativeWindowHandle)
    {
        this.hostWindow = hostWindow ?? throw new ArgumentNullException(nameof(hostWindow));
        if (nativeWindowHandle == IntPtr.Zero)
            throw new ArgumentException("A real HWND is required.", nameof(nativeWindowHandle));
        dispatcher = new GraphicsOwnerDispatcher(Thread.CurrentThread.ManagedThreadId);
        Direct3D12Native.GetDeviceApi();
        hostWindow.GetDrawableSize(out int width, out int height);
        drawable = width > 0 && height > 0;
        var info = new CelesteDirect3D12WindowInfo
        {
            window = nativeWindowHandle,
            width = checked((uint)width),
            height = checked((uint)height),
            interval = interval
        };
        Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12CreateWindow(&info,
            out window, out device));
        graphics = new Direct3D12GraphicsDeviceIOFactory(this, hostWindow.Handle);
    }

    // The host may reveal its initially hidden window here. Waiting for visible
    // DXGI presentation first would deadlock against DXGI_STATUS_OCCLUDED.
    public event Action FirstFrameReady;
    public event Action FramePresented;
    public ISourceGraphicsDeviceIOFactory DeviceFactory => graphics;
    public ISourceHostDrawTransportIO DrawTransport => graphics;
    public void Pump() => dispatcher.Pump();

    public IntPtr AcquireDevice() => device != IntPtr.Zero
        ? device
        : throw new ObjectDisposedException(nameof(Win32Direct3D12GraphicsSubmission));

    public void ReleaseDevice(IntPtr actualDevice)
    {
        RequireDevice(actualDevice);
        dispatcher.Invoke(ReleaseOnOwner);
    }

    private void RequireDevice(IntPtr actualDevice)
    {
        if (actualDevice == IntPtr.Zero || actualDevice != device)
            throw new ArgumentException("The device belongs to a different window.", nameof(actualDevice));
    }

    private void ReleaseOnOwner()
    {
        dispatcher.RequireOwnerThread();
        if (window == IntPtr.Zero) return;
        Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12DestroyWindow(window));
        window = device = IntPtr.Zero;
    }

    public void PrepareDraw()
    {
        dispatcher.RequireOwnerThread();
        hostWindow.GetDrawableSize(out int width, out int height);
        drawable = !stopped && width > 0 && height > 0;
        Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12ResizeWindow(window,
            stopped ? 0 : checked((uint)width), stopped ? 0 : checked((uint)height), interval));
    }

    public void SetPresentationInterval(SourcePresentInterval value)
    {
        uint requested = value switch
        {
            SourcePresentInterval.Default or SourcePresentInterval.One => 1,
            SourcePresentInterval.Two => 2,
            SourcePresentInterval.Immediate => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(value))
        };
        dispatcher.Invoke(() => interval = requested);
    }

    public IntPtr AcquireOutput(IntPtr actualDevice)
    {
        RequireDevice(actualDevice);
        if (dispatcher.IsOwnerThread) return AcquireOnOwner();
        return AcquireDispatched();
    }

    private IntPtr AcquireDispatched()
    {
        IntPtr output = IntPtr.Zero;
        dispatcher.Invoke(() => output = AcquireOnOwner());
        return output;
    }

    private IntPtr AcquireOnOwner()
    {
        Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12AcquireWindowOutput(window,
            out IntPtr output));
        return output;
    }

    public void Submit(IntPtr packet, bool waitForCompletion)
    {
        if (dispatcher.IsOwnerThread) SubmitOnOwner(packet, waitForCompletion);
        else SubmitDispatched(packet, waitForCompletion);
    }

    private void SubmitDispatched(IntPtr packet, bool waitForCompletion) =>
        dispatcher.Invoke(() => SubmitOnOwner(packet, waitForCompletion));

    private void SubmitOnOwner(IntPtr packet, bool waitForCompletion) =>
        Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12SubmitWindowPacket(
            window, packet, waitForCompletion ? 1u : 0u));

    public void PresentCompleted()
    {
        if (dispatcher.IsOwnerThread) PresentOnOwner();
        else dispatcher.Invoke(PresentOnOwner);
    }

    private void PresentOnOwner()
    {
        if (drawable && !stopped && !firstFrameReady)
        {
            firstFrameReady = true;
            FirstFrameReady?.Invoke();
        }

        Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12PresentWindow(window,
            stopped ? 0u : 1u, out uint presented));
        if (presented != 0) FramePresented?.Invoke();
    }

    public void StopPresenting() => dispatcher.Invoke(() => stopped = true);

    public void Dispose()
    {
        if (disposed) return;
        ReleaseOnOwner();
        dispatcher.Dispose();
        disposed = true;
    }
}
