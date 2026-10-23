using System.Numerics;

namespace Celeste.Core.Components
{
    // The current actual Entity supplies its one position storage.
    public interface ISourceEntityPosition
    {
        Vector2 Position { get; }
    }
}
