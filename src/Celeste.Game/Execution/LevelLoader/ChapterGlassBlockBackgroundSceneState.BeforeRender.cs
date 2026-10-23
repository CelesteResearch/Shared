using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Primitives;

namespace Celeste.Game.Execution.LevelLoader
{
    public partial class ChapterGlassBlockBackgroundSceneState
    {
        private void BeforeRender()
        {
            var entities =
                GetGlassBlocks();
            if (!(hasBlocks = entities.Count > 0)) return;
            var camera = ((OriginalLevelSceneRoot)Scene).Camera;
            int width = BufferWidth, height = BufferHeight;
            if (starsTarget == null || starsTarget.Width != width || starsTarget.Height != height)
            {
                starsTarget?.Dispose();
                starsTarget =
                    ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget(SurfaceTargetName,
                        width, height);
            }

            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(starsTarget.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            var batch = ((ISourceDrawScope)context).Draw.SpriteBatch;
            batch.Begin(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend, SourceSamplerState.PointClamp,
                SourceDepthStencilState.None, SourceRasterizerState.CullNone, null, Matrix4x4.Identity);
            var origin = new Vector2(8f, 8f);
            for (var i = 0; i < stars.Length; i++)
            {
                var texture = stars[i].Texture;
                var color = stars[i].Color * Alpha;
                var scroll = stars[i].Scroll;
                var point = new Vector2(Mod(stars[i].Position.X - camera.X * (1f - scroll.X), width),
                    Mod(stars[i].Position.Y - camera.Y * (1f - scroll.Y), height));
                SourceAtlasDrawing.Draw(context, this, texture, point, origin, color);
                if (point.X < origin.X)
                    SourceAtlasDrawing.Draw(context, this, texture, point + new Vector2(width, 0f), origin, color);
                else if (point.X > width - origin.X)
                    SourceAtlasDrawing.Draw(context, this, texture, point - new Vector2(width, 0f), origin, color);
                if (point.Y < origin.Y)
                    SourceAtlasDrawing.Draw(context, this, texture, point + new Vector2(0f, height), origin, color);
                else if (point.Y > height - origin.Y)
                    SourceAtlasDrawing.Draw(context, this, texture, point - new Vector2(0f, height), origin, color);
            }

            batch.End();
            var vertex = 0;
            for (var j = 0; j < rays.Length; j++)
            {
                var point = new Vector2(Mod(rays[j].Position.X - camera.X * .9f, width),
                    Mod(rays[j].Position.Y - camera.Y * .9f, height));
                DrawRay(point, ref vertex, ref rays[j]);
                if (point.X < 64f) DrawRay(point + new Vector2(width, 0f), ref vertex, ref rays[j]);
                else if (point.X > width - 64) DrawRay(point - new Vector2(width, 0f), ref vertex, ref rays[j]);
                if (point.Y < 64f) DrawRay(point + new Vector2(0f, height), ref vertex, ref rays[j]);
                else if (point.Y > height - 64) DrawRay(point - new Vector2(0f, height), ref vertex, ref rays[j]);
            }

            if (beamsTarget == null)
                beamsTarget =
                    ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget(BeamTargetName,
                        width,
                        height);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(beamsTarget.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                Matrix4x4.Identity, verts, vertex);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (Alpha != 1f)
                Alpha = ScalarMath.Approach(Alpha, 1f, engine.DeltaTime * FadeInRate,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }

        private void DrawRay(Vector2 position, ref int vertex, ref Ray ray)
        {
            var cross = new Vector2(0f - rayNormal.Y, rayNormal.X);
            var halfWidth = rayNormal * ray.Width * .5f;
            var quarterLength = cross * ray.Length * .25f * .5f;
            var halfLength = cross * ray.Length * .5f * .5f;
            var a = position + halfWidth - quarterLength - halfLength;
            var b = position - halfWidth - quarterLength - halfLength;
            var c = position + halfWidth - quarterLength;
            var d = position - halfWidth - quarterLength;
            var e = position + halfWidth + quarterLength;
            var f = position - halfWidth + quarterLength;
            var g = position + halfWidth + quarterLength + halfLength;
            var h = position - halfWidth + quarterLength + halfLength;
            var clear = PackedColor.Transparent;
            var color = ray.Color * Alpha;
            Quad(ref vertex, a, c, d, b, clear, color, color, clear);
            Quad(ref vertex, c, e, f, d, color, color, color, color);
            Quad(ref vertex, e, g, h, f, color, clear, clear, color);
        }

        private void Quad(ref int vertex, Vector2 a, Vector2 b, Vector2 c, Vector2 d,
            PackedColor ca, PackedColor cb, PackedColor cc, PackedColor cd)
        {
            WriteVertex(ref vertex, a, ca);
            WriteVertex(ref vertex, b, cb);
            WriteVertex(ref vertex, c, cc);
            WriteVertex(ref vertex, a, ca);
            WriteVertex(ref vertex, c, cc);
            WriteVertex(ref vertex, d, cd);
        }

        private void WriteVertex(ref int vertex, Vector2 position, PackedColor color)
        {
            verts[vertex].Position.X = position.X;
            verts[vertex].Position.Y = position.Y;
            verts[vertex++].Color = color;
        }

        private float Mod(float value, float period)
        {
            return (value % period + period) % period;
        }
    }
}
