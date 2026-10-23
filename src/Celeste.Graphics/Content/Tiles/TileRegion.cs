using System;
using System.Collections.Generic;
using System.Xml;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class TileRegion
    {
        public readonly global::Celeste.Graphics.Content.Atlas.AtlasEntry Atlas;
        public readonly global::Celeste.Core.Geometry.IntRect Clip;
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

        public TileRegion(global::Celeste.Graphics.Content.Atlas.AtlasEntry atlas, int x, int y, int width,
            int height)
        {
            Atlas = atlas;
            Width = width;
            Height = height;
            Clip = atlas.GetRelativeRect(x, y, width, height);
            OffsetX = -Math.Min((float)x - atlas.OffsetX, 0f);
            OffsetY = -Math.Min((float)y - atlas.OffsetY, 0f);
        }
    }
}
