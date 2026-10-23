using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO : ISourceGraphicsDeviceTargetIO
    {
        public void SetViewport(ref CameraViewport viewport)
        {
            var owned = BorrowWriteScope();
            try
            {
                var native = new D3D11Viewport
                {
                    TopLeftX = viewport.X, TopLeftY = viewport.Y,
                    Width = viewport.Width, Height = viewport.Height,
                    MinDepth = viewport.MinDepth, MaxDepth = viewport.MaxDepth,
                };
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordViewport(device, ref native));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetScissorRect(ref IntRect rectangle)
        {
            var owned = BorrowWriteScope();
            try
            {
                var native = new D3D11Rect
                {
                    Left = rectangle.X, Top = rectangle.Y,
                    Right = unchecked(rectangle.X + rectangle.Width),
                    Bottom = unchecked(rectangle.Y + rectangle.Height),
                };
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordScissor(device, ref native));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public SourceDepthFormat GetBackbufferDepthFormat()
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuGetBackbufferDescription(device,
                    out _, out _, out _, out _, out var depthFormat));
            return (SourceDepthFormat)depthFormat;
        }

        public void Clear(SourceClearOptions options, ref Vector4 color, float depth, int stencil)
        {
            var owned = BorrowWriteScope();
            try
            {
                var rgba = stackalloc float[4];
                rgba[0] = color.X;
                rgba[1] = color.Y;
                rgba[2] = color.Z;
                rgba[3] = color.W;
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuRecordClearCurrent(device, rgba,
                        (options & SourceClearOptions.Target) != 0 ? 1u : 0u,
                        (options & SourceClearOptions.DepthBuffer) != 0 ? 1u : 0u,
                        (options & SourceClearOptions.Stencil) != 0 ? 1u : 0u,
                        depth, unchecked((byte)stencil)));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetRenderTargets(SourceNativeRenderTargetBinding* targets, int count,
            IntPtr depthStencilBuffer, SourceDepthFormat depthFormat, byte preserve)
        {
            var owned = BorrowWriteScope();
            try
            {
                // SourceGraphicsDevice already performed preservation, depth and discard decisions.
                // The native aggregate retains the real textures/views and cube face, not a managed table.
                Direct3D11GraphicsBindings.RequireSuccess(count <= 0
                    ? Direct3D11GraphicsBindings.SourceGpuRecordBackbufferTargets(device)
                    : Direct3D11GraphicsBindings.SourceGpuRecordSourceTargets(device, targets,
                        unchecked((uint)count), depthStencilBuffer));
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }

        public void SetRenderTargets(IntPtr targets, int count,
            IntPtr depthStencilBuffer, SourceDepthFormat depthFormat, byte preserve)
        {
            SetRenderTargets((SourceNativeRenderTargetBinding*)targets, count,
                depthStencilBuffer, depthFormat, preserve);
        }

        public void ResolveTarget(ref SourceNativeRenderTargetBinding binding)
        {
            var owned = BorrowWriteScope();
            try
            {
                fixed (SourceNativeRenderTargetBinding* pointer = &binding)
                {
                    Direct3D11GraphicsBindings.RequireSuccess(
                        Direct3D11GraphicsBindings.SourceGpuRecordSourceResolve(pointer));
                }
            }
            finally
            {
                CompleteWriteScope(owned);
            }
        }
    }
}
