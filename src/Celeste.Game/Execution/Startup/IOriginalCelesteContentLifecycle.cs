namespace Celeste.Game.Execution.Startup
{
    public interface IOriginalCelesteContentLifecycle
    {
        void LoadContent();
        void UnloadContent();
    }
}
