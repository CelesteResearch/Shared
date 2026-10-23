using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Effects.Liquids;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Environment.Lava.Barriers
{
    public class OriginalIceBlockState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly IOriginalLavaProcess engine;

        ISourceEngineContext ISourceEngineContextEntity.
            EngineContext => engine;

        private readonly LavaRectangleComponentState lava;

        private SourceSolidEntityState solid;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SourceSolidEntityState Solid => solid;

        public OriginalIceBlockState(Vector2 position, float width, float height, IOriginalLavaProcess engine)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position)
        {
            this.engine = engine;
            Collider = new HitboxColliderGeometry(width, height);
            Add(new CoreModeListenerState(OnChangeMode));
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(lava = new(width, height, 2, engine, "danger/lava/bubble_a",
                "particles/bubble"));
            lava.UpdateMultiplier = 0f;
            lava.SurfaceColor = new(166, 255, 244, 255);
            lava.EdgeColor = new(108, 214, 235, 255);
            lava.CenterColor = new(76, 168, 214, 255);
            lava.SmallWaveAmplitude = 1f;
            lava.BigWaveAmplitude = 1f;
            lava.CurveAmplitude = 1f;
            lava.Spikey = 3f;
            Depth = -8500;
        }


        public override void Added(object scene)
        {
            base.Added(scene);
            var position = Position + new Vector2(2f, 3f);
            var width = Width - 4f;
            var height = Height - 5f;
            var worlds = ((ISourcePlatformCollisionScene)scene).SolidWorldFactory;
            ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(solid =
                new(position, width, height, false, worlds.Create(position, false)));
            Collidable = Solid.Collidable = ((OriginalLevelSceneRoot)Scene).CoreMode == RoomCoreMode.Cold;
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            Collidable = Solid.Collidable = mode == RoomCoreMode.Cold;
            if (Collidable) return;

            var level = (OriginalLevelSceneRoot)Scene;
            var center = Center;
            for (var i = 0; i < Width; i += 4)
            for (var j = 0; j < Height; j += 4)
            {
                var vector = Position + new Vector2(i + 2, j + 2) +
                             SourceRandomMath.Range(engine.Random, -Vector2.One * 2f, Vector2.One * 2f);
                level.Particles.Emit(engine.ParticleTypes.IceBlock.P_Deactivate, vector,
                    Vector2Geometry.Angle(vector - center));
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            player.Die(engine.VectorArithmetic.SafeNormalize(player.Center - Center));
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Collidable) base.Render(context);
        }
    }
}
