using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    public static class PlatformLineCollision
    {
        public static bool Check(global::Celeste.Core.Geometry.Bounds bounds, Vector2 from, Vector2 to) =>
            RectLine(bounds, from, to);

        public static bool Check(global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld world,
            Vector2 from, Vector2 to)
        {
            foreach (var platform in world.Platforms)
            {
                if (!platform.Collidable || platform.IsJumpThru) continue;
                if (platform.TileGrid != null)
                {
                    if (GridLine(platform, from, to)) return true;
                }
                else
                    foreach (global::Celeste.Core.Geometry.Bounds region in platform.Regions)
                        if (RectLine(platform.WorldBounds(region), from, to))
                            return true;
            }

            return false;
        }

        private static bool GridLine(global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform platform,
            Vector2 from, Vector2 to)
        {
            // Grid.Collide(line) has no enclosing rectangle early-out. In
            // particular, negative cell coordinates truncate toward zero.
            from = (from - platform.Position) / new Vector2(8);
            to = (to - platform.Position) / new Vector2(8);
            bool steep = Math.Abs(to.Y - from.Y) > Math.Abs(to.X - from.X);
            if (steep)
            {
                from = new Vector2(from.Y, from.X);
                to = new Vector2(to.Y, to.X);
            }

            if (from.X > to.X)
            {
                var swap = from;
                from = to;
                to = swap;
            }

            float error = 0;
            float slope = Math.Abs(to.Y - from.Y) / (to.X - from.X);
            int step = from.Y < to.Y ? 1 : -1, y = (int)from.Y, end = (int)to.X;
            var grid = platform.TileGrid;
            for (int x = (int)from.X; x <= end; x++)
            {
                int tx = steep ? y : x, ty = steep ? x : y;
                if (tx >= 0 && ty >= 0 && tx < grid.Columns && ty < grid.Rows && grid[tx, ty] != '0') return true;
                error += slope;
                if (error >= .5f)
                {
                    y += step;
                    error -= 1;
                }
            }

            return false;
        }

        private static int Sector(global::Celeste.Core.Geometry.Bounds bounds, Vector2 point)
        {
            int sector = 0;
            if (point.X < bounds.X) sector |= 1;
            else if (point.X >= bounds.Right) sector |= 2;
            if (point.Y < bounds.Y) sector |= 4;
            else if (point.Y >= bounds.Bottom) sector |= 8;
            return sector;
        }

        private static bool RectLine(global::Celeste.Core.Geometry.Bounds bounds, Vector2 from, Vector2 to)
        {
            int a = Sector(bounds, from), b = Sector(bounds, to);
            if (a == 0 || b == 0) return true;
            if ((a & b) != 0) return false;
            int both = a | b;
            if ((both & 4) != 0 &&
                Line(new Vector2(bounds.X, bounds.Y), new Vector2(bounds.Right, bounds.Y), from, to)) return true;
            if ((both & 8) != 0 && Line(new Vector2(bounds.X, bounds.Bottom), new Vector2(bounds.Right, bounds.Bottom),
                    from, to)) return true;
            if ((both & 1) != 0 &&
                Line(new Vector2(bounds.X, bounds.Y), new Vector2(bounds.X, bounds.Bottom), from, to)) return true;
            return (both & 2) != 0 && Line(new Vector2(bounds.Right, bounds.Y),
                new Vector2(bounds.Right, bounds.Bottom), from, to);
        }

        private static bool Line(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
        {
            var a = a2 - a1;
            var b = b2 - b1;
            float cross = a.X * b.Y - a.Y * b.X;
            if (cross == 0) return false;
            var difference = b1 - a1;
            float alongA = (difference.X * b.Y - difference.Y * b.X) / cross;
            if (alongA < 0 || alongA > 1) return false;
            float alongB = (difference.X * a.Y - difference.Y * a.X) / cross;
            return !(alongB < 0 || alongB > 1);
        }
    }
}
