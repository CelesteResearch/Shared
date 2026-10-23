using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Entities.Protocols;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Effects.Liquids;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Lava.Rising;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Environment.Lava.Barriers
{
    public class OriginalFireBarrierState : SceneEntityState, global::Celeste.Core.Scheduling.ISourceEngineContextEntity
    {
        private readonly IOriginalLavaProcess engine;

        global::Celeste.Core.Scheduling.ISourceEngineContext global::Celeste.Core.Scheduling.ISourceEngineContextEntity.
            EngineContext => engine;

        private LavaRectangleComponentState Lava;

        private SourceSolidEntityState solid;

        private SoundSourceComponentState idleSfx;

        public OriginalFireBarrierState(Vector2 position, float width, float height, IOriginalLavaProcess engine)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration,
                position)
        {
            this.engine = engine;
            base.Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags
                .TransitionUpdate.Value;
            base.Collider = new HitboxColliderGeometry(width, height);
            Add(new PlayerColliderComponentState(OnPlayer));
            Add(new CoreModeListenerState(OnChangeMode));
            Add(Lava = new LavaRectangleComponentState(width, height, 4, engine, "danger/lava/bubble_a",
                "particles/bubble"));
            Lava.SurfaceColor = OriginalRisingLavaState.Hot[0];
            Lava.EdgeColor = OriginalRisingLavaState.Hot[1];
            Lava.CenterColor = OriginalRisingLavaState.Hot[2];
            Lava.SmallWaveAmplitude = 2f;
            Lava.BigWaveAmplitude = 1f;
            Lava.CurveAmplitude = 1f;
            base.Depth = -8500;
            Add(idleSfx = engine.SoundSources.Create());
            idleSfx.Position = engine.VectorArithmetic.Divide(new Vector2(base.Width, base.Height), 2f);
        }


        public override void Added(object scene)
        {
            base.Added(scene);
            var position = Position + new Vector2(2f, 3f);
            var width = base.Width - 4f;
            var height = base.Height - 5f;
            var worlds = ((ISourcePlatformCollisionScene)scene).SolidWorldFactory;
            ((OriginalLevelSceneRoot)scene).Scheduler.QueueSourceEntity(solid =
                new SourceSolidEntityState(position, width, height, false, worlds.Create(position, false)));
            Collidable = (solid.Collidable = ((OriginalLevelSceneRoot)Scene).CoreMode == RoomCoreMode.Hot);
            if (Collidable)
            {
                idleSfx.Play("event:/env/local/09_core/lavagate_idle");
            }
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            Collidable = (solid.Collidable = mode == RoomCoreMode.Hot);
            if (!Collidable)
            {
                OriginalLevelSceneRoot level = ((OriginalLevelSceneRoot)Scene);
                Vector2 center = base.Center;
                for (int i = 0; (float)i < base.Width; i += 4)
                {
                    for (int j = 0; (float)j < base.Height; j += 4)
                    {
                        Vector2 vector = Position + new Vector2(i + 2, j + 2) +
                                         SourceRandomMath.Range(engine.Random, -Vector2.One * 2f, Vector2.One * 2f);
                        level.Particles.Emit(engine.ParticleTypes.FireBarrier.P_Deactivate, vector,
                            Vector2Geometry.Angle(vector - center));
                    }
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
            player.Die(engine.VectorArithmetic.SafeNormalize(player.Center - base.Center));
        }

        public override void Update()
        {
            if ((base.Scene as OriginalLevelSceneRoot).Transitioning)
            {
                if (idleSfx != null)
                {
                    idleSfx.UpdateSfxPosition();
                }
            }
            else
            {
                base.Update();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Collidable)
            {
                base.Render(context);
            }
        }
    }
}
