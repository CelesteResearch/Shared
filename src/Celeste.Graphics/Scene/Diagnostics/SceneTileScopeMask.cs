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
            if (tileWidth <= 0 || tileHeight <= 0 || columns < 0 || rows < 0 ||
                gridWorld.Width != (double)columns * tileWidth || gridWorld.Height != (double)rows * tileHeight)
                throw new ArgumentOutOfRangeException(nameof(gridWorld));
            int count = checked(columns * rows);
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
                    for (int i = 0; i < roomWorldBounds.Length; i++)
                    {
                        IntRect room = roomWorldBounds[i];
                        if (room.Width > 0 && room.Height > 0 && sceneWorld.Width > 0 &&
                            sceneWorld.Height > 0 &&
                            new Bounds(room.X, room.Y, room.Width, room.Height).Intersects(sceneWorld))
                            Include(new Bounds(room.X, room.Y, room.Width, room.Height), in gridWorld, tileWidth,
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
            double left = Math.Max((double)area.X, grid.X);
            double top = Math.Max((double)area.Y, grid.Y);
            double right = Math.Min((double)area.Right, (double)grid.Right);
            double bottom = Math.Min((double)area.Bottom, (double)grid.Bottom);
            if (left >= right || top >= bottom) return;
            int x0 = (int)((left - grid.X) / tileWidth);
            int y0 = (int)((top - grid.Y) / tileHeight);
            int x1 = (int)Math.Ceiling((right - grid.X) / tileWidth);
            int y1 = (int)Math.Ceiling((bottom - grid.Y) / tileHeight);
            for (int x = x0; x < Math.Min(x1, columns); x++)
                mask.Slice(x * rows + y0, Math.Min(y1, rows) - y0).Fill(1);
        }
    }
}
