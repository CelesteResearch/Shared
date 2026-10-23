using Celeste.Core.Rendering.Renderers;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Presentation.Hud
{
    public interface IOriginalSubHudRendererFactory
    {
        ISceneRenderer Create(ISourceEngineContext engine);
    }
}
