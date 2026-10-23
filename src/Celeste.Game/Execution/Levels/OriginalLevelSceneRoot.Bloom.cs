using Celeste.Game.Presentation.Effects.Bloom;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public BloomRendererPresentation Bloom;

        public void ConstructSourceBloomRenderer()
        {
            Bloom = new BloomRendererPresentation((IOriginalBloomProcess)EngineContext);
            Renderers.Add(Bloom);
        }
    }
}
