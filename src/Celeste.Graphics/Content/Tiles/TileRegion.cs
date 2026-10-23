using System;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class TileRegion
    {
        public readonly AtlasEntry Atlas;
        public readonly IntRect Clip;
        public readonly float OffsetX, OffsetY;
        public readonly int Width, Height;

        public TileRegion(TileRegion source)
        {
            Atlas = source.Atlas;
            Width = source.Width;
            Height = source.Height;
            Clip = source.Clip;
            OffsetX = source.OffsetX;
            OffsetY = source.OffsetY;
        }

        public TileRegion(AtlasEntry atlas, int x, int y, int width,
            int height)
        {
            Atlas = atlas;
            Width = width;
            Height = height;
            Clip = atlas.GetRelativeRect(x, y, width, height);
            OffsetX = -Math.Min(x - atlas.OffsetX, 0f);
            OffsetY = -Math.Min(y - atlas.OffsetY, 0f);
        }
    }
}
