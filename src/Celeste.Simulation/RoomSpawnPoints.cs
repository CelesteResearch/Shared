using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;

namespace Celeste.Simulation
{
    public static class RoomSpawnPoints
    {
        public static Bounds Bounds(MapElement room)
        {
            return new(room.Int("x"), room.Int("y"), room.Int("width"),
                room.Int("height") == 184 ? 180 : room.Int("height"));
        }

        public static List<Vector2> All(MapElement room)
        {
            var points = new List<Vector2>();
            foreach (var source in room.Child("entities")?.Children ??
                                   [])
                if (source.Name == "player")
                    points.Add(new(room.Int("x") + source.Float("x"), room.Int("y") + source.Float("y")));
            return points;
        }

        public static Vector2 Closest(MapElement room, Vector2 from)
        {
            var points = All(room);
            var result = points[0];
            var distance = Vector2.DistanceSquared(result, from);
            for (var i = 1; i < points.Count; i++)
            {
                var next = Vector2.DistanceSquared(points[i], from);
                if (next < distance)
                {
                    distance = next;
                    result = points[i];
                }
            }

            return result;
        }

        public static Vector2 Default(MapElement room)
        {
            return Closest(room, new(Bounds(room).X, Bounds(room).Bottom));
        }

        // Everest Level.DefaultSpawnPoint uses LevelData.DefaultSpawn for custom level sets.
        // LevelData records the first marked player spawn while reading map entities.
        public static Vector2 Default(MapElement room, bool celesteLevelSet)
        {
            if (celesteLevelSet) return Default(room);
            Vector2? first = null, defaultSpawn = null;
            foreach (var source in room.Child("entities")?.Children ??
                                   [])
            {
                if (source.Name != "player") continue;
                var point = new Vector2(room.Int("x") + source.Float("x"), room.Int("y") + source.Float("y"));
                if (!first.HasValue) first = point;
                if (!defaultSpawn.HasValue && source.Attributes.TryGetValue("isDefaultSpawn", out var marked) &&
                    Convert.ToBoolean(marked, CultureInfo.InvariantCulture))
                    defaultSpawn = point;
            }

            return defaultSpawn ?? first.Value;
        }

        public static int Facing(MapElement room,
            Bounds collider, int initialFacing, bool hasIntro,
            Func<MapElement, bool> shouldLoad = null)
        {
            foreach (var source in room.Child("triggers")?.Children ??
                                   [])
            {
                if (source.Name != "spawnFacingTrigger" || (shouldLoad != null && !shouldLoad(source))) continue;
                var trigger = new Bounds(
                    room.Int("x") + source.Float("x"), room.Int("y") + source.Float("y"),
                    source.Int("width"), source.Int("height"));
                if (trigger.Intersects(collider))
                    return Enum.TryParse(source.Text("facing"), true, out SpawnFacing facing) ? (int)facing : 0;
            }

            return hasIntro && collider.X + collider.Width / 2 > room.Int("x") + room.Int("width") / 2
                ? -1
                : initialFacing;
        }

        private enum SpawnFacing
        {
            Left = -1,
            Right = 1,
        }
    }
}
