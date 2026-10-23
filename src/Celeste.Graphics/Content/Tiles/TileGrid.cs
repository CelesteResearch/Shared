using Celeste.Core.Display;
using Celeste.Core.Geometry;
using System;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Graphics.Content.Tiles
{
    public class TileGrid : SourceComponentState
    {
        private static int Clamp(int value, int min, int max) => Math.Min(Math.Max(value, min), max);

        public Vector2 Position;

        public PackedColor Color = PackedColor.White;

        public int VisualExtend;

        public VirtualMap<global::Celeste.Graphics.Content.Atlas.AtlasEntry> Tiles;

        public CameraState ClipCamera;

        public float Alpha = 1f;

        public int TileWidth { get; private set; }

        public int TileHeight { get; private set; }

        public int TilesX => Tiles.Columns;

        public int TilesY => Tiles.Rows;

        public TileGrid(int tileWidth, int tileHeight, int tilesX, int tilesY) : base(false, true)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Tiles = new VirtualMap<global::Celeste.Graphics.Content.Atlas.AtlasEntry>(tilesX, tilesY);
        }

        public void Populate(Tileset tileset, int[,] tiles, int offsetX = 0, int offsetY = 0)
        {
            for (int i = 0; i < tiles.GetLength(0) && i + offsetX < TilesX; i++)
            {
                for (int j = 0; j < tiles.GetLength(1) && j + offsetY < TilesY; j++)
                {
                    Tiles[i + offsetX, j + offsetY] = tileset[tiles[i, j]];
                }
            }
        }

        public void Overlay(Tileset tileset, int[,] tiles, int offsetX = 0, int offsetY = 0)
        {
            for (int i = 0; i < tiles.GetLength(0) && i + offsetX < TilesX; i++)
            {
                for (int j = 0; j < tiles.GetLength(1) && j + offsetY < TilesY; j++)
                {
                    if (tiles[i, j] >= 0)
                    {
                        Tiles[i + offsetX, j + offsetY] = tileset[tiles[i, j]];
                    }
                }
            }
        }

        public void Extend(int left, int right, int up, int down)
        {
            Position -= new Vector2(left * TileWidth, up * TileHeight);
            int num = TilesX + left + right;
            int num2 = TilesY + up + down;
            if (num <= 0 || num2 <= 0)
            {
                Tiles = new VirtualMap<global::Celeste.Graphics.Content.Atlas.AtlasEntry>(0, 0);
                return;
            }

            VirtualMap<global::Celeste.Graphics.Content.Atlas.AtlasEntry> virtualMap =
                new VirtualMap<global::Celeste.Graphics.Content.Atlas.AtlasEntry>(num, num2);
            for (int i = 0; i < TilesX; i++)
            {
                for (int j = 0; j < TilesY; j++)
                {
                    int num3 = i + left;
                    int num4 = j + up;
                    if (num3 >= 0 && num3 < num && num4 >= 0 && num4 < num2)
                    {
                        virtualMap[num3, num4] = Tiles[i, j];
                    }
                }
            }

            for (int k = 0; k < left; k++)
            {
                for (int l = 0; l < num2; l++)
                {
                    virtualMap[k, l] = Tiles[0, Clamp(l - up, 0, TilesY - 1)];
                }
            }

            for (int m = num - right; m < num; m++)
            {
                for (int n = 0; n < num2; n++)
                {
                    virtualMap[m, n] = Tiles[TilesX - 1, Clamp(n - up, 0, TilesY - 1)];
                }
            }

            for (int num5 = 0; num5 < up; num5++)
            {
                for (int num6 = 0; num6 < num; num6++)
                {
                    virtualMap[num6, num5] = Tiles[Clamp(num6 - left, 0, TilesX - 1), 0];
                }
            }

            for (int num7 = num2 - down; num7 < num2; num7++)
            {
                for (int num8 = 0; num8 < num; num8++)
                {
                    virtualMap[num8, num7] = Tiles[Clamp(num8 - left, 0, TilesX - 1), TilesY - 1];
                }
            }

            Tiles = virtualMap;
        }

        public void FillRect(int x, int y, int columns, int rows,
            global::Celeste.Graphics.Content.Atlas.AtlasEntry tile)
        {
            int num = Math.Max(0, x);
            int num2 = Math.Max(0, y);
            int num3 = Math.Min(TilesX, x + columns);
            int num4 = Math.Min(TilesY, y + rows);
            for (int i = num; i < num3; i++)
            {
                for (int j = num2; j < num4; j++)
                {
                    Tiles[i, j] = tile;
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < TilesX; i++)
            {
                for (int j = 0; j < TilesY; j++)
                {
                    Tiles[i, j] = null;
                }
            }
        }

        public IntRect GetClippedRenderTiles()
        {
            Vector2 vector = ((ISourceEntityPosition)Entity).Position + Position;
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
                CameraState clipCamera = ClipCamera;
                val = (int)Math.Max(0.0,
                    Math.Floor((clipCamera.Left - vector.X) / (float)TileWidth) - (double)VisualExtend);
                val2 = (int)Math.Max(0.0,
                    Math.Floor((clipCamera.Top - vector.Y) / (float)TileHeight) - (double)VisualExtend);
                val3 = (int)Math.Min(TilesX,
                    Math.Ceiling((clipCamera.Right - vector.X) / (float)TileWidth) + (double)VisualExtend);
                val4 = (int)Math.Min(TilesY,
                    Math.Ceiling((clipCamera.Bottom - vector.Y) / (float)TileHeight) + (double)VisualExtend);
            }

            val = Math.Max(val, 0);
            val2 = Math.Max(val2, 0);
            val3 = Math.Min(val3, TilesX);
            val4 = Math.Min(val4, TilesY);
            return new IntRect(val, val2, val3 - val, val4 - val2);
        }

        public override void Render(ISourceRenderContext context)
        {
            RenderAt(((ISourceEntityPosition)Entity).Position + Position, context);
        }

        public void RenderAt(Vector2 position, ISourceRenderContext context)
        {
            if (Alpha <= 0f)
            {
                return;
            }

            IntRect clippedRenderTiles = GetClippedRenderTiles();
            PackedColor color = Color * Alpha;
            for (int i = clippedRenderTiles.Left; i < clippedRenderTiles.Right; i++)
            {
                for (int j = clippedRenderTiles.Top; j < clippedRenderTiles.Bottom; j++)
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
}
