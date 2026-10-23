using System;
using System.Collections.Generic;
using System.Xml;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class Tileset
    {
        private readonly global::Celeste.Graphics.Content.Atlas.AtlasEntry[,] tiles;
        private readonly bool wrapIndices;
        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Texture { get; private set; }
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }

        public global::Celeste.Graphics.Content.Atlas.AtlasEntry this[int x, int y] =>
            wrapIndices ? tiles[x % tiles.GetLength(0), y % tiles.GetLength(1)] : tiles[x, y];

        public global::Celeste.Graphics.Content.Atlas.AtlasEntry this[int index] =>
            index < 0
                ? null
                : wrapIndices
                    ? tiles[index % tiles.GetLength(0), index / tiles.GetLength(0) % tiles.GetLength(1)]
                    : tiles[index % tiles.GetLength(0), index / tiles.GetLength(0)];

        public Tileset(global::Celeste.Graphics.Content.Atlas.AtlasEntry atlas, int width, int height,
            bool wrapIndices) : this(atlas, width, height)
        {
            this.wrapIndices = wrapIndices;
        }

        public Tileset(global::Celeste.Graphics.Content.Atlas.AtlasEntry atlas, int width, int height)
        {
            Texture = atlas;
            TileWidth = width;
            // Original Tileset assigns TileHeight to itself, retaining the zero value.
            TileHeight = TileHeight;
            tiles = new global::Celeste.Graphics.Content.Atlas.AtlasEntry[atlas.FrameWidth / width,
                atlas.FrameHeight / height];
            for (int x = 0; x < tiles.GetLength(0); x++)
            for (int y = 0; y < tiles.GetLength(1); y++)
                tiles[x, y] = atlas.GetSubtexture(x * width, y * height, width, height);
        }
    }
}
