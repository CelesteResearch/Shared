using System;
using System.Collections.Generic;
using System.Linq;
using Celeste.Simulation.Gameplay.Platforms.Collision;

namespace Celeste.Game.Content.Maps
{
    /// <summary>
    /// Restores the platform tracker order established by Level.LoadLevel's entity queue.
    /// Hosts supply the current room's platforms; transition survivors remain before them.
    /// </summary>
    public static class OriginalRoomPlatformSourceOrder
    {
        public static global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform[] Reorder(
            global::Celeste.Simulation.Gameplay.Platforms.Collision.PlatformCollisionWorld world,
            global::Celeste.Core.Maps.MapElement room,
            IEnumerable<global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform> roomPlatforms,
            IEnumerable<global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform> decalPlatforms)
        {
            if (world == null) throw new ArgumentNullException(nameof(world));
            if (room == null) throw new ArgumentNullException(nameof(room));
            if (roomPlatforms == null) throw new ArgumentNullException(nameof(roomPlatforms));
            if (decalPlatforms == null) throw new ArgumentNullException(nameof(decalPlatforms));
            var sources = room.Child("entities")?.Children ?? new List<global::Celeste.Core.Maps.MapElement>();
            var decals =
                new HashSet<global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform>(decalPlatforms);
            return PlatformTrackerOrder.Reorder(world, roomPlatforms, p => decals.Contains(p) ? int.MaxValue
                : p.Source?.Name == "__templePortalCurtain" ? int.MaxValue - 1
                : sources.IndexOf(p.Source));
        }
    }
}
