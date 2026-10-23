using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Gameplay.Actors;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    // JumpThru.HasRider scans the live Actor tracker in insertion order and asks
    // each Actor.IsRiding. The caller supplies that tracker projection, not a
    // room-owned actor adapter list retained after EntityList removal.
    public static class PlatformRiderQuery
    {
        public static bool HasRider(IReadOnlyList<CassetteActor> actors,
            CollisionPlatform platform)
        {
            for (int i = 0, count = actors.Count; i < count; i++)
            {
                var actor = actors[i];
                if (actor.IsRiding != null)
                {
                    if (actor.IsRiding(platform)) return true;
                    continue;
                }

                if (!actor.HasCollider || (platform.IsJumpThru &&
                                           (actor.Body.IgnoreJumpThrus || platform.Intersects(actor.Bounds)))) continue;
                if (platform.Intersects(actor.Body.BoundsAt(actor.Body.Position + Vector2.UnitY))) return true;
            }

            return false;
        }
    }
}
