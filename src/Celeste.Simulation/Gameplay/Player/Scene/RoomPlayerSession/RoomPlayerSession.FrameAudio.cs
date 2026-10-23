using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public global::Celeste.Simulation.Gameplay.Player.Audio.Frame.PlayerFrameAudioState FrameAudio
        {
            get;
            private set;
        }

        private void BindFrameAudio()
        {
            FrameAudio =
                new global::Celeste.Simulation.Gameplay.Player.Audio.Frame.PlayerFrameAudioState(
                    new FrameAudioWorld(this));
            Sprite.OnFrameChange = FrameAudio.OnFrameChange;
        }

        internal Celeste.Simulation.Gameplay.Platforms.Audio.SourceSurfaceSoundSelection
            FrameCallbackPlatform(Vector2 at, string sourceName)
        {
            var entities = ((Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities;
            return Celeste.Simulation.Gameplay.Platforms.Audio.SourceSurfacePlatformSelection.QueryAt(this,
                entities.GetTrackedEntities(sourceName), sourceCollisionTemp, at,
                entities.GetTrackedEntity<RoomPlayerSession>());
        }

        private sealed class
            FrameAudioWorld : global::Celeste.Simulation.Gameplay.Player.Audio.Frame.IPlayerFrameAudioWorld
        {
            private readonly RoomPlayerSession player;

            public FrameAudioWorld(RoomPlayerSession player)
            {
                this.player = player;
            }

            public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite => player.Sprite;
            public bool ScenePresent => player.Scene != null;
            public bool Dead => player.Dead;
            public int Facing => player.Data.Facing;
            public Vector2 Position => player.Body.Position;

            public int? StepSurface()
            {
                var platform = player.FrameCallbackPlatform(player.Position + Vector2.UnitY, "Celeste.Platform");
                return platform.HasValue ? platform.GetStepSoundIndex(player) : (int?)null;
            }

            public int? WallSurface(int side)
            {
                var platform = player.FrameCallbackPlatform(player.Center + Vector2.UnitX * side, "Celeste.Solid");
                return platform.HasValue ? platform.GetWallSoundIndex(player, side) : (int?)null;
            }

            public void PlaySound(string path, string parameter, float value)
                => player.Play(path, parameter, value);

            public void BurstForegroundDust(Vector2 position, float angle, int count, float range)
            {
                ((global::Celeste.Simulation.Gameplay.Player.Scene.Particles.ISourcePlayerFrameParticleScene)player
                        .Level)
                    .BurstPlayerForegroundDust(position, angle, count, range);
            }
        }
    }
}
