using Celeste.Core.Display;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Text;
using Celeste.Graphics.Rendering;

namespace Celeste.Simulation.UI.Menus.Completion
{
    public class AreaCompleteTitlePresentation : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        public class Letter
        {
            private readonly ISourceEngineContext engine;
            public string Value;

            public Vector2 Position;

            public PackedColor Color = PackedColor.White;

            public PackedColor Shadow = PackedColor.Black;

            private float delay;

            private float ease;

            private Vector2 scale;

            private SimpleCurve curve;

            public Letter(ISourceEngineContext engine, int index, string value, Vector2 position)
            {
                this.engine = engine;
                Value = value;
                Position = position;
                delay = 0.2f + (float)index * 0.02f;
                curve = new SimpleCurve(position + Vector2.UnitY * 60f, position, position - Vector2.UnitY * 100f);
                scale = new Vector2(0.75f, 1.5f);
            }

            public void Update()
            {
                scale.X = ScalarMath.Approach(scale.X, 1f, 3f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                scale.Y = ScalarMath.Approach(scale.Y, 1f, 3f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (delay > 0f)
                {
                    delay -= engine.DeltaTime;
                }
                else if (ease < 1f)
                {
                    ease += 4f * engine.DeltaTime;
                    if (ease >= 1f)
                    {
                        ease = 1f;
                        scale = new Vector2(1.5f, 0.75f);
                    }
                }
            }

            public void Render(ISourceRenderContext context, SceneEntityState actualEntity, Vector2 offset, float scale,
                float alphaMultiplier)
            {
                if (ease > 0f)
                {
                    Vector2 vector = offset + ((ISourceCurveEnvironment)engine).CurveArithmetic.GetPoint(curve, ease);
                    float num = ScalarMath.Lerp(0f, 1f, ScalarMath.Clamp(ease * 3f, 0f, 1f),
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic) * alphaMultiplier;
                    Vector2 vector2 = this.scale * scale;
                    if (num < 1f)
                    {
                        ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, actualEntity, Value, vector,
                            new Vector2(0.5f, 1f), vector2, Color * num);
                        return;
                    }

                    ((ISourceActiveFontScope)engine).ActiveFont.Draw(context, actualEntity, Value,
                        vector + Vector2.UnitY * 3.5f * scale, new Vector2(0.5f, 1f), vector2, Shadow);
                    ((ISourceActiveFontScope)engine).ActiveFont.DrawOutline(context, actualEntity, Value, vector,
                        new Vector2(0.5f, 1f), vector2, Color, 2f, Shadow);
                }
            }
        }

        public float Alpha = 1f;

        private Vector2 origin;

        private List<Letter> letters = new List<Letter>();

        private float rectangleEase;

        private float scale;

        public AreaCompleteTitlePresentation(Vector2 origin, string text, float scale, ISourceEngineContext engine,
            bool rainbow = false)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.origin = origin;
            this.scale = scale;
            Vector2 vector = ((ISourceActiveFontScope)engine).ActiveFont.Measure(text) * scale;
            Vector2 vector2 = origin + Vector2.UnitY * vector.Y * 0.5f + Vector2.UnitX * vector.X * -0.5f;
            for (int i = 0; i < text.Length; i++)
            {
                Vector2 vector3 = ((ISourceActiveFontScope)engine).ActiveFont.Measure(text[i].ToString()) * scale;
                if (text[i] != ' ')
                {
                    Letter letter = new Letter(engine, i, text[i].ToString(),
                        vector2 + Vector2.UnitX * vector3.X * 0.5f);
                    if (rainbow)
                    {
                        float hue = (float)i / (float)text.Length;
                        letter.Color = ColorMath.HsvToPackedColor(hue, 0.8f, 0.9f);
                        letter.Shadow = SourceColorInterpolation.Lerp(letter.Color, PackedColor.Black, 0.7f,
                            ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                    }

                    letters.Add(letter);
                }

                vector2 += Vector2.UnitX * vector3.X;
            }

            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 2.6f, delegate
            {
                SourceTweenState tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.SineOut, 0.5f, start: true);
                tween.OnUpdate = delegate(SourceTweenState t) { rectangleEase = t.Eased; };
                Add(tween);
            });
        }

        public override void Update()
        {
            base.Update();
            foreach (Letter letter in letters)
            {
                letter.Update();
            }
        }

        public void DrawLineUI(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, base.X, base.Y + origin.Y - 40f, 1920f * rectangleEase, 80f,
                PackedColor.Black * 0.65f);
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            foreach (Letter letter in letters)
            {
                letter.Render(context, this, Position, scale, Alpha);
            }
        }
    }
}
