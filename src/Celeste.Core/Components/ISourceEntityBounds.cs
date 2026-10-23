namespace Celeste.Core.Components
{
    public interface ISourceEntityBounds : ISourceEntityPosition, ISourceEntityVisibility, ISourceEntityScene
    {
        float Left { get; }
        float Top { get; }
        float Width { get; }
        float Height { get; }
    }
}
