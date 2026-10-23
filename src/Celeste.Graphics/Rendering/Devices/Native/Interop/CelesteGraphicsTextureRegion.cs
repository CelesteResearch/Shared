using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Devices.Native.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CelesteGraphicsTextureRegion
    {
        public uint level, layer, x, y, z, width, height, depth;
    }
}
