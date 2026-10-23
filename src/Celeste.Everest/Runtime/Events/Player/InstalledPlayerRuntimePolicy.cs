using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Runtime;
using Celeste.Simulation.Presentation.Player.Death;

namespace Celeste.Everest.Runtime.Events.Player
{
    public sealed class InstalledPlayerRuntimePolicy : ISourcePlayerRuntimePolicy, ISourcePlayerStateRegistrationPolicy
    {
        public bool PreserveRedDashHorizontalSpeedBeforeUpTransition => true;

        public void ResetSprite(RoomPlayerSession player,
            global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode mode)
        {
            Action<string> onFrameChange = player.Sprite.OnFrameChange;
            Action<string> onLastFrame = player.Sprite.OnLastFrame;
            Action<string, string> onChange = player.Sprite.OnChange;
            player.ResetSpriteSourceBody(mode);
            player.Sprite.OnFrameChange = onFrameChange;
            player.Sprite.OnLastFrame = onLastFrame;
            player.Sprite.OnChange = onChange;
        }

        private readonly ISourceEngineContext engine;
        private int diedInGBJ;

        public InstalledPlayerRuntimePolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public void RegisterStates(RoomPlayerSession player)
        {
            var states = (ISourceNamedStateMachine)player.Machine;
            states.SetStateName(0, "Normal");
            states.SetStateName(1, "Climb");
            states.SetStateName(2, "Dash");
            states.SetStateName(3, "Swim");
            states.SetStateName(4, "Boost");
            states.SetStateName(5, "RedDash");
            states.SetStateName(6, "HitSquash");
            states.SetStateName(7, "Launch");
            states.SetStateName(8, "Pickup");
            states.SetStateName(9, "DreamDash");
            states.SetStateName(10, "SummitLaunch");
            states.SetStateName(11, "Dummy");
            states.SetStateName(12, "IntroWalk");
            states.SetStateName(13, "IntroJump");
            states.SetStateName(14, "IntroRespawn");
            states.SetStateName(15, "IntroWakeUp");
            states.SetStateName(16, "BirdDashTutorial");
            states.SetStateName(17, "Frozen");
            states.SetStateName(18, "ReflectionFall");
            states.SetStateName(19, "StarFly");
            states.SetStateName(20, "TempleFall");
            states.SetStateName(21, "CassetteFly");
            states.SetStateName(22, "Attract");
            states.SetStateName(23, "IntroMoonJump");
            states.SetStateName(24, "FlingBird");
            states.SetStateName(25, "IntroThinkForABit");
            EverestPlayerSourceEvents.RegisterStates(player);
        }

        public bool AllowSwimSurfaceCorrection(RoomPlayerSession player) => player.IsOverWater();

        public void Added(RoomPlayerSession player, object scene)
        {
            if (player.OverrideIntroType.HasValue)
            {
                player.IntroType = player.OverrideIntroType.Value;
                player.OverrideIntroType = null;
            }

            player.AddedSourceBody(scene);
            player.FramesAlive = int.MaxValue;
            if (player.Scene is ISourcePlayerAntiSoftlockLevel) player.FramesAlive = 0;
            EverestPlayerSourceEvents.Spawn(player);
        }

        public void Update(RoomPlayerSession player, float deltaTime, float rawDeltaTime)
        {
            EverestPlayerSourceEvents.BeforeUpdate(player);
            player.UpdateSourceBody(deltaTime, rawDeltaTime);
            var level = player.Scene as ISourcePlayerAntiSoftlockLevel;
            if (level == null) return;
            if (level.CanPause && player.FramesAlive < int.MaxValue)
                unchecked
                {
                    player.FramesAlive++;
                }

            if (player.FramesAlive >= 8) diedInGBJ = 0;
            EverestPlayerSourceEvents.AfterUpdate(player);
        }

        public PlayerDeathPresentation Die(RoomPlayerSession player, Vector2 direction, bool evenIfInvincible,
            bool registerDeathInStats)
        {
            var level = player.Scene as ISourcePlayerAntiSoftlockLevel;
            var corpse = player.DieSourceBody(direction, evenIfInvincible, registerDeathInStats);
            if (corpse != null)
            {
                EverestPlayerSourceEvents.Die(player);
                if (player.FramesAlive < 6 && level != null)
                {
                    unchecked
                    {
                        diedInGBJ++;
                    }

                    if (diedInGBJ != 0 && diedInGBJ % 2 == 0 && level.LevelSet != "Celeste" &&
                        !((IEverestPlayerRuntimeEnvironment)engine).PlayerCoreSettings.DisableAntiSoftlock)
                    {
                        if (!EverestPlayerAntiSoftlockEvents.PauseInGBJ(player)) level.Pause(0, false, false);
                        return null;
                    }
                }
            }

            return corpse;
        }

        public void BoostBegin(RoomPlayerSession player, Action originalBoostBegin)
        {
            if ((player.Scene as global::Celeste.Simulation.Gameplay.Player.Scene.ISourcePlayerBoostMetadataScene)
                ?.BoostTheoInBubble == true)
            {
                player.RefillDash();
                player.RefillStamina();
            }
            else originalBoostBegin();
        }

        public bool UsesOriginalReflectionFall(RoomPlayerSession player)
            => ((global::Celeste.Simulation.Gameplay.Player.Scene.Reflection.ISourceReflectionFallScene)player.Scene)
                .ReflectionFallLevelSet == "Celeste";

        public void SceneBegin(RoomPlayerSession player, object scene)
        {
            diedInGBJ = 0;
        }
    }
}
