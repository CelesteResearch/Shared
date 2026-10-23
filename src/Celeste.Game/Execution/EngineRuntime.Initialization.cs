using Celeste.Input.Runtime;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Scene.Tracking.Initialization;
using Celeste.Game.Execution.Engine.Initialization;
using global::Celeste.Game.Execution.Engine;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public partial class EngineRuntime
    {
        protected override void Initialize()
        {
            base.Initialize();
            ((ISourceMInputEnvironment)Process).MInput.Initialize();
            var tracker = ((ISourceTrackerInitializationEnvironment)Process).TrackerInitialization;
            ((ISourceSceneCatalogEnvironment)Process).SceneCatalog.InitializeSourceTracker(tracker);
            var pools = ((ISourceEngineContext)Process).EntityPools;
            pools.InitializeFromUniverse(tracker.TypeUniverse);
            var publications = (IOriginalEngineInitializationPublication)Process;
            publications.PublishSourcePooler(pools);
            publications.ConfigureSourcePoolConstructors();
            publications.ConstructSourceCommands();
            publications.CompleteSourceEngineInitialization();
        }
    }
}
