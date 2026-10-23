using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Collision;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    public sealed class PlatformCollisionWorld : PixelCollisionWorld<
        CollisionPlatform>
    {
        public static PlatformCollisionWorld FromRoom(
            MapElement room)
        {
            return FromRoom(room, true);
        }

        // Chapter-backed terrain and incoming collision layers do not consume room solid regions.
        // Keep the same platform construction and source order without parsing discarded geometry.
        internal static PlatformCollisionWorld FromRoom(
            MapElement room, bool includeSolidRegions)
        {
            var geometry = includeSolidRegions
                ? CollisionWorld.FromRoom(room)
                : null;
            var result = new PlatformCollisionWorld();
            var origin = new Vector2(room.Int("x"), room.Int("y"));
            var tiles = new CollisionPlatform(origin)
            {
                IsSolidTiles = true, AllowStaticMovers = false, EnableAssistModeChecks = false,
                PathfinderHitbox = false, Source = room.Child("solids"),
            };
            if (geometry != null)
                foreach (var bounds in geometry.Solids)
                    tiles.Regions.Add(new(bounds.X - origin.X, bounds.Y - origin.Y,
                        bounds.Width,
                        bounds.Height));
            result.Platforms.Add(tiles);
            foreach (var entity in room.Child("entities")?.Children ??
                                   [])
                if (entity.Name == "jumpThru")
                {
                    var platform =
                        new CollisionPlatform(
                                origin + new Vector2(entity.Int("x"), entity.Int("y")), true)
                            { Source = entity };
                    platform.Regions.Add(new(0, 0, entity.Int("width", 8), 5));
                    result.Platforms.Add(platform);
                }

            return result;
        }
    }
}
