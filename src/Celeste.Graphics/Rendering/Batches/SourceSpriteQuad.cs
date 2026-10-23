using System.Numerics;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Batches
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SourceSpriteQuad
    {
        public Vector3 Position0;
        public uint Color0;
        public Vector2 TextureCoordinate0;
        public Vector3 Position1;
        public uint Color1;
        public Vector2 TextureCoordinate1;
        public Vector3 Position2;
        public uint Color2;
        public Vector2 TextureCoordinate2;
        public Vector3 Position3;
        public uint Color3;
        public Vector2 TextureCoordinate3;
    }
}
