using Celeste.Game.Gameplay.Clutter.Generation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void DisposeSourceClutterGenerator()
        {
            ((ISourceClutterGeneratorEnvironment)EngineContext)
                .ClutterGenerator.Dispose();
        }
    }
}
