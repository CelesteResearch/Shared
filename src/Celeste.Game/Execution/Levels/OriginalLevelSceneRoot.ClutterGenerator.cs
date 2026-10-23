namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void DisposeSourceClutterGenerator() =>
            ((global::Celeste.Game.Gameplay.Clutter.Generation.ISourceClutterGeneratorEnvironment)EngineContext)
            .ClutterGenerator.Dispose();
    }
}
