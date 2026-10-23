using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Profiles;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Geometry.Backdrops.Aurora;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Simulation.Presentation.Backdrops.NorthernLights;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Presentation.Backdrops.NorthernLights
{
    public class NorthernLightsBackdropPresentation : BackdropPresentation, ISourceNorthernLightsBackdrop
    {
        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        private SourceTexture2DResource ReadTexture(VirtualTexture texture)
        {
            return ((IGameProfileEnvironment)engine).SourceProfile == GameProfile.InstalledEverest
                ? texture.TextureSafe
                : texture.Texture;
        }

        float ISourceNorthernLightsBackdrop.OffsetY
        {
            get => OffsetY;
            set => OffsetY = value;
        }

        float ISourceNorthernLightsBackdrop.NorthernLightsAlpha
        {
            get => NorthernLightsAlpha;
            set => NorthernLightsAlpha = value;
        }

        private class Strand
        {
            public readonly List<Node> Nodes = [];

            public float Duration;

            public float Percent;

            public float Alpha;

            public Strand(NorthernLightsBackdropPresentation owner)
            {
                this.owner = owner;
                Reset(SourceRandomMath.NextFloat(owner.Random));
            }

            private readonly NorthernLightsBackdropPresentation owner;


            public void Reset(float startPercent)
            {
                Percent = startPercent;
                Duration = SourceRandomMath.Range(owner.Random, 12f, 32f);
                Alpha = 0f;
                Nodes.Clear();
                var position = new Vector2(SourceRandomMath.Range(owner.Random, -40, 60),
                    SourceRandomMath.Range(owner.Random, 40, 90));
                var num = SourceRandomMath.NextFloat(owner.Random);
                var value = owner.Random.Choose(colors);
                for (var i = 0; i < 40; i++)
                {
                    var item = new Node
                    {
                        Position = position,
                        TextureOffset = num,
                        Height = SourceRandomMath.Range(owner.Random, 10, 80),
                        TopAlpha = SourceRandomMath.Range(owner.Random, 0.3f, 0.8f),
                        BottomAlpha = SourceRandomMath.Range(owner.Random, 0.5f, 1f),
                        SineOffset = SourceRandomMath.NextFloat(owner.Random) * ((float)Math.PI * 2f),
                        Color = SourceColorInterpolation.Lerp(value, owner.Random.Choose(colors),
                            SourceRandomMath.Range(owner.Random, 0f, 0.3f),
                            ((ISourceScalarEnvironment)owner.engine).ScalarArithmetic),
                    };
                    num += SourceRandomMath.Range(owner.Random, 0.02f, 0.2f);
                    position += new Vector2(SourceRandomMath.Range(owner.Random, 4, 20),
                        SourceRandomMath.Range(owner.Random, -15, 15));
                    Nodes.Add(item);
                }
            }
        }

        private class Node
        {
            public Vector2 Position;

            public float TextureOffset;

            public float Height;

            public float TopAlpha;

            public float BottomAlpha;

            public float SineOffset;

            public PackedColor Color;
        }

        private struct Particle
        {
            public Vector2 Position;

            public float Speed;

            public PackedColor Color;
        }

        private static readonly PackedColor[] colors =
        [
            PackedColor.FromHex("2de079"),
            PackedColor.FromHex("62f4f6"),
            PackedColor.FromHex("45bc2e"),
            PackedColor.FromHex("3856f0"),
        ];

        private readonly List<Strand> strands = [];

        private readonly Particle[] particles = new Particle[50];

        private readonly SourceVertexPositionColorTexture[] verts = new SourceVertexPositionColorTexture[1024];

        private readonly SourceVertexPositionColor[] gradient = new SourceVertexPositionColor[6];

        private VirtualRenderTarget buffer;

        private float timer;

        public float OffsetY;

        public float NorthernLightsAlpha = 1f;

        public NorthernLightsBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            for (var i = 0; i < 3; i++) strands.Add(new(this));

            for (var j = 0; j < particles.Length; j++)
            {
                particles[j].Position = new(SourceRandomMath.Range(Random, 0, 320),
                    SourceRandomMath.Range(Random, 0, 180));
                particles[j].Speed = SourceRandomMath.Range(Random, 4, 14);
                particles[j].Color = Random.Choose(colors);
            }

            var color = PackedColor.FromHex("020825");
            var color2 = PackedColor.FromHex("170c2f");
            gradient[0] = new(new(0f, 0f, 0f), color);
            gradient[1] = new(new(320f, 0f, 0f), color);
            gradient[2] = new(new(320f, 180f, 0f), color2);
            gradient[3] = new(new(0f, 0f, 0f), color);
            gradient[4] = new(new(320f, 180f, 0f), color2);
            gradient[5] = new(new(0f, 180f, 0f), color2);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            if (Visible)
            {
                timer += engine.Frame.DeltaTime;
                foreach (var strand in strands)
                {
                    strand.Percent += engine.Frame.DeltaTime / strand.Duration;
                    strand.Alpha = ScalarMath.Approach(strand.Alpha, strand.Percent < 1f ? 1 : 0,
                        engine.Frame.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    if (strand.Alpha <= 0f && strand.Percent >= 1f) strand.Reset(0f);

                    foreach (var node in strand.Nodes) node.SineOffset += engine.Frame.DeltaTime;
                }

                for (var i = 0; i < particles.Length; i++)
                    particles[i].Position.Y += particles[i].Speed * engine.Frame.DeltaTime;
            }

            base.Update(scene);
        }

        public override void BeforeRender(ISourceBackdropScene scene)
        {
            if (buffer == null)
                buffer = ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("northern-lights",
                    320, 180);

            var vert = 0;
            foreach (var strand in strands)
            {
                var node = strand.Nodes[0];
                for (var i = 1; i < strand.Nodes.Count; i++)
                {
                    var node2 = strand.Nodes[i];
                    var num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f, i / 4f) *
                              NorthernLightsAlpha;
                    var num2 =
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f,
                            (strand.Nodes.Count - i) / 4f) * NorthernLightsAlpha;
                    var num3 = OffsetY + (float)Math.Sin(node.SineOffset) * 3f;
                    var num4 = OffsetY + (float)Math.Sin(node2.SineOffset) * 3f;
                    AuroraRibbonGeometry.EmitSegment(
                        verts, ref vert, node.Position, node2.Position, node.Height, node2.Height,
                        node.TextureOffset, node2.TextureOffset, num3, num4, node.Color, node2.Color,
                        node.BottomAlpha * strand.Alpha * num, node.TopAlpha * strand.Alpha * num,
                        node2.TopAlpha * strand.Alpha * num2, node2.BottomAlpha * strand.Alpha * num2);
                    node = node2;
                }
            }

            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(
                buffer.Target);
            SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                Matrix4x4.Identity, gradient, gradient.Length);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Textures[0] = ReadTexture(
                ((ISourceMiscAtlasResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .MiscAtlas["northernlights"].Texture);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SamplerStates[0] = SourceSamplerState.LinearWrap;
            SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                Matrix4x4.Identity, verts, vert,
                ((ISourceBackdropEffectResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).FxTexture);
            var clear = false;
            GaussianBlurPresentation.Blur((ISourceGaussianBlurEnvironment)engine,
                buffer.Target,
                ((ISourceGameplayBlurBufferResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).TempA,
                buffer,
                0f, clear, GaussianBlurSamples.Five, 0.25f, GaussianBlurDirection.Vertical);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
            var camera = scene.Camera;
            for (var j = 0; j < particles.Length; j++)
                SourcePrimitiveDrawing.Rect(((ISourceRenderEnvironment)engine).CurrentContext, this, new()
                {
                    X = ScalarMath.Mod(particles[j].Position.X - camera.X * 0.2f, 320f),
                    Y = ScalarMath.Mod(particles[j].Position.Y - camera.Y * 0.2f, 180f),
                }, 1f, 1f, particles[j].Color);

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public override void Ended(ISourceBackdropScene scene)
        {
            if (buffer != null) buffer.Dispose();

            buffer = null;
            base.Ended(scene);
        }

        private void Set(ref int vert, float px, float py, float tx, float ty, PackedColor color)
        {
            AuroraRibbonGeometry.WriteVertex(
                verts, ref vert, px, py, tx, ty, color);
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(buffer.Target, Vector2.Zero,
                PackedColor.White.PackedValue);
        }
    }
}
