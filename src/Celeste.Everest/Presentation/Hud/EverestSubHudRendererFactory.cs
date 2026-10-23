using Celeste.Core.Rendering.Renderers;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Hud;

namespace Celeste.Everest.Presentation.Hud
{
    public sealed class EverestSubHudRendererFactory : IOriginalSubHudRendererFactory
    {
        public ISceneRenderer Create(ISourceEngineContext engine) => new SubHudRendererState(engine);
    }
}
