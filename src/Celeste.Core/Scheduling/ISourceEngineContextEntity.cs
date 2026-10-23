namespace Celeste.Core.Scheduling
{
    // A source entity that already retains the actual process Engine exposes that same reference.
    // This capability does not allocate, infer, or obtain timing from its current Scene.
    public interface ISourceEngineContextEntity
    {
        ISourceEngineContext EngineContext { get; }
    }
}
