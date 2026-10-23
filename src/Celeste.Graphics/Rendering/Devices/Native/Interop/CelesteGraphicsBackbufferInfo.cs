using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices.Native.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteGraphicsBackbufferInfo
    {
        public int width, height;
        public SourceSurfaceFormat format;
        public SourceDepthFormat depthFormat;
        public int multiSampleCount;
    }
}
