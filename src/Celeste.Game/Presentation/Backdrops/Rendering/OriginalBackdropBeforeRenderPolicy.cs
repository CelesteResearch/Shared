using Celeste.Core.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Presentation.Backdrops.Rendering
{
    public sealed class OriginalBackdropBeforeRenderPolicy : ISourceBackdropBeforeRenderPolicy
    {
        public bool ShouldBeforeRender(BackdropPresentation backdrop)
        {
            return true;
        }

        public void Render(BackdropRendererPresentation renderer, ISourceRenderContext context,
            ISourceBackdropScene scene)
        {
            renderer.RenderOriginal(context, scene);
        }

        public void RenderParallax(ParallaxBackdropPresentation backdrop, ISourceRenderContext context,
            ISourceBackdropScene scene)
        {
            backdrop.RenderOriginal(context, scene);
        }
    }
}
