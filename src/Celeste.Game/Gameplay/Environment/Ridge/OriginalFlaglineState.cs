using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Color = Celeste.Core.Display.PackedColor;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalFlaglineState : SourceComponentState
    {
        protected readonly ISourceEngineContext engine;

        protected struct Cloth
        {
            public int Color;

            public int Height;

            public int Length;

            public int Step;
        }

        private readonly Color[] colors;

        private readonly Color[] highlights;

        private readonly Color lineColor;

        private readonly Color pinColor;

        protected Cloth[] clothes;

        protected float waveTimer;

        public float ClothDroopAmount = 0.6f;

        public Vector2 To;

        public Vector2 From => ((ISourceEntityPosition)Entity).Position;

        public OriginalFlaglineState(ISourceEngineContext engine, Vector2 to, Color lineColor, Color pinColor,
            Color[] colors, int minFlagHeight, int maxFlagHeight, int minFlagLength, int maxFlagLength, int minSpace,
            int maxSpace)
            : base(true, true)
        {
            this.engine = engine;
            To = to;
            this.colors = colors;
            this.lineColor = lineColor;
            this.pinColor = pinColor;
            waveTimer = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * ((float)Math.PI * 2f);
            highlights = new Color[colors.Length];
            for (var i = 0; i < colors.Length; i++)
                highlights[i] = SourceColorInterpolation.Lerp(colors[i], Color.White, 0.1f,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);

            clothes = new Cloth[10];
            for (var j = 0; j < clothes.Length; j++)
                clothes[j] = new()
                {
                    Color = ((ISourceRandomEnvironment)engine).Random.Next(colors.Length),
                    Height = ((ISourceRandomEnvironment)engine).Random.Next(minFlagHeight, maxFlagHeight),
                    Length = ((ISourceRandomEnvironment)engine).Random.Next(minFlagLength, maxFlagLength),
                    Step = ((ISourceRandomEnvironment)engine).Random.Next(minSpace, maxSpace),
                };
        }

        public override void Update()
        {
            waveTimer += engine.DeltaTime;
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var vector = From.X < To.X ? From : To;
            var vector2 = From.X < To.X ? To : From;
            var num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector - vector2);
            var num2 = num / 8f;
            var simpleCurve = new SimpleCurve(vector, vector2,
                (vector2 + vector) / 2f + Vector2.UnitY * (num2 + (float)Math.Sin(waveTimer) * num2 * 0.3f));
            RenderCurve(context, vector, simpleCurve, num);
        }

        protected void RenderCurve(ISourceRenderContext context, Vector2 vector, SimpleCurve simpleCurve, float num)
        {
            var vector3 = vector;
            var vector4 = vector;
            var num3 = 0f;
            var num4 = 0;
            var flag = false;
            while (num3 < 1f)
            {
                var cloth = clothes[num4 % clothes.Length];
                num3 += (flag ? cloth.Length : cloth.Step) / num;
                vector4 = ((ISourceCurveEnvironment)engine).CurveArithmetic.GetPoint(simpleCurve, num3);
                SourcePrimitiveDrawing.Line(context, Entity, vector3, vector4, lineColor,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                if (num3 < 1f && flag)
                {
                    var num5 = cloth.Length * ClothDroopAmount;
                    var simpleCurve2 = new SimpleCurve(vector3, vector4,
                        (vector3 + vector4) / 2f +
                        new Vector2(0f, num5 + (float)Math.Sin(waveTimer * 2f + num3) * num5 * 0.4f));
                    var vector5 = vector3;
                    for (var num6 = 1f; num6 <= cloth.Length; num6 += 1f)
                    {
                        var point =
                            ((ISourceCurveEnvironment)engine).CurveArithmetic.GetPoint(simpleCurve2,
                                num6 / cloth.Length);
                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                        if (point.X != vector5.X)
                        {
                            SourcePrimitiveDrawing.Rect(context, Entity, vector5.X, vector5.Y, point.X - vector5.X + 1f,
                                cloth.Height, colors[cloth.Color]);
                            vector5 = point;
                        }
                    }

                    SourcePrimitiveDrawing.Rect(context, Entity, vector3.X, vector3.Y, 1f, cloth.Height,
                        highlights[cloth.Color]);
                    SourcePrimitiveDrawing.Rect(context, Entity, vector4.X, vector4.Y, 1f, cloth.Height,
                        highlights[cloth.Color]);
                    SourcePrimitiveDrawing.Rect(context, Entity, vector3.X, vector3.Y - 1f, 1f, 3f, pinColor);
                    SourcePrimitiveDrawing.Rect(context, Entity, vector4.X, vector4.Y - 1f, 1f, 3f, pinColor);
                    num4++;
                }

                vector3 = vector4;
                flag = !flag;
            }
        }
    }
}
