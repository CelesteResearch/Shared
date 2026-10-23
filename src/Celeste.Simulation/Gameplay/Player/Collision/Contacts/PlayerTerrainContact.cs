using System;
using Celeste.Simulation.Gameplay.Actors;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Contacts
{
    // Terrain's rider and horizontal assist checks are gameplay rules. Both hosts
    // bind these queries to the same live RoomPlayerSession.
    public static class PlayerTerrainContact
    {
        public static bool IsRiding(RoomPlayerSession player,
            CollisionPlatform platform)
        {
            var actualPlatform = platform.SourceEntityOwner;
            return platform.IsJumpThru
                ? player.IsRiding(
                    (ISourceJumpThruEntity)actualPlatform)
                : player.IsRiding(actualPlatform);
        }

        public static bool HorizontalAssist(RoomPlayerSession player,
            CassetteActor actor, int amount)
        {
            return ReferenceEquals(actor.Body, player.Body)
                   && player.Input.MoveX.Value == Math.Sign(amount)
                   && Math.Sign(player.Data.Motion.Normal.Speed.X) == Math.Sign(amount);
        }
    }
}
