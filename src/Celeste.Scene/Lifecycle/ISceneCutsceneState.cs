namespace Celeste.Scene.Lifecycle
{
    public interface ISceneCutsceneState
    {
        bool InCutscene { get; }
        void ClearInCutscene();
    }
}
