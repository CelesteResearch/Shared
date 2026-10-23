using System;

namespace Celeste.Core.Scheduling
{
    public sealed class SourceEngineGraphicsLifecycle
    {
        private readonly SourceEngineSceneState scenes;
        private readonly ISourceEngineViewDevice view;

        public SourceEngineGraphicsLifecycle(SourceEngineSceneState scenes, ISourceEngineViewDevice view)
        {
            this.scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void HandleGraphicsReset()
        {
            view.UpdateView();
            if (scenes.CurrentScene != null) Graphics(scenes.CurrentScene).HandleGraphicsReset();
            if (scenes.NextScene != null && !ReferenceEquals(scenes.NextScene, scenes.CurrentScene))
                Graphics(scenes.NextScene).HandleGraphicsReset();
        }

        public void HandleGraphicsCreate()
        {
            view.UpdateView();
            if (scenes.CurrentScene != null) Graphics(scenes.CurrentScene).HandleGraphicsCreate();
            if (scenes.NextScene != null && !ReferenceEquals(scenes.NextScene, scenes.CurrentScene))
                Graphics(scenes.NextScene).HandleGraphicsCreate();
        }

        private static ISourceSceneGraphicsLifecycle Graphics(ISourceSceneExecution scene)
            => scene as ISourceSceneGraphicsLifecycle
               ?? throw new InvalidOperationException("The actual scene has no source graphics lifecycle.");
    }
}
