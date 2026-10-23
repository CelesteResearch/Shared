using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Collision.Contacts
{
    // Terrain's rider and horizontal assist checks are gameplay rules. Both hosts
    // bind these queries to the same live RoomPlayerSession.
    public static class PlayerTerrainContact
    {
        public static bool IsRiding(RoomPlayerSession player,
            global::Celeste.Simulation.Gameplay.Platforms.Collision.CollisionPlatform platform)
        {
            var actualPlatform = platform.SourceEntityOwner;
            return platform.IsJumpThru
                ? player.IsRiding(
                    (global::Celeste.Simulation.Gameplay.Platforms.Foundation.ISourceJumpThruEntity)actualPlatform)
                : player.IsRiding(actualPlatform);
        }

        public static bool HorizontalAssist(RoomPlayerSession player,
            global::Celeste.Simulation.Gameplay.Actors.CassetteActor actor, int amount)
        {
            return ReferenceEquals(actor.Body, player.Body)
                   && player.Input.MoveX.Value == Math.Sign(amount)
                   && Math.Sign(player.Data.Motion.Normal.Speed.X) == Math.Sign(amount);
        }
    }
}
