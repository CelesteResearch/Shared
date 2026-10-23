using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using System;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        public IntPtr GenColorRenderbuffer(int width, int height, SourceSurfaceFormat format,
            int sampleCount, IntPtr texture)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuCreateRenderbuffer(device,
                    unchecked((uint)width), unchecked((uint)height),
                    D3D11Conversions.SurfaceFormat(format), unchecked((uint)sampleCount),
                    0, texture, 0, out IntPtr renderbuffer));
            return renderbuffer;
        }

        public IntPtr GenDepthStencilRenderbuffer(int width, int height, SourceDepthFormat format,
            int sampleCount)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuCreateRenderbuffer(device,
                    unchecked((uint)width), unchecked((uint)height),
                    D3D11Conversions.DepthSurfaceFormat(format), unchecked((uint)sampleCount),
                    (int)format, IntPtr.Zero, 0, out IntPtr renderbuffer));
            return renderbuffer;
        }

        public void AddDisposeRenderbuffer(IntPtr renderbuffer)
            => Direct3D11GraphicsBindings.SourceGpuAddDisposeRenderbuffer(renderbuffer);

        public int GetMaxMultiSampleCount(SourceSurfaceFormat format, int preferredCount)
        {
            if (preferredCount == 0) return 0;

            // FNA3D D3D11_GetMaxMultiSampleCount: query the requested count, then shift right.
            do
            {
                Direct3D11GraphicsBindings.RequireSuccess(
                    Direct3D11GraphicsBindings.SourceGpuGetMultisampleQuality(device,
                        D3D11Conversions.SurfaceFormat(format),
                        unchecked((uint)preferredCount), out uint levels));
                if (levels > 0) break;
                preferredCount >>= 1;
            } while (preferredCount > 0);

            return preferredCount;
        }
    }
}
