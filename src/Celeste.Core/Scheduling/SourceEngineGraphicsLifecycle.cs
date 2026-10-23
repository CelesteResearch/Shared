using System;

namespace Celeste.Core.Scheduling
{
    public sealed class SourceEngineGraphicsLifecycle(SourceEngineSceneState scenes, ISourceEngineViewDevice view)
    {
        private readonly SourceEngineSceneState _scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
        private readonly ISourceEngineViewDevice _view = view ?? throw new ArgumentNullException(nameof(view));


        public void HandleGraphicsReset()
        {
            _view.UpdateView();
            if (_scenes.CurrentScene != null) Graphics(_scenes.CurrentScene).HandleGraphicsReset();
            if (_scenes.NextScene != null && !ReferenceEquals(_scenes.NextScene, _scenes.CurrentScene))
                Graphics(_scenes.NextScene).HandleGraphicsReset();
        }

        public void HandleGraphicsCreate()
        {
            _view.UpdateView();
            if (_scenes.CurrentScene != null) Graphics(_scenes.CurrentScene).HandleGraphicsCreate();
            if (_scenes.NextScene != null && !ReferenceEquals(_scenes.NextScene, _scenes.CurrentScene))
                Graphics(_scenes.NextScene).HandleGraphicsCreate();
        }

        private static ISourceSceneGraphicsLifecycle Graphics(ISourceSceneExecution scene)
        {
            return scene as ISourceSceneGraphicsLifecycle
                   ?? throw new InvalidOperationException("The actual scene has no source graphics lifecycle.");
        }
    }
}
