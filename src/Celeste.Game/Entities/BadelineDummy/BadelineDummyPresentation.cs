using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Game.Gameplay.Walls.Breakable;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.BadelineDummy
{
    public class BadelineDummyPresentation : SceneEntityState
    {
        public void SetAlpha(float alpha)
        {
            Hair.Alpha = alpha;
            Sprite.Color = PackedColor.White * alpha;
            Light.Alpha = alpha;
        }

        public static readonly Vector4 HairColor = new Vector4(155, 63, 181, 255) / 255f;
        public bool ScenePresent => Scene != null;

        public bool HairActive
        {
            get => Hair.Active;
            set => Hair.Active = value;
        }

        public bool HairVisible
        {
            get => Hair.Visible;
            set => Hair.Visible = value;
        }

        public PlayerSprite Sprite;
        public PlayerHair Hair;
        public BadelineAutoAnimatorPresentation AutoAnimator;
        public SineWaveState Wave;

        public VertexLightState Light;

        private readonly ISourceEngineContext engine;
        public float FloatSpeed = 120, FloatAccel = 240;
        public float DeltaTime => engine.DeltaTime;

        private OriginalLevelSceneRoot ActualLevel =>
            Scene as OriginalLevelSceneRoot;

        private IOriginalGameplayProcess Process =>
            (IOriginalGameplayProcess)engine;

        private void PlaySourceSound(string name, Vector2 position)
        {
            Process.AudioSession.Play(name, position, Process.SaveContext);
        }

        private void EmitSourceVanish(OriginalLevelSceneRoot level)
        {
            level.Particles.Emit(Process.ParticleTypes.BadelineOldsite.P_Vanish, 12, Center, Vector2.One * 6);
        }

        public float Floatness = 2;
        public Vector2 FloatNormal = new(0, 1);


        public BadelineDummyPresentation(ISourceEngineContext engine, Vector2 position)
            : base(
                ((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration, position)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Collider = new HitboxColliderGeometry(6, 6, -3, -7);
            Sprite = new(engine,
                PlayerSpriteMode.Badeline);
            Sprite.Play("fallSlow");
            Sprite.Scale = new(-1, Sprite.Scale.Y);
            Hair = new(Sprite, engine)
            {
                Color =
                    ((IOriginalBadelineOldsiteEnvironment)engine).BadelineOldsiteStatics.HairColor,
                Border = PackedColor.Black, Facing = -1,
            };
            OwnedComponents.Add(Hair);
            OwnedComponents.Add(Sprite);
            AutoAnimator =
                new(engine);
            OwnedComponents.Add(AutoAnimator);
            Sprite.OnFrameChange = animation =>
            {
                if (IsFootstep(animation, Sprite.CurrentAnimationFrame))
                    PlaySourceSound("event:/char/badeline/footstep", Position);
            };
            Wave = new(engine, .25f);
            OwnedComponents.Add(Wave);
            Wave.OnUpdate = value => Sprite.Position = FloatNormal * value * Floatness;
            Light = new(engine, new(0, -8),
                new(219, 112, 147, 255), 1, 20, 60);
            OwnedComponents.Add(Light);
        }

        public static BadelineDummyPresentation Create(
            OriginalLevelSceneRoot level, Vector2 position)
        {
            return new(level.EngineContext, position);
        }

        internal static bool IsFootstep(string animation, int frame)
        {
            return (animation == "walk" || animation == "runSlow" || animation == "runFast") &&
                   (frame == 0 || frame == 6);
        }

        public override void Update()
        {
            if (Sprite.Scale.X != 0) Hair.Facing = Math.Sign(Sprite.Scale.X);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var renderPosition = Sprite.RenderPosition;
            Sprite.RenderPosition = Vector2Geometry.Floor(Sprite.RenderPosition);
            base.Render(context);
            Sprite.RenderPosition = renderPosition;
        }

        public void Appear(bool silent = false)
        {
            Appear(ActualLevel, silent);
        }

        public void Appear(OriginalLevelSceneRoot level,
            bool silent = false)
        {
            if (!silent)
            {
                PlaySourceSound("event:/char/badeline/appear", Position);
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            }

            level.Displacement.AddBurst(Center, .5f, 24, 96, .4f);
            EmitSourceVanish(level);
        }

        public void Vanish()
        {
            PlaySourceSound("event:/char/badeline/disappear", Position);
            Shockwave();
            EmitSourceVanish(ActualLevel);
            RemoveSelf();
        }


        private void Shockwave()
        {
            ActualLevel.Displacement.AddBurst(Center, .5f, 24, 96, .4f);
        }

        public IEnumerator FloatTo(Vector2 target, int? turnAtEndTo = null, bool faceDirection = true,
            bool fadeLight = false, bool quickEnd = false)
        {
            Sprite.Play("fallSlow");
            if (faceDirection && Math.Sign(target.X - Position.X) != 0)
                Sprite.Scale = new(Math.Sign(target.X - Position.X), Sprite.Scale.Y);
            Vector2 direction =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                        target - Position),
                perpendicular = new(-direction.Y, direction.X);
            float speed = 0;
            while (Position != target)
            {
                speed = ScalarMath.Approach(speed, FloatSpeed, FloatAccel * DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                Position =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(
                        Position, target, speed * DeltaTime);
                Floatness = ScalarMath.Approach(Floatness, 4, 8 * DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                FloatNormal =
                    ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(
                        FloatNormal, perpendicular, DeltaTime * 12);
                if (fadeLight)
                    Light.Alpha = ScalarMath.Approach(Light.Alpha, 0, DeltaTime * 2,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            if (quickEnd) Floatness = 2;
            else
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                while (Floatness != 2)
                {
                    Floatness = ScalarMath.Approach(Floatness, 2, 8 * DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    yield return null;
                }

            if (turnAtEndTo.HasValue) Sprite.Scale = new(turnAtEndTo.Value, Sprite.Scale.Y);
        }

        public IEnumerator WalkTo(float x, float speed = 64)
        {
            Floatness = 0;
            Sprite.Play("walk");
            if (Math.Sign(x - Position.X) != 0) Sprite.Scale = new(Math.Sign(x - Position.X), Sprite.Scale.Y);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (Position.X != x)
            {
                Position = new(
                    ScalarMath.Approach(Position.X, x, DeltaTime * speed,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic),
                    Position.Y);
                yield return null;
            }

            Sprite.Play("idle");
        }

        public IEnumerator SmashBlock(Vector2 target)
        {
            ActualLevel.Displacement.AddBurst(Position, .5f, 24, 96);
            Sprite.Play("dreamDashLoop");
            var from = Position;
            for (float p = 0; p < 1; p += DeltaTime * 6)
            {
                Position = from + (target - from) *
                    ((ISourceEasingEnvironment)engine).EasingArithmetic
                    .CubeOut(p);
                yield return null;
            }

            ((ISourceScene)Scene).SourceScene.Entities
                .FindFirst<OriginalDashBlockState>()
                .Break(Position, new(0, -1), false);
            Sprite.Play("idle");
            for (float p = 0; p < 1; p += DeltaTime * 4)
            {
                Position = target + (from - target) *
                    ((ISourceEasingEnvironment)engine).EasingArithmetic
                    .CubeOut(p);
                yield return null;
            }

            Sprite.Play("fallSlow");
        }
    }
}
