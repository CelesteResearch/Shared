using System.Numerics;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Audio;
using Celeste.Simulation.Gameplay.Player.Audio.Frame;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Gameplay.Player.Scene.Particles;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public PlayerFrameAudioState FrameAudio { get; private set; }

        private void BindFrameAudio()
        {
            FrameAudio =
                new(
                    new FrameAudioWorld(this));
            Sprite.OnFrameChange = FrameAudio.OnFrameChange;
        }

        internal SourceSurfaceSoundSelection
            FrameCallbackPlatform(Vector2 at, string sourceName)
        {
            var entities = ((ISourceScene)Scene).SourceScene.Entities;
            return SourceSurfacePlatformSelection.QueryAt(this,
                entities.GetTrackedEntities(sourceName), sourceCollisionTemp, at,
                entities.GetTrackedEntity<RoomPlayerSession>());
        }

        private sealed class
            FrameAudioWorld : IPlayerFrameAudioWorld
        {
            private readonly RoomPlayerSession player;

            public FrameAudioWorld(RoomPlayerSession player)
            {
                this.player = player;
            }

            public PlayerSprite Sprite => player.Sprite;
            public bool ScenePresent => player.Scene != null;
            public bool Dead => player.Dead;
            public int Facing => player.Data.Facing;
            public Vector2 Position => player.Body.Position;

            public int? StepSurface()
            {
                var platform = player.FrameCallbackPlatform(player.Position + Vector2.UnitY, "Celeste.Platform");
                return platform.HasValue ? platform.GetStepSoundIndex(player) : null;
            }

            public int? WallSurface(int side)
            {
                var platform = player.FrameCallbackPlatform(player.Center + Vector2.UnitX * side, "Celeste.Solid");
                return platform.HasValue ? platform.GetWallSoundIndex(player, side) : null;
            }

            public void PlaySound(string path, string parameter, float value)
            {
                player.Play(path, parameter, value);
            }

            public void BurstForegroundDust(Vector2 position, float angle, int count, float range)
            {
                ((ISourcePlayerFrameParticleScene)player
                        .Level)
                    .BurstPlayerForegroundDust(position, angle, count, range);
            }
        }
    }
}
