using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Scene.Scenes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Geometry.ThreeD.Billboards;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;
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
            (OriginalGameGraphicsResources)((Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)EngineContext)
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
            float y = (1f - texScale) * 0.5f + 0.01f;
            float y2 = 1f - (1f - texScale) * 0.5f;
            for (int i = 0; i < steps; i++)
            {
                float num = (float)(i - 1) / (float)steps;
                float num2 = (float)i / (float)steps;
                Vector2 vector = Vector2Geometry.AngleToVector(num * ((float)Math.PI * 2f), distance);
                Vector2 vector2 = Vector2Geometry.AngleToVector(num2 * ((float)Math.PI * 2f), distance);
                float num3 = 0f;
                float num4 = 0f;
                if (wavy > 0f)
                {
                    num3 = (float)Math.Sin(num * ((float)Math.PI * 2f) * 3f + wavy) * Math.Abs(top - bottom) * 0.4f;
                    num4 = (float)Math.Sin(num2 * ((float)Math.PI * 2f) * 3f + wavy) * Math.Abs(top - bottom) * 0.4f;
                }

                int num5 = i * 6;
                Verts[num5].Color = topColor;
                Verts[num5].TextureCoordinate = new Vector2(num * texScale, y);
                Verts[num5].Position = new Vector3(vector.X, top + num3, vector.Y);
                Verts[num5 + 1].Color = topColor;
                Verts[num5 + 1].TextureCoordinate = new Vector2(num2 * texScale, y);
                Verts[num5 + 1].Position = new Vector3(vector2.X, top + num4, vector2.Y);
                Verts[num5 + 2].Color = botColor;
                Verts[num5 + 2].TextureCoordinate = new Vector2(num2 * texScale, y2);
                Verts[num5 + 2].Position = new Vector3(vector2.X, bottom + num4, vector2.Y);
                Verts[num5 + 3].Color = topColor;
                Verts[num5 + 3].TextureCoordinate = new Vector2(num * texScale, y);
                Verts[num5 + 3].Position = new Vector3(vector.X, top + num3, vector.Y);
                Verts[num5 + 4].Color = botColor;
                Verts[num5 + 4].TextureCoordinate = new Vector2(num2 * texScale, y2);
                Verts[num5 + 4].Position = new Vector3(vector2.X, bottom + num4, vector2.Y);
                Verts[num5 + 5].Color = botColor;
                Verts[num5 + 5].TextureCoordinate = new Vector2(num * texScale, y2);
                Verts[num5 + 5].Position = new Vector3(vector.X, bottom + num3, vector.Y);
            }
        }

        public void Rotate(float amount)
        {
            for (int i = 0; i < Verts.Length; i++)
            {
                Verts[i].TextureCoordinate.X += amount;
            }
        }

        public void Draw(Matrix4x4 matrix, SourceRasterizerState rstate = null, float alpha = 1f)
        {
            Device.DepthStencilState = SourceDepthStencilState.Default;
            Device.RasterizerState = ((rstate == null) ? MountainModelState.CullCCRasterizer : rstate);
            Device.SamplerStates[0] = SourceSamplerState.LinearWrap;
            Device.BlendState = SourceBlendState.AlphaBlend;
            Device.Textures[0] = (SourceTexture2DResource)(Texture.Texture);
            PackedColor color = TopColor * alpha;
            PackedColor color2 = BotColor * alpha;
            for (int i = 0; i < Verts.Length; i += 6)
            {
                Verts[i].Color = color;
                Verts[i + 1].Color = color;
                Verts[i + 2].Color = color2;
                Verts[i + 3].Color = color;
                Verts[i + 4].Color = color2;
                Verts[i + 5].Color = color2;
            }

            GraphicsResources.FxTexture.Parameters["World"].SetValue(matrix);
            foreach (SourceEffectPass pass in GraphicsResources.FxTexture.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserPrimitives(SourcePrimitiveType.TriangleList, Verts, 0, Verts.Length / 3);
            }
        }
    }
}
