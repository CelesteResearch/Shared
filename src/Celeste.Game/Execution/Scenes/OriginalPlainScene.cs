using Celeste.Core.Scheduling;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Execution.Scenes
{
    public sealed class OriginalPlainScene : SourceSceneState
    {
        public OriginalPlainScene(ISourceEngineContext engine)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
        }
    }
}
