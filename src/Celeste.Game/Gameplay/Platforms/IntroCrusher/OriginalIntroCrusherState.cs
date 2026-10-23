using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Platforms.IntroCrusher
{
    public class OriginalIntroCrusherState : SourceSolidEntityState
    {
        protected Vector2 shake;

        protected readonly ISourceEngineContext engine;
        protected OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;

        private readonly Vector2 start;

        protected Vector2 end;

        protected TileGrid tilegrid;

        private readonly SoundSourceComponentState shakingSfx;

        public OriginalIntroCrusherState(ISourceEngineContext engine, Vector2 position, int width, int height,
            Vector2 node,
            ISourceSolidWorld world)
            : base(position, width, height, true, world)
        {
            this.engine = engine;
            start = position;
            end = node;
            Depth = -10501;
            SurfaceSoundIndex = 4;
            OwnedComponents.Add(tilegrid =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .ForegroundAutotiler
                .GenerateBox('3', width / 8, height / 8).TileGrid);
            OwnedComponents.Add(shakingSfx = new(engine));
        }

        public OriginalIntroCrusherState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                SourceVector2Math.Add(data.Nodes[0], offset), world)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (Level.Session.GetLevelFlag("1") || Level.Session.GetLevelFlag("0b"))
                Position = end;
            else
                OwnedComponents.Add(new SimulationCoroutine(engine, Sequence()));
        }

        protected void AddedToSourceSolid(object scene)
        {
            base.Added(scene);
        }

        public override void Update()
        {
            tilegrid.Position = shake;
            base.Update();
        }

        protected IEnumerator Sequence()
        {
            RoomPlayerSession entity;
            do
            {
                yield return null;
                entity = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            } while (entity == null || !(entity.X >= X + 30f) || !(entity.X <= Right + 8f));

            shakingSfx.Play("event:/game/00_prologue/fallblock_first_shake");
            var time = 1.2f;
            var shaker =
                new ShakerComponentState(engine, time, true, delegate(Vector2 v) { shake = v; });
            OwnedComponents.Add(shaker);
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                RumbleLength.Medium);
            while (time > 0f)
            {
                var entity2 =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (entity2 != null && (entity2.X >= X + Width - 8f || entity2.X < X + 28f))
                {
                    shaker.RemoveSelf();
                    break;
                }

                yield return null;
                time -= engine.DeltaTime;
            }

            for (var num = 2; num < Width; num += 4)
            {
                Level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FallingBlock.P_FallDustA, 2,
                    new(X + num, Y), SourceVector2Math.Multiply(Vector2.One, 4f),
                    (float)Math.PI / 2f);
                Level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FallingBlock.P_FallDustB, 2,
                    new(X + num, Y), SourceVector2Math.Multiply(Vector2.One, 4f));
            }

            shakingSfx.Param("release", 1f);
            time = 0f;
            do
            {
                yield return null;
                time = ScalarMath.Approach(time, 1f, 2f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                MoveTo(Vector2Interpolation.Lerp(start, end,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(time),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic));
            } while (!(time >= 1f));

            for (var num2 = 0; num2 <= Width; num2 += 4)
            {
                Level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FallingBlock.P_FallDustA, 1,
                    new(X + num2, Bottom), SourceVector2Math.Multiply(Vector2.One, 4f),
                    -(float)Math.PI / 2f);
                var direction = !(num2 < Width / 2f) ? 0f : (float)Math.PI;
                Level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FallingBlock.P_LandDust, 1,
                    new(X + num2, Bottom), SourceVector2Math.Multiply(Vector2.One, 4f),
                    direction);
            }

            shakingSfx.Stop();
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/00_prologue/fallblock_first_impact",
                Position);
            Level.Shake();
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Strong,
                RumbleLength.Medium);
            OwnedComponents.Add(new ShakerComponentState(engine, 0.25f, true,
                delegate(Vector2 v) { shake = v; }));
        }
    }
}
