using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Randomness;
using Celeste.Scene.Lifecycle;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Presentation.Idle;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public PlayerIdleState Idle { get; private set; }

        private void BindIdle()
        {
            Idle = new(
                new IdleWorld(this));
            // These are constructor callbacks on this actual Sprite. ResetSprite does
            // not restore them in the original either, so a swapped sprite really does
            // arrive with all five callbacks null (see RoomPlayerSession.ResetSprite.cs).
            Sprite.OnLastFrame = Idle.OnLastFrame;
            Sprite.OnChange = Idle.OnChange;
        }

        internal void UpdateIdleBookkeeping(float deltaTime)
        {
            StrawberryCollectResetTimer -= EngineContext.DeltaTime;
            if (StrawberryCollectResetTimer <= 0f) StrawberryCollectIndex = 0;
            Idle.BeforeComponents(deltaTime, Data.Motion.Normal.Speed);
            if (!Dead)
                ((ISourceMusicUnderwaterEnvironment)EngineContext).MusicUnderwater =
                    World.Contacts.UnderwaterMusicCheck();
            if (JustRespawned && Data.Motion.Normal.Speed != Vector2.Zero)
                JustRespawned = false;
        }

        private sealed class IdleWorld : IPlayerIdleWorld
        {
            private readonly RoomPlayerSession player;

            public IdleWorld(RoomPlayerSession player)
            {
                this.player = player;
            }

            public bool ScenePresent => player.Scene != null;

            public bool Dead => player.Dead;
            public PlayerSprite Sprite => player.Sprite;

            // Player.level is a cached reference, independent of Entity.Scene.
            public bool InCutscene => player.Level != null &&
                                      ((ISceneCutsceneState)player.Level).InCutscene;

            public bool CoreHot =>
                ((ISourceCoreModeScene)player.Level).CoreMode ==
                RoomCoreMode.Hot;

            public ISourceRandom Random =>
                ((ISourceRandomEnvironment)player.EngineContext).Random;

            public ISourceAudioEventReference PlaySound(string name)
            {
                return player.Play(name);
            }

            public void StopSound(ISourceAudioEventReference handle)
            {
                ((ISourceSpatialAudioEnvironment)player.EngineContext).SpatialAudio
                    .Stop(handle);
            }
        }
    }
}
