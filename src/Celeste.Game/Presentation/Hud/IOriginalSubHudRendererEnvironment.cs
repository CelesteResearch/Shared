using Celeste.Core.Rendering.Renderers;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Presentation.Hud
{
    public interface IOriginalSubHudRendererEnvironment
    {
        IOriginalSubHudRendererFactory SubHudRenderers { get; }
    }
}
