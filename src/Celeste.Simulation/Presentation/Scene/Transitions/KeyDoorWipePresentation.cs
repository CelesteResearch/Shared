using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class KeyDoorWipePresentation : ScreenWipePresentation
    {
        private readonly SourceVertexPositionColor[] vertex = new SourceVertexPositionColor[57];

        public KeyDoorWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (var i = 0; i < vertex.Length; i++) vertex[i].Color = WipeColor;
        }

        public override void Render(object scene)
        {
            var num = 1090;
            var num2 = 540;
            var num3 = WipeIn ? 1f - Percent : Percent;
            var num4 = Easing.SineInOut(Extrema.Min(1f, num3 / 0.5f));
            var num5 = Easing.SineInOut(1f - ScalarMath.Clamp((num3 - 0.5f) / 0.3f, 0f, 1f));
            var num6 = num4;
            var num7 = 1f + (1f - num4) * 0.5f;
            var num8 = 960f * num4;
            var num9 = 128f * num5 * num6;
            var num10 = 128f * num5 * num7;
            var num11 = num2 - num2 * 0.3f * num5 * num7;
            var y = num2 + num2 * 0.5f * num5 * num7;
            var num12 = 0f;
            var angleRadians = 0f;
            var num13 = 0;
            vertex[num13++].Position = new(-10f, -10f, 0f);
            vertex[num13++].Position = new(num8, -10f, 0f);
            vertex[num13++].Position = new(num8, num11 - num10, 0f);
            for (var i = 1; i <= 8; i++)
            {
                num12 = -(float)Math.PI / 2f - (i - 1) / 8f * ((float)Math.PI / 2f);
                angleRadians = -(float)Math.PI / 2f - i / 8f * ((float)Math.PI / 2f);
                vertex[num13++].Position = new(-10f, -10f, 0f);
                vertex[num13++].Position =
                    new(
                        new Vector2(num8, num11) + Vector2Geometry.AngleToVector(num12, 1f) * new Vector2(num9, num10),
                        0f);
                vertex[num13++].Position =
                    new(
                        new Vector2(num8, num11) +
                        Vector2Geometry.AngleToVector(angleRadians, 1f) * new Vector2(num9, num10), 0f);
            }

            vertex[num13++].Position = new(-10f, -10f, 0f);
            vertex[num13++].Position = new(num8 - num9, num11, 0f);
            vertex[num13++].Position = new(-10f, num, 0f);
            for (var j = 1; j <= 6; j++)
            {
                num12 = (float)Math.PI - (j - 1) / 8f * ((float)Math.PI / 2f);
                angleRadians = (float)Math.PI - j / 8f * ((float)Math.PI / 2f);
                vertex[num13++].Position = new(-10f, num, 0f);
                vertex[num13++].Position =
                    new(
                        new Vector2(num8, num11) + Vector2Geometry.AngleToVector(num12, 1f) * new Vector2(num9, num10),
                        0f);
                vertex[num13++].Position =
                    new(
                        new Vector2(num8, num11) +
                        Vector2Geometry.AngleToVector(angleRadians, 1f) * new Vector2(num9, num10), 0f);
            }

            vertex[num13++].Position = new(-10f, num, 0f);
            vertex[num13++].Position =
                new(
                    new Vector2(num8, num11) +
                    Vector2Geometry.AngleToVector(angleRadians, 1f) * new Vector2(num9, num10),
                    0f);
            vertex[num13++].Position = new(num8 - num9 * 0.8f, y, 0f);
            vertex[num13++].Position = new(-10f, num, 0f);
            vertex[num13++].Position = new(num8 - num9 * 0.8f, y, 0f);
            vertex[num13++].Position = new(num8, y, 0f);
            vertex[num13++].Position = new(-10f, num, 0f);
            vertex[num13++].Position = new(num8, y, 0f);
            vertex[num13++].Position = new(num8, num, 0f);
            DrawPrimitives(vertex);
            for (num13 = 0; num13 < vertex.Length; num13++) vertex[num13].Position.X = 1920f - vertex[num13].Position.X;

            DrawPrimitives(vertex);
        }
    }
}
