using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Diagnostics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;

namespace Celeste.Simulation.Gameplay.Enemies.Seeker
{
    public sealed class SeekerPathfinder
    {
        public readonly struct Point : IEquatable<Point>
        {
            public readonly int X, Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool Equals(Point other)
            {
                return X == other.X && Y == other.Y;
            }

            public override bool Equals(object value)
            {
                return value is Point other && Equals(other);
            }

            public override int GetHashCode()
            {
                return unchecked((X * 397) ^ Y);
            }

            public static bool operator ==(Point a, Point b)
            {
                return a.Equals(b);
            }

            public static bool operator !=(Point a, Point b)
            {
                return !a.Equals(b);
            }
        }


        private struct Tile
        {
            public bool Solid;

            public int Cost;

            public Point? Parent;
        }

        private class PointMapComparer : IComparer<Point>
        {
            private readonly Tile[,] map;

            public PointMapComparer(Tile[,] map)
            {
                this.map = map;
            }

            public int Compare(Point a, Point b)
            {
                return map[b.X, b.Y].Cost - map[a.X, a.Y].Cost;
            }
        }

        private static readonly Point[] directions =
        [
            new(1, 0),
            new(0, 1),
            new(-1, 0),
            new(0, -1),
        ];

        private const int MapSize = 200;

        private readonly ISeekerPathfinderWorld level;

        private readonly Tile[,] map;

        private readonly List<Point> active = [];

        private readonly PointMapComparer comparer;

        public bool DebugRenderEnabled;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public List<Vector2> LastPath => lastPath;
        public Point LastStart => debugLastStart;
        public Point LastEnd => debugLastEnd;

        private List<Vector2> lastPath;

        private Point debugLastStart;

        private Point debugLastEnd;

        public SeekerPathfinder(ISeekerPathfinderWorld level)
        {
            this.level = level;
            map = new Tile[200, 200];
            comparer = new(map);
        }

