using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Effects.Liquids
{
    public class LavaRectangleComponentState : SourceComponentState
    {
        private readonly ISourceLavaRectangleEnvironment engine;
        private readonly string surfaceAnimationKey;
        private readonly string bubbleKey;

        public enum OnlyModes
        {
            None,
            OnlyTop,
            OnlyBottom
        }

        private struct Bubble
        {
            public Vector2 Position;

            public float Speed;

            public float Alpha;
        }

        private struct SurfaceBubble
        {
            public float X;

            public float Frame;

            public byte Animation;
        }

        public Vector2 Position;

        public float Fade = 16f;

        public float Spikey;

        public OnlyModes OnlyMode;

        public float SmallWaveAmplitude = 1f;

        public float BigWaveAmplitude = 4f;

        public float CurveAmplitude = 12f;

        public float UpdateMultiplier = 1f;

        public PackedColor SurfaceColor = PackedColor.White;

        public PackedColor EdgeColor = PackedColor.LightGray;

        public PackedColor CenterColor = PackedColor.DarkGray;

        private float timer;

        private SourceVertexPositionColor[] verts;

        private bool dirty;

        private int vertCount;

        private Bubble[] bubbles;

        private SurfaceBubble[] surfaceBubbles;

        private int surfaceBubbleIndex;

        private List<List<AtlasEntry>> surfaceBubbleAnimations;

        public int SurfaceStep { get; private set; }

        public float Width { get; private set; }

        public float Height { get; private set; }

        public LavaRectangleComponentState(float width, float height, int step,
            ISourceLavaRectangleEnvironment engine, string surfaceAnimationKey, string bubbleKey)
            : base(active: true, visible: true)
        {
            this.engine = engine;
            this.surfaceAnimationKey = surfaceAnimationKey;
            this.bubbleKey = bubbleKey;
            timer = SourceRandomMath.NextFloat(engine.Random, 100f);
            Resize(width, height, step);
        }

        public void Resize(float width, float height, int step)
        {
            Width = width;
            Height = height;
            SurfaceStep = step;
            dirty = true;
            var sizes = engine.LavaRectangleSizeArithmetic.Compute(width, height, SurfaceStep);
            int num = sizes.VertexSegments;
            verts = new SourceVertexPositionColor[num * 3 * 6 + 6];
            bubbles = new Bubble[sizes.BubbleCount];
            surfaceBubbles = new SurfaceBubble[sizes.SurfaceBubbleCount];
            for (int i = 0; i < bubbles.Length; i++)
            {
                bubbles[i].Position = new Vector2(1f + SourceRandomMath.NextFloat(engine.Random, Width - 2f),
                    SourceRandomMath.NextFloat(engine.Random, Height));
                bubbles[i].Speed = SourceRandomMath.Range(engine.Random, 4, 12);
                bubbles[i].Alpha = SourceRandomMath.Range(engine.Random, 0.4f, 0.8f);
            }

            for (int j = 0; j < surfaceBubbles.Length; j++)
            {
                surfaceBubbles[j].X = -1f;
            }

            surfaceBubbleAnimations = new List<List<AtlasEntry>>();
            surfaceBubbleAnimations.Add(engine.LiquidAtlas.GetAtlasSubtextures(surfaceAnimationKey));
        }

        public override void Update()
        {
            timer += UpdateMultiplier * engine.DeltaTime;
            if (UpdateMultiplier != 0f)
            {
                dirty = true;
            }

            for (int i = 0; i < bubbles.Length; i++)
            {
                bubbles[i].Position.Y -= UpdateMultiplier * bubbles[i].Speed * engine.DeltaTime;
                if (bubbles[i].Position.Y < 2f - Wave((int)(bubbles[i].Position.X / (float)SurfaceStep), Width))
                {
                    bubbles[i].Position.Y = Height - 1f;
                    if (SourceRandomMath.NextFloat(engine.Random) < 0.75f)
                    {
                        surfaceBubbles[surfaceBubbleIndex].X = bubbles[i].Position.X;
                        surfaceBubbles[surfaceBubbleIndex].Frame = 0f;
                        surfaceBubbles[surfaceBubbleIndex].Animation =
                            (byte)engine.Random.Next(surfaceBubbleAnimations.Count);
                        surfaceBubbleIndex = (surfaceBubbleIndex + 1) % surfaceBubbles.Length;
                    }
                }
            }

            for (int j = 0; j < surfaceBubbles.Length; j++)
            {
                if (surfaceBubbles[j].X >= 0f)
                {
                    surfaceBubbles[j].Frame += engine.DeltaTime * 6f;
                    if (surfaceBubbles[j].Frame >= (float)surfaceBubbleAnimations[surfaceBubbles[j].Animation].Count)
                    {
                        surfaceBubbles[j].X = -1f;
                    }
                }
            }

            base.Update();
        }

        private Vector2 SourceLerp(Vector2 first, Vector2 second, float amount)
            => Vector2Interpolation.Lerp(first, second, amount, engine.ScalarArithmetic);

        private float Sin(float value)
        {
            return (1f + (float)Math.Sin(value)) / 2f;
        }

        private float Wave(int step, float length)
        {
            if (engine.LiquidWavePolicy.SuppressWaves) return 0f;
            int num = step * SurfaceStep;
            float num2 = ((OnlyMode != OnlyModes.None)
                ? 1f
                : (ScalarMath.ClampedMap(num, 0f, length * 0.1f) *
                   ScalarMath.ClampedMap(num, length * 0.9f, length, 1f, 0f)));
            float num3 = Sin((float)num * 0.25f + timer * 4f) * SmallWaveAmplitude;
            num3 += Sin((float)num * 0.05f + timer * 0.5f) * BigWaveAmplitude;
            if (step % 2 == 0)
            {
                num3 += Spikey;
            }

            if (OnlyMode != OnlyModes.None)
            {
                num3 += (1f - ScalarMath.YoYo((float)num / length)) * CurveAmplitude;
            }

            return num3 * num2;
        }

        private void Quad(ref int vert, Vector2 va, Vector2 vb, Vector2 vc, Vector2 vd, PackedColor color)
        {
            Quad(ref vert, va, color, vb, color, vc, color, vd, color);
        }

        private void Quad(ref int vert, Vector2 va, PackedColor ca, Vector2 vb, PackedColor cb, Vector2 vc,
            PackedColor cc,
            Vector2 vd, PackedColor cd)
        {
            VertexColorQuadWriter.Write(verts, ref vert, va, ca, vb, cb, vc, cc, vd, cd);
        }

        private void Edge(ref int vert, Vector2 a, Vector2 b, float fade, float insetFade)
        {
            float num = engine.VectorArithmetic.Length(a - b);
            float num2 = ((OnlyMode == OnlyModes.None) ? (insetFade / num) : 0f);
            float num3 = num / (float)SurfaceStep;
            Vector2 vector = Vector2Geometry.Perpendicular(engine.VectorArithmetic.SafeNormalize(b - a));
            for (int i = 1; (float)i <= num3; i++)
            {
                Vector2 vector2 = SourceLerp(a, b, (float)(i - 1) / num3);
                float num4 = Wave(i - 1, num);
                Vector2 vector3 = vector2 - vector * num4;
                Vector2 vector4 = SourceLerp(a, b, (float)i / num3);
                float num5 = Wave(i, num);
                Vector2 vector5 = vector4 - vector * num5;
                Vector2 vector6 = SourceLerp(a, b,
                    ScalarMath.ClampedMap((float)(i - 1) / num3, 0f, 1f, num2, 1f - num2));
                Vector2 vector7 = SourceLerp(a, b, ScalarMath.ClampedMap((float)i / num3, 0f, 1f, num2, 1f - num2));
                Quad(ref vert, vector3 + vector, EdgeColor, vector5 + vector, EdgeColor,
                    vector7 + vector * (fade - num5),
                    CenterColor, vector6 + vector * (fade - num4), CenterColor);
                Quad(ref vert, vector6 + vector * (fade - num4), vector7 + vector * (fade - num5),
                    vector7 + vector * fade,
                    vector6 + vector * fade, CenterColor);
                Quad(ref vert, vector3, vector5, vector5 + vector * 1f, vector3 + vector * 1f, SurfaceColor);
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            engine.GameplayBatchScope.End(context);
            if (dirty)
            {
                Vector2 zero = Vector2.Zero;
                Vector2 vector = zero;
                Vector2 vector2 = new Vector2(zero.X + Width, zero.Y);
                Vector2 vector3 = new Vector2(zero.X, zero.Y + Height);
                Vector2 vector4 = zero + new Vector2(Width, Height);
                Vector2 vector5 = new Vector2(engine.ExtremaArithmetic.Min(Fade, Width / 2f),
                    engine.ExtremaArithmetic.Min(Fade, Height / 2f));
                vertCount = 0;
                if (OnlyMode == OnlyModes.None)
                {
                    Edge(ref vertCount, vector, vector2, vector5.Y, vector5.X);
                    Edge(ref vertCount, vector2, vector4, vector5.X, vector5.Y);
                    Edge(ref vertCount, vector4, vector3, vector5.Y, vector5.X);
                    Edge(ref vertCount, vector3, vector, vector5.X, vector5.Y);
                    Quad(ref vertCount, vector + vector5, vector2 + new Vector2(0f - vector5.X, vector5.Y),
                        vector4 - vector5, vector3 + new Vector2(vector5.X, 0f - vector5.Y), CenterColor);
                }
                else if (OnlyMode == OnlyModes.OnlyTop)
                {
                    Edge(ref vertCount, vector, vector2, vector5.Y, 0f);
                    Quad(ref vertCount, vector + new Vector2(0f, vector5.Y), vector2 + new Vector2(0f, vector5.Y),
                        vector4,
                        vector3, CenterColor);
                }
                else if (OnlyMode == OnlyModes.OnlyBottom)
                {
                    Edge(ref vertCount, vector4, vector3, vector5.Y, 0f);
                    Quad(ref vertCount, vector, vector2, vector4 + new Vector2(0f, 0f - vector5.Y),
                        vector3 + new Vector2(0f, 0f - vector5.Y), CenterColor);
                }

                dirty = false;
            }

            var camera = (base.Scene as ISourceCameraScene).Camera;
            SourcePrimitiveGraphics.DrawVertices(engine.PrimitiveGraphics,
                SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(
                    new Vector3(((ISourceEntityPosition)base.Entity).Position + Position, 0f)), camera.Matrix),
                verts, vertCount);
            engine.GameplayBatchScope.Begin(context);
            Vector2 vector6 = ((ISourceEntityPosition)base.Entity).Position + Position;
            AtlasEntry mTexture = engine.LiquidAtlas[bubbleKey];
            for (int i = 0; i < bubbles.Length; i++)
            {
                SourceAtlasDrawing.DrawCentered(context, Entity, mTexture, vector6 + bubbles[i].Position,
                    SurfaceColor * bubbles[i].Alpha);
            }

            for (int j = 0; j < surfaceBubbles.Length; j++)
            {
                if (surfaceBubbles[j].X >= 0f)
                {
                    AtlasEntry mTexture2 =
                        surfaceBubbleAnimations[surfaceBubbles[j].Animation][(int)surfaceBubbles[j].Frame];
                    int num = (int)(surfaceBubbles[j].X / (float)SurfaceStep);
                    SourceAtlasDrawing.DrawJustified(context, Entity, mTexture2,
                        vector6 + new Vector2(y: 1f - Wave(num, Width), x: num * SurfaceStep), new Vector2(0.5f, 1f),
                        SurfaceColor);
                }
            }
        }
    }
}
