using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace Celeste.Simulation
{
    public static class RoomSpawnPoints
    {
        public static global::Celeste.Core.Geometry.Bounds Bounds(global::Celeste.Core.Maps.MapElement room) =>
            new global::Celeste.Core.Geometry.Bounds(room.Int("x"), room.Int("y"), room.Int("width"),
                room.Int("height") == 184 ? 180 : room.Int("height"));

        public static List<Vector2> All(global::Celeste.Core.Maps.MapElement room)
        {
            var points = new List<Vector2>();
            foreach (global::Celeste.Core.Maps.MapElement source in room.Child("entities")?.Children ??
                                                                    new List<global::Celeste.Core.Maps.MapElement>())
                if (source.Name == "player")
                    points.Add(new Vector2(room.Int("x") + source.Float("x"), room.Int("y") + source.Float("y")));
            return points;
        }

        public static Vector2 Closest(global::Celeste.Core.Maps.MapElement room, Vector2 from)
        {
            var points = All(room);
            var result = points[0];
            float distance = Vector2.DistanceSquared(result, from);
            for (int i = 1; i < points.Count; i++)
            {
                float next = Vector2.DistanceSquared(points[i], from);
                if (next < distance)
                {
                    distance = next;
                    result = points[i];
                }
            }

            return result;
        }

        public static Vector2 Default(global::Celeste.Core.Maps.MapElement room) =>
            Closest(room, new Vector2(Bounds(room).X, Bounds(room).Bottom));

        // Everest Level.DefaultSpawnPoint uses LevelData.DefaultSpawn for custom level sets.
        // LevelData records the first marked player spawn while reading map entities.
        public static Vector2 Default(global::Celeste.Core.Maps.MapElement room, bool celesteLevelSet)
        {
            if (celesteLevelSet) return Default(room);
            Vector2? first = null, defaultSpawn = null;
            foreach (global::Celeste.Core.Maps.MapElement source in room.Child("entities")?.Children ??
                                                                    new List<global::Celeste.Core.Maps.MapElement>())
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

        public static int Facing(global::Celeste.Core.Maps.MapElement room,
            global::Celeste.Core.Geometry.Bounds collider, int initialFacing, bool hasIntro,
            Func<global::Celeste.Core.Maps.MapElement, bool> shouldLoad = null)
        {
            foreach (global::Celeste.Core.Maps.MapElement source in room.Child("triggers")?.Children ??
                                                                    new List<global::Celeste.Core.Maps.MapElement>())
            {
                if (source.Name != "spawnFacingTrigger" || shouldLoad != null && !shouldLoad(source)) continue;
                global::Celeste.Core.Geometry.Bounds trigger = new global::Celeste.Core.Geometry.Bounds(
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
            Right = 1
        }
    }
}
