using System.Numerics;

namespace Celeste.Core.Components
{
    public interface ISourceMutableEntityPosition : ISourceEntityPosition
    {
        new Vector2 Position { get; set; }
    }
}
