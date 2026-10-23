using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Devices.Native.Interop;

namespace Celeste.Graphics.Rendering.Devices.Native;

public unsafe partial class NativeGraphicsDeviceIO
{
    private CelesteGraphicsCapabilities ReadCapabilities()
    {
        CelesteGraphicsCapabilities capabilities;
        RequireSuccess(api->GetCapabilities(device, &capabilities));
        return capabilities;
    }

    public byte SupportsNoOverwrite() => ReadCapabilities().noOverwrite;
    public byte SupportsHardwareInstancing() => ReadCapabilities().hardwareInstancing;
    public byte SupportsSRGBRenderTargets() => ReadCapabilities().srgbRenderTargets;
    public byte SupportsDXT1() => ReadCapabilities().dxt1;
    public byte SupportsS3TC() => ReadCapabilities().s3tc;

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
