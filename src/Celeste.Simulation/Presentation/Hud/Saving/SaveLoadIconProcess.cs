using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Presentation.Hud.Saving
{
    public sealed class SaveLoadIconProcess
    {
        private readonly ISourceEngineContext engine;
        private readonly ISaveLoadIconResources resources;
        public SaveLoadIconEntity Instance;
        public bool OnScreen => Instance != null;

        public SaveLoadIconProcess(ISourceEngineContext engine, ISaveLoadIconResources resources)
        {
            this.engine = engine;
            this.resources = resources;
        }

        public void Show(ISourceSceneExecution scene)
        {
            if (Instance != null)
                Instance.RemoveSelf();
            var next = new SaveLoadIconEntity(engine, resources, this);
            Instance = next;
            ((ISourceScene)scene).SourceScene.QueueSourceEntity(next);
        }

        public void Hide()
        {
            if (Instance != null)
                Instance.Display = false;
        }
    }
}
