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
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Game.Presentation.Mountain.Model
{
    public class MountainSkybox
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

        public MountainSkybox(ISourceEngineContext engine, VirtualTexture texture, float size = 25f)
        {
            EngineContext = engine;
            Texture = texture;
            Verts = new SourceVertexPositionColorTexture[30];
            var vector = new Vector3(0f - size, size, 0f - size);
            var vector2 = new Vector3(size, size, 0f - size);
            var vector3 = new Vector3(size, size, size);
            var vector4 = new Vector3(0f - size, size, size);
            var vector5 = new Vector3(0f - size, 0f - size, 0f - size);
            var vector6 = new Vector3(size, 0f - size, 0f - size);
            var vector7 = new Vector3(size, 0f - size, size);
            var vector8 = new Vector3(0f - size, 0f - size, size);
            var mTexture = new AtlasEntry(texture);
            var subtexture = mTexture.GetSubtexture(0, 0, 820, 820);
            var subtexture2 = mTexture.GetSubtexture(820, 0, 820, 820);
            var subtexture3 = mTexture.GetSubtexture(2460, 0, 820, 820);
            var subtexture4 = mTexture.GetSubtexture(1640, 0, 820, 820);
            var subtexture5 = mTexture.GetSubtexture(3280, 0, 819, 820);
            AddFace(Verts, 0, subtexture, vector, vector2, vector3, vector4);
            AddFace(Verts, 1, subtexture3, vector2, vector, vector5, vector6);
            AddFace(Verts, 2, subtexture2, vector4, vector3, vector7, vector8);
            AddFace(Verts, 3, subtexture5, vector3, vector2, vector6, vector7);
            AddFace(Verts, 4, subtexture4, vector, vector4, vector8, vector5);
        }

        private void AddFace(SourceVertexPositionColorTexture[] verts, int face, AtlasEntry tex, Vector3 a, Vector3 b,
            Vector3 c, Vector3 d)
        {
            var x = (tex.ClipRect.Left + 1) / (float)tex.Texture.Width;
            var y = (tex.ClipRect.Top + 1) / (float)tex.Texture.Height;
            var x2 = (tex.ClipRect.Right - 1) / (float)tex.Texture.Width;
            var y2 = (tex.ClipRect.Bottom - 1) / (float)tex.Texture.Height;
            var num = face * 6;
            verts[num++] = new(a, PackedColor.White, new(x, y));
            verts[num++] = new(b, PackedColor.White, new(x2, y));
            verts[num++] = new(c, PackedColor.White, new(x2, y2));
            verts[num++] = new(a, PackedColor.White, new(x, y));
            verts[num++] = new(c, PackedColor.White, new(x2, y2));
            verts[num++] = new(d, PackedColor.White, new(x, y2));
        }

        public void Draw(Matrix4x4 matrix, PackedColor color)
        {
            Device.RasterizerState = MountainModelState.CullNoneRasterizer;
            Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
            Device.BlendState = SourceBlendState.AlphaBlend;
            Device.Textures[0] = Texture.Texture;
            for (var i = 0; i < Verts.Length; i++) Verts[i].Color = color;

            GraphicsResources.FxTexture.Parameters["World"].SetValue(matrix);
            foreach (var pass in GraphicsResources.FxTexture.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserPrimitives(SourcePrimitiveType.TriangleList, Verts, 0, Verts.Length / 3);
            }
        }
    }
}
