using System.Numerics;

namespace Celeste.Core.Components
{
    public interface ISourceMutableEntityState : ISourceEntityPosition, ISourceEntityVisibility
    {
        new Vector2 Position { get; set; }
        bool Active { get; set; }
        new bool Visible { get; set; }
        bool Collidable { get; set; }
        int Depth { get; set; }
        void RemoveSelf();
    }
}
