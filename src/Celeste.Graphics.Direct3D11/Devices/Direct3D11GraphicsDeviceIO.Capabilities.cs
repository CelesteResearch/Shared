using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed partial class Direct3D11GraphicsDeviceIO
    {
        // These are the literal capability results of the borrowed D3D11 backend, not profile defaults.
        public byte SupportsNoOverwrite()
        {
            return 1;
        }

        public byte SupportsHardwareInstancing()
        {
            return 1;
        }

        public void GetMaxTextureSlots(out int fragmentSlots, out int vertexSlots)
        {
            fragmentSlots = 16;
            vertexSlots = 16;
        }

        public byte SupportsDXT1()
        {
            return SupportsTextureDimensions(SourceSurfaceFormat.Dxt1);
        }

        public byte SupportsS3TC()
        {
            return SupportsTextureDimensions(SourceSurfaceFormat.Dxt5);
        }

        private byte SupportsTextureDimensions(SourceSurfaceFormat format)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuGetFormatSupport(device,
                    D3D11Conversions.SurfaceFormat(format), out var support));
            return (support & (32u | 64u | 128u)) != 0 ? (byte)1 : (byte)0;
        }

        public byte SupportsSRGBRenderTargets()
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuGetFormatSupport(device,
                    D3D11Conversions.SurfaceFormat(SourceSurfaceFormat.ColorSrgbEXT), out var support));
            return (support & 16384u) != 0 ? (byte)1 : (byte)0;
        }
    }
}
