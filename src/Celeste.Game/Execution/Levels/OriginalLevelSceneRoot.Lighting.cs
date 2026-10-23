using Celeste.Game.Presentation.Lighting;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public LightingRendererPresentation Lighting;

        public void ConstructSourceLightingRenderer()
        {
            Lighting = new LightingRendererPresentation(EngineContext);
            Renderers.Add(Lighting);
        }
    }
}
