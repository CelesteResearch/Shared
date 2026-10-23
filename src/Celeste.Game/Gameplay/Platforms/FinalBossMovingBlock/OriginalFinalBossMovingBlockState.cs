using Celeste.Core.Display;
using Celeste.Scene.Tracking;
using Celeste.Core.Rendering;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Tiles;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock
{
    public partial class OriginalFinalBossMovingBlockState : SourceSolidEntityState, IFinalBossMovingBlock
    {
        protected ISourceEngineContext Engine => SourceWorld.EngineContext;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)Engine;
        float IFinalBossMovingBlock.X => X;
        int IFinalBossMovingBlock.BossNodeIndex => BossNodeIndex;

        protected virtual void MoveAlongTween(Vector2 from, Vector2 to, float eased)
            => MoveTo(Vector2Interpolation.Lerp(from, to, eased, ((ISourceScalarEnvironment)Engine).ScalarArithmetic));

        private ParticleTypePresentation P_Stop => Process.ParticleTypes.FinalBossMovingBlock.P_Stop;

        private ParticleTypePresentation P_Break => Process.ParticleTypes.FinalBossMovingBlock.P_Break;

        public int BossNodeIndex;

        private float startDelay;

        private int nodeIndex;

        private Vector2[] nodes;

        private TileGrid sprite;

        private TileGrid highlight;

        private SimulationCoroutine moveCoroutine;

        private bool isHighlighted;

        public OriginalFinalBossMovingBlockState(Vector2[] nodes, float width, float height, int bossNodeIndex,
            ISourceEngineContext engine, ISourceSolidWorldFactory worlds)
            : base(nodes[0], width, height, false, worlds.Create(nodes[0], false))
        {
            BossNodeIndex = bossNodeIndex;
            this.nodes = nodes;
            int newSeed = ((ISourceRandomEnvironment)Engine).Random.Next();
            ((ISourceRandomProcessEnvironment)Engine).RandomProcess.PushRandom(newSeed);
            sprite = ((ISourceAutotilingResources)((ISourceGameGraphicsEnvironment)Engine).GameGraphics)
                .ForegroundAutotiler
                .GenerateBox('g', (int)base.Width / 8, (int)base.Height / 8).TileGrid;
            OwnedComponents.Add(sprite);
            ((ISourceRandomProcessEnvironment)Engine).RandomProcess.PopRandom();
            ((ISourceRandomProcessEnvironment)Engine).RandomProcess.PushRandom(newSeed);
            highlight = ((ISourceAutotilingResources)((ISourceGameGraphicsEnvironment)Engine).GameGraphics)
                .ForegroundAutotiler.GenerateBox('G', (int)(base.Width / 8f), (int)base.Height / 8).TileGrid;
            highlight.Alpha = 0f;
            OwnedComponents.Add(highlight);
            ((ISourceRandomProcessEnvironment)Engine).RandomProcess.PopRandom();
            OwnedComponents.Add(new TileInterceptorState(sprite, false));
            OwnedComponents.Add(new LightOccludeState());
        }

        public OriginalFinalBossMovingBlockState(EntityData data, Vector2 offset, ISourceEngineContext engine,
            ISourceSolidWorldFactory worlds)
            : this(data.NodesWithPosition(offset), data.Width, data.Height,
                EntityAttributeReader.Int(data.Values, "nodeIndex"), engine, worlds)
        {
        }

        public override void OnShake(Vector2 amount)
        {
            base.OnShake(amount);
            sprite.Position = amount;
        }

        public void StartMoving(float delay)
        {
            startDelay = delay;
            OwnedComponents.Add(moveCoroutine = new SimulationCoroutine(Engine, MoveSequence()));
        }

        private IEnumerator MoveSequence()
        {
            while (true)
            {
                StartShaking(0.2f + startDelay);
                if (!isHighlighted)
                {
                    for (float p = 0f; p < 1f; p += Engine.Frame.DeltaTime / (0.2f + startDelay + 0.2f))
                    {
                        highlight.Alpha = ((ISourceEasingEnvironment)Engine).EasingArithmetic.CubeIn(p);
                        sprite.Alpha = 1f - highlight.Alpha;
                        yield return null;
                    }

                    highlight.Alpha = 1f;
                    sprite.Alpha = 0f;
                    isHighlighted = true;
                }
                else
                {
                    yield return 0.2f + startDelay + 0.2f;
                }

                startDelay = 0f;
                nodeIndex++;
                nodeIndex %= nodes.Length;
                Vector2 from = Position;
                Vector2 to = nodes[nodeIndex];
                SourceTweenState tween = SourceTweenState.Create(Engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    ((ISourceEasingEnvironment)Engine).EasingArithmetic.CubeIn, 0.8f, start: true);
                tween.OnUpdate = delegate(SourceTweenState t) { MoveAlongTween(from, to, t.Eased); };
                tween.OnComplete = delegate(SourceTweenState t)
                {
                    if (CollideCheck("Celeste.SolidTiles",
                            Position + ((ISourceVectorEnvironment)Engine).VectorArithmetic.SafeNormalize(to - from) *
                            2f))
                    {
                        Process.AudioSession.Play("event:/game/06_reflection/fallblock_boss_impact", base.Center,
                            Process.SaveContext);
                        ImpactParticles(to - from);
                    }
                    else
                    {
                        StopParticles(to - from);
                    }
                };
                OwnedComponents.Add(tween);
                yield return 0.8f;
            }
        }

        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions
            .NoInlining)]
        private void StopParticles(Vector2 moved)
            => global::Celeste.Game.Presentation.Platforms.Effects.MovingSolidParticleEffects.Stop(this, Engine, moved);

        private void BreakParticles()
        {
            Vector2 center = base.Center;
            for (int i = 0; (float)i < base.Width; i += 4)
            {
                for (int j = 0; (float)j < base.Height; j += 4)
                {
                    Vector2 vector = Position + new Vector2(2 + i, 2 + j);
                    ((OriginalLevelSceneRoot)Scene).Particles.Emit(P_Break, 1, vector, Vector2.One * 2f,
                        (float)Math.Atan2((vector - center).Y, (vector - center).X));
                }
            }
        }

        [global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions
            .NoInlining)]
        private void ImpactParticles(Vector2 moved)
            => global::Celeste.Game.Presentation.Platforms.Effects.MovingSolidParticleEffects.Impact(this, Engine,
                moved);

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = Position;
            Position += base.Shake;
            base.Render(context);
            if (highlight.Alpha > 0f && highlight.Alpha < 1f)
            {
                int num = (int)((1f - highlight.Alpha) * 16f);
                IntRect rect = new IntRect((int)base.X, (int)base.Y, (int)base.Width, (int)base.Height);
                rect.X = unchecked(rect.X - num);
                rect.Y = unchecked(rect.Y - num);
                rect.Width = unchecked(rect.Width + num * 2);
                rect.Height = unchecked(rect.Height + num * 2);
                SourcePrimitiveDrawing.HollowRect(context, this, rect,
                    SourceColorInterpolation.Lerp(PackedColor.Purple, PackedColor.Pink, 0.7f,
                        ((ISourceScalarEnvironment)Engine).ScalarArithmetic));
            }

            Position = position;
        }

        private void Finish()
        {
            Vector2 vector = base.CenterRight + Vector2.UnitX * 10f;
            for (int i = 0; (float)i < base.Width / 8f; i++)
            {
                for (int j = 0; (float)j < base.Height / 8f; j++)
                {
                    Level.Scheduler.QueueSourceEntity(Engine.EntityPools
                        .Create<DebrisState>(() => new DebrisState(Engine, SourceWorld.TargetMotionPolicy))
                        .Init(Position + new Vector2(4 + i * 8, 4 + j * 8), 'f').BlastFrom(vector));
                }
            }

            BreakParticles();
            DestroyStaticMovers();
            RemoveSelf();
        }

        public void Destroy(float delay)
        {
            if (base.Scene != null)
            {
                if (moveCoroutine != null)
                {
                    OwnedComponents.Remove(moveCoroutine);
                }

                if (delay <= 0f)
                {
                    Finish();
                    return;
                }

                StartShaking(delay);
                SourceAlarmState.Set(Engine.AlarmPool, OwnedComponents, delay, Finish);
            }
        }
    }
}
