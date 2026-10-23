namespace Celeste.Game.Execution
{
    public interface IOriginalCelesteFrameLifecycle
    {
        void BeginSourceFrame();
        void CompleteSourceFrame();
        void AbortSourceFrame();
    }
}
