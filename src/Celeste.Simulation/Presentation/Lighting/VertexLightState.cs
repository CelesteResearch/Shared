using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;

namespace Celeste.Simulation.Presentation.Lighting
{
    public sealed class VertexLightState : SourceComponentState
    {
        private readonly ISourceEngineContext engine;
        public Vector2 EntityPosition => ((ISourceEntityPosition)Entity).Position;

        public bool EntityVisible => ((ISourceEntityVisibility)Entity).Visible;

        // Backend context is distinct from the source Entity and its source Scene.
        public int Index = -1;
        public bool Dirty = true, InSolid, Started, Spotlight;
        public Vector2 LastNonSolidPosition, LastEntityPosition, LastPosition;
        public float InSolidAlphaMultiplier = 1, SpotlightDirection, SpotlightPush;
        public PackedColor Color = PackedColor.White;
        public float Alpha = 1;
        private Vector2 position;
        private float startRadius = 16, endRadius = 32;
        public Vector2 Center => EntityPosition + position;

        public Vector2 Position
        {
            get => position;
            set
            {
                if (position != value)
                {
                    Dirty = true;
                    position = value;
                }
            }
        }

        public float X
        {
            get => position.X;
            set => Position = new(value, position.Y);
        }

        public float Y
        {
            get => position.Y;
            set => Position = new(position.X, value);
        }

        public float StartRadius
        {
            get => startRadius;
            set
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (startRadius != value)
                {
                    Dirty = true;
                    startRadius = value;
                }
            }
        }

        public float EndRadius
        {
            get => endRadius;
            set
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (endRadius != value)
                {
                    Dirty = true;
                    endRadius = value;
                }
            }
        }

        public VertexLightState(ISourceEngineContext engine) : base(true, true)
        {
            this.engine = engine;
        }

        public VertexLightState(ISourceEngineContext engine, PackedColor color, float alpha, int startFade, int endFade)
            : this(engine, Vector2.Zero, color, alpha, startFade, endFade)
        {
        }

        public VertexLightState(ISourceEngineContext engine, Vector2 position, PackedColor color, float alpha,
            int startFade, int endFade)
            : base(true, true)
        {
            this.engine = engine;
            Position = position;
            Color = color;
            Alpha = alpha;
            StartRadius = startFade;
            EndRadius = endFade;
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            LastNonSolidPosition = Center;
            LastEntityPosition = EntityPosition;
            LastPosition = Position;
        }

        public override void Update()
        {
            InSolidAlphaMultiplier = ScalarMath.Approach(InSolidAlphaMultiplier,
                InSolid ? 0f : 1f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void HandleGraphicsReset()
        {
            Dirty = true;
            base.HandleGraphicsReset();
        }

        public SourceTweenState CreatePulseTween(ISourceEngineContext engine)
        {
            var startA = StartRadius;
            var startB = startA + 6f;
            var endA = EndRadius;
            var endB = endA + 12f;
            var arithmetic = ((ISourceScalarEnvironment)engine).ScalarArithmetic;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Persist, null, .5f);
            tween.OnUpdate = t =>
            {
                StartRadius = (int)arithmetic.Lerp(startB, startA, t.Eased);
                EndRadius = (int)arithmetic.Lerp(endB, endA, t.Eased);
            };
            return tween;
        }

        public SourceTweenState CreateFadeInTween(float time, ISourceEngineContext engine)
        {
            var from = 0f;
            var to = Alpha;
            Alpha = 0f;
            var arithmetic = ((ISourceScalarEnvironment)engine).ScalarArithmetic;
            var easing = ((ISourceEasingEnvironment)engine).EasingArithmetic;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Persist, easing.CubeOut,
                time);
            tween.OnUpdate = t => Alpha = arithmetic.Lerp(from, to, t.Eased);
            return tween;
        }

        public SourceTweenState CreateBurstTween(float time, ISourceEngineContext engine)
        {
            time += .8f;
            var delay = (time - .8f) / time;
            var startA = StartRadius;
            var startB = startA + 6f;
            var endA = EndRadius;
            var endB = endA + 12f;
            var arithmetic = ((ISourceScalarEnvironment)engine).ScalarArithmetic;
            var easing = ((ISourceEasingEnvironment)engine).EasingArithmetic;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Persist, null, time);
            tween.OnUpdate = t =>
            {
                float value;
                if (t.Percent >= delay)
                {
                    value = (t.Percent - delay) / (1f - delay);
                    value = ScalarMath.Clamp(value, 0f, 1f);
                    value = easing.CubeIn(value);
                }
                else
                {
                    value = 0f;
                }

                StartRadius = (int)arithmetic.Lerp(startB, startA, value);
                EndRadius = (int)arithmetic.Lerp(endB, endA, value);
            };
            return tween;
        }
    }
}
