using Celeste.Core.Collections;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using System;
using System.Collections.Generic;

namespace Celeste.Graphics.Content.Tiles.Autotiling
{
    public partial class Autotiler
    {
        public List<global::Celeste.Core.Geometry.IntRect> LevelBounds =
            new List<global::Celeste.Core.Geometry.IntRect>();

        private Dictionary<char, AutotileTerrain> lookup = null;
        public virtual IReadOnlyCollection<char> TerrainIds => lookup.Keys;

        private readonly char emptyId, unsetId;

        private readonly int tileWidth, tileHeight;

        protected byte[] adjacent = new byte[9];

        protected readonly ISourceEngineContext engine;

        private global::Celeste.Graphics.Content.Tiles.AnimatedTileBank bank;

        private readonly global::Celeste.Graphics.Content.Tiles.IAnimatedTileBankEnvironment bankEnvironment;

        protected Autotiler(ISourceEngineContext engine) => this.engine = engine;

        public Autotiler(AutotileRules rules, ISourceEngineContext engine,
            global::Celeste.Graphics.Content.Tiles.AnimatedTileBank bank,
            global::Celeste.Graphics.Content.Tiles.IAnimatedTileBankEnvironment bankEnvironment = null)
        {
            this.engine = engine;
            this.bank = bank;
            this.bankEnvironment = bankEnvironment;
            emptyId = rules.EmptyId;
            unsetId = rules.UnsetId;
            tileWidth = rules.TileWidth;
            tileHeight = rules.TileHeight;
            lookup = rules.Terrains;
        }

        public void BindAnimations(global::Celeste.Graphics.Content.Tiles.AnimatedTileBank value) =>
            bank = value ?? throw new ArgumentNullException(nameof(value));

        public virtual AutotileGeneration GenerateMap(VirtualMap<char> mapData, bool paddingIgnoreOutOfLevel)
        {
            AutotileBehavior behaviour = new AutotileBehavior
            {
                EdgesExtend = true,
                EdgesIgnoreOutOfLevel = false,
                PaddingIgnoreOutOfLevel = paddingIgnoreOutOfLevel
            };
            return Generate(mapData, 0, 0, mapData.Columns, mapData.Rows, forceSolid: false, emptyId, behaviour);
        }

        public virtual AutotileGeneration GenerateMap(VirtualMap<char> mapData, AutotileBehavior behaviour)
        {
            return Generate(mapData, 0, 0, mapData.Columns, mapData.Rows, forceSolid: false, emptyId, behaviour);
        }

        public virtual AutotileGeneration GenerateBox(char id, int tilesX, int tilesY)
        {
            return Generate(null, 0, 0, tilesX, tilesY, forceSolid: true, id, default(AutotileBehavior));
        }

        public virtual AutotileGeneration GenerateOverlay(char id, int x, int y, int tilesX, int tilesY,
            VirtualMap<char> mapData)
        {
            for (int segmentX = x; segmentX < x + tilesX; segmentX = (segmentX / 50 + 1) * 50)
            for (int segmentY = y; segmentY < y + tilesY; segmentY = (segmentY / 50 + 1) * 50)
                if (!mapData.AnyInSegmentAtTile(segmentX, segmentY))
                    mapData[segmentX, segmentY] = mapData.EmptyValue;
            AutotileBehavior behaviour = new AutotileBehavior
            {
                EdgesExtend = true,
                EdgesIgnoreOutOfLevel = true,
                PaddingIgnoreOutOfLevel = true
            };
            return Generate(mapData, x, y, tilesX, tilesY, forceSolid: true, id, behaviour);
        }

