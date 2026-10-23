using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private OriginalGameGraphicsResources graphicsResources
            => (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext).GameGraphics;

        public OriginalGameplayBuffers Buffers => graphicsResources.Buffers;
    }
}
