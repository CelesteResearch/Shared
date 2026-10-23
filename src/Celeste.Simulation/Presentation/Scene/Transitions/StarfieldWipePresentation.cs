using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Scene.Rendering;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class StarfieldWipePresentation : ScreenWipePresentation
    {
        private struct Star
        {
            public float X;

            public float Y;

            public float Sine;

            public float SineDistance;

            public float Speed;

            public float Scale;

            public float Rotation;

            public Star(float scale, ISourceRandomEnvironment randomEnvironment)
            {
                Scale = scale;
                float num = 1f - scale;
                X = SourceRandomMath.Range(randomEnvironment.Random, 0, 2920);
                Y = 1080f * (0.5f + (float)RandomSelection.Choose(randomEnvironment.Random, -1, 1) * num *
                    SourceRandomMath.Range(randomEnvironment.Random, 0.25f, 0.5f));
                Sine = SourceRandomMath.NextFloat(randomEnvironment.Random, (float)Math.PI * 2f);
                SineDistance = scale * 1080f * 0.05f;
                Speed = (0.5f + (1f - Scale) * 0.5f) * 1920f * 0.05f;
                Rotation = SourceRandomMath.NextFloat(randomEnvironment.Random, (float)Math.PI * 2f);
            }

            public void Update(ISourceEngineContext engine)
            {
                X += Speed * engine.DeltaTime;
                Sine += (1f - Scale) * 8f * engine.DeltaTime;
                Rotation += (1f - Scale) * engine.DeltaTime;
            }
        }

        public SourceBlendState SubtractBlendmode => ProcessWipe.StarfieldSubtractBlendmode;

        private static ISourceRendererScene InitializeSourceGlobals(ISourceRendererScene scene)
        {
            ((ISourceScreenWipeEnvironment)((ISourceEngineContextScene)scene).EngineContext)
                .ProcessWipe.InitializeStarfield();
            return scene;
        }

        private Star[] stars = new Star[64];

        private SourceVertexPositionColor[] verts = new SourceVertexPositionColor[1536];

        private Vector2[] starShape = new Vector2[5];

        private bool hasDrawn;

        public StarfieldWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(InitializeSourceGlobals(scene), wipeIn, onComplete)
        {
            for (int i = 0; i < 5; i++)
            {
                starShape[i] = Vector2Geometry.AngleToVector((float)i / 5f * ((float)Math.PI * 2f), 1f);
            }

            for (int j = 0; j < stars.Length; j++)
            {
                stars[j] = new Star((float)Math.Pow((float)j / (float)stars.Length, 5.0),
                    (ISourceRandomEnvironment)EngineContext);
            }

            for (int k = 0; k < verts.Length; k++)
            {
                verts[k].Color = (WipeIn ? PackedColor.Black : PackedColor.White);
            }
        }

        public override void Update(object scene)
        {
            base.Update(scene);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Update(EngineContext);
            }
        }

        public override void BeforeRender(object scene)
        {
            hasDrawn = true;
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.SetRenderTarget(
                ((ISourceScreenWipeGraphicsContext)RenderContext.Graphics).WipeTarget.Target);
            ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice.Clear(WipeIn
                ? PackedColor.White
                : PackedColor.Black);
            if (Percent > 0.8f)
            {
                float num = ScalarMath.Map(Percent, 0.8f, 1f) * 1082f;
                RenderContext.BeginBatch(new SourceRenderBatchState(SourceSpriteSortMode.Deferred, null, null, null,
                    null,
                    null, Matrix4x4.Identity));
                SourcePrimitiveDrawing.Rect(RenderContext, this, -1f, (1080f - num) * 0.5f, 1922f, num,
                    ((!WipeIn) ? PackedColor.White : PackedColor.Black));
                RenderContext.EndBatch();
            }

            int index = 0;
            for (int i = 0; i < stars.Length; i++)
            {
                float xPosition = -500f + stars[i].X % 2920f;
                float yPosition = (float)((double)stars[i].Y + Math.Sin(stars[i].Sine) * (double)stars[i].SineDistance);
                float scale = (0.1f + stars[i].Scale * 0.9f) * 1080f * 0.8f * Easing.CubeIn(Percent);
                DrawStar(ref index,
                    SourceMatrixMath.Multiply(
                        SourceMatrixMath.Multiply(SourceMatrixMath.CreateRotationZ(stars[i].Rotation),
                            SourceMatrixMath.CreateScale(scale)),
                        SourceMatrixMath.CreateTranslation(xPosition, yPosition, 0f)));
            }

            SourcePrimitiveGraphics.DrawVertices(PrimitiveGraphics, Matrix4x4.Identity, verts, verts.Length);
        }

        private void DrawStar(ref int index, Matrix4x4 matrix)
        {
            int num = index;
            for (int i = 1; i < starShape.Length - 1; i++)
            {
                verts[index++].Position = new Vector3(starShape[0], 0f);
                verts[index++].Position = new Vector3(starShape[i], 0f);
                verts[index++].Position = new Vector3(starShape[i + 1], 0f);
            }

            for (int j = 0; j < 5; j++)
            {
                Vector2 vector = starShape[j];
                Vector2 vector2 = starShape[(j + 1) % 5];
                Vector2 value = SourceVector2Math.Add(
                    SourceVector2Math.Multiply(SourceVector2Math.Add(vector, vector2), 0.5f),
                    Vector2Geometry.Perpendicular(
                        ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.SafeNormalize(
                            SourceVector2Math.Subtract(vector, vector2))));
                verts[index++].Position = new Vector3(vector, 0f);
                verts[index++].Position = new Vector3(value, 0f);
                verts[index++].Position = new Vector3(vector2, 0f);
            }

            for (int k = num; k < num + 24; k++)
            {
                verts[k].Position = SourceVector3Math.Transform(verts[k].Position, matrix);
            }
        }

        public override void Render(object scene)
        {
            RenderContext.BeginBatch(new SourceRenderBatchState(SourceSpriteSortMode.Deferred, SubtractBlendmode,
                SourceSamplerState.LinearClamp, null, null, null, RenderContext.Graphics.ScreenMatrix));
            if ((WipeIn && Percent <= 0.01f) || (!WipeIn && Percent >= 0.99f))
            {
                SourcePrimitiveDrawing.Rect(RenderContext, this, -1f, -1f, 1922f, 1082f, PackedColor.White);
            }
            else if (hasDrawn)
            {
                var target = ((ISourceScreenWipeGraphicsContext)RenderContext.Graphics).WipeTarget;
                ((ISourceDrawScope)RenderContext).Draw.SpriteBatch.Draw(target.Target,
                    new Vector2(-1f, -1f), PackedColor.White.PackedValue);
            }

            RenderContext.EndBatch();
        }
    }
}
