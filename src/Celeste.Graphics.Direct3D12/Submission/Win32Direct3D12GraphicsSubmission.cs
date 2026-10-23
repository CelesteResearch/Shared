using System;
using System.Threading;
using Celeste.Core.Framework.Startup;
using Celeste.Graphics.Direct3D12.Devices;
using Celeste.Graphics.Direct3D12.Interop;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Devices.Native.Submission;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Direct3D12.Submission
{
    /// <summary>Owns shared rendering and a swapchain attached to a caller-owned HWND.</summary>
    // ReSharper disable once UnusedType.Global
    public sealed unsafe class Win32Direct3D12GraphicsSubmission : INativeGraphicsSubmission, IDisposable
    {
        private readonly ISourceHostWindowIO _hostWindow;
        private readonly GraphicsOwnerDispatcher _dispatcher;
        private readonly Direct3D12GraphicsDeviceIOFactory _graphics;
        private IntPtr _window;
        private IntPtr _device;
        private uint _interval = 1;
        private bool _stopped;
        private bool _drawable;
        private bool _firstFrameReady;
        private bool _disposed;

        public Win32Direct3D12GraphicsSubmission(ISourceHostWindowIO hostWindow, IntPtr nativeWindowHandle)
        {
            _hostWindow = hostWindow ?? throw new ArgumentNullException(nameof(hostWindow));
            if (nativeWindowHandle == IntPtr.Zero)
                throw new ArgumentException("A real HWND is required.", nameof(nativeWindowHandle));
            _dispatcher = new(Thread.CurrentThread.ManagedThreadId);
            Direct3D12Native.GetDeviceApi();
            hostWindow.GetDrawableSize(out var width, out var height);
            _drawable = width > 0 && height > 0;
            var info = new CelesteDirect3D12WindowInfo
            {
                window = nativeWindowHandle,
                width = checked((uint)width),
                height = checked((uint)height),
                interval = _interval,
            };
            Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12CreateWindow(&info,
                out _window, out _device));
            _graphics = new(this, hostWindow.Handle);
        }

        // The host may reveal its initially hidden window here. Waiting for visible
        // DXGI presentation first would deadlock against DXGI_STATUS_OCCLUDED.
        // ReSharper disable once EventNeverSubscribedTo.Global
        public event Action FirstFrameReady;

        // ReSharper disable once EventNeverSubscribedTo.Global
        public event Action FramePresented;

        // ReSharper disable once UnusedMember.Global
        public ISourceGraphicsDeviceIOFactory DeviceFactory => _graphics;

        // ReSharper disable once UnusedMember.Global
        public ISourceHostDrawTransportIO DrawTransport => _graphics;

        // ReSharper disable once UnusedMember.Global
        public void Pump()
        {
            _dispatcher.Pump();
        }

        public IntPtr AcquireDevice()
        {
            return _device != IntPtr.Zero
                ? _device
                : throw new ObjectDisposedException(nameof(Win32Direct3D12GraphicsSubmission));
        }

        public void ReleaseDevice(IntPtr actualDevice)
        {
            RequireDevice(actualDevice);
            _dispatcher.Invoke(ReleaseOnOwner);
        }

        private void RequireDevice(IntPtr actualDevice)
        {
            if (actualDevice == IntPtr.Zero || actualDevice != _device)
                throw new ArgumentException("The device belongs to a different window.", nameof(actualDevice));
        }

        private void ReleaseOnOwner()
        {
            _dispatcher.RequireOwnerThread();
            if (_window == IntPtr.Zero) return;
            Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12DestroyWindow(_window));
            _window = _device = IntPtr.Zero;
        }

        public void PrepareDraw()
        {
            _dispatcher.RequireOwnerThread();
            _hostWindow.GetDrawableSize(out var width, out var height);
            _drawable = !_stopped && width > 0 && height > 0;
            Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12ResizeWindow(_window,
                _stopped ? 0 : checked((uint)width), _stopped ? 0 : checked((uint)height), _interval));
        }

        public void SetPresentationInterval(SourcePresentInterval value)
        {
            uint requested = value switch
            {
                SourcePresentInterval.Default or SourcePresentInterval.One => 1,
                SourcePresentInterval.Two => 2,
                SourcePresentInterval.Immediate => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            };
            _dispatcher.Invoke(() => _interval = requested);
        }

        public IntPtr AcquireOutput(IntPtr actualDevice)
        {
            RequireDevice(actualDevice);
            return _dispatcher.IsOwnerThread ? AcquireOnOwner() : AcquireDispatched();
        }

        private IntPtr AcquireDispatched()
        {
            var output = IntPtr.Zero;
            _dispatcher.Invoke(() => output = AcquireOnOwner());
            return output;
        }

        private IntPtr AcquireOnOwner()
        {
            Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12AcquireWindowOutput(_window,
                out var output));
            return output;
        }

        public void Submit(IntPtr packet, bool waitForCompletion)
        {
            if (_dispatcher.IsOwnerThread) SubmitOnOwner(packet, waitForCompletion);
            else SubmitDispatched(packet, waitForCompletion);
        }

        private void SubmitDispatched(IntPtr packet, bool waitForCompletion)
        {
            _dispatcher.Invoke(() => SubmitOnOwner(packet, waitForCompletion));
        }

        private void SubmitOnOwner(IntPtr packet, bool waitForCompletion)
        {
            Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12SubmitWindowPacket(
                _window, packet, waitForCompletion ? 1u : 0u));
        }

        public void PresentCompleted()
        {
            if (_dispatcher.IsOwnerThread) PresentOnOwner();
            else _dispatcher.Invoke(PresentOnOwner);
        }

        private void PresentOnOwner()
        {
            if (_drawable && !_stopped && !_firstFrameReady)
            {
                _firstFrameReady = true;
                FirstFrameReady?.Invoke();
            }

            Direct3D12Native.RequireSuccess(Direct3D12WindowNative.CelesteDirect3D12PresentWindow(_window,
                _stopped ? 0u : 1u, out var presented));
            if (presented != 0) FramePresented?.Invoke();
        }

        // ReSharper disable once UnusedMember.Global
        public void StopPresenting()
        {
            _dispatcher.Invoke(() => _stopped = true);
        }

        public void Dispose()
        {
            if (_disposed) return;
            ReleaseOnOwner();
            _dispatcher.Dispose();
            _disposed = true;
        }
    }
}
