using System;
using Celeste.Core.Mathematics.LinearAlgebra;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class HeartWipePresentation : ScreenWipePresentation
    {
        private SourceVertexPositionColor[] vertex = new SourceVertexPositionColor[111];

        public HeartWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            for (int i = 0; i < vertex.Length; i++)
            {
                vertex[i].Color = WipeColor;
            }
        }

        public override void Render(object scene)
        {
            float num = ((WipeIn ? Percent : (1f - Percent)) - 0.2f) / 0.8f;
            if (num <= 0f)
            {
                RenderContext.BeginBatch(new SourceRenderBatchState(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, null, null,
                    RenderContext.Graphics.ScreenMatrix));
                SourcePrimitiveDrawing.Rect(RenderContext, this, -1f, -1f, RenderContext.Graphics.Width + 2,
                    RenderContext.Graphics.Height + 2, WipeColor);
                RenderContext.EndBatch();
                return;
            }

            Vector2 vector =
                VectorArithmetic.Divide(new Vector2(RenderContext.Graphics.Width, RenderContext.Graphics.Height), 2f);
            float num2 = (float)RenderContext.Graphics.Width * 0.75f * num;
            float num3 = (float)RenderContext.Graphics.Width * num;
            float num4 = -0.25f;
            float num5 = -(float)Math.PI / 2f;
            Vector2 vector2 =
                SourceVector2Math.Add(vector, new Vector2((0f - (float)Math.Cos(num4)) * num2, (0f - num2) / 2f));
            int num6 = 0;
            for (int i = 1; i <= 16; i++)
            {
                float angleRadians = num4 + (num5 - num4) * ((float)(i - 1) / 16f);
                float angleRadians2 = num4 + (num5 - num4) * ((float)i / 16f);
                vertex[num6++].Position = new Vector3(vector.X, 0f - num3, 0f);
                vertex[num6++].Position =
                    new Vector3(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians, num2)), 0f);
                vertex[num6++].Position =
                    new Vector3(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians2, num2)), 0f);
            }

            vertex[num6++].Position = new Vector3(vector.X, 0f - num3, 0f);
            vertex[num6++].Position = new Vector3(SourceVector2Math.Add(vector2, new Vector2(0f, 0f - num2)), 0f);
            vertex[num6++].Position = new Vector3(0f - num3, 0f - num3, 0f);
            vertex[num6++].Position = new Vector3(0f - num3, 0f - num3, 0f);
            vertex[num6++].Position = new Vector3(SourceVector2Math.Add(vector2, new Vector2(0f, 0f - num2)), 0f);
            vertex[num6++].Position = new Vector3(0f - num3, vector2.Y, 0f);
            float num7 = (float)Math.PI * 3f / 4f;
            for (int j = 1; j <= 16; j++)
            {
                float angleRadians3 = -(float)Math.PI / 2f - (float)(j - 1) / 16f * num7;
                float angleRadians4 = -(float)Math.PI / 2f - (float)j / 16f * num7;
                vertex[num6++].Position = new Vector3(0f - num3, vector2.Y, 0f);
                vertex[num6++].Position =
                    new Vector3(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians3, num2)), 0f);
                vertex[num6++].Position =
                    new Vector3(SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(angleRadians4, num2)), 0f);
            }

            Vector2 value =
                SourceVector2Math.Add(vector2, Vector2Geometry.AngleToVector(-(float)Math.PI / 2f - num7, num2));
            Vector2 value2 = SourceVector2Math.Add(vector, new Vector2(0f, num2 * 1.8f));
            vertex[num6++].Position = new Vector3(0f - num3, vector2.Y, 0f);
            vertex[num6++].Position = new Vector3(value, 0f);
            vertex[num6++].Position = new Vector3(0f - num3, (float)RenderContext.Graphics.Height + num3, 0f);
            vertex[num6++].Position = new Vector3(0f - num3, (float)RenderContext.Graphics.Height + num3, 0f);
            vertex[num6++].Position = new Vector3(value, 0f);
            vertex[num6++].Position = new Vector3(value2, 0f);
            vertex[num6++].Position = new Vector3(0f - num3, (float)RenderContext.Graphics.Height + num3, 0f);
            vertex[num6++].Position = new Vector3(value2, 0f);
            vertex[num6++].Position = new Vector3(vector.X, (float)RenderContext.Graphics.Height + num3, 0f);
            DrawPrimitives(vertex);
            for (num6 = 0; num6 < vertex.Length; num6++)
            {
                vertex[num6].Position.X = 1920f - vertex[num6].Position.X;
            }

            DrawPrimitives(vertex);
        }
    }
}
