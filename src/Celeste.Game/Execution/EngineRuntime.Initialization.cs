using Celeste.Game.Execution.Engine.Initialization;
using Celeste.Input.Runtime;
using Celeste.Scene.Tracking;
using Celeste.Scene.Tracking.Initialization;

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
            var pools = Process.EntityPools;
            pools.InitializeFromUniverse(tracker.TypeUniverse);
            var publications = (IOriginalEngineInitializationPublication)Process;
            publications.PublishSourcePooler(pools);
            publications.ConfigureSourcePoolConstructors();
            publications.ConstructSourceCommands();
            publications.CompleteSourceEngineInitialization();
        }
    }
}
