using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Presentation.Walls.Breakable
{
    public static class BreakableTileBlockEffects
    {
        public static void PlayBreakSound(ISourceSolidWorld world, char tileType, SceneEntityState block)
        {
            if (tileType == '1')
                ((ISourceSpatialAudioEnvironment)world.EngineContext).SpatialAudio.Play(
                    "event:/game/general/wall_break_dirt", block.Position);
            else if (tileType == '3')
                ((ISourceSpatialAudioEnvironment)world.EngineContext).SpatialAudio.Play(
                    "event:/game/general/wall_break_ice", block.Position);
            else if (tileType == '9')
                ((ISourceSpatialAudioEnvironment)world.EngineContext).SpatialAudio.Play(
                    "event:/game/general/wall_break_wood", block.Position);
            else
                ((ISourceSpatialAudioEnvironment)world.EngineContext).SpatialAudio.Play(
                    "event:/game/general/wall_break_stone", block.Position);
        }

        public static void EmitDebris(SceneEntityState block, ISourceSolidWorld world, ref char tileType,
            bool playSound,
            Vector2 from)
        {
            EmitDebris(block, world, ref tileType, playSound, new CapturedOrigin(from));
        }

        public static void EmitDebris(SceneEntityState block, ISourceSolidWorld world, ref char tileType,
            bool playSound,
            RoomPlayerSession player)
        {
            EmitDebris(block, world, ref tileType, playSound, new PlayerOrigin(player));
        }

        private interface IBlastOrigin
        {
            Vector2 Get();
        }

        private readonly struct CapturedOrigin : IBlastOrigin
        {
            private readonly Vector2 value;

            public CapturedOrigin(Vector2 value)
            {
                this.value = value;
            }

            public Vector2 Get()
            {
                return value;
            }
        }

        private readonly struct PlayerOrigin : IBlastOrigin
        {
            private readonly RoomPlayerSession player;

            public PlayerOrigin(RoomPlayerSession player)
            {
                this.player = player;
            }

            public Vector2 Get()
            {
                return player.Center;
            }
        }

        private static void EmitDebris<T>(SceneEntityState block, ISourceSolidWorld world, ref char tileType,
            bool playSound, T origin) where T : struct, IBlastOrigin
        {
            for (var x = 0; x < block.Width / 8f; x++)
            for (var y = 0; y < block.Height / 8f; y++)
                ((ISourceScene)block.Scene).SourceScene.QueueSourceEntity(world.EngineContext.EntityPools
                    .Create<DebrisState>().Init(block.Position + new Vector2(4 + x * 8, 4 + y * 8), tileType, playSound)
                    .BlastFrom(origin.Get()));
        }
    }
}
