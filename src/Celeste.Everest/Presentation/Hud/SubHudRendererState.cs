using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Everest.Runtime.Startup;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Scene.Rendering;
using Celeste.Scene.Scenes;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Rendering;

namespace Celeste.Everest.Presentation.Hud
{
    public class SubHudRendererState : SceneRenderer
    {
        private readonly SubHudRendererProcessState process;

        public SubHudRendererState(ISourceEngineContext engine)
        {
            process = ((IEverestSubHudRendererEnvironment)engine).SubHudRendererProcess;
        }

        private VirtualRenderTarget Buffer => process.Buffer;

        public bool DrawToBuffer(ISourceRenderContext context)
        {
            return HiresRendererState.DrawToBuffer(context, Buffer, 1920, 1080);
        }

        public void BeginRender(ISourceRenderContext context, SourceBlendState blend = null,
            SourceSamplerState sampler = null)
        {
            HiresRendererState.BeginRender(context, Buffer, 1920, 1080, blend, sampler);
        }

        public void EndRender(ISourceRenderContext context)
        {
            HiresRendererState.EndRender(context);
        }

        public override void BeforeRender(object scene)
        {
            process.Events.BeforeRender(this, (SourceSceneState)scene);
            var context = ((ISourceRenderContextScene)scene).SourceRenderContext;
            if (!DrawToBuffer(context))
                return;
            var device = ((ISourceGraphicsDeviceEnvironment)((ISourceEngineContextScene)scene).EngineContext)
                .GraphicsDevice;
            device.SetRenderTarget(Buffer.Target);
            device.Clear(PackedColor.Transparent);
            RenderContent(scene);
        }

        public override void Render(object scene)
        {
            var context = ((ISourceRenderContextScene)scene).SourceRenderContext;
            if (!DrawToBuffer(context))
            {
                RenderContent(scene);
                return;
            }

            HiresRendererState.BeginBufferComposite(context);
            ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(Buffer.Target, new Vector2(-1f),
                PackedColor.White.PackedValue);
            EndRender(context);
        }

        public void RenderContent(object scene)
        {
            var context = ((ISourceRenderContextScene)scene).SourceRenderContext;
            var entities = ((ISourceScene)scene).SourceScene.Entities;
            var engine = ((ISourceEngineContextScene)scene).EngineContext;
            if (!entities.HasVisibleEntities(((IEverestGameTagsEnvironment)engine).EverestTags.SubHUD.Value))
                return;
            BeginRender(context);
            entities.RenderOnly(((IEverestGameTagsEnvironment)engine).EverestTags.SubHUD.Value, context);
            EndRender(context);
        }
    }
}
