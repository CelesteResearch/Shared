using System;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Scene.Diagnostics
{
    public readonly struct AnimatedTileCellGeometry
    {
        public readonly long CellIndex;
        public readonly AtlasTextureDraw Draw;
        public readonly SourceSpriteQuad Quad;
        private readonly int textureWidth, textureHeight;
        public SourceTexture2DResource Texture => Draw.Resource;

        public AnimatedTileCellGeometry(long cellIndex, in AtlasTextureDraw draw)
        {
            CellIndex = cellIndex;
            Draw = draw;
            textureWidth = draw.Resource.Width;
            textureHeight = draw.Resource.Height;
            Quad = AtlasQuadGeometry.Create(in draw);
        }

        public bool Matches(long cellIndex, in AtlasTextureDraw draw)
            => CellIndex == cellIndex && ReferenceEquals(Draw.Texture, draw.Texture) &&
               ReferenceEquals(Texture, draw.Resource) &&
               textureWidth == draw.Resource.Width && textureHeight == draw.Resource.Height &&
               Draw.Clip.X == draw.Clip.X && Draw.Clip.Y == draw.Clip.Y &&
               Draw.Clip.Width == draw.Clip.Width && Draw.Clip.Height == draw.Clip.Height &&
               Draw.Position.Equals(draw.Position) && Draw.Origin.Equals(draw.Origin) &&
               Draw.DrawOffset.Equals(draw.DrawOffset) && Draw.Scale.Equals(draw.Scale) &&
               Draw.Color.PackedValue == draw.Color.PackedValue &&
               BitConverter.SingleToInt32Bits(Draw.Rotation) == BitConverter.SingleToInt32Bits(draw.Rotation) &&
               Draw.FlipX == draw.FlipX && Draw.FlipY == draw.FlipY;
    }
}
