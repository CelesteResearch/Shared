namespace Celeste.Core.Components
{
    // The real Entity Scene getter; no metadata membership or copied scene cache.
    public interface ISourceEntityScene
    {
        object Scene { get; }
    }
}