        public bool Find(ref List<Vector2> path, Vector2 from, Vector2 to, bool fewerTurns = true, bool logging = false)
        {
            lastPath = null;
            var num = level.RoomX / 8;
            var num2 = level.RoomY / 8;
            var num3 = level.RoomWidth / 8;
            var num4 = level.RoomHeight / 8;
            var levelSolidOffset = new Point(level.SolidOffsetX, level.SolidOffsetY);
            for (var i = 0; i < num3; i++)
            for (var j = 0; j < num4; j++)
            {
                map[i, j].Solid = level.SolidTile(i + levelSolidOffset.X, j + levelSolidOffset.Y) != '0';
                map[i, j].Cost = int.MaxValue;
                map[i, j].Parent = null;
            }

            foreach (var identity in level.Solids)
            {
                var entity = (ISourceEntityCollider)identity;
                if (!entity.Collidable || entity.Collider is not HitboxColliderGeometry) continue;

                var k = (int)Math.Floor((entity.Position.X + entity.Collider.Left) / 8f);
                for (var num5 = (int)Math.Ceiling((entity.Position.X + entity.Collider.Right) / 8f); k < num5; k++)
                {
                    var l = (int)Math.Floor((entity.Position.Y + entity.Collider.Top) / 8f);
                    for (var num6 = (int)Math.Ceiling((entity.Position.Y + entity.Collider.Bottom) / 8f); l < num6; l++)
                    {
                        var num7 = k - num;
                        var num8 = l - num2;
                        if (num7 >= 0 && num8 >= 0 && num7 < num3 && num8 < num4) map[num7, num8].Solid = true;
                    }
                }
            }

            var point = debugLastStart =
                new((int)Math.Floor(from.X / 8f) - num, (int)Math.Floor(from.Y / 8f) - num2);
            var point2 = debugLastEnd =
                new((int)Math.Floor(to.X / 8f) - num, (int)Math.Floor(to.Y / 8f) - num2);
            if (point.X < 0 || point.Y < 0 || point.X >= num3 || point.Y >= num4 || point2.X < 0 || point2.Y < 0 ||
                point2.X >= num3 || point2.Y >= num4)
            {
                if (logging) SourceDebugLog.Log("PF: FAILED - Start or End outside the level bounds");

                return false;
            }

            if (map[point.X, point.Y].Solid)
            {
                if (logging) SourceDebugLog.Log("PF: FAILED - Start inside a solid");

                return false;
            }

            if (map[point2.X, point2.Y].Solid)
            {
                if (logging) SourceDebugLog.Log("PF: FAILED - End inside a solid");

                return false;
            }

            active.Clear();
            active.Add(point);
            map[point.X, point.Y].Cost = 0;
            var flag = false;
            while (active.Count > 0 && !flag)
            {
                var value = active[active.Count - 1];
                active.RemoveAt(active.Count - 1);
                for (var m = 0; m < 4; m++)
                {
                    var point3 = new Point(directions[m].X, directions[m].Y);
                    var point4 = new Point(value.X + point3.X, value.Y + point3.Y);
                    var num9 = 1;
                    if (point4.X < 0 || point4.Y < 0 || point4.X >= num3 || point4.Y >= num4 ||
                        map[point4.X, point4.Y].Solid)
                        continue;

                    for (var n = 0; n < 4; n++)
                    {
                        var point5 = new Point(point4.X + directions[n].X, point4.Y + directions[n].Y);
                        if (point5.X >= 0 && point5.Y >= 0 && point5.X < num3 && point5.Y < num4 &&
                            map[point5.X, point5.Y].Solid)
                        {
                            num9 = 7;
                            break;
                        }
                    }

                    if (fewerTurns && map[value.X, value.Y].Parent.HasValue &&
                        point4.X != map[value.X, value.Y].Parent.Value.X &&
                        point4.Y != map[value.X, value.Y].Parent.Value.Y)
                        num9 += 4;

                    var cost = map[value.X, value.Y].Cost;
                    if (point3.Y != 0) num9 += (int)(cost * 0.5f);

                    var num10 = cost + num9;
                    if (map[point4.X, point4.Y].Cost > num10)
                    {
                        map[point4.X, point4.Y].Cost = num10;
                        map[point4.X, point4.Y].Parent = value;
                        var num11 = active.BinarySearch(point4, comparer);
                        if (num11 < 0) num11 = ~num11;

                        active.Insert(num11, point4);
                        if (point4 == point2)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }

            if (!flag)
            {
                if (logging) SourceDebugLog.Log("PF: FAILED - ran out of active nodes, can't find ending");

                return false;
            }

            path.Clear();
            var point6 = point2;
            var num12 = 0;
            while (point6 != point && num12++ < 1000)
            {
                path.Add(new Vector2(point6.X + 0.5f, point6.Y + 0.5f) * 8f + level.LevelOffset);
                point6 = map[point6.X, point6.Y].Parent.Value;
            }

            if (num12 >= 1000)
            {
                Console.WriteLine("WARNING: Pathfinder 'succeeded' but then was unable to work out its path?");
                return false;
            }

            for (var num13 = 1; num13 < path.Count - 1; num13++)
            {
                if (path.Count <= 2) break;

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if ((path[num13].X ==
                     path[num13 - 1].X && /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                     path[num13].X == path[num13 + 1].X) ||
                    ( /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                        path[num13].Y ==
                        path[num13 - 1].Y && /* ReSharper disable once CompareOfFloatsByEqualityOperator */
                        path[num13].Y == path[num13 + 1].Y))
                {
                    path.RemoveAt(num13);
                    num13--;
                }
            }

            path.Reverse();
            lastPath = path;
            if (logging) SourceDebugLog.Log("PF: SUCCESS");

            return true;
        }

        public void Render(ISourceRenderContext context)
        {
            for (var i = 0; i < 200; i++)
            for (var j = 0; j < 200; j++)
                if (map[i, j].Solid)
                    SourcePrimitiveDrawing.Rect(context, this, level.RoomX + i * 8, level.RoomY + j * 8, 8f, 8f,
                        PackedColor.Red * 0.25f);

            if (LastPath != null)
            {
                var start = LastPath[0];
                for (var k = 1; k < LastPath.Count; k++)
                {
                    var vector = LastPath[k];
                    SourcePrimitiveDrawing.Line(context, this, start, vector, PackedColor.Red, level.VectorArithmetic);
                    SourcePrimitiveDrawing.Rect(context, this, start.X - 2f, start.Y - 2f, 4f, 4f, PackedColor.Red);
                    start = vector;
                }

                SourcePrimitiveDrawing.Rect(context, this, start.X - 2f, start.Y - 2f, 4f, 4f, PackedColor.Red);
            }

            SourcePrimitiveDrawing.Rect(context, this, level.RoomX + debugLastStart.X * 8 + 2,
                level.RoomY + debugLastStart.Y * 8 + 2, 4f, 4f, PackedColor.Green);
            SourcePrimitiveDrawing.Rect(context, this, level.RoomX + debugLastEnd.X * 8 + 2,
                level.RoomY + debugLastEnd.Y * 8 + 2, 4f, 4f, PackedColor.Green);
        }
    }
}
