namespace Celeste.Core.Scheduling
{
    public interface ISourceGameUpdateObserver
    {
        void AfterSceneUpdate();
        void AfterGameUpdate();
    }
}
