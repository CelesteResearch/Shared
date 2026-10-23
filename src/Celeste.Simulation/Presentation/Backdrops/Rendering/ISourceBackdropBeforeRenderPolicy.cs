using Celeste.Core.Rendering;
using Celeste.Simulation.Presentation.Backdrops.Parallax;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Rendering
{
    public interface ISourceBackdropBeforeRenderPolicy
    {
        bool ShouldBeforeRender(BackdropPresentation backdrop);
        void Render(BackdropRendererPresentation renderer, ISourceRenderContext context, ISourceBackdropScene scene);

        void RenderParallax(ParallaxBackdropPresentation backdrop, ISourceRenderContext context,
            ISourceBackdropScene scene);
    }
}
