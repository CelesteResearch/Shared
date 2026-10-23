using System;
using System.Collections.Generic;
using System.Xml;
using Celeste.Core.Collections;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Core.Serialization.Xml;
using Celeste.Graphics.Content;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Audio.Surfaces;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Chapters.Flow;
using Celeste.Everest.Diagnostics.Logging;
using Generated = Celeste.Graphics.Content.Tiles.Autotiling.AutotileGeneration;
using Behaviour = Celeste.Graphics.Content.Tiles.Autotiling.AutotileBehavior;
using Rectangle = Celeste.Core.Geometry.IntRect;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;

namespace Celeste.Everest.Content.Tiles.Autotiling
{
    public sealed partial class EverestAutotiler
    {
        private Tiles TileHandler(VirtualMap<char> mapData, int x, int y, Rectangle forceFill, char forceID,
            Behaviour behaviour)
        {
            char tile = GetTile(mapData, x, y, forceFill, forceID, behaviour);
            if (IsEmpty(tile))
            {
                return null;
            }

            if (!lookup.TryGetValue(tile, out var value))
            {
                var sourceMessage2 = Logger.BeginEnabledMessage("Autotiler", EverestLogLevel.Error);
                if (sourceMessage2.ShouldLog)
                    sourceMessage2.Write("Undefined tile id '" + (tile) + "' at (" + (x) + ", " + (y) + ")");
                return new Tiles
                {
                    Textures = { Graphics.GameAtlas.GetFallback() }
                };
            }

            int scanWidth = value.ScanWidth;
            int scanHeight = value.ScanHeight;
            if (value.CustomFills == null && scanWidth == 3 && scanHeight == 3 && value.whitelists.Count == 0 &&
                value.blacklists.Count == 0)
            {
                return orig_TileHandler(mapData, x, y, forceFill, forceID, behaviour);
            }

            bool flag = true;
            Span<char> span = stackalloc char[scanWidth * scanHeight];
            Span<bool> span2 = stackalloc bool[scanWidth * scanHeight];
            int index = 0;
            for (int i = 0; i < scanHeight; i++)
            {
                for (int j = 0; j < scanWidth; j++)
                {
                    char tile2;
                    bool flag2 = TryGetTile(value, mapData, x + (j - scanWidth / 2), y + (i - scanHeight / 2),
                        forceFill,
                        forceID, behaviour, out tile2);
                    if (!flag2 && behaviour.EdgesIgnoreOutOfLevel && !CheckForSameLevel(x, y, x + j, y + i))
                    {
                        flag2 = true;
                    }

                    span2[index] = flag2;
                    span[index++] = tile2;
                    if (!flag2)
                    {
                        flag = false;
                    }
                }
            }

            if (flag)
            {
                if (value.CustomFills != null)
                {
                    int depth = GetDepth(value, mapData, x, y, forceFill, behaviour, 1);
                    return value.CustomFills[depth - 1];
                }

                if (CheckCross(value, mapData, x, y, forceFill, behaviour, 1 + scanWidth / 2, 1 + scanHeight / 2))
                {
                    return value.Center;
                }

                return value.Padded;
            }

            foreach (Masked item in value.Masked)
            {
                bool flag3 = true;
                for (int k = 0; k < scanWidth * scanHeight; k++)
                {
                    if (item.Mask[k] != 2)
                    {
                        if (item.Mask[k] == 1 && !span2[k])
                        {
                            flag3 = false;
                            break;
                        }

                        if (item.Mask[k] == 0 && span2[k])
                        {
                            flag3 = false;
                            break;
                        }

                        if (item.Mask[k] == 3 && span[k] == tile)
                        {
                            flag3 = false;
                            break;
                        }

                        if (value.blacklists.Count > 0 && value.blacklists.ContainsKey(item.Mask[k]) &&
                            value.blacklists[item.Mask[k]].Contains(span[k].ToString()))
                        {
                            flag3 = false;
                            break;
                        }

                        if (value.whitelists.Count > 0 && value.whitelists.ContainsKey(item.Mask[k]) &&
                            !value.whitelists[item.Mask[k]].Contains(span[k].ToString()))
                        {
                            flag3 = false;
                            break;
                        }
                    }
                }

                if (flag3)
                {
                    return item.Tiles;
                }
            }

            return null;
        }

