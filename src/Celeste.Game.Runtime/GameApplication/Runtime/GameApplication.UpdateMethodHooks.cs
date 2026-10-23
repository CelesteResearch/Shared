using Celeste.Core.Scheduling.Hooks;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceUpdateMethodHooksEnvironment
    {
        public SourceEngineUpdateHooks SourceEngineUpdateHooks { get; } = new();
        public SourceSceneUpdateHooks SourceSceneUpdateHooks { get; } = new();
    }
}
