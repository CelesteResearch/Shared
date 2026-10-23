using System;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Graphics.Content.Tiles
{
    public class TileGrid : SourceComponentState
    {
        private static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        public Vector2 Position;
        public PackedColor Color = PackedColor.White;
        public int VisualExtend;
        public VirtualMap<AtlasEntry> Tiles;
        public CameraState ClipCamera;
        public float Alpha = 1f;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int TileWidth { get; private set; }

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public int TileHeight { get; private set; }
        public int TilesX => Tiles.Columns;
        public int TilesY => Tiles.Rows;

        // ReSharper disable once ConvertToPrimaryConstructor
        public TileGrid(int tileWidth, int tileHeight, int tilesX, int tilesY) : base(false, true)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Tiles = new(tilesX, tilesY);
        }

        public void Populate(Tileset tileset, int[,] tiles, int offsetX = 0, int offsetY = 0)
        {
            for (var i = 0; i < tiles.GetLength(0) && i + offsetX < TilesX; i++)
            for (var j = 0; j < tiles.GetLength(1) && j + offsetY < TilesY; j++)
                Tiles[i + offsetX, j + offsetY] = tileset[tiles[i, j]];
        }

        public void Overlay(Tileset tileset, int[,] tiles, int offsetX = 0, int offsetY = 0)
        {
            for (var i = 0; i < tiles.GetLength(0) && i + offsetX < TilesX; i++)
            for (var j = 0; j < tiles.GetLength(1) && j + offsetY < TilesY; j++)
                if (tiles[i, j] >= 0)
                    Tiles[i + offsetX, j + offsetY] = tileset[tiles[i, j]];
        }

        public void Extend(int left, int right, int up, int down)
        {
            Position -= new Vector2(left * TileWidth, up * TileHeight);
            var num = TilesX + left + right;
            var num2 = TilesY + up + down;
            if (num <= 0 || num2 <= 0)
            {
                Tiles = new(0, 0);
                return;
            }

            var virtualMap = new VirtualMap<AtlasEntry>(num, num2);
            for (var i = 0; i < TilesX; i++)
            for (var j = 0; j < TilesY; j++)
            {
                var num3 = i + left;
                var num4 = j + up;
                if (num3 >= 0 && num3 < num && num4 >= 0 && num4 < num2)
                    virtualMap[num3, num4] = Tiles[i, j];
            }

            for (var k = 0; k < left; k++)
            for (var l = 0; l < num2; l++)
                virtualMap[k, l] = Tiles[0, Clamp(l - up, 0, TilesY - 1)];
            for (var m = num - right; m < num; m++)
            for (var n = 0; n < num2; n++)
                virtualMap[m, n] = Tiles[TilesX - 1, Clamp(n - up, 0, TilesY - 1)];
            for (var num5 = 0; num5 < up; num5++)
            for (var num6 = 0; num6 < num; num6++)
                virtualMap[num6, num5] = Tiles[Clamp(num6 - left, 0, TilesX - 1), 0];
            for (var num7 = num2 - down; num7 < num2; num7++)
            for (var num8 = 0; num8 < num; num8++)
                virtualMap[num8, num7] = Tiles[Clamp(num8 - left, 0, TilesX - 1), TilesY - 1];
            Tiles = virtualMap;
        }

        public void FillRect(int x, int y, int columns, int rows, AtlasEntry tile)
        {
            var num = Math.Max(0, x);
            var num2 = Math.Max(0, y);
            var num3 = Math.Min(TilesX, x + columns);
            var num4 = Math.Min(TilesY, y + rows);
            for (var i = num; i < num3; i++)
            for (var j = num2; j < num4; j++)
                Tiles[i, j] = tile;
        }

        public void Clear()
        {
            for (var i = 0; i < TilesX; i++)
            for (var j = 0; j < TilesY; j++)
                Tiles[i, j] = null;
        }

        public IntRect GetClippedRenderTiles()
        {
            var vector = ((ISourceEntityPosition)Entity).Position + Position;
            int val;
            int val2;
            int val3;
            int val4;
            if (ClipCamera == null)
            {
                val = -VisualExtend;
                val2 = -VisualExtend;
                val3 = TilesX + VisualExtend;
                val4 = TilesY + VisualExtend;
            }
            else
            {
                var clipCamera = ClipCamera;
                val = (int)Math.Max(0.0, Math.Floor((clipCamera.Left - vector.X) / TileWidth) - VisualExtend);
                val2 = (int)Math.Max(0.0, Math.Floor((clipCamera.Top - vector.Y) / TileHeight) - VisualExtend);
                val3 = (int)Math.Min(TilesX, Math.Ceiling((clipCamera.Right - vector.X) / TileWidth) + VisualExtend);
                val4 = (int)Math.Min(TilesY, Math.Ceiling((clipCamera.Bottom - vector.Y) / TileHeight) + VisualExtend);
            }

            val = Math.Max(val, 0);
            val2 = Math.Max(val2, 0);
            val3 = Math.Min(val3, TilesX);
            val4 = Math.Min(val4, TilesY);
            return new(val, val2, val3 - val, val4 - val2);
        }

        public override void Render(ISourceRenderContext context)
        {
            RenderAt(((ISourceEntityPosition)Entity).Position + Position, context);
        }

        public void RenderAt(Vector2 position, ISourceRenderContext context)
        {
            if (Alpha <= 0f)
                return;
            var clippedRenderTiles = GetClippedRenderTiles();
            var color = Color * Alpha;
            for (var i = clippedRenderTiles.Left; i < clippedRenderTiles.Right; i++)
            for (var j = clippedRenderTiles.Top; j < clippedRenderTiles.Bottom; j++)
            {
                var tile = Tiles[i, j];
                if (tile != null)
                {
                    var drawPosition = position + new Vector2(i * TileWidth, j * TileHeight);
                    var image = new AtlasTextureDraw(tile, drawPosition, Vector2.Zero, color, Vector2.One);
                    ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in image, Entity);
                }
            }
        }
    }
}
