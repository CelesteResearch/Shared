using System;
using System.Collections.Generic;
using Celeste.Core.Geometry;
using System.Numerics;
using Celeste.Core.Collections;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;

namespace Celeste.Graphics.Scene.Diagnostics
{
    public sealed class TileGridGeometrySnapshot
    {
        private VirtualMap<AtlasEntry> map;
        private TileGridCellGeometry[] cells = Array.Empty<TileGridCellGeometry>();
        private int cellCount;
        private static readonly List<TileGridCellGeometry> invalidIndexCells = new();
        private readonly List<int> activeSegmentRows = new();
        private readonly List<IntRect> columnRanges = new();
        private readonly AtlasQuadTemplateCache quadTemplates = new();
        private int tileWidth, tileHeight;
        public int Count => cellCount;

        public TileGridCellGeometry this[int index]
        {
            get
            {
                if ((uint)index >= (uint)cellCount) return invalidIndexCells[index];
                return cells[index];
            }
        }

        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public int TileWidth => tileWidth;
        public int TileHeight => tileHeight;

        public bool Refresh(TileGrid grid, ReadOnlySpan<IntRect> ranges)
        {
            bool reset = !ReferenceEquals(map, grid.Tiles) || tileWidth != grid.TileWidth ||
                         tileHeight != grid.TileHeight;
            if (reset)
            {
                map = grid.Tiles;
                Columns = map.Columns;
                Rows = map.Rows;
                tileWidth = grid.TileWidth;
                tileHeight = grid.TileHeight;
                Array.Clear(cells, 0, cellCount);
                cellCount = 0;
            }

            quadTemplates.Clear();
            bool changed = reset;
            int count = 0;
            var color = grid.Color * grid.Alpha;
            // Native TileGrid.RenderAt visits x, then y. Skip empty sparse segments,
            // but consume each live segment on every refresh to observe in-place edits.
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

                            var entry = segment == null
                                ? map.EmptyValue
                                : segment[x % VirtualMap<AtlasEntry>.SegmentSize,
                                    y % VirtualMap<AtlasEntry>.SegmentSize];
                            if (entry == null) continue;
                            long index = (long)x * Rows + y;
                            var texture = entry.ReadTextureForSpriteBatch();
                            if (count == cellCount)
                            {
                                var cell = new TileGridCellGeometry(index, entry, texture,
                                    new Vector2(x * tileWidth, y * tileHeight), color, quadTemplates);
                                if (cellCount == cells.Length)
                                {
                                    int capacity = cells.Length > int.MaxValue / 2
                                        ? int.MaxValue
                                        : Math.Max(4, cells.Length * 2);
                                    Array.Resize(ref cells, capacity);
                                }

                                cells[cellCount] = cell;
                                cellCount++;
                                changed = true;
                            }
                            else
                            {
                                if ((uint)count >= (uint)cellCount) _ = invalidIndexCells[count];
                                ref readonly var existingCell = ref cells[count];
                                if (!existingCell.MatchesSnapshot(index, entry, texture, color))
                                {
                                    var cell = new TileGridCellGeometry(index, entry, texture,
                                        new Vector2(x * tileWidth, y * tileHeight), color, quadTemplates);
                                    if ((uint)count >= (uint)cellCount) _ = invalidIndexCells[count];
                                    cells[count] = cell;
                                    changed = true;
                                }
                            }

                            count++;
                        }
                    }
                }
            }

            if (count != cellCount)
            {
                if (count > cellCount) invalidIndexCells.RemoveRange(count, cellCount - count);
                Array.Clear(cells, count, cellCount - count);
                cellCount = count;
                changed = true;
            }

            return changed;
        }
    }
}
