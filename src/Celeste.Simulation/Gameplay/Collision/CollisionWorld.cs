using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Collision
{
    public sealed class CollisionWorld : ICollisionWorld
    {
        public List<Bounds> Solids { get; } = [];

        public List<Bounds> JumpThrus { get; } = [];

        public bool SolidAt(Bounds bounds)
        {
            return Solids.Exists(s => s.Intersects(bounds));
        }

        public bool SolidAt(Vector2 point)
        {
            return Solids.Exists(s => s.Contains(point));
        }

        public bool JumpThruAt(Bounds bounds)
        {
            return JumpThrus.Exists(s => s.Intersects(bounds));
        }

        public bool JumpThruAt(Bounds bounds,
            Bounds previous)
        {
            return JumpThrus.Exists(s => s.Intersects(bounds) && !s.Intersects(previous));
        }

        public static CollisionWorld FromRoom(
            MapElement room)
        {
            var world = new CollisionWorld();
            int ox = room.Int("x"), oy = room.Int("y");
            var rows = (room.Child("solids")?.Text("innerText") ?? "").Replace("\r", "").Split('\n');
            for (var y = 0; y < rows.Length; y++)
            {
                var x = 0;
                while (x < rows[y].Length)
                {
                    if (rows[y][x] == '0' || rows[y][x] == '\0')
                    {
                        x++;
                        continue;
                    }

                    var start = x++;
                    while (x < rows[y].Length && rows[y][x] != '0' && rows[y][x] != '\0') x++;
                    world.Solids.Add(
                        new(ox + start * 8, oy + y * 8, (x - start) * 8, 8));
                }
            }

            var entities = room.Child("entities");
            if (entities != null)
                foreach (var entity in entities.Children)
                    if (entity.Name == "jumpThru")
                        world.JumpThrus.Add(new(ox + entity.Int("x"),
                            oy + entity.Int("y"),
                            entity.Int("width", 8), 5));
            return world;
        }
    }
}
