using Celeste.Core.Display;
using Celeste.Simulation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Game.Entities.BadelineDummy
{
    public class BadelineDummyPresentation : global::Celeste.Scene.Entities.SceneEntityState
    {
        public void SetAlpha(float alpha)
        {
            Hair.Alpha = alpha;
            Sprite.Color = global::Celeste.Core.Display.PackedColor.White * alpha;
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

        public global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite Sprite;
        public global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair Hair;
        public global::Celeste.Game.Entities.BadelineDummy.BadelineAutoAnimatorPresentation AutoAnimator;
        public global::Celeste.Scene.Components.Oscillation.SineWaveState Wave;

        public global::Celeste.Simulation.Presentation.Lighting.VertexLightState Light;

        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;
        public float FloatSpeed = 120, FloatAccel = 240;
        public float DeltaTime => engine.DeltaTime;

        private global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot ActualLevel =>
            Scene as global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

        private global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess Process =>
            (global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine;

        private void PlaySourceSound(string name, Vector2 position) =>
            Process.AudioSession.Play(name, position, Process.SaveContext);

        private void EmitSourceVanish(global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot level) =>
            level.Particles.Emit(Process.ParticleTypes.BadelineOldsite.P_Vanish, 12, Center, Vector2.One * 6);

        public float Floatness = 2;
        public Vector2 FloatNormal = new Vector2(0, 1);


        public BadelineDummyPresentation(global::Celeste.Core.Scheduling.ISourceEngineContext engine, Vector2 position)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration, position)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Collider = new global::Celeste.Physics.Collision.Shapes.HitboxColliderGeometry(6, 6, -3, -7);
            Sprite = new global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite(engine,
                global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode.Badeline);
            Sprite.Play("fallSlow");
            Sprite.Scale = new Vector2(-1, Sprite.Scale.Y);
            Hair = new global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair(Sprite, engine)
            {
                Color =
                    ((global::Celeste.Game.Gameplay.Enemies.Badeline.Chasers.
                        IOriginalBadelineOldsiteEnvironment)engine).BadelineOldsiteStatics.HairColor,
                Border = global::Celeste.Core.Display.PackedColor.Black, Facing = -1
            };
            OwnedComponents.Add(Hair);
            OwnedComponents.Add(Sprite);
            AutoAnimator =
                new global::Celeste.Game.Entities.BadelineDummy.BadelineAutoAnimatorPresentation(engine);
            OwnedComponents.Add(AutoAnimator);
            Sprite.OnFrameChange = animation =>
            {
                if (IsFootstep(animation, Sprite.CurrentAnimationFrame))
                    PlaySourceSound("event:/char/badeline/footstep", Position);
            };
            Wave = new global::Celeste.Scene.Components.Oscillation.SineWaveState(engine, .25f);
            OwnedComponents.Add(Wave);
            Wave.OnUpdate = value => Sprite.Position = FloatNormal * value * Floatness;
            Light = new global::Celeste.Simulation.Presentation.Lighting.VertexLightState(engine, new Vector2(0, -8),
                new global::Celeste.Core.Display.PackedColor(219, 112, 147, 255), 1, 20, 60);
            OwnedComponents.Add(Light);
        }

        public static BadelineDummyPresentation Create(
            global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot level, Vector2 position)
        {
            return new BadelineDummyPresentation(level.EngineContext, position);
        }

        internal static bool IsFootstep(string animation, int frame) =>
            (animation == "walk" || animation == "runSlow" || animation == "runFast") && (frame == 0 || frame == 6);

        public override void Update()
        {
            if (Sprite.Scale.X != 0) Hair.Facing = Math.Sign(Sprite.Scale.X);
            base.Update();
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            Vector2 renderPosition = Sprite.RenderPosition;
            Sprite.RenderPosition = global::Celeste.Core.Mathematics.Vector2Geometry.Floor(Sprite.RenderPosition);
            base.Render(context);
            Sprite.RenderPosition = renderPosition;
        }

        public void Appear(bool silent = false) => Appear(ActualLevel, silent);

        public void Appear(global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot level,
            bool silent = false)
        {
            if (!silent)
            {
                PlaySourceSound("event:/char/badeline/appear", Position);
                ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
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


        private void Shockwave() => ActualLevel.Displacement.AddBurst(Center, .5f, 24, 96, .4f);

        public IEnumerator FloatTo(Vector2 target, int? turnAtEndTo = null, bool faceDirection = true,
            bool fadeLight = false, bool quickEnd = false)
        {
            Sprite.Play("fallSlow");
            if (faceDirection && Math.Sign(target.X - Position.X) != 0)
                Sprite.Scale = new Vector2(Math.Sign(target.X - Position.X), Sprite.Scale.Y);
            Vector2 direction =
                    ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                        target - Position),
                perpendicular = new Vector2(-direction.Y, direction.X);
            float speed = 0;
            while (Position != target)
            {
                speed = global::Celeste.Core.Mathematics.ScalarMath.Approach(speed, FloatSpeed, FloatAccel * DeltaTime,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                Position =
                    ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic.Approach(
                        Position, target, speed * DeltaTime);
                Floatness = global::Celeste.Core.Mathematics.ScalarMath.Approach(Floatness, 4, 8 * DeltaTime,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                FloatNormal =
                    ((global::Celeste.Core.Mathematics.ISourceVectorEnvironment)engine).VectorArithmetic.Approach(
                        FloatNormal, perpendicular, DeltaTime * 12);
                if (fadeLight)
                    Light.Alpha = global::Celeste.Core.Mathematics.ScalarMath.Approach(Light.Alpha, 0, DeltaTime * 2,
                        ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            if (quickEnd) Floatness = 2;
            else
                while (Floatness != 2)
                {
                    Floatness = global::Celeste.Core.Mathematics.ScalarMath.Approach(Floatness, 2, 8 * DeltaTime,
                        ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    yield return null;
                }

            if (turnAtEndTo.HasValue) Sprite.Scale = new Vector2(turnAtEndTo.Value, Sprite.Scale.Y);
        }

        public IEnumerator WalkTo(float x, float speed = 64)
        {
            Floatness = 0;
            Sprite.Play("walk");
            if (Math.Sign(x - Position.X) != 0) Sprite.Scale = new Vector2(Math.Sign(x - Position.X), Sprite.Scale.Y);
            while (Position.X != x)
            {
                Position = new Vector2(
                    global::Celeste.Core.Mathematics.ScalarMath.Approach(Position.X, x, DeltaTime * speed,
                        ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic),
                    Position.Y);
                yield return null;
            }

            Sprite.Play("idle");
        }

        public IEnumerator SmashBlock(Vector2 target)
        {
            ActualLevel.Displacement.AddBurst(Position, .5f, 24, 96);
            Sprite.Play("dreamDashLoop");
            Vector2 from = Position;
            for (float p = 0; p < 1; p += DeltaTime * 6)
            {
                Position = from + (target - from) *
                    ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine).EasingArithmetic
                    .CubeOut(p);
                yield return null;
            }

            ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities
                .FindFirst<global::Celeste.Game.Gameplay.Walls.Breakable.OriginalDashBlockState>()
                .Break(Position, new Vector2(0, -1), false);
            Sprite.Play("idle");
            for (float p = 0; p < 1; p += DeltaTime * 4)
            {
                Position = target + (from - target) *
                    ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine).EasingArithmetic
                    .CubeOut(p);
                yield return null;
            }

            Sprite.Play("fallSlow");
        }
    }
}
