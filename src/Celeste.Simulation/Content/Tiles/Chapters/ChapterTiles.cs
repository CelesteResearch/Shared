using System.Collections.Generic;
using System.Text.RegularExpressions;
using Celeste.Core.Collections;
using Celeste.Core.Geometry;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Content.Tiles.Chapters
{
    public sealed class ChapterTiles
    {
        public IntRect Bounds;
        public VirtualMap<char> Background, Solids;
        public List<IntRect> LevelBounds;

        public static ChapterTiles Build(ChapterSource mapData)
        {
            var levelBounds = new List<IntRect>();
            var tileBounds = mapData.TileBounds;
            levelBounds.Clear();
            var virtualMap = new VirtualMap<char>(tileBounds.Width, tileBounds.Height, '0');
            var virtualMap2 = new VirtualMap<char>(tileBounds.Width, tileBounds.Height, '0');
            var virtualMap3 = new VirtualMap<bool>(tileBounds.Width, tileBounds.Height);
            var regex = new Regex("\\r\\n|\\n\\r|\\n|\\r");
            foreach (var level in mapData.Levels)
            {
                var left = level.TileBounds.Left;
                var top = level.TileBounds.Top;
                var array = regex.Split(level.Bg);
                for (var i = top; i < top + array.Length; i++)
                for (var j = left; j < left + array[i - top].Length; j++)
                    virtualMap[j - tileBounds.X, i - tileBounds.Y] = array[i - top][j - left];

                var array2 = regex.Split(level.Solids);
                for (var k = top; k < top + array2.Length; k++)
                for (var l = left; l < left + array2[k - top].Length; l++)
                    virtualMap2[l - tileBounds.X, k - tileBounds.Y] = array2[k - top][l - left];

                for (var m = level.TileBounds.Left; m < level.TileBounds.Right; m++)
                for (var n = level.TileBounds.Top; n < level.TileBounds.Bottom; n++)
                    virtualMap3[m - tileBounds.Left, n - tileBounds.Top] = true;

                levelBounds.Add(new(level.TileBounds.X - tileBounds.X,
                    level.TileBounds.Y - tileBounds.Y,
                    level.TileBounds.Width, level.TileBounds.Height));
            }

            foreach (var item in mapData.Filler)
                for (var num = item.Left; num < item.Right; num++)
                for (var num2 = item.Top; num2 < item.Bottom; num2++)
                {
                    var c = '0';
                    if (item.Top - tileBounds.Y > 0)
                    {
                        var c2 = virtualMap2[num - tileBounds.X, item.Top - tileBounds.Y - 1];
                        if (c2 != '0') c = c2;
                    }

                    if (c == '0' && item.Left - tileBounds.X > 0)
                    {
                        var c3 = virtualMap2[item.Left - tileBounds.X - 1, num2 - tileBounds.Y];
                        if (c3 != '0') c = c3;
                    }

                    if (c == '0' && item.Right - tileBounds.X < tileBounds.Width - 1)
                    {
                        var c4 = virtualMap2[item.Right - tileBounds.X, num2 - tileBounds.Y];
                        if (c4 != '0') c = c4;
                    }

                    if (c == '0' && item.Bottom - tileBounds.Y < tileBounds.Height - 1)
                    {
                        var c5 = virtualMap2[num - tileBounds.X, item.Bottom - tileBounds.Y];
                        if (c5 != '0') c = c5;
                    }

                    if (c == '0') c = '1';

                    virtualMap2[num - tileBounds.X, num2 - tileBounds.Y] = c;
                    virtualMap3[num - tileBounds.X, num2 - tileBounds.Y] = true;
                }

            foreach (var level2 in mapData.Levels)
            {
                for (var num3 = level2.TileBounds.Left; num3 < level2.TileBounds.Right; num3++)
                {
                    var top2 = level2.TileBounds.Top;
                    var value = virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y];
                    for (var num4 = 1;
                         num4 < 4 && !virtualMap3[num3 - tileBounds.X, top2 - tileBounds.Y - num4];
                         num4++)
                        virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y - num4] = value;

                    top2 = level2.TileBounds.Bottom - 1;
                    var value2 = virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y];
                    for (var num5 = 1;
                         num5 < 4 && !virtualMap3[num3 - tileBounds.X, top2 - tileBounds.Y + num5];
                         num5++)
                        virtualMap[num3 - tileBounds.X, top2 - tileBounds.Y + num5] = value2;
                }

                for (var num6 = level2.TileBounds.Top - 4; num6 < level2.TileBounds.Bottom + 4; num6++)
                {
                    var left2 = level2.TileBounds.Left;
                    var value3 = virtualMap[left2 - tileBounds.X, num6 - tileBounds.Y];
                    for (var num7 = 1;
                         num7 < 4 && !virtualMap3[left2 - tileBounds.X - num7, num6 - tileBounds.Y];
                         num7++)
                        virtualMap[left2 - tileBounds.X - num7, num6 - tileBounds.Y] = value3;

                    left2 = level2.TileBounds.Right - 1;
                    var value4 = virtualMap[left2 - tileBounds.X, num6 - tileBounds.Y];
                    for (var num8 = 1;
                         num8 < 4 && !virtualMap3[left2 - tileBounds.X + num8, num6 - tileBounds.Y];
                         num8++)
                        virtualMap[left2 - tileBounds.X + num8, num6 - tileBounds.Y] = value4;
                }
            }

            foreach (var level3 in mapData.Levels)
                for (var num9 = level3.TileBounds.Left; num9 < level3.TileBounds.Right; num9++)
                {
                    var top3 = level3.TileBounds.Top;
                    if (virtualMap2[num9 - tileBounds.X, top3 - tileBounds.Y] == '0')
                        for (var num10 = 1; num10 < 8; num10++)
                            virtualMap3[num9 - tileBounds.X, top3 - tileBounds.Y - num10] = true;

                    top3 = level3.TileBounds.Bottom - 1;
                    if (virtualMap2[num9 - tileBounds.X, top3 - tileBounds.Y] == '0')
                        for (var num11 = 1; num11 < 8; num11++)
                            virtualMap3[num9 - tileBounds.X, top3 - tileBounds.Y + num11] = true;
                }

            foreach (var level4 in mapData.Levels)
            {
                for (var num12 = level4.TileBounds.Left; num12 < level4.TileBounds.Right; num12++)
                {
                    var top4 = level4.TileBounds.Top;
                    var value5 = virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y];
                    for (var num13 = 1;
                         num13 < 4 && !virtualMap3[num12 - tileBounds.X, top4 - tileBounds.Y - num13];
                         num13++)
                        virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y - num13] = value5;

                    top4 = level4.TileBounds.Bottom - 1;
                    var value6 = virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y];
                    for (var num14 = 1;
                         num14 < 4 && !virtualMap3[num12 - tileBounds.X, top4 - tileBounds.Y + num14];
                         num14++)
                        virtualMap2[num12 - tileBounds.X, top4 - tileBounds.Y + num14] = value6;
                }

                for (var num15 = level4.TileBounds.Top - 4; num15 < level4.TileBounds.Bottom + 4; num15++)
                {
                    var left3 = level4.TileBounds.Left;
                    var value7 = virtualMap2[left3 - tileBounds.X, num15 - tileBounds.Y];
                    for (var num16 = 1;
                         num16 < 4 && !virtualMap3[left3 - tileBounds.X - num16, num15 - tileBounds.Y];
                         num16++)
                        virtualMap2[left3 - tileBounds.X - num16, num15 - tileBounds.Y] = value7;

                    left3 = level4.TileBounds.Right - 1;
                    var value8 = virtualMap2[left3 - tileBounds.X, num15 - tileBounds.Y];
                    for (var num17 = 1;
                         num17 < 4 && !virtualMap3[left3 - tileBounds.X + num17, num15 - tileBounds.Y];
                         num17++)
                        virtualMap2[left3 - tileBounds.X + num17, num15 - tileBounds.Y] = value8;
                }
            }

            return new()
                { Bounds = tileBounds, Background = virtualMap, Solids = virtualMap2, LevelBounds = levelBounds };
        }
    }
}
