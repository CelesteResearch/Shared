using Celeste.Graphics.Direct3D11.Interop.Descriptors;
using Celeste.Graphics.Direct3D11.Interop;
using Celeste.Graphics.Direct3D11.Submission;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed unsafe partial class Direct3D11GraphicsDeviceIO
    {
        // These are the literal capability results of the borrowed D3D11 backend, not profile defaults.
        public byte SupportsNoOverwrite() => 1;
        public byte SupportsHardwareInstancing() => 1;

        public void GetMaxTextureSlots(out int fragmentSlots, out int vertexSlots)
        {
            fragmentSlots = 16;
            vertexSlots = 16;
        }

        public byte SupportsDXT1() => SupportsTextureDimensions(SourceSurfaceFormat.Dxt1);
        public byte SupportsS3TC() => SupportsTextureDimensions(SourceSurfaceFormat.Dxt5);

        private byte SupportsTextureDimensions(SourceSurfaceFormat format)
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuGetFormatSupport(device,
                    D3D11Conversions.SurfaceFormat(format), out uint support));
            return (support & (32u | 64u | 128u)) != 0 ? (byte)1 : (byte)0;
        }

        public byte SupportsSRGBRenderTargets()
        {
            Direct3D11GraphicsBindings.RequireSuccess(
                Direct3D11GraphicsBindings.SourceGpuGetFormatSupport(device,
                    D3D11Conversions.SurfaceFormat(SourceSurfaceFormat.ColorSrgbEXT), out uint support));
            return (support & 16384u) != 0 ? (byte)1 : (byte)0;
        }
    }
}
