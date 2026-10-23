using System;
using Celeste.Core.Geometry;

namespace Celeste.Graphics.Scene.Diagnostics
{
    public static class SceneTileScopeMask
    {
        // Caller retains storage. Rebuild when the Scene view or tile-grid extent changes.
        // TileGrid data is already generated for the chapter; this never invokes its renderer.
        public static void Fill(SceneTileScope scope, in Bounds sceneWorld,
            ReadOnlySpan<IntRect> roomWorldBounds, in Bounds gridWorld,
            int columns, int rows, int tileWidth, int tileHeight, Span<byte> mask)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (tileWidth <= 0 || tileHeight <= 0 || columns < 0 || rows < 0 ||
                gridWorld.Width !=
                (double)columns * tileWidth || /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                gridWorld.Height != (double)rows * tileHeight)
                throw new ArgumentOutOfRangeException(nameof(gridWorld));
            var count = checked(columns * rows);
            if (mask.Length != count) throw new ArgumentException("One mask byte per tile is required.", nameof(mask));
            mask.Clear();
            switch (scope)
            {
                case SceneTileScope.EntireMap:
                    mask.Fill(1);
                    return;
                case SceneTileScope.VisibleWorld:
                    Include(in sceneWorld, in gridWorld, tileWidth, tileHeight, columns, rows, mask);
                    return;
                case SceneTileScope.VisibleRooms:
                    for (var i = 0; i < roomWorldBounds.Length; i++)
                    {
                        var room = roomWorldBounds[i];
                        if (room is { Width: > 0, Height: > 0 } && sceneWorld.Width > 0 &&
                            sceneWorld.Height > 0 &&
                            new Bounds(room.X, room.Y, room.Width, room.Height).Intersects(sceneWorld))
                            Include(new(room.X, room.Y, room.Width, room.Height), in gridWorld, tileWidth,
                                tileHeight, columns, rows, mask);
                    }

                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scope));
            }
        }

        private static void Include(in Bounds area, in Bounds grid, int tileWidth, int tileHeight,
            int columns, int rows, Span<byte> mask)
        {
            if (area.Width <= 0 || area.Height <= 0) return;
            var left = Math.Max((double)area.X, grid.X);
            var top = Math.Max((double)area.Y, grid.Y);
            var right = Math.Min(area.Right, (double)grid.Right);
            var bottom = Math.Min(area.Bottom, (double)grid.Bottom);
            if (left >= right || top >= bottom) return;
            var x0 = (int)((left - grid.X) / tileWidth);
            var y0 = (int)((top - grid.Y) / tileHeight);
            var x1 = (int)Math.Ceiling((right - grid.X) / tileWidth);
            var y1 = (int)Math.Ceiling((bottom - grid.Y) / tileHeight);
            for (var x = x0; x < Math.Min(x1, columns); x++)
                mask.Slice(x * rows + y0, Math.Min(y1, rows) - y0).Fill(1);
        }
    }
}
