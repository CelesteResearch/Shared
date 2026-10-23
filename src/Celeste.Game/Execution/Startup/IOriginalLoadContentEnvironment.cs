namespace Celeste.Game.Execution.Startup
{
    public interface IOriginalLoadContentEnvironment
    {
        IOriginalCelesteContentLifecycle SourceLoadContent { get; }
    }
}
