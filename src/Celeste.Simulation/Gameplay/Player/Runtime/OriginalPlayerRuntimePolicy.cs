using System;
using System.Numerics;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Player.Death;

namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public sealed class OriginalPlayerRuntimePolicy : ISourcePlayerRuntimePolicy
    {
        public bool PreserveRedDashHorizontalSpeedBeforeUpTransition => false;

        public void ResetSprite(RoomPlayerSession player,
            PlayerSpriteMode mode)
        {
            player.ResetSpriteSourceBody(mode);
        }

        public void Added(RoomPlayerSession player, object scene)
        {
            player.AddedSourceBody(scene);
        }

        public void Update(RoomPlayerSession player, float deltaTime, float rawDeltaTime)
        {
            player.UpdateSourceBody(deltaTime, rawDeltaTime);
        }

        public PlayerDeathPresentation Die(RoomPlayerSession player, Vector2 direction, bool evenIfInvincible,
            bool registerDeathInStats)
        {
            return player.DieSourceBody(direction, evenIfInvincible, registerDeathInStats);
        }

        public void BoostBegin(RoomPlayerSession player, Action originalBoostBegin)
        {
            originalBoostBegin();
        }

        public bool UsesOriginalReflectionFall(RoomPlayerSession player)
        {
            return true;
        }

        public bool AllowSwimSurfaceCorrection(RoomPlayerSession player)
        {
            return true;
        }

        public void SceneBegin(RoomPlayerSession player, object scene)
        {
        }
    }
}