        private bool CheckForSameLevel(int x1, int y1, int x2, int y2)
        {
            foreach (Rectangle levelBound in LevelBounds)
            {
                if (levelBound.Contains(x1, y1) && levelBound.Contains(x2, y2))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckTile(TerrainType set, VirtualMap<char> mapData, int x, int y, Rectangle forceFill,
            Behaviour behaviour)
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

                char c = mapData[ScalarMath.Clamp(x, 0, mapData.Columns - 1), ScalarMath.Clamp(y, 0, mapData.Rows - 1)];
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

        private char GetTile(VirtualMap<char> mapData, int x, int y, Rectangle forceFill, char forceID,
            Behaviour behaviour)
        {
            if (forceFill.Contains(x, y))
            {
                return forceID;
            }

            if (mapData == null)
            {
                if (!behaviour.EdgesExtend)
                {
                    return '0';
                }

                return forceID;
            }

            if (x < 0 || y < 0 || x >= mapData.Columns || y >= mapData.Rows)
            {
                if (!behaviour.EdgesExtend)
                {
                    return '0';
                }

                int x2 = ScalarMath.Clamp(x, 0, mapData.Columns - 1);
                int y2 = ScalarMath.Clamp(y, 0, mapData.Rows - 1);
                return mapData[x2, y2];
            }

            return mapData[x, y];
        }

        private bool IsEmpty(char id)
        {
            if (id != '0')
            {
                return id == '\0';
            }

            return true;
        }

        private Tiles orig_TileHandler(VirtualMap<char> mapData, int x, int y, Rectangle forceFill, char forceID,
            Behaviour behaviour)
        {
            char tile = GetTile(mapData, x, y, forceFill, forceID, behaviour);
            if (IsEmpty(tile))
            {
                return null;
            }

            TerrainType terrainType = lookup[tile];
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

            foreach (Masked item in terrainType.Masked)
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

        private bool TryGetTile(TerrainType set, VirtualMap<char> mapData, int x, int y, Rectangle forceFill,
            char forceID,
            Behaviour behaviour, out char tile)
        {
            tile = '0';
            if (forceFill.Contains(x, y))
            {
                tile = forceID;
                return true;
            }

            if (mapData == null)
            {
                return behaviour.EdgesExtend;
            }

            if (x >= 0 && y >= 0 && x < mapData.Columns && y < mapData.Rows)
            {
                tile = mapData[x, y];
                if (!IsEmpty(tile))
                {
                    return !set.Ignore(tile);
                }

                return false;
            }

            if (!behaviour.EdgesExtend)
            {
                return false;
            }

            tile = mapData[ScalarMath.Clamp(x, 0, mapData.Columns - 1), ScalarMath.Clamp(y, 0, mapData.Rows - 1)];
            if (!IsEmpty(tile))
            {
                return !set.Ignore(tile);
            }

            return false;
        }

        private int GetDepth(TerrainType terrainType, VirtualMap<char> mapData, int x, int y, Rectangle forceFill,
            Behaviour behaviour, int depth)
        {
            int width = depth + terrainType.ScanWidth / 2;
            int height = depth + terrainType.ScanHeight / 2;
            if (CheckCross(terrainType, mapData, x, y, forceFill, behaviour, width, height) &&
                depth < terrainType.CustomFills.Count)
            {
                return GetDepth(terrainType, mapData, x, y, forceFill, behaviour, ++depth);
            }

            return depth;
        }

        private bool CheckCross(TerrainType terrainType, VirtualMap<char> mapData, int x, int y, Rectangle forceFill,
            Behaviour behaviour, int width, int height)
        {
            if (behaviour.PaddingIgnoreOutOfLevel)
            {
                if ((CheckTile(terrainType, mapData, x - width, y, forceFill, behaviour) ||
                     !CheckForSameLevel(x, y, x - width, y)) &&
                    (CheckTile(terrainType, mapData, x + width, y, forceFill, behaviour) ||
                     !CheckForSameLevel(x, y, x + width, y)) &&
                    (CheckTile(terrainType, mapData, x, y - height, forceFill, behaviour) ||
                     !CheckForSameLevel(x, y, x, y - height)))
                {
                    if (!CheckTile(terrainType, mapData, x, y + height, forceFill, behaviour))
                    {
                        return !CheckForSameLevel(x, y, x, y + height);
                    }

                    return true;
                }

                return false;
            }

            if (CheckTile(terrainType, mapData, x - width, y, forceFill, behaviour) &&
                CheckTile(terrainType, mapData, x + width, y, forceFill, behaviour) &&
                CheckTile(terrainType, mapData, x, y - height, forceFill, behaviour))
            {
                return CheckTile(terrainType, mapData, x, y + height, forceFill, behaviour);
            }

            return false;
        }

        public bool TryGetCustomDebris(out string path, char tiletype)
        {
            TerrainType value;
            return !string.IsNullOrEmpty(path = (lookup.TryGetValue(tiletype, out value) ? value.Debris : ""));
        }

        public bool TryGetCustomDebrisImpactSfx(out string sfxEvent, char tiletype)
        {
            TerrainType value;
            return !string.IsNullOrEmpty(sfxEvent =
                (lookup.TryGetValue(tiletype, out value) ? value.DebrisImpactSfx : ""));
        }
    }
}
