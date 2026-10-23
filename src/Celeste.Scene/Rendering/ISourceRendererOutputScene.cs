using Celeste.Core.Rendering.Renderers;

namespace Celeste.Scene.Rendering
{
    public interface ISourceRendererOutputScene
    {
        void BeforeRenderNativeRenderer(ISceneRenderer renderer);
        void RenderNativeRenderer(ISceneRenderer renderer);
    }
}
