using System;
using Celeste.Game.Presentation.Rendering;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public GameplayRendererState GameplayRenderer { get; private set; }

        public void ConstructSourceGameplayRenderer()
        {
            if (GameplayRenderer != null)
                throw new InvalidOperationException("The actual GameplayRenderer is already constructed.");
            GameplayRenderer = new(EngineContext);
            Renderers.Add(GameplayRenderer);
        }
    }
}
