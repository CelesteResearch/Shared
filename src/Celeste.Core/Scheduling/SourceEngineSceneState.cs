namespace Celeste.Core.Scheduling
{
    public sealed class SourceEngineSceneState
    {
        public ISourceSceneExecution CurrentScene { get; private set; }
        public ISourceSceneExecution NextScene;

        public void SetCurrentSceneImmediately(ISourceSceneExecution scene)
        {
            CurrentScene = scene;
        }

        public bool ApplyTransition(ISourceEngineSceneTransition transition)
        {
            if (ReferenceEquals(CurrentScene, NextScene)) return false;
            var previous = CurrentScene;
            CurrentScene?.End();
            CurrentScene = NextScene;
            transition.OnSceneTransition(previous, NextScene);
            CurrentScene?.Begin();
            return true;
        }
    }
}
