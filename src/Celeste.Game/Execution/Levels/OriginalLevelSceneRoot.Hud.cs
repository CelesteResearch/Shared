using Celeste.Game.Presentation.Hud;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public HudRendererState HudRenderer { get; private set; }

        public void ConstructSourceHudRenderer()
        {
            HudRenderer = new HudRendererState();
            Renderers.Add(HudRenderer);
        }
    }
}
