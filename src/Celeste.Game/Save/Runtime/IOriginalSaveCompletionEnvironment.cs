namespace Celeste.Game.Save.Runtime
{
    public interface IOriginalSaveCompletionEnvironment
    {
        bool EventMode { get; }
        int AreaCount { get; }
    }
}
