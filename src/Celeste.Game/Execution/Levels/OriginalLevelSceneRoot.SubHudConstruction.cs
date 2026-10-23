using Celeste.Game.Presentation.Hud;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public void ConstructSourceSubHudRenderer(IOriginalSubHudRendererFactory factory)
        {
            SubHudRenderer = factory.Create(EngineContext);
            Renderers.Add(SubHudRenderer);
        }
    }
}
