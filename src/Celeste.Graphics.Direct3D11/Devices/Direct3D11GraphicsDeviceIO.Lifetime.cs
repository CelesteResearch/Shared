using System;
using System.Text;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO : ISourceGraphicsDeviceIO, ISourceTextureIO
    {
        public ISourceTextureIO TextureIO => this;

        public void Image_Free(IntPtr pointer)
        {
            ImageStreams.FreeImage(pointer);
        }

        public IntPtr CreateDevice(ref SourceNativePresentationParameters parameters, byte debugMode)
        {
            if (debugMode != 0)
                throw new NotSupportedException(
                    "The physical device cannot be recreated with a different debug layer.");
            if (parameters.deviceWindowHandle != IntPtr.Zero && parameters.deviceWindowHandle != hostWindow)
                throw new NotSupportedException(
                    "A second source device window is not available in this host graphics transport.");
            AdoptDevice(submission.AcquireDevice());
            var owned = BorrowWriteScope();
            try
            {
                var scaleNearest = hints.GetHintBoolean("FNA3D_BACKBUFFER_SCALE_NEAREST", false) ? 1u : 0u;
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuInitializeBackbuffer(device,
                        unchecked((uint)parameters.backBufferWidth), unchecked((uint)parameters.backBufferHeight),
                        D3D11Conversions.SurfaceFormat(parameters.backBufferFormat),
                        D3D11Conversions.TextureBytesPerBlock[(int)parameters.backBufferFormat],
                        unchecked((uint)parameters.multiSampleCount),
                        D3D11Conversions.DepthSurfaceFormat(parameters.depthStencilFormat),
                        (int)parameters.depthStencilFormat, (int)parameters.backBufferFormat, scaleNearest));
                submission.SetPresentationSyncInterval(
                    Direct3D11GraphicsBindings.SourceGpuSetPresentationInterval(device,
                        (int)parameters.presentationInterval));
            }
            finally
            {
                CompleteWriteScope(owned);
            }

            return device;
        }

        public IntPtr Allocate(int bytes)
        {
            return Direct3D11GraphicsBindings.SourceGpuAllocate(unchecked((uint)bytes));
        }

        public void Free(IntPtr pointer)
        {
            Direct3D11GraphicsBindings.SourceGpuFree(pointer);
        }

        public void AddDisposeVertexBuffer(IntPtr buffer)
        {
            SourceFrameDiagnostics.Current?.RecordLoadResource(false, true);
            if (device == IntPtr.Zero)
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuDisposeVertexBuffer(device, buffer));
                return;
            }

            var owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuDisposeVertexBuffer(device, buffer));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void AddDisposeIndexBuffer(IntPtr buffer)
        {
            SourceFrameDiagnostics.Current?.RecordLoadResource(false, true);
            if (device == IntPtr.Zero)
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuDisposeIndexBuffer(device, buffer));
                return;
            }

            var owned = BorrowWriteScope();
            try
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuDisposeIndexBuffer(device, buffer));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetTextureName(IntPtr texture, string name)
        {
            var utf8 = Encoding.UTF8.GetBytes(name);
            fixed (byte* pointer = utf8)
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuSetTextureName(texture,
                        pointer, unchecked((uint)utf8.Length)));
            }
        }

        public void DestroyDevice()
        {
            if (device == IntPtr.Zero) return;
            Direct3D11GraphicsBindings.SourceGpuDestroySourceDevice(device);
            Direct3D11GraphicsBindings.SourceGpuReleaseDeviceContext(device);
            device = IntPtr.Zero;
        }

        public void GetBackbufferSize(out int width, out int height)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuGetBackbufferDescription(device,
                    out var nativeWidth, out var nativeHeight, out _, out _, out _));
            width = unchecked((int)nativeWidth);
            height = unchecked((int)nativeHeight);
        }

        public SourceSurfaceFormat GetBackbufferSurfaceFormat()
        {
            return (SourceSurfaceFormat)Direct3D11GraphicsBindings.SourceGpuGetBackbufferSurfaceFormat(device);
        }
    }
}
