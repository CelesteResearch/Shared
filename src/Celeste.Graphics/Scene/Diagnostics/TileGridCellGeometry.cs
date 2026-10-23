using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering.Batches;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Scene.Diagnostics
{
    public readonly struct TileGridCellGeometry
    {
        public readonly long CellIndex;
        public readonly AtlasEntry Entry;
        public readonly SourceTexture2DResource Texture;
        public readonly SourceSpriteQuad Quad;
        private readonly int x, y, width, height, textureWidth, textureHeight;
        private readonly float offsetX, offsetY, scale;
        private readonly uint color;

        public TileGridCellGeometry(long cellIndex, AtlasEntry entry, SourceTexture2DResource texture, Vector2 position,
            PackedColor tint)
        {
            CellIndex = cellIndex;
            Entry = entry;
            Texture = texture;
            x = entry.X;
            y = entry.Y;
            width = entry.Width;
            height = entry.Height;
            textureWidth = texture.Width;
            textureHeight = texture.Height;
            offsetX = entry.OffsetX;
            offsetY = entry.OffsetY;
            scale = entry.SourceDrawScale;
            color = tint.PackedValue;
            Quad = AtlasQuadGeometry.Create(entry, texture, position, tint);
        }

        internal TileGridCellGeometry(long cellIndex, AtlasEntry entry, SourceTexture2DResource texture,
            Vector2 position,
            PackedColor tint, AtlasQuadTemplateCache templateCache)
        {
            CellIndex = cellIndex;
            Entry = entry;
            Texture = texture;
            x = entry.X;
            y = entry.Y;
            width = entry.Width;
            height = entry.Height;
            textureWidth = texture.Width;
            textureHeight = texture.Height;
            offsetX = entry.OffsetX;
            offsetY = entry.OffsetY;
            scale = entry.SourceDrawScale;
            color = tint.PackedValue;
            Quad = templateCache.Create(entry, texture, position, tint);
        }

        public bool Matches(long cellIndex, AtlasEntry entry, SourceTexture2DResource texture, PackedColor tint)
            => CellIndex == cellIndex && ReferenceEquals(Entry, entry) && ReferenceEquals(Texture, texture) &&
               x == entry.X && y == entry.Y &&
               width == entry.Width && height == entry.Height &&
               textureWidth == texture.Width && textureHeight == texture.Height &&
               BitConverter.SingleToInt32Bits(offsetX) == BitConverter.SingleToInt32Bits(entry.OffsetX) &&
               BitConverter.SingleToInt32Bits(offsetY) == BitConverter.SingleToInt32Bits(entry.OffsetY) &&
               BitConverter.SingleToInt32Bits(scale) == BitConverter.SingleToInt32Bits(entry.SourceDrawScale) &&
               color == tint.PackedValue;

        internal bool MatchesSnapshot(long cellIndex, AtlasEntry entry, SourceTexture2DResource texture,
            PackedColor tint)
        {
            uint snapshotColor = color;
            return CellIndex == cellIndex && ReferenceEquals(Entry, entry) && ReferenceEquals(Texture, texture) &&
                   x == entry.X && y == entry.Y &&
                   width == entry.Width && height == entry.Height &&
                   textureWidth == texture.Width && textureHeight == texture.Height &&
                   BitConverter.SingleToInt32Bits(offsetX) == BitConverter.SingleToInt32Bits(entry.OffsetX) &&
                   BitConverter.SingleToInt32Bits(offsetY) == BitConverter.SingleToInt32Bits(entry.OffsetY) &&
                   BitConverter.SingleToInt32Bits(scale) == BitConverter.SingleToInt32Bits(entry.SourceDrawScale) &&
                   snapshotColor == tint.PackedValue;
        }
    }
}
