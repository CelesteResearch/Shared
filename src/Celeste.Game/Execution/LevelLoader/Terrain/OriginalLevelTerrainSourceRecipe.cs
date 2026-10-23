using System.Collections.Generic;
using System.Text.RegularExpressions;
using Celeste.Core.Collections;
using Celeste.Core.Maps.Grids;
using Celeste.Core.Geometry;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Graphics;

namespace Celeste.Game.Execution.LevelLoader.Terrain
{
// Loader source locals become the actual maps borrowed by BackgroundTiles and SolidTiles.
    public static class OriginalLevelTerrainSourceRecipe
    {
        public static (VirtualMap<char> Background, VirtualMap<char> Solids) Build(IntRect tileBounds,
            OriginalChapterMapData mapData,
            OriginalGameGraphicsResources graphicsResources)
            => Build(tileBounds, mapData, graphicsResources, VirtualMapFactory.Instance);

        public static (VirtualMap<char> Background, VirtualMap<char> Solids) Build(IntRect tileBounds,
            OriginalChapterMapData mapData, OriginalGameGraphicsResources graphicsResources,
            IVirtualMapFactory factory)
        {
            graphicsResources.ForegroundAutotiler.LevelBounds.Clear();
            VirtualMap<char> virtualMap = factory.Create<char>(tileBounds.Width, tileBounds.Height, '0');
            VirtualMap<char> virtualMap2 = factory.Create<char>(tileBounds.Width, tileBounds.Height, '0');
            VirtualMap<bool> virtualMap3 = factory.Create<bool>(tileBounds.Width, tileBounds.Height, emptyValue: false);
            Regex regex = new Regex("\\r\\n|\\n\\r|\\n|\\r");
            foreach (OriginalLevelRoomData level in mapData.Levels)
            {
                int left = level.TileBounds.Left;
                int top = level.TileBounds.Top;
                string[] array = regex.Split(level.Bg);
                for (int i = top; i < top + array.Length; i++)
                {
                    for (int j = left; j < left + array[i - top].Length; j++)
                    {
                        virtualMap[j - tileBounds.X, i - tileBounds.Y] = array[i - top][j - left];
                    }
                }

                string[] array2 = regex.Split(level.Solids);
                for (int k = top; k < top + array2.Length; k++)
                {
                    for (int l = left; l < left + array2[k - top].Length; l++)
                    {
                        virtualMap2[l - tileBounds.X, k - tileBounds.Y] = array2[k - top][l - left];
                    }
                }

                for (int m = level.TileBounds.Left; m < level.TileBounds.Right; m++)
                {
                    for (int n = level.TileBounds.Top; n < level.TileBounds.Bottom; n++)
                    {
                        virtualMap3[m - tileBounds.Left, n - tileBounds.Top] = true;
                    }
                }

                graphicsResources.ForegroundAutotiler.LevelBounds.Add(new IntRect(level.TileBounds.X - tileBounds.X,
                    level.TileBounds.Y - tileBounds.Y, level.TileBounds.Width, level.TileBounds.Height));
            }

            foreach (IntRect item in mapData.Filler)
            {
                for (int num = item.Left; num < item.Right; num++)
                {
                    for (int num2 = item.Top; num2 < item.Bottom; num2++)
                    {
                        char c = '0';
                        if (item.Top - tileBounds.Y > 0)
                        {
                            char c2 = virtualMap2[num - tileBounds.X, item.Top - tileBounds.Y - 1];
                            if (c2 != '0')
                            {
                                c = c2;
                            }
                        }

                        if (c == '0' && item.Left - tileBounds.X > 0)
                        {
                            char c3 = virtualMap2[item.Left - tileBounds.X - 1, num2 - tileBounds.Y];
                            if (c3 != '0')
                            {
                                c = c3;
                            }
                        }

                        if (c == '0' && item.Right - tileBounds.X < tileBounds.Width - 1)
                        {
                            char c4 = virtualMap2[item.Right - tileBounds.X, num2 - tileBounds.Y];
                            if (c4 != '0')
                            {
                                c = c4;
                            }
                        }

                        if (c == '0' && item.Bottom - tileBounds.Y < tileBounds.Height - 1)
                        {
                            char c5 = virtualMap2[num - tileBounds.X, item.Bottom - tileBounds.Y];
                            if (c5 != '0')
                            {
                                c = c5;
                            }
                        }

                        if (c == '0')
                        {
                            c = '1';
                        }

                        virtualMap2[num - tileBounds.X, num2 - tileBounds.Y] = c;
                        virtualMap3[num - tileBounds.X, num2 - tileBounds.Y] = true;
                    }
                }
            }

            foreach (OriginalLevelRoomData level2 in mapData.Levels)
            {
                for (int num3 = level2.TileBounds.Left; num3 < level2.TileBounds.Right; num3++)
                {
                    int top2 = level2.TileBounds.Top;
                    char value = virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y];
                    for (int num4 = 1;
                         num4 < 4 && !virtualMap3[num3 - tileBounds.X, top2 - tileBounds.Y - num4];
                         num4++)
                    {
                        virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y - num4] = value;
                    }

                    top2 = level2.TileBounds.Bottom - 1;
                    char value2 = virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y];
                    for (int num5 = 1;
                         num5 < 4 && !virtualMap3[num3 - tileBounds.X, top2 - tileBounds.Y + num5];
                         num5++)
                    {
                        virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y + num5] = value2;
                    }
                }

                for (int num6 = level2.TileBounds.Top - 4; num6 < level2.TileBounds.Bottom + 4; num6++)
                {
                    int left2 = level2.TileBounds.Left;
                    char value3 = virtualMap[left2 - tileBounds.X, num6 - tileBounds.Y];
                    for (int num7 = 1;
                         num7 < 4 && !virtualMap3[left2 - tileBounds.X - num7, num6 - tileBounds.Y];
                         num7++)
                    {
                        virtualMap[left2 - tileBounds.X - num7, num6 - tileBounds.Y] = value3;
                    }

                    left2 = level2.TileBounds.Right - 1;
                    char value4 = virtualMap[left2 - tileBounds.X, num6 - tileBounds.Y];
                    for (int num8 = 1;
                         num8 < 4 && !virtualMap3[left2 - tileBounds.X + num8, num6 - tileBounds.Y];
                         num8++)
                    {
                        virtualMap[left2 - tileBounds.X + num8, num6 - tileBounds.Y] = value4;
                    }
                }
            }

            foreach (OriginalLevelRoomData level3 in mapData.Levels)
            {
                for (int num9 = level3.TileBounds.Left; num9 < level3.TileBounds.Right; num9++)
                {
                    int top3 = level3.TileBounds.Top;
                    if (virtualMap2[num9 - tileBounds.X, top3 - tileBounds.Y] == '0')
                    {
                        for (int num10 = 1; num10 < 8; num10++)
                        {
                            virtualMap3[num9 - tileBounds.X, top3 - tileBounds.Y - num10] = true;
                        }
                    }

                    top3 = level3.TileBounds.Bottom - 1;
                    if (virtualMap2[num9 - tileBounds.X, top3 - tileBounds.Y] == '0')
                    {
                        for (int num11 = 1; num11 < 8; num11++)
                        {
                            virtualMap3[num9 - tileBounds.X, top3 - tileBounds.Y + num11] = true;
                        }
                    }
                }
            }

            foreach (OriginalLevelRoomData level4 in mapData.Levels)
            {
                for (int num12 = level4.TileBounds.Left; num12 < level4.TileBounds.Right; num12++)
                {
                    int top4 = level4.TileBounds.Top;
                    char value5 = virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y];
                    for (int num13 = 1;
                         num13 < 4 && !virtualMap3[num12 - tileBounds.X, top4 - tileBounds.Y - num13];
                         num13++)
                    {
                        virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y - num13] = value5;
                    }

                    top4 = level4.TileBounds.Bottom - 1;
                    char value6 = virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y];
                    for (int num14 = 1;
                         num14 < 4 && !virtualMap3[num12 - tileBounds.X, top4 - tileBounds.Y + num14];
                         num14++)
                    {
                        virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y + num14] = value6;
                    }
                }

                for (int num15 = level4.TileBounds.Top - 4; num15 < level4.TileBounds.Bottom + 4; num15++)
                {
                    int left3 = level4.TileBounds.Left;
                    char value7 = virtualMap2[left3 - tileBounds.X, num15 - tileBounds.Y];
                    for (int num16 = 1;
                         num16 < 4 && !virtualMap3[left3 - tileBounds.X - num16, num15 - tileBounds.Y];
                         num16++)
                    {
                        virtualMap2[left3 - tileBounds.X - num16, num15 - tileBounds.Y] = value7;
                    }

                    left3 = level4.TileBounds.Right - 1;
                    char value8 = virtualMap2[left3 - tileBounds.X, num15 - tileBounds.Y];
                    for (int num17 = 1;
                         num17 < 4 && !virtualMap3[left3 - tileBounds.X + num17, num15 - tileBounds.Y];
                         num17++)
                    {
                        virtualMap2[left3 - tileBounds.X + num17, num15 - tileBounds.Y] = value8;
                    }
                }
            }

            return (virtualMap, virtualMap2);
        }
    }
}
