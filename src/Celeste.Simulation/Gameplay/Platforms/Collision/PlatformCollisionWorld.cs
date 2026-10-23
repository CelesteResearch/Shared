using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Physics.Collision;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    public sealed class PlatformCollisionWorld : PixelCollisionWorld<
        global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform>
    {
        public static global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld FromRoom(
            global::Celeste.Core.Maps.MapElement room) => FromRoom(room, true);

        // Chapter-backed terrain and incoming collision layers do not consume room solid regions.
        // Keep the same platform construction and source order without parsing discarded geometry.
        internal static global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld FromRoom(
            global::Celeste.Core.Maps.MapElement room, bool includeSolidRegions)
        {
            var geometry = includeSolidRegions
                ? global::Celeste.Simulation.Gameplay.Collision.CollisionWorld.FromRoom(room)
                : null;
            var result = new global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld();
            var origin = new Vector2(room.Int("x"), room.Int("y"));
            var tiles = new global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform(origin)
            {
                IsSolidTiles = true, AllowStaticMovers = false, EnableAssistModeChecks = false,
                PathfinderHitbox = false, Source = room.Child("solids")
            };
            if (geometry != null)
                foreach (global::Celeste.Core.Geometry.Bounds bounds in geometry.Solids)
                    tiles.Regions.Add(new global::Celeste.Core.Geometry.Bounds(bounds.X - origin.X, bounds.Y - origin.Y,
                        bounds.Width,
                        bounds.Height));
            result.Platforms.Add(tiles);
            foreach (global::Celeste.Core.Maps.MapElement entity in room.Child("entities")?.Children ??
                                                                    new List<global::Celeste.Core.Maps.MapElement>())
                if (entity.Name == "jumpThru")
                {
                    var platform =
                        new global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform(
                                origin + new Vector2(entity.Int("x"), entity.Int("y")), true)
                            { Source = entity };
                    platform.Regions.Add(new global::Celeste.Core.Geometry.Bounds(0, 0, entity.Int("width", 8), 5));
                    result.Platforms.Add(platform);
                }

            return result;
        }
    }
}
