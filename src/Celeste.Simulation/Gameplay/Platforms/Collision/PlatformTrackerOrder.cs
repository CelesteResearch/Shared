using System;
using System.Collections.Generic;
using System.Linq;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    public static class PlatformTrackerOrder
    {
        public static CollisionPlatform[] Reorder(PlatformCollisionWorld world,
            IEnumerable<CollisionPlatform> platforms, Func<CollisionPlatform, int> sourceOrder)
        {
            if (world == null) throw new ArgumentNullException(nameof(world));
            if (platforms == null) throw new ArgumentNullException(nameof(platforms));
            if (sourceOrder == null) throw new ArgumentNullException(nameof(sourceOrder));
            var ordered = platforms.OrderBy(sourceOrder).ToArray();
            foreach (var platform in ordered) world.Platforms.Remove(platform);
            world.Platforms.AddRange(ordered);
            return ordered;
        }
    }
}
