using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class HeartWipePresentation : ScreenWipePresentation
    {
        private readonly SourceVertexPositionColor[] vertex = new SourceVertexPositionColor[111];

        public HeartWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (var i = 0; i < vertex.Length; i++) vertex[i].Color = WipeColor;
        }

        public override void Render(object scene)
        {
            var num = ((WipeIn ? Percent : 1f - Percent) - 0.2f) / 0.8f;
            if (num <= 0f)
            {
                RenderContext.BeginBatch(new(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, null, null,
                    RenderContext.Graphics.ScreenMatrix));
                SourcePrimitiveDrawing.Rect(RenderContext, this, -1f, -1f, RenderContext.Graphics.Width + 2,
                    RenderContext.Graphics.Height + 2, WipeColor);
                RenderContext.EndBatch();
                return;
            }

            var vector =
                VectorArithmetic.Divide(new Vector2(RenderContext.Graphics.Width, RenderContext.Graphics.Height), 2f);
            var num2 = RenderContext.Graphics.Width * 0.75f * num;
            var num3 = RenderContext.Graphics.Width * num;
            var num4 = -0.25f;
            var num5 = -(float)Math.PI / 2f;
            var vector2 =
                SourceVector2Math.Add(vector, new((0f - (float)Math.Cos(num4)) * num2, (0f - num2) / 2f));
            var num6 = 0;
            for (var i = 1; i <= 16; i++)
            {
                var angleRadians = num4 + (num5 - num4) * ((i - 1) / 16f);
                var angleRadians2 = num4 + (num5 - num4) * (i / 16f);
                vertex[num6++].Position = new(vector.X, 0f - num3, 0f);
                vertex[num6++].Position =
                    new(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians, num2)), 0f);
                vertex[num6++].Position =
                    new(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians2, num2)), 0f);
            }

            vertex[num6++].Position = new(vector.X, 0f - num3, 0f);
            vertex[num6++].Position = new(SourceVector2Math.Add(vector2, new(0f, 0f - num2)), 0f);
            vertex[num6++].Position = new(0f - num3, 0f - num3, 0f);
            vertex[num6++].Position = new(0f - num3, 0f - num3, 0f);
            vertex[num6++].Position = new(SourceVector2Math.Add(vector2, new(0f, 0f - num2)), 0f);
            vertex[num6++].Position = new(0f - num3, vector2.Y, 0f);
            var num7 = (float)Math.PI * 3f / 4f;
            for (var j = 1; j <= 16; j++)
            {
                var angleRadians3 = -(float)Math.PI / 2f - (j - 1) / 16f * num7;
                var angleRadians4 = -(float)Math.PI / 2f - j / 16f * num7;
                vertex[num6++].Position = new(0f - num3, vector2.Y, 0f);
                vertex[num6++].Position =
                    new(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians3, num2)), 0f);
                vertex[num6++].Position =
                    new(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians4, num2)), 0f);
            }

            var value =
                SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(-(float)Math.PI / 2f - num7, num2));
            var value2 = SourceVector2Math.Add(vector, new(0f, num2 * 1.8f));
            vertex[num6++].Position = new(0f - num3, vector2.Y, 0f);
            vertex[num6++].Position = new(value, 0f);
            vertex[num6++].Position = new(0f - num3, RenderContext.Graphics.Height + num3, 0f);
            vertex[num6++].Position = new(0f - num3, RenderContext.Graphics.Height + num3, 0f);
            vertex[num6++].Position = new(value, 0f);
            vertex[num6++].Position = new(value2, 0f);
            vertex[num6++].Position = new(0f - num3, RenderContext.Graphics.Height + num3, 0f);
            vertex[num6++].Position = new(value2, 0f);
            vertex[num6++].Position = new(vector.X, RenderContext.Graphics.Height + num3, 0f);
            DrawPrimitives(vertex);
            for (num6 = 0; num6 < vertex.Length; num6++) vertex[num6].Position.X = 1920f - vertex[num6].Position.X;

            DrawPrimitives(vertex);
        }
    }
}
