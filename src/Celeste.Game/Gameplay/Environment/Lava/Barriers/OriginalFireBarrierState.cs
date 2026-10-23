using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Gameplay.Environment.Lava.Rising;
using Celeste.Graphics.Effects.Liquids;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Environment.Lava.Barriers
{
    public class OriginalFireBarrierState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly IOriginalLavaProcess engine;

        ISourceEngineContext ISourceEngineContextEntity.
            EngineContext => engine;

        private readonly LavaRectangleComponentState Lava;

        private SourceSolidEntityState solid;

        private readonly SoundSourceComponentState idleSfx;

        public OriginalFireBarrierState(Vector2 position, float width, float height, IOriginalLavaProcess engine)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags
                .TransitionUpdate.Value;
            Collider = new HitboxColliderGeometry(width, height);
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(new CoreModeListenerState(OnChangeMode));
            Add(Lava = new(width, height, 4, engine, "danger/lava/bubble_a",
                "particles/bubble"));
            Lava.SurfaceColor = OriginalRisingLavaState.Hot[0];
            Lava.EdgeColor = OriginalRisingLavaState.Hot[1];
            Lava.CenterColor = OriginalRisingLavaState.Hot[2];
            Lava.SmallWaveAmplitude = 2f;
            Lava.BigWaveAmplitude = 1f;
            Lava.CurveAmplitude = 1f;
            Depth = -8500;
            Add(idleSfx = engine.SoundSources.Create());
            idleSfx.Position = engine.VectorArithmetic.Divide(new Vector2(Width, Height), 2f);
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
            Collidable = solid.Collidable = ((OriginalLevelSceneRoot)Scene).CoreMode == RoomCoreMode.Hot;
            if (Collidable) idleSfx.Play("event:/env/local/09_core/lavagate_idle");
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            Collidable = solid.Collidable = mode == RoomCoreMode.Hot;
            if (!Collidable)
            {
                var level = (OriginalLevelSceneRoot)Scene;
                var center = Center;
                for (var i = 0; i < Width; i += 4)
                for (var j = 0; j < Height; j += 4)
                {
                    var vector = Position + new Vector2(i + 2, j + 2) +
                                 SourceRandomMath.Range(engine.Random, -Vector2.One * 2f, Vector2.One * 2f);
                    level.Particles.Emit(engine.ParticleTypes.FireBarrier.P_Deactivate, vector,
                        Vector2Geometry.Angle(vector - center));
                }

                idleSfx.Stop();
            }
            else
            {
                idleSfx.Play("event:/env/local/09_core/lavagate_idle");
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            player.Die(engine.VectorArithmetic.SafeNormalize(player.Center - Center));
        }

        public override void Update()
        {
            if ((Scene as OriginalLevelSceneRoot).Transitioning)
            {
                if (idleSfx != null) idleSfx.UpdateSfxPosition();
            }
            else
            {
                base.Update();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Collidable) base.Render(context);
        }
    }
}
