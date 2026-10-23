using System;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Devices
{
    /// <summary>Owns one independent D3D11 context across source game lifetimes.</summary>
    public sealed class Direct3D11GraphicsContext : IDisposable
    {
        private IntPtr context;

        public Direct3D11GraphicsContext()
        {
            context = Direct3D11GraphicsBindings.SourceGpuCreateDeviceContext();
            if (context == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
        }

        public ulong Generation => Direct3D11GraphicsBindings.SourceGpuDeviceGeneration(context);

        public IntPtr AcquireDevice()
        {
            if (context == IntPtr.Zero) throw new ObjectDisposedException(nameof(Direct3D11GraphicsContext));
            IntPtr device = Direct3D11GraphicsBindings.SourceGpuEnsureSourceDevice(context);
            if (device == IntPtr.Zero) Direct3D11GraphicsBindings.RequireSuccess(0);
            return device;
        }

        public void Dispose()
        {
            if (context == IntPtr.Zero) return;
            // Clear retained GPU resources before releasing the context owner's loan.
            Direct3D11GraphicsBindings.SourceGpuDestroySourceDevice(context);
            Direct3D11GraphicsBindings.SourceGpuReleaseDeviceContext(context);
            context = IntPtr.Zero;
        }
    }
}