        private AutotileGeneration Generate(VirtualMap<char> mapData, int startX, int startY, int tilesX, int tilesY,
            bool forceSolid, char forceID, AutotileBehavior behaviour)
        {
            global::Celeste.Graphics.Content.Tiles.TileGrid tileGrid =
                new global::Celeste.Graphics.Content.Tiles.TileGrid(tileWidth, tileHeight, tilesX, tilesY);
            global::Celeste.Graphics.Content.Tiles.AnimatedTiles animatedTiles =
                new global::Celeste.Graphics.Content.Tiles.AnimatedTiles(tilesX, tilesY,
                    bankEnvironment != null ? bankEnvironment.AnimatedTilesBank : bank, engine);
            global::Celeste.Core.Geometry.IntRect forceFill = global::Celeste.Core.Geometry.IntRect.Empty;
            if (forceSolid)
            {
                forceFill = new global::Celeste.Core.Geometry.IntRect(startX, startY, tilesX, tilesY);
            }

            if (mapData != null)
            {
                for (int i = startX; i < startX + tilesX; i += 50)
                {
                    for (int j = startY; j < startY + tilesY; j += 50)
                    {
                        if (!mapData.AnyInSegmentAtTile(i, j))
                        {
                            j = j / 50 * 50;
                            continue;
                        }

                        int k = i;
                        for (int num = Math.Min(i + 50, startX + tilesX); k < num; k++)
                        {
                            int l = j;
                            for (int num2 = Math.Min(j + 50, startY + tilesY); l < num2; l++)
                            {
                                AutotileCandidates tiles =
                                    VanillaTileHandler(mapData, k, l, forceFill, forceID, behaviour);
                                if (tiles != null)
                                {
                                    tileGrid.Tiles[k - startX, l - startY] =
                                        ((ISourceRandomEnvironment)engine).Random.Choose(tiles.Textures);
                                    if (tiles.HasOverlays)
                                    {
                                        animatedTiles.Set(k - startX, l - startY,
                                            ((ISourceRandomEnvironment)engine).Random.Choose(tiles.OverlapSprites));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int m = startX; m < startX + tilesX; m++)
                {
                    for (int n = startY; n < startY + tilesY; n++)
                    {
                        AutotileCandidates tiles2 = VanillaTileHandler(null, m, n, forceFill, forceID, behaviour);
                        if (tiles2 != null)
                        {
                            tileGrid.Tiles[m - startX, n - startY] =
                                ((ISourceRandomEnvironment)engine).Random.Choose(tiles2.Textures);
                            if (tiles2.HasOverlays)
                            {
                                animatedTiles.Set(m - startX, n - startY,
                                    ((ISourceRandomEnvironment)engine).Random.Choose(tiles2.OverlapSprites));
                            }
                        }
                    }
                }
            }

            return new AutotileGeneration
            {
                TileGrid = tileGrid,
                SpriteOverlay = animatedTiles
            };
        }

        private AutotileCandidates VanillaTileHandler(VirtualMap<char> mapData, int x, int y,
            global::Celeste.Core.Geometry.IntRect forceFill, char forceID,
            AutotileBehavior behaviour)
        {
            char tile = GetTile(mapData, x, y, forceFill, forceID, behaviour);
            if (IsEmpty(tile))
            {
                return null;
            }

            AutotileTerrain terrainType = lookup[tile];
            bool flag = true;
            int num = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    bool flag2 = CheckTile(terrainType, mapData, x + j, y + i, forceFill, behaviour);
                    if (!flag2 && behaviour.EdgesIgnoreOutOfLevel && !CheckForSameLevel(x, y, x + j, y + i))
                    {
                        flag2 = true;
                    }

                    adjacent[num++] = (byte)(flag2 ? 1u : 0u);
                    if (!flag2)
                    {
                        flag = false;
                    }
                }
            }

            if (flag)
            {
                if (behaviour.PaddingIgnoreOutOfLevel
                        ? ((!CheckTile(terrainType, mapData, x - 2, y, forceFill, behaviour) &&
                            CheckForSameLevel(x, y, x - 2, y)) ||
                           (!CheckTile(terrainType, mapData, x + 2, y, forceFill, behaviour) &&
                            CheckForSameLevel(x, y, x + 2, y)) ||
                           (!CheckTile(terrainType, mapData, x, y - 2, forceFill, behaviour) &&
                            CheckForSameLevel(x, y, x, y - 2)) ||
                           (!CheckTile(terrainType, mapData, x, y + 2, forceFill, behaviour) &&
                            CheckForSameLevel(x, y, x, y + 2)))
                        : (!CheckTile(terrainType, mapData, x - 2, y, forceFill, behaviour) ||
                           !CheckTile(terrainType, mapData, x + 2, y, forceFill, behaviour) ||
                           !CheckTile(terrainType, mapData, x, y - 2, forceFill, behaviour) ||
                           !CheckTile(terrainType, mapData, x, y + 2, forceFill, behaviour)))
                {
                    return lookup[tile].Padded;
                }

                return lookup[tile].Center;
            }

            foreach (AutotileMaskRule item in terrainType.Masked)
            {
                bool flag4 = true;
                for (int k = 0; k < 9 && flag4; k++)
                {
                    if (item.Mask[k] != 2 && item.Mask[k] != adjacent[k])
                    {
                        flag4 = false;
                    }
                }

                if (flag4)
                {
                    return item.Tiles;
                }
            }

            return null;
        }

        private bool CheckForSameLevel(int x1, int y1, int x2, int y2)
        {
            foreach (global::Celeste.Core.Geometry.IntRect levelBound in LevelBounds)
            {
                if (levelBound.Contains(x1, y1) && levelBound.Contains(x2, y2))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckTile(AutotileTerrain set, VirtualMap<char> mapData, int x, int y,
            global::Celeste.Core.Geometry.IntRect forceFill,
            AutotileBehavior behaviour)
        {
            if (forceFill.Contains(x, y))
            {
                return true;
            }

            if (mapData == null)
            {
                return behaviour.EdgesExtend;
            }

            if (x < 0 || y < 0 || x >= mapData.Columns || y >= mapData.Rows)
            {
                if (!behaviour.EdgesExtend)
                {
                    return false;
                }

                char c = mapData[Math.Min(Math.Max(x, 0), mapData.Columns - 1),
                    Math.Min(Math.Max(y, 0), mapData.Rows - 1)];
                if (!IsEmpty(c))
                {
                    return !set.Ignore(c);
                }

                return false;
            }

            char c2 = mapData[x, y];
            if (!IsEmpty(c2))
            {
                return !set.Ignore(c2);
            }

            return false;
        }

        private char GetTile(VirtualMap<char> mapData, int x, int y, global::Celeste.Core.Geometry.IntRect forceFill,
            char forceID,
            AutotileBehavior behaviour)
        {
            if (forceFill.Contains(x, y))
            {
                return forceID;
            }

            if (mapData == null)
            {
                if (!behaviour.EdgesExtend)
                {
                    return emptyId;
                }

                return forceID;
            }

            if (x < 0 || y < 0 || x >= mapData.Columns || y >= mapData.Rows)
            {
                if (!behaviour.EdgesExtend)
                {
                    return emptyId;
                }

                int x2 = Math.Min(Math.Max(x, 0), mapData.Columns - 1);
                int y2 = Math.Min(Math.Max(y, 0), mapData.Rows - 1);
                return mapData[x2, y2];
            }

            return mapData[x, y];
        }

        private bool IsEmpty(char id)
        {
            if (id != emptyId)
            {
                return id == unsetId;
            }

            return true;
        }
    }
}
