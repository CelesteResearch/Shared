using Celeste.Graphics.Content.Atlas;

namespace Celeste.Graphics.Content.Tiles
{
    public sealed class Tileset
    {
        private readonly AtlasEntry[,] tiles;
        private readonly bool wrapIndices;
        public AtlasEntry Texture { get; private set; }
        public int TileWidth { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int TileHeight { get; private set; }

        public AtlasEntry this[int x, int y] =>
            wrapIndices ? tiles[x % tiles.GetLength(0), y % tiles.GetLength(1)] : tiles[x, y];

        public AtlasEntry this[int index] =>
            index < 0
                ? null
                : wrapIndices
                    ? tiles[index % tiles.GetLength(0), index / tiles.GetLength(0) % tiles.GetLength(1)]
                    : tiles[index % tiles.GetLength(0), index / tiles.GetLength(0)];

        public Tileset(AtlasEntry atlas, int width, int height,
            bool wrapIndices) : this(atlas, width, height)
        {
            this.wrapIndices = wrapIndices;
        }

        public Tileset(AtlasEntry atlas, int width, int height)
        {
            Texture = atlas;
            TileWidth = width;
            // Original Tileset assigns TileHeight to itself, retaining the zero value.
            TileHeight = TileHeight;
            tiles = new AtlasEntry[atlas.FrameWidth / width,
                atlas.FrameHeight / height];
            for (var x = 0; x < tiles.GetLength(0); x++)
            for (var y = 0; y < tiles.GetLength(1); y++)
                tiles[x, y] = atlas.GetSubtexture(x * width, y * height, width, height);
        }
    }
}
