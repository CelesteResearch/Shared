using System;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Idle.PlayerIdleState Idle { get; private set; }

        private void BindIdle()
        {
            Idle = new global::Celeste.Simulation.Gameplay.Player.Presentation.Idle.PlayerIdleState(
                new IdleWorld(this));
            // These are constructor callbacks on this actual Sprite. ResetSprite does
            // not restore them in the original either, so a swapped sprite really does
            // arrive with all five callbacks null (see RoomPlayerSession.ResetSprite.cs).
            Sprite.OnLastFrame = Idle.OnLastFrame;
            Sprite.OnChange = Idle.OnChange;
        }

        internal void UpdateIdleBookkeeping(float deltaTime)
        {
            StrawberryCollectResetTimer -= engineContext.DeltaTime;
            if (StrawberryCollectResetTimer <= 0f) StrawberryCollectIndex = 0;
            Idle.BeforeComponents(deltaTime, Data.Motion.Normal.Speed);
            if (!Dead)
                ((global::Celeste.Core.Audio.ISourceMusicUnderwaterEnvironment)engineContext).MusicUnderwater =
                    World.Contacts.UnderwaterMusicCheck();
            if (JustRespawned && Data.Motion.Normal.Speed != Vector2.Zero)
                JustRespawned = false;
        }

        private sealed class IdleWorld : global::Celeste.Simulation.Gameplay.Player.Presentation.Idle.IPlayerIdleWorld
        {
            private readonly RoomPlayerSession player;

            public IdleWorld(RoomPlayerSession player)
            {
                this.player = player;
            }

            public bool ScenePresent => player.Scene != null;

            public bool Dead => player.Dead;
            public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite => player.Sprite;

            // Player.level is a cached reference, independent of Entity.Scene.
            public bool InCutscene => player.Level != null &&
                                      ((global::Celeste.Scene.Lifecycle.ISceneCutsceneState)player.Level).InCutscene;

            public bool CoreHot =>
                ((global::Celeste.Simulation.Gameplay.Environment.Core.ISourceCoreModeScene)player.Level).CoreMode ==
                global::Celeste.Simulation.Gameplay.Environment.Core.RoomCoreMode.Hot;

            public global::Celeste.Core.Randomness.ISourceRandom Random =>
                ((global::Celeste.Core.Randomness.ISourceRandomEnvironment)player.engineContext).Random;

            public global::Celeste.Core.Audio.ISourceAudioEventReference PlaySound(string name) => player.Play(name);

            public void StopSound(global::Celeste.Core.Audio.ISourceAudioEventReference handle) =>
                ((global::Celeste.Core.Audio.ISourceSpatialAudioEnvironment)player.engineContext).SpatialAudio
                .Stop(handle);
        }
    }
}
