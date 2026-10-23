using System;
using System.Collections.Generic;
using Celeste.Core.Maps;
using Celeste.Simulation.Gameplay.Platforms.Collision;

namespace Celeste.Game.Content.Maps
{
    /// <summary>
    ///     Restores the platform tracker order established by Level.LoadLevel's entity queue.
    ///     Hosts supply the current room's platforms; transition survivors remain before them.
    /// </summary>
    public static class OriginalRoomPlatformSourceOrder
    {
        public static CollisionPlatform[] Reorder(
            PlatformCollisionWorld world,
            MapElement room,
            IEnumerable<CollisionPlatform> roomPlatforms,
            IEnumerable<CollisionPlatform> decalPlatforms)
        {
            if (world == null) throw new ArgumentNullException(nameof(world));
            if (room == null) throw new ArgumentNullException(nameof(room));
            if (roomPlatforms == null) throw new ArgumentNullException(nameof(roomPlatforms));
            if (decalPlatforms == null) throw new ArgumentNullException(nameof(decalPlatforms));
            var sources = room.Child("entities")?.Children ?? [];
            var decals =
                new HashSet<CollisionPlatform>(decalPlatforms);
            return PlatformTrackerOrder.Reorder(world, roomPlatforms, p => decals.Contains(p) ? int.MaxValue
                : p.Source?.Name == "__templePortalCurtain" ? int.MaxValue - 1
                : sources.IndexOf(p.Source));
        }
    }
}
