using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering.Effects;
using System.Runtime.InteropServices;

namespace Celeste.Graphics.Rendering.Batches
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SourceSpriteInfo
    {
        public int TextureHash;
        public float SourceX, SourceY, SourceWidth, SourceHeight;
        public float DestinationX, DestinationY, DestinationWidth, DestinationHeight;
        public uint Color;
        public float OriginX, OriginY, RotationSin, RotationCos, Depth;
        public byte Effects;

        public void Generate(ref SourceSpriteQuad vertex) => SourceSpriteGeometry.Generate(ref vertex,
            SourceX, SourceY, SourceWidth, SourceHeight,
            DestinationX, DestinationY, DestinationWidth, DestinationHeight,
            Color, OriginX, OriginY, RotationSin, RotationCos, Depth, Effects);
    }
}
