using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public class OriginalBadelineCryingOrbState : SceneEntityState
    {
        public SpriteImage Sprite;
        public BloomPointState Bloom;
        private float ease;
        public Vector2 Target;
        public SimulationCoroutine Routine;
        private readonly ISourceEngineContext engine;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic ExtremaArithmetic => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic EasingArithmetic => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public float Ease
        {
            get => ease;
            set
            {
                ease = value;
                Sprite.Scale = Vector2.One * ease;
                Bloom.Alpha = ease;
            }
        }

        public OriginalBadelineCryingOrbState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            Sprite = new SpriteImage(
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["characters/badeline/orb"]);
            OwnedComponents.Add(Sprite);
            Bloom = new BloomPointState(0f, 32f);
            OwnedComponents.Add(Bloom);
            Routine = new SimulationCoroutine(engine, FloatRoutine());
            OwnedComponents.Add(Routine);
            Sprite.CenterOrigin();
            Depth = -10001;
        }

        public IEnumerator FloatRoutine()
        {
            Vector2 speed = Vector2.Zero;
            Ease = .2f;
            while (true)
            {
                Vector2 target = Target + Vector2Geometry.AngleToVector(
                    (float)((ISourceRandomEnvironment)engine).Random.NextDouble() * ((float)Math.PI * 2f),
                    16f + (float)((ISourceRandomEnvironment)engine).Random.NextDouble() * 40f);
                float reset = 0f;
                while (reset < 1f && VectorArithmetic.Length(target - Position) > 8f)
                {
                    var vector = VectorArithmetic.SafeNormalize(target - Position);
                    speed += vector * 420f * engine.DeltaTime;
                    if (VectorArithmetic.Length(speed) > 90f) speed = VectorArithmetic.SafeNormalize(speed, 90f);
                    Position += speed * engine.DeltaTime;
                    reset += engine.DeltaTime;
                    Ease = ScalarMath.Approach(Ease, 1f, engine.DeltaTime * 4f, ExtremaArithmetic);
                    yield return null;
                }
            }
        }

        public IEnumerator CircleRoutine(float offset)
        {
            Vector2 from = Position;
            float ease = 0f;
            var player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            while (player != null)
            {
                float angle = ((ISourceScene)Scene).SourceScene.Clock.TimeActive * 2f + offset;
                Vector2 vector = player.Center + Vector2Geometry.AngleToVector(angle, 24f);
                ease = ScalarMath.Approach(ease, 1f, engine.DeltaTime * 2f, ExtremaArithmetic);
                Position = from + (vector - from) * EasingArithmetic.CubeInOut(ease);
                yield return null;
            }
        }

        public IEnumerator AbsorbRoutine()
        {
            var player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            if (player != null)
            {
                Vector2 from = Position;
                Vector2 to = player.Center;
                for (float p = 0f; p < 1f; p += engine.DeltaTime)
                {
                    float value = EasingArithmetic.BigBackIn(p);
                    Position = from + (to - from) * value;
                    Ease = .2f + (1f - value) * .8f;
                    yield return null;
                }
            }
        }
    }
}
