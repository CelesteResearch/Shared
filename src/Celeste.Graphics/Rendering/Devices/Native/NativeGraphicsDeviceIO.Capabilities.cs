using Celeste.Graphics.Rendering.Devices.Native.Interop;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices.Native
{
    public unsafe partial class NativeGraphicsDeviceIO
    {
        private CelesteGraphicsCapabilities ReadCapabilities()
        {
            CelesteGraphicsCapabilities capabilities;
            RequireSuccess(api->GetCapabilities(device, &capabilities));
            return capabilities;
        }

        public byte SupportsNoOverwrite()
        {
            return ReadCapabilities().noOverwrite;
        }

        public byte SupportsHardwareInstancing()
        {
            return ReadCapabilities().hardwareInstancing;
        }

        public byte SupportsSRGBRenderTargets()
        {
            return ReadCapabilities().srgbRenderTargets;
        }

        public byte SupportsDXT1()
        {
            return ReadCapabilities().dxt1;
        }

        public byte SupportsS3TC()
        {
            return ReadCapabilities().s3tc;
        }

        public void GetMaxTextureSlots(out int fragmentSlots, out int vertexSlots)
        {
            var capabilities = ReadCapabilities();
            fragmentSlots = capabilities.fragmentTextureSlots;
            vertexSlots = capabilities.vertexTextureSlots;
        }

        public int GetMaxMultiSampleCount(SourceSurfaceFormat format, int preferredCount)
        {
            int actualCount;
            RequireSuccess(api->GetMaxMultiSampleCount(device, format, preferredCount, &actualCount));
            return actualCount;
        }
    }
}
