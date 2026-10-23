using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
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
            Sprite = new(
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["characters/badeline/orb"]);
            OwnedComponents.Add(Sprite);
            Bloom = new(0f, 32f);
            OwnedComponents.Add(Bloom);
            Routine = new(engine, FloatRoutine());
            OwnedComponents.Add(Routine);
            Sprite.CenterOrigin();
            Depth = -10001;
        }

        public IEnumerator FloatRoutine()
        {
            var speed = Vector2.Zero;
            Ease = .2f;
            while (true)
            {
                var target = Target + Vector2Geometry.AngleToVector(
                    (float)((ISourceRandomEnvironment)engine).Random.NextDouble() * ((float)Math.PI * 2f),
                    16f + (float)((ISourceRandomEnvironment)engine).Random.NextDouble() * 40f);
                var reset = 0f;
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
            var from = Position;
            var ease = 0f;
            var player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            while (player != null)
            {
                var angle = ((ISourceScene)Scene).SourceScene.Clock.TimeActive * 2f + offset;
                var vector = player.Center + Vector2Geometry.AngleToVector(angle, 24f);
                ease = ScalarMath.Approach(ease, 1f, engine.DeltaTime * 2f, ExtremaArithmetic);
                Position = from + (vector - from) * EasingArithmetic.CubeInOut(ease);
                yield return null;
            }
        }

        public IEnumerator AbsorbRoutine()
        {
            var player =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            if (player != null)
            {
                var from = Position;
                var to = player.Center;
                for (var p = 0f; p < 1f; p += engine.DeltaTime)
                {
                    var value = EasingArithmetic.BigBackIn(p);
                    Position = from + (to - from) * value;
                    Ease = .2f + (1f - value) * .8f;
                    yield return null;
                }
            }
        }
    }
}
