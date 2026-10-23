using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Devices.Native.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteGraphicsCapabilities
    {
        public byte noOverwrite, hardwareInstancing, srgbRenderTargets, dxt1, s3tc;
        public int fragmentTextureSlots, vertexTextureSlots;
    }
}
