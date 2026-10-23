using System;
using System.Numerics;
using Celeste.Simulation.Presentation.Player.Death;

namespace Celeste.Simulation.Gameplay.Player.Runtime
{
    public interface ISourcePlayerRuntimePolicy
    {
        void ResetSprite(RoomPlayerSession player,
            global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode mode);

        bool PreserveRedDashHorizontalSpeedBeforeUpTransition { get; }

        bool UsesOriginalReflectionFall(RoomPlayerSession player);
        bool AllowSwimSurfaceCorrection(RoomPlayerSession player);
        void Added(RoomPlayerSession player, object scene);
        void Update(RoomPlayerSession player, float deltaTime, float rawDeltaTime);

        PlayerDeathPresentation Die(RoomPlayerSession player, Vector2 direction, bool evenIfInvincible,
            bool registerDeathInStats);

        void BoostBegin(RoomPlayerSession player, Action originalBoostBegin);
        void SceneBegin(RoomPlayerSession player, object scene);
    }
}
