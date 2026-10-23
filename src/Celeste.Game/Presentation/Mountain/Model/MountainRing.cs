using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Game.Presentation.Mountain.Model
{
    public class MountainRing
    {
        public readonly ISourceEngineContext EngineContext;
        private SourceGraphicsDevice Device => ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice;

        private IOriginalEngineGraphicsState Metrics =>
            ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics;

        private OriginalMountainResources MountainResources =>
            ((IOriginalMountainEnvironment)EngineContext).MountainResources;

        private OriginalGameGraphicsResources GraphicsResources =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext)
            .GameGraphics;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;
        private ISourceScalarArithmetic ScalarArithmetic => ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic;

        private ISourceExtremaArithmetic ExtremaArithmetic =>
            ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;

        private ISourceEasingArithmetic EasingArithmetic => ((ISourceEasingEnvironment)EngineContext).EasingArithmetic;

        public SourceVertexPositionColorTexture[] Verts;

        public VirtualTexture Texture;

        public PackedColor TopColor;

        public PackedColor BotColor;

        public MountainRing(ISourceEngineContext engine, float top, float bottom, float distance, float wavy, int steps,
            PackedColor color, VirtualTexture texture, float texScale = 1f)
            : this(engine, top, bottom, distance, wavy, steps, color, color, texture, texScale)
        {
        }

        public MountainRing(ISourceEngineContext engine, float top, float bottom, float distance, float wavy, int steps,
            PackedColor topColor, PackedColor botColor, VirtualTexture texture, float texScale = 1f)
        {
            EngineContext = engine;
            Texture = texture;
            TopColor = topColor;
            BotColor = botColor;
            Verts = new SourceVertexPositionColorTexture[steps * 24];
            var y = (1f - texScale) * 0.5f + 0.01f;
            var y2 = 1f - (1f - texScale) * 0.5f;
            for (var i = 0; i < steps; i++)
            {
                var num = (i - 1) / (float)steps;
                var num2 = i / (float)steps;
                var vector = Vector2Geometry.AngleToVector(num * ((float)Math.PI * 2f), distance);
                var vector2 = Vector2Geometry.AngleToVector(num2 * ((float)Math.PI * 2f), distance);
                var num3 = 0f;
                var num4 = 0f;
                if (wavy > 0f)
                {
                    num3 = (float)Math.Sin(num * ((float)Math.PI * 2f) * 3f + wavy) * Math.Abs(top - bottom) * 0.4f;
                    num4 = (float)Math.Sin(num2 * ((float)Math.PI * 2f) * 3f + wavy) * Math.Abs(top - bottom) * 0.4f;
                }

                var num5 = i * 6;
                Verts[num5].Color = topColor;
                Verts[num5].TextureCoordinate = new(num * texScale, y);
                Verts[num5].Position = new(vector.X, top + num3, vector.Y);
                Verts[num5 + 1].Color = topColor;
                Verts[num5 + 1].TextureCoordinate = new(num2 * texScale, y);
                Verts[num5 + 1].Position = new(vector2.X, top + num4, vector2.Y);
                Verts[num5 + 2].Color = botColor;
                Verts[num5 + 2].TextureCoordinate = new(num2 * texScale, y2);
                Verts[num5 + 2].Position = new(vector2.X, bottom + num4, vector2.Y);
                Verts[num5 + 3].Color = topColor;
                Verts[num5 + 3].TextureCoordinate = new(num * texScale, y);
                Verts[num5 + 3].Position = new(vector.X, top + num3, vector.Y);
                Verts[num5 + 4].Color = botColor;
                Verts[num5 + 4].TextureCoordinate = new(num2 * texScale, y2);
                Verts[num5 + 4].Position = new(vector2.X, bottom + num4, vector2.Y);
                Verts[num5 + 5].Color = botColor;
                Verts[num5 + 5].TextureCoordinate = new(num * texScale, y2);
                Verts[num5 + 5].Position = new(vector.X, bottom + num3, vector.Y);
            }
        }

        public void Rotate(float amount)
        {
            for (var i = 0; i < Verts.Length; i++) Verts[i].TextureCoordinate.X += amount;
        }

        public void Draw(Matrix4x4 matrix, SourceRasterizerState rstate = null, float alpha = 1f)
        {
            Device.DepthStencilState = SourceDepthStencilState.Default;
            Device.RasterizerState = rstate == null ? MountainModelState.CullCCRasterizer : rstate;
            Device.SamplerStates[0] = SourceSamplerState.LinearWrap;
            Device.BlendState = SourceBlendState.AlphaBlend;
            Device.Textures[0] = Texture.Texture;
            var color = TopColor * alpha;
            var color2 = BotColor * alpha;
            for (var i = 0; i < Verts.Length; i += 6)
            {
                Verts[i].Color = color;
                Verts[i + 1].Color = color;
                Verts[i + 2].Color = color2;
                Verts[i + 3].Color = color;
                Verts[i + 4].Color = color2;
                Verts[i + 5].Color = color2;
            }

            GraphicsResources.FxTexture.Parameters["World"].SetValue(matrix);
            foreach (var pass in GraphicsResources.FxTexture.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserPrimitives(SourcePrimitiveType.TriangleList, Verts, 0, Verts.Length / 3);
            }
        }
    }
}
