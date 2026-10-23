using System;
using Celeste.Core.Collections;
using Celeste.Core.Randomness;
using Celeste.Graphics.Content.Tiles;
using Generated = Celeste.Graphics.Content.Tiles.Autotiling.AutotileGeneration;
using Behaviour = Celeste.Graphics.Content.Tiles.Autotiling.AutotileBehavior;
using Rectangle = Celeste.Core.Geometry.IntRect;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public sealed partial class EverestAutotiler
    {
        public override Generated GenerateMap(VirtualMap<char> mapData, bool paddingIgnoreOutOfLevel)
        {
            var behaviour = new Behaviour
            {
                EdgesExtend = true,
                EdgesIgnoreOutOfLevel = false,
                PaddingIgnoreOutOfLevel = paddingIgnoreOutOfLevel,
            };
            return Generate(mapData, 0, 0, mapData.Columns, mapData.Rows, false, '0', behaviour);
        }

        public override Generated GenerateMap(VirtualMap<char> mapData, Behaviour behaviour)
        {
            return Generate(mapData, 0, 0, mapData.Columns, mapData.Rows, false, '0', behaviour);
        }

        public override Generated GenerateBox(char id, int tilesX, int tilesY)
        {
            return Generate(null, 0, 0, tilesX, tilesY, true, id, default);
        }

        public override Generated GenerateOverlay(char id, int x, int y, int tilesX, int tilesY,
            VirtualMap<char> mapData)
        {
            for (var num = x; num < x + tilesX; num = (num / 50 + 1) * 50)
            for (var num2 = y; num2 < y + tilesY; num2 = (num2 / 50 + 1) * 50)
                if (!mapData.AnyInSegmentAtTile(num, num2))
                    mapData[num, num2] = mapData.EmptyValue;

            return orig_GenerateOverlay(id, x, y, tilesX, tilesY, mapData);
        }

        private Generated Generate(VirtualMap<char> mapData, int startX, int startY, int tilesX, int tilesY,
            bool forceSolid, char forceID, Behaviour behaviour)
        {
            var tileGrid = new TileGrid(8, 8, tilesX, tilesY);
            var animatedTiles = new AnimatedTiles(tilesX, tilesY, Graphics.AnimatedTilesBank, engine);
            var forceFill = Rectangle.Empty;
            if (forceSolid) forceFill = new(startX, startY, tilesX, tilesY);

            if (mapData != null)
                for (var i = startX; i < startX + tilesX; i += 50)
                for (var j = startY; j < startY + tilesY; j += 50)
                {
                    if (!mapData.AnyInSegmentAtTile(i, j))
                    {
                        j = j / 50 * 50;
                        continue;
                    }

                    var k = i;
                    for (var num = Math.Min(i + 50, startX + tilesX); k < num; k++)
                    {
                        var l = j;
                        for (var num2 = Math.Min(j + 50, startY + tilesY); l < num2; l++)
                        {
                            var tiles = TileHandler(mapData, k, l, forceFill, forceID, behaviour);
                            if (tiles != null)
                            {
                                tileGrid.Tiles[k - startX, l - startY] = Random.Choose(tiles.Textures);
                                if (tiles.HasOverlays)
                                    animatedTiles.Set(k - startX, l - startY, Random.Choose(tiles.OverlapSprites));
                            }
                        }
                    }
                }
            else
                for (var m = startX; m < startX + tilesX; m++)
                for (var n = startY; n < startY + tilesY; n++)
                {
                    var tiles2 = TileHandler(null, m, n, forceFill, forceID, behaviour);
                    if (tiles2 != null)
                    {
                        tileGrid.Tiles[m - startX, n - startY] = Random.Choose(tiles2.Textures);
                        if (tiles2.HasOverlays)
                            animatedTiles.Set(m - startX, n - startY, Random.Choose(tiles2.OverlapSprites));
                    }
                }

            return new()
            {
                TileGrid = tileGrid,
                SpriteOverlay = animatedTiles,
            };
        }

        public Generated orig_GenerateOverlay(char id, int x, int y, int tilesX, int tilesY, VirtualMap<char> mapData)
        {
            var behaviour = new Behaviour
            {
                EdgesExtend = true,
                EdgesIgnoreOutOfLevel = true,
                PaddingIgnoreOutOfLevel = true,
            };
            return Generate(mapData, x, y, tilesX, tilesY, true, id, behaviour);
        }
    }
}
