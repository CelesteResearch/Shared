using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Simulation.Presentation.Rendering;

namespace Celeste.Game.Presentation.Hud
{
    public static class OriginalHiresRendererBatch
    {
        public static void BeginRender(ISourceRenderContext context, SourceBlendState blend = null,
            SourceSamplerState sampler = null)
            => HiresRendererState.BeginRender(context, 1920, 1080, blend, sampler);

        public static void EndRender(ISourceRenderContext context) => HiresRendererState.EndRender(context);
    }
}
