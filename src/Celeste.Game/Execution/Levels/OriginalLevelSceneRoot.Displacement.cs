using Celeste.Game.Presentation.Effects.Displacement;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public DisplacementRendererPresentation Displacement { get; private set; }

        public void ConstructSourceDisplacementRenderer()
        {
            Displacement = new(EngineContext);
            Renderers.Add(Displacement);
        }
    }
}
