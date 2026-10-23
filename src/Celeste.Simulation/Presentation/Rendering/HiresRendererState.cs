using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Rendering
{
    public class HiresRendererState : SceneRenderer
    {
        private readonly int logicalWidth, logicalHeight;

        protected HiresRendererState(int logicalWidth, int logicalHeight)
        {
            this.logicalWidth = logicalWidth;
            this.logicalHeight = logicalHeight;
        }

        public static VirtualRenderTarget Buffer(ISourceRenderContext context)
        {
            return (VirtualRenderTarget)context.Graphics.HudTarget;
        }

        public bool DrawToBuffer(ISourceRenderContext context)
        {
            return DrawToBuffer(context, logicalWidth, logicalHeight);
        }

        public static bool DrawToBuffer(ISourceRenderContext context, int logicalWidth, int logicalHeight)
        {
            return DrawToBuffer(context, Buffer(context), logicalWidth, logicalHeight);
        }

        public static bool DrawToBuffer(ISourceRenderContext context, VirtualRenderTarget buffer,
            int logicalWidth, int logicalHeight)
        {
            if (buffer != null)
            {
                if (context.Graphics.ViewWidth >= logicalWidth)
                    return context.Graphics.ViewHeight < logicalHeight;
                return true;
            }

            return false;
        }

        public void BeginRender(ISourceRenderContext context,
            SourceBlendState blend = null, SourceSamplerState sampler = null)
        {
            BeginRender(context, logicalWidth, logicalHeight, blend, sampler);
        }

        public static void BeginRender(ISourceRenderContext context, int logicalWidth, int logicalHeight,
            SourceBlendState blend = null, SourceSamplerState sampler = null)
        {
            BeginRender(context, Buffer(context), logicalWidth, logicalHeight, blend, sampler);
        }

        public static void BeginRender(ISourceRenderContext context, VirtualRenderTarget buffer,
            int logicalWidth, int logicalHeight, SourceBlendState blend = null, SourceSamplerState sampler = null)
        {
            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                blend ?? SourceBlendState.AlphaBlend, sampler ?? SourceSamplerState.LinearClamp,
                SourceDepthStencilState.Default, SourceRasterizerState.CullNone, null,
                DrawToBuffer(context, buffer, logicalWidth, logicalHeight)
                    ? Matrix4x4.Identity
                    : context.Graphics.ScreenMatrix);
        }

        public static void EndRender(ISourceRenderContext context)
        {
            ((ISourceDrawScope)context).Draw.SpriteBatch.End();
        }

        public override void BeforeRender(object scene)
        {
            var context = ((ISourceRenderContextScene)scene).SourceRenderContext;
            if (DrawToBuffer(context))
            {
                var device = ((ISourceGraphicsDeviceEnvironment)((ISourceEngineContextScene)scene).EngineContext)
                    .GraphicsDevice;
                device.SetRenderTarget(Buffer(context).Target);
                device.Clear(PackedColor.Transparent);
                RenderContent(scene, context);
            }
        }

        public override void Render(object scene)
        {
            var context = ((ISourceRenderContextScene)scene).SourceRenderContext;
            if (DrawToBuffer(context))
            {
                BeginBufferComposite(context);
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(Buffer(context).Target, new Vector2(-1f),
                    PackedColor.White.PackedValue);
                EndRender(context);
            }
            else
            {
                RenderContent(scene, context);
            }
        }

        public static void BeginBufferComposite(ISourceRenderContext context)
        {
            ((ISourceDrawScope)context).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp,
                SourceDepthStencilState.Default, SourceRasterizerState.CullNone, null, context.Graphics.ScreenMatrix);
        }

        public virtual void RenderContent(object scene, ISourceRenderContext context)
        {
        }
    }
}
