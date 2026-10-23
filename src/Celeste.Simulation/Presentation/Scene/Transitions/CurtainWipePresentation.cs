using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class CurtainWipePresentation : ScreenWipePresentation
    {
        private readonly SourceVertexPositionColor[] vertexBufferLeft = new SourceVertexPositionColor[192];

        private readonly SourceVertexPositionColor[] vertexBufferRight = new SourceVertexPositionColor[192];

        public CurtainWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (var i = 0; i < vertexBufferLeft.Length; i++) vertexBufferLeft[i].Color = WipeColor;
        }

        public override void Render(object scene)
        {
            var num = (WipeIn ? Easing.CubeInOut : Easing.CubeInOut)(WipeIn ? 1f - Percent : Percent);
            var num2 = Extrema.Min(1f, num / 0.3f);
            var num3 = Extrema.Max(0f, Extrema.Min(1f, (num - 0.1f) / 0.9f / 0.9f));
            var vector = new Vector2(0f, 540f * num2);
            var vector2 = VectorArithmetic.Divide(new Vector2(1920f, 1592f), 2f);
            var control = SourceVector2Math.Add(VectorArithmetic.Divide(SourceVector2Math.Add(vector, vector2), 2f),
                SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitY, 1080f), 0.25f));
            var vector3 = new Vector2(896f + 200f * num, -350f + 256f * num2);
            var point = new SimpleCurve(vector, vector2, control).GetPoint(num3, CurveArithmetic);
            var vector4 = new Vector2(point.X + 64f * num, 1080f);
            var i = 0;
            vertexBufferLeft[i++].Position = new(-10f, -10f, 0f);
            vertexBufferLeft[i++].Position = new(vector3.X, -10f, 0f);
            vertexBufferLeft[i++].Position = new(vector3.X, vector3.Y, 0f);
            vertexBufferLeft[i++].Position = new(-10f, -10f, 0f);
            vertexBufferLeft[i++].Position = new(-10f, point.Y, 0f);
            vertexBufferLeft[i++].Position = new(point.X, point.Y, 0f);
            vertexBufferLeft[i++].Position = new(point.X, point.Y, 0f);
            vertexBufferLeft[i++].Position = new(-10f, point.Y, 0f);
            vertexBufferLeft[i++].Position = new(-10f, 1090f, 0f);
            vertexBufferLeft[i++].Position = new(point.X, point.Y, 0f);
            vertexBufferLeft[i++].Position = new(-10f, 1090f, 0f);
            vertexBufferLeft[i++].Position = new(vector4.X, vector4.Y + 10f, 0f);
            var num4 = i;
            var value = vector3;
            for (; i < vertexBufferLeft.Length; i += 3)
            {
                var point2 =
                    new SimpleCurve(vector3, point,
                            SourceVector2Math.Add(VectorArithmetic.Divide(SourceVector2Math.Add(vector3, point), 2f),
                                new(0f, 384f * num3)))
                        .GetPoint((i - num4) / (float)(vertexBufferLeft.Length - num4 - 3), CurveArithmetic);
                vertexBufferLeft[i].Position = new(-10f, -10f, 0f);
                vertexBufferLeft[i + 1].Position = new(value, 0f);
                vertexBufferLeft[i + 2].Position = new(point2, 0f);
                value = point2;
            }

            for (i = 0; i < vertexBufferLeft.Length; i++)
            {
                vertexBufferRight[i] = vertexBufferLeft[i];
                vertexBufferRight[i].Position.X = 1920f - vertexBufferRight[i].Position.X;
            }

            DrawPrimitives(vertexBufferLeft);
            DrawPrimitives(vertexBufferRight);
        }
    }
}
