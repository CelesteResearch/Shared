using System;
using Celeste.Core.Mathematics.LinearAlgebra;
using System.Numerics;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Core.Mathematics;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class CurtainWipePresentation : ScreenWipePresentation
    {
        private SourceVertexPositionColor[] vertexBufferLeft = new SourceVertexPositionColor[192];

        private SourceVertexPositionColor[] vertexBufferRight = new SourceVertexPositionColor[192];

        public CurtainWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (int i = 0; i < vertexBufferLeft.Length; i++)
            {
                vertexBufferLeft[i].Color = WipeColor;
            }
        }

        public override void Render(object scene)
        {
            float num = (WipeIn ? Easing.CubeInOut : Easing.CubeInOut)(WipeIn ? (1f - Percent) : Percent);
            float num2 = Extrema.Min(1f, num / 0.3f);
            float num3 = Extrema.Max(0f, Extrema.Min(1f, (num - 0.1f) / 0.9f / 0.9f));
            Vector2 vector = new Vector2(0f, 540f * num2);
            Vector2 vector2 = VectorArithmetic.Divide(new Vector2(1920f, 1592f), 2f);
            Vector2 control = SourceVector2Math.Add(VectorArithmetic.Divide(SourceVector2Math.Add(vector, vector2), 2f),
                SourceVector2Math.Multiply(SourceVector2Math.Multiply(Vector2.UnitY, 1080f), 0.25f));
            Vector2 vector3 = new Vector2(896f + 200f * num, -350f + 256f * num2);
            Vector2 point = new SimpleCurve(vector, vector2, control).GetPoint(num3, CurveArithmetic);
            Vector2 vector4 = new Vector2(point.X + 64f * num, 1080f);
            int i = 0;
            vertexBufferLeft[i++].Position = new Vector3(-10f, -10f, 0f);
            vertexBufferLeft[i++].Position = new Vector3(vector3.X, -10f, 0f);
            vertexBufferLeft[i++].Position = new Vector3(vector3.X, vector3.Y, 0f);
            vertexBufferLeft[i++].Position = new Vector3(-10f, -10f, 0f);
            vertexBufferLeft[i++].Position = new Vector3(-10f, point.Y, 0f);
            vertexBufferLeft[i++].Position = new Vector3(point.X, point.Y, 0f);
            vertexBufferLeft[i++].Position = new Vector3(point.X, point.Y, 0f);
            vertexBufferLeft[i++].Position = new Vector3(-10f, point.Y, 0f);
            vertexBufferLeft[i++].Position = new Vector3(-10f, 1090f, 0f);
            vertexBufferLeft[i++].Position = new Vector3(point.X, point.Y, 0f);
            vertexBufferLeft[i++].Position = new Vector3(-10f, 1090f, 0f);
            vertexBufferLeft[i++].Position = new Vector3(vector4.X, vector4.Y + 10f, 0f);
            int num4 = i;
            Vector2 value = vector3;
            for (; i < vertexBufferLeft.Length; i += 3)
            {
                Vector2 point2 =
                    new SimpleCurve(vector3, point,
                            SourceVector2Math.Add(VectorArithmetic.Divide(SourceVector2Math.Add(vector3, point), 2f),
                                new Vector2(0f, 384f * num3)))
                        .GetPoint((float)(i - num4) / (float)(vertexBufferLeft.Length - num4 - 3), CurveArithmetic);
                vertexBufferLeft[i].Position = new Vector3(-10f, -10f, 0f);
                vertexBufferLeft[i + 1].Position = new Vector3(value, 0f);
                vertexBufferLeft[i + 2].Position = new Vector3(point2, 0f);
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
