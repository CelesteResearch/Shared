using Celeste.Core.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Effects.Blur;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content.Textures;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Game.Presentation.Backdrops.Blackhole
{
    public partial class BlackholeBackdropPresentation : BackdropPresentation
    {
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        private SourceTexture2DResource ReadTexture(VirtualTexture texture)
            => ((IGameProfileEnvironment)engine).SourceProfile == GameProfile.InstalledEverest
                ? texture.TextureSafe
                : texture.Texture;

        private float LerpScalar(float from, float to, float amount) =>
            ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(from, to, amount);

        private PackedColor LerpColor(PackedColor from, PackedColor to, float amount) =>
            SourceColorInterpolation.Lerp(from, to, amount, ((ISourceScalarEnvironment)engine).ScalarArithmetic);

        public enum Strengths
        {
            Mild,
            Medium,
            High,
            Wild
        }

        private struct StreamParticle
        {
            public int Color;

            public AtlasEntry Texture;

            public float Percent;

            public float Speed;

            public Vector2 Normal;
        }

        private struct Particle
        {
            public int Color;

            public Vector2 Normal;

            public float Percent;
        }

        private struct SpiralDebris
        {
            public int Color;

            public float Percent;

            public float Offset;
        }

        private const string STRENGTH_FLAG = "blackhole_strength";

        private const int BG_STEPS = 20;

        private const int STREAM_MIN_COUNT = 30;

        private const int STREAM_MAX_COUNT = 50;

        private const int PARTICLE_MIN_COUNT = 150;

        private const int PARTICLE_MAX_COUNT = 220;

        private const int SPIRAL_MIN_COUNT = 0;

        private const int SPIRAL_MAX_COUNT = 10;

        private const int SPIRAL_SEGMENTS = 12;

        private PackedColor[] colorsMild = new PackedColor[3]
        {
            PackedColor.FromHex("6e3199") * 0.8f,
            PackedColor.FromHex("851f91") * 0.8f,
            PackedColor.FromHex("3026b0") * 0.8f
        };

        private PackedColor[] colorsWild = new PackedColor[3]
        {
            PackedColor.FromHex("ca4ca7"),
            PackedColor.FromHex("b14cca"),
            PackedColor.FromHex("ca4ca7")
        };

        private PackedColor[] colorsLerp;

        private PackedColor[,] colorsLerpBlack;

        private PackedColor[,] colorsLerpTransparent;

        private const int colorSteps = 20;

        public float Alpha = 1f;

        public float Scale = 1f;

        public float Direction = 1f;

        public float StrengthMultiplier = 1f;

        public Vector2 CenterOffset;

        public Vector2 OffsetOffset;

        private Strengths strength;

        private PackedColor bgColorInner = PackedColor.FromHex("000000");

        private PackedColor bgColorOuterMild = PackedColor.FromHex("512a8b");

        private PackedColor bgColorOuterWild = PackedColor.FromHex("bd2192");

        private AtlasEntry bgTexture;

        private StreamParticle[] streams = new StreamParticle[50];

        private SourceVertexPositionColorTexture[] streamVerts = new SourceVertexPositionColorTexture[300];

        private Particle[] particles = new Particle[220];

        private SpiralDebris[] spirals = new SpiralDebris[10];

        private SourceVertexPositionColorTexture[] spiralVerts = new SourceVertexPositionColorTexture[720];

        private VirtualRenderTarget buffer;

        private Vector2 center;

        private Vector2 offset;

        private Vector2 shake;

        private float spinTime;

        private bool checkedFlag;

        public int StreamCount => (int)LerpScalar(30f, 50f, (StrengthMultiplier - 1f) / 3f);

        public int ParticleCount => (int)LerpScalar(150f, 220f, (StrengthMultiplier - 1f) / 3f);

        public int SpiralCount => (int)LerpScalar(0f, 10f, (StrengthMultiplier - 1f) / 3f);

        public BlackholeBackdropPresentation(ISourceEngineContext engine)
            : this(engine, default)
        {
        }

        public BlackholeBackdropPresentation(ISourceEngineContext engine, BlackholeBackdropConstruction construction)
        {
            this.engine = engine;
            if (construction.MildColors != null) colorsMild = construction.MildColors;
            bgTexture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/temple/portal/portal"];
            List<AtlasEntry> atlasSubtextures =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "bgs/10/blackhole/particle");
            if (construction.StreamTextures != null) atlasSubtextures = construction.StreamTextures;
            int num = 0;
            for (int i = 0; i < 50; i++)
            {
                AtlasEntry mTexture = (streams[i].Texture = Random.Choose(atlasSubtextures));
                streams[i].Percent = SourceRandomMath.NextFloat(Random);
                streams[i].Speed = SourceRandomMath.Range(Random, 0.2f, 0.4f);
                streams[i].Normal =
                    Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f), 1f);
                streams[i].Color = Random.Next(colorsMild.Length);
                streamVerts[num].TextureCoordinate = new Vector2(mTexture.LeftUV, mTexture.TopUV);
                streamVerts[num + 1].TextureCoordinate = new Vector2(mTexture.RightUV, mTexture.TopUV);
                streamVerts[num + 2].TextureCoordinate = new Vector2(mTexture.RightUV, mTexture.BottomUV);
                streamVerts[num + 3].TextureCoordinate = new Vector2(mTexture.LeftUV, mTexture.TopUV);
                streamVerts[num + 4].TextureCoordinate = new Vector2(mTexture.RightUV, mTexture.BottomUV);
                streamVerts[num + 5].TextureCoordinate = new Vector2(mTexture.LeftUV, mTexture.BottomUV);
                num += 6;
            }

            int num2 = 0;
            for (int j = 0; j < 10; j++)
            {
                AtlasEntry mTexture2 = (streams[j].Texture = Random.Choose(atlasSubtextures));
                spirals[j].Percent = SourceRandomMath.NextFloat(Random);
                spirals[j].Offset = SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f);
                spirals[j].Color = Random.Next(colorsMild.Length);
                for (int k = 0; k < 12; k++)
                {
                    float x = LerpScalar(mTexture2.LeftUV, mTexture2.RightUV, (float)k / 12f);
                    float x2 = LerpScalar(mTexture2.LeftUV, mTexture2.RightUV, (float)(k + 1) / 12f);
                    spiralVerts[num2].TextureCoordinate = new Vector2(x, mTexture2.TopUV);
                    spiralVerts[num2 + 1].TextureCoordinate = new Vector2(x2, mTexture2.TopUV);
                    spiralVerts[num2 + 2].TextureCoordinate = new Vector2(x2, mTexture2.BottomUV);
                    spiralVerts[num2 + 3].TextureCoordinate = new Vector2(x, mTexture2.TopUV);
                    spiralVerts[num2 + 4].TextureCoordinate = new Vector2(x2, mTexture2.BottomUV);
                    spiralVerts[num2 + 5].TextureCoordinate = new Vector2(x, mTexture2.BottomUV);
                    num2 += 6;
                }
            }

            for (int l = 0; l < 220; l++)
            {
                particles[l].Percent = SourceRandomMath.NextFloat(Random);
                particles[l].Normal =
                    Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f), 1f);
                particles[l].Color = Random.Next(colorsMild.Length);
            }

            center = new Vector2(320f, 180f) / 2f;
            offset = Vector2.Zero;
            colorsLerp = new PackedColor[colorsMild.Length];
            colorsLerpBlack = new PackedColor[colorsMild.Length, 20];
            colorsLerpTransparent = new PackedColor[colorsMild.Length, 20];
        }

        public void SnapStrength(OriginalLevelSceneRoot level, Strengths strength)
        {
            this.strength = strength;
            StrengthMultiplier = 1f + (float)strength;
            level.Session.SetCounter("blackhole_strength", (int)strength);
        }

        public void NextStrength(OriginalLevelSceneRoot level, Strengths strength)
        {
            this.strength = strength;
            level.Session.SetCounter("blackhole_strength", (int)strength);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            if (!checkedFlag)
            {
                int counter = ((OriginalLevelSceneRoot)scene).Session.GetCounter("blackhole_strength");
                if (counter >= 0)
                {
                    SnapStrength((OriginalLevelSceneRoot)scene, (Strengths)counter);
                }

                checkedFlag = true;
            }

            if (!Visible)
            {
                return;
            }

            StrengthMultiplier = ScalarMath.Approach(StrengthMultiplier, 1f + (float)strength,
                engine.Frame.DeltaTime * 0.1f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (scene.SourceScene.Clock.OnInterval(0.05f, engine))
            {
                for (int i = 0; i < colorsMild.Length; i++)
                {
                    colorsLerp[i] = LerpColor(colorsMild[i], colorsWild[i], (StrengthMultiplier - 1f) / 3f);
                    for (int j = 0; j < 20; j++)
                    {
                        colorsLerpBlack[i, j] = LerpColor(colorsLerp[i], ForegroundBlack, (float)j / 19f) *
                                                FadeAlphaMultiplier;
                        colorsLerpTransparent[i, j] =
                            LerpColor(colorsLerp[i], PackedColor.Transparent, (float)j / 19f) *
                            FadeAlphaMultiplier;
                    }
                }
            }

            float num = 1f + (StrengthMultiplier - 1f) * 0.7f;
            int streamCount = StreamCount;
            int num2 = 0;
            for (int k = 0; k < streamCount; k++)
            {
                streams[k].Percent += streams[k].Speed * engine.Frame.DeltaTime * num * Direction;
                if (streams[k].Percent >= 1f && Direction > 0f)
                {
                    streams[k].Normal =
                        Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f), 1f);
                    streams[k].Percent -= 1f;
                }
                else if (streams[k].Percent < 0f && Direction < 0f)
                {
                    streams[k].Normal =
                        Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f), 1f);
                    streams[k].Percent += 1f;
                }

                float percent = streams[k].Percent;
                float num3 =
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(
                        ScalarMath.ClampedMap(percent, 0f, 0.8f));
                float num4 =
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(
                        ScalarMath.ClampedMap(percent, 0.2f, 1f));
                Vector2 normal = streams[k].Normal;
                Vector2 vector = new Vector2(-normal.Y, normal.X);
                Vector2 vector2 = normal * 16f + normal * (1f - num3) * 200f;
                float num5 = (1f - num3) * 8f;
                PackedColor a = colorsLerpBlack[streams[k].Color, (int)(num3 * 0.6f * 19f)];
                Vector2 vector3 = normal * 16f + normal * (1f - num4) * 280f;
                float num6 = (1f - num4) * 8f;
                PackedColor c = colorsLerpBlack[streams[k].Color, (int)(num4 * 0.6f * 19f)];
                Vector2 a2 = vector2 - vector * num5;
                Vector2 b = vector2 + vector * num5;
                Vector2 c2 = vector3 + vector * num6;
                Vector2 d = vector3 - vector * num6;
                AssignVertColors(streamVerts, num2, ref a, ref a, ref c, ref c);
                AssignVertPosition(streamVerts, num2, ref a2, ref b, ref c2, ref d);
                num2 += 6;
            }

            float num7 = StrengthMultiplier * 0.25f;
            int particleCount = ParticleCount;
            for (int l = 0; l < particleCount; l++)
            {
                particles[l].Percent += engine.Frame.DeltaTime * num7 * Direction;
                if (particles[l].Percent >= 1f && Direction > 0f)
                {
                    particles[l].Normal =
                        Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f), 1f);
                    particles[l].Percent -= 1f;
                }
                else if (particles[l].Percent < 0f && Direction < 0f)
                {
                    particles[l].Normal =
                        Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random) * ((float)Math.PI * 2f), 1f);
                    particles[l].Percent += 1f;
                }
            }

            float num8 = 0.2f + (StrengthMultiplier - 1f) * 0.1f;
            int spiralCount = SpiralCount;
            PackedColor value = LerpColor(LerpColor(bgColorOuterMild, bgColorOuterWild, (StrengthMultiplier - 1f) / 3f),
                PackedColor.White, 0.1f) * 0.8f;
            int num9 = 0;
            for (int m = 0; m < spiralCount; m++)
            {
                spirals[m].Percent += streams[m].Speed * engine.Frame.DeltaTime * num8 * Direction;
                if (spirals[m].Percent >= 1f && Direction > 0f)
                {
                    spirals[m].Offset = SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f);
                    spirals[m].Percent -= 1f;
                }
                else if (spirals[m].Percent < 0f && Direction < 0f)
                {
                    spirals[m].Offset = SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f);
                    spirals[m].Percent += 1f;
                }

                float percent2 = spirals[m].Percent;
                float num10 = spirals[m].Offset;
                float value2 = ScalarMath.ClampedMap(percent2, 0f, 0.8f);
                float value3 = ScalarMath.ClampedMap(percent2, 0f, 1f);
                for (int n = 0; n < 12; n++)
                {
                    float num11 = 1f - LerpScalar(value2, value3, (float)n / 12f);
                    float num12 = 1f - LerpScalar(value2, value3, (float)(n + 1) / 12f);
                    Vector2 vector4 = Vector2Geometry.AngleToVector(num11 * (20f + (float)n * 0.2f) + num10, 1f);
                    Vector2 vector5 = vector4 * num11 * 200f;
                    float num13 = num11 * (4f + StrengthMultiplier * 4f);
                    Vector2 vector6 = Vector2Geometry.AngleToVector(num12 * (20f + (float)(n + 1) * 0.2f) + num10, 1f);
                    Vector2 vector7 = vector6 * num12 * 200f;
                    float num14 = num12 * (4f + StrengthMultiplier * 4f);
                    PackedColor a3 = LerpColor(value, ForegroundBlack, (1f - num11) * 0.5f);
                    PackedColor b2 = LerpColor(value, ForegroundBlack, (1f - num12) * 0.5f);
                    Vector2 a4 = vector5 + vector4 * num13;
                    Vector2 b3 = vector7 + vector6 * num14;
                    Vector2 c3 = vector7 - vector6 * num14;
                    Vector2 d2 = vector5 - vector4 * num13;
                    AssignVertColors(spiralVerts, num9, ref a3, ref b2, ref b2, ref a3);
                    AssignVertPosition(spiralVerts, num9, ref a4, ref b3, ref c3, ref d2);
                    num9 += 6;
                }
            }

            Vector2 wind = scene.Wind;
            Vector2 vector8 = new Vector2(320f, 180f) / 2f + wind * 0.15f + CenterOffset;
            center += (vector8 - center) * (1f - (float)Math.Pow(0.009999999776482582, engine.Frame.DeltaTime));
            Vector2 vector9 = -wind * 0.25f + OffsetOffset;
            offset += (vector9 - offset) * (1f - (float)Math.Pow(0.009999999776482582, engine.Frame.DeltaTime));
            if (scene.SourceScene.Clock.OnInterval(0.025f, engine))
            {
                shake = Vector2Geometry.AngleToVector(SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f),
                    2f * (StrengthMultiplier - 1f));
            }

            spinTime += (2f + StrengthMultiplier) * engine.Frame.DeltaTime;
        }

        private void AssignVertColors(SourceVertexPositionColorTexture[] verts, int v, ref PackedColor a,
            ref PackedColor b,
            ref PackedColor c, ref PackedColor d)
        {
            verts[v].Color = a;
            verts[v + 1].Color = b;
            verts[v + 2].Color = c;
            verts[v + 3].Color = a;
            verts[v + 4].Color = c;
            verts[v + 5].Color = d;
        }

        private void AssignVertPosition(SourceVertexPositionColorTexture[] verts, int v, ref Vector2 a, ref Vector2 b,
            ref Vector2 c, ref Vector2 d)
        {
            verts[v].Position = new Vector3(a, 0f);
            verts[v + 1].Position = new Vector3(b, 0f);
            verts[v + 2].Position = new Vector3(c, 0f);
            verts[v + 3].Position = new Vector3(a, 0f);
            verts[v + 4].Position = new Vector3(c, 0f);
            verts[v + 5].Position = new Vector3(d, 0f);
        }

        public override void BeforeRender(ISourceBackdropScene scene)
        {
            if (buffer == null || buffer.IsDisposed)
            {
                buffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("Black Hole", 320,
                    180);
            }

            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                (SourceRenderTarget2DResource)buffer.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(BackgroundClearColor);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
            PackedColor value = LerpColor(bgColorOuterMild, bgColorOuterWild, (StrengthMultiplier - 1f) / 3f);
            for (int i = BackgroundFirstLayer; BackgroundLayerIndex(i) < 20; i += BackgroundLayerStep)
            {
                float num = (1f - spinTime % 1f) * 0.05f + (float)i / 20f;
                PackedColor color = LerpColor(bgColorInner, value,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.SineOut(num));
                float scale = ScalarMath.ClampedMap(num, 0f, 1f, 0.1f, 4f);
                float rotation = (float)Math.PI * 2f * num;
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(bgTexture.Texture.TextureSafe,
                    center + offset * num + shake * (1f - num), bgTexture.ClipRect, color.PackedValue, rotation,
                    bgTexture.Center - bgTexture.DrawOffset, scale, SourceSpriteEffects.None, 0f);
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            if (SpiralCount > 0)
            {
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[0] =
                    ResolvePrimitiveTexture(
                        ReadTexture(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Sources[0]));
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    Matrix4x4.CreateTranslation(center.X, center.Y, 0f), spiralVerts, SpiralCount * 12 * 6,
                    ((ISourceBackdropEffectResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).FxTexture);
            }

            if (StreamCount > 0)
            {
                ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[0] =
                    ResolvePrimitiveTexture(
                        ReadTexture(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.Sources[0]));
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    Matrix4x4.CreateTranslation(center.X, center.Y, 0f), streamVerts, StreamCount * 6,
                    ((ISourceBackdropEffectResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).FxTexture);
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
            int particleCount = ParticleCount;
            for (int j = 0; j < particleCount; j++)
            {
                float num2 =
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(ScalarMath.Clamp(particles[j].Percent,
                        0f,
                        1f));
                Vector2 vector = center + particles[j].Normal * ScalarMath.ClampedMap(num2, 1f, 0f, 8f, 220f);
                PackedColor color2 = colorsLerpTransparent[particles[j].Color, (int)(num2 * 19f)];
                float num3 = 1f + (1f - num2) * 1.5f;
                SourcePrimitiveDrawing.Rect(((ISourceRenderEnvironment)engine).CurrentContext, this,
                    vector - new Vector2(num3, num3) / 2f, num3, num3, color2);
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public override void Ended(ISourceBackdropScene scene)
        {
            if (buffer != null)
            {
                buffer.Dispose();
                buffer = null;
            }
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (buffer != null && !buffer.IsDisposed)
            {
                Vector2 vector = new Vector2(buffer.Width, buffer.Height) / 2f;
                ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw((SourceTexture2DResource)buffer.Target, vector,
                    buffer.Bounds, (PackedColor.White * FadeAlphaMultiplier * Alpha).PackedValue, 0f, vector, Scale,
                    SourceSpriteEffects.None, 0f);
            }
        }
    }
}
