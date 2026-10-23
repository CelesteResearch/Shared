using System.Runtime.InteropServices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Devices.Native.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteGraphicsTextureInfo
    {
        public SourceSurfaceFormat sourceFormat;
        public uint dimension, width, height, depth, levels, renderTarget;
    }
}
