using System;
using System.Collections.Generic;
using Celeste.Core.Geometry;
using System.Numerics;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display;

namespace Celeste.Graphics.Scene.Diagnostics
{
    public sealed class AnimatedTileGeometrySnapshot
    {
        private readonly List<AnimatedTileCellGeometry> cells = new();
        private readonly List<int> activeSegmentRows = new();
        private readonly List<IntRect> columnRanges = new();
        public int Count => cells.Count;
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public AnimatedTileCellGeometry this[int index] => cells[index];

        // Consume current native animation state, without updating or rendering the component.
        // Sparse segments are rechecked each refresh, including in-place edits.
        public bool Refresh(AnimatedTiles animated, ReadOnlySpan<IntRect> ranges)
        {
            var map = animated.Sprites;
            bool changed = Rows != map.Rows || Columns != map.Columns;
            Rows = map.Rows;
            Columns = map.Columns;
            int count = 0;
            var color = animated.Color * animated.Alpha;
            int firstX = map.Columns, lastX = 0;
            foreach (var range in ranges)
                if (range.Width > 0 && range.Height > 0)
                {
                    firstX = Math.Min(firstX, Math.Max(0, range.Left));
                    lastX = Math.Max(lastX, Math.Min(map.Columns, range.Right));
                }

            for (int sx = firstX / 50; sx * 50 < lastX; sx++)
            {
                int left = Math.Max(firstX, sx * 50), right = Math.Min(lastX, (sx + 1) * 50);
                int firstSegmentY = map.SegmentRows, lastSegmentY = 0;
                if (ranges.Length == 1)
                {
                    firstSegmentY = Math.Max(0, ranges[0].Top) / 50;
                    lastSegmentY = (Math.Min(map.Rows, ranges[0].Bottom) + 49) / 50;
                }
                else
                {
                    foreach (var range in ranges)
                        if (range.Width > 0 && range.Height > 0 && range.Left < right && range.Right > left)
                        {
                            firstSegmentY = Math.Min(firstSegmentY, Math.Max(0, range.Top) / 50);
                            lastSegmentY = Math.Max(lastSegmentY, (Math.Min(map.Rows, range.Bottom) + 49) / 50);
                        }
                }

                activeSegmentRows.Clear();
                if (ranges.Length == 1)
                {
                    for (int sy = firstSegmentY; sy < lastSegmentY; sy++)
                        if (map.EmptyValue != null || map.GetSegment(sx, sy) != null)
                            activeSegmentRows.Add(sy);
                }
                else
                {
                    for (int sy = firstSegmentY; sy < lastSegmentY; sy++)
                    {
                        bool selected = false;
                        foreach (var range in ranges)
                            if (range.Left < right && range.Right > left && range.Top < (sy + 1) * 50 &&
                                range.Bottom > sy * 50)
                            {
                                selected = true;
                                break;
                            }

                        if (selected && (map.EmptyValue != null || map.GetSegment(sx, sy) != null))
                            activeSegmentRows.Add(sy);
                    }
                }

                if (activeSegmentRows.Count == 0) continue;
                for (int x = left; x < right; x++)
                {
                    int firstY = map.Rows, lastY = 0;
                    bool singleRange = ranges.Length == 1;
                    if (singleRange)
                    {
                        firstY = Math.Max(0, ranges[0].Top);
                        lastY = Math.Min(map.Rows, ranges[0].Bottom);
                    }
                    else
                    {
                        columnRanges.Clear();
                        foreach (var range in ranges)
                            if (range.Width > 0 && range.Height > 0 && x >= range.Left && x < range.Right)
                            {
                                int top = Math.Max(0, range.Top), bottom = Math.Min(map.Rows, range.Bottom);
                                if (top >= bottom) continue;
                                int index = 0;
                                while (index < columnRanges.Count && columnRanges[index].Bottom < top) index++;
                                while (index < columnRanges.Count && columnRanges[index].Top <= bottom)
                                {
                                    top = Math.Min(top, columnRanges[index].Top);
                                    bottom = Math.Max(bottom, columnRanges[index].Bottom);
                                    columnRanges.RemoveAt(index);
                                }

                                columnRanges.Insert(index, new IntRect(0, top, 1, bottom - top));
                            }

                        if (columnRanges.Count == 0) continue;
                        firstY = columnRanges[0].Top;
                        lastY = columnRanges[columnRanges.Count - 1].Bottom;
                    }

                    int rangeIndex = 0;
                    foreach (int sy in activeSegmentRows)
                    {
                        int top = Math.Max(firstY, sy * 50), bottom = Math.Min(lastY, (sy + 1) * 50);
                        if (top >= bottom) continue;
                        var segment = map.GetSegment(x / 50, sy);
                        if (segment == null && map.EmptyValue == null) continue;
                        for (int y = top; y < bottom; y++)
                        {
                            if (!singleRange)
                            {
                                while (rangeIndex < columnRanges.Count && columnRanges[rangeIndex].Bottom <= y)
                                    rangeIndex++;
                                if (rangeIndex == columnRanges.Count || y < columnRanges[rangeIndex].Top) continue;
                            }

                            var overlays = segment == null ? map.EmptyValue : segment[x % 50, y % 50];
                            if (overlays == null) continue;
                            for (int i = 0; i < overlays.Count; i++)
                            {
                                var tile = overlays[i];
                                var animation = animated.Bank.Animations[tile.AnimationID];
                                var region = animation.Frames[(int)tile.Frame % animation.Frames.Length];
                                var position = animation.Offset + new Vector2(x + 0.5f, y + 0.5f) * 8f;
                                var draw = new AtlasTextureDraw(region, position, animation.Origin, color, tile.Scale);
                                if (count == cells.Count)
                                {
                                    cells.Add(new AnimatedTileCellGeometry((long)x * map.Rows + y, in draw));
                                    changed = true;
                                }
                                else if (!cells[count].Matches((long)x * map.Rows + y, in draw))
                                {
                                    cells[count] = new AnimatedTileCellGeometry((long)x * map.Rows + y, in draw);
                                    changed = true;
                                }

                                count++;
                            }
                        }
                    }
                }
            }

            if (count != cells.Count)
            {
                cells.RemoveRange(count, cells.Count - count);
                changed = true;
            }

            return changed;
        }
    }
}
