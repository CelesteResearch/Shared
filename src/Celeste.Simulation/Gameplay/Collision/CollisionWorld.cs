using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Collision
{
    public sealed class CollisionWorld : ICollisionWorld
    {
        public List<global::Celeste.Core.Geometry.Bounds> Solids { get; } =
            new List<global::Celeste.Core.Geometry.Bounds>();

        public List<global::Celeste.Core.Geometry.Bounds> JumpThrus { get; } =
            new List<global::Celeste.Core.Geometry.Bounds>();

        public bool SolidAt(global::Celeste.Core.Geometry.Bounds bounds) => Solids.Exists(s => s.Intersects(bounds));
        public bool SolidAt(Vector2 point) => Solids.Exists(s => s.Contains(point));

        public bool JumpThruAt(global::Celeste.Core.Geometry.Bounds bounds) =>
            JumpThrus.Exists(s => s.Intersects(bounds));

        public bool JumpThruAt(global::Celeste.Core.Geometry.Bounds bounds,
            global::Celeste.Core.Geometry.Bounds previous) =>
            JumpThrus.Exists(s => s.Intersects(bounds) && !s.Intersects(previous));

        public static global::Celeste.Simulation.Gameplay.Collision.CollisionWorld FromRoom(
            global::Celeste.Core.Maps.MapElement room)
        {
            var world = new global::Celeste.Simulation.Gameplay.Collision.CollisionWorld();
            int ox = room.Int("x"), oy = room.Int("y");
            string[] rows = (room.Child("solids")?.Text("innerText") ?? "").Replace("\r", "").Split('\n');
            for (int y = 0; y < rows.Length; y++)
            {
                int x = 0;
                while (x < rows[y].Length)
                {
                    if (rows[y][x] == '0' || rows[y][x] == '\0')
                    {
                        x++;
                        continue;
                    }

                    int start = x++;
                    while (x < rows[y].Length && rows[y][x] != '0' && rows[y][x] != '\0') x++;
                    world.Solids.Add(
                        new global::Celeste.Core.Geometry.Bounds(ox + start * 8, oy + y * 8, (x - start) * 8, 8));
                }
            }

            global::Celeste.Core.Maps.MapElement entities = room.Child("entities");
            if (entities != null)
                foreach (global::Celeste.Core.Maps.MapElement entity in entities.Children)
                    if (entity.Name == "jumpThru")
                        world.JumpThrus.Add(new global::Celeste.Core.Geometry.Bounds(ox + entity.Int("x"),
                            oy + entity.Int("y"),
                            entity.Int("width", 8), 5));
            return world;
        }
    }
}
