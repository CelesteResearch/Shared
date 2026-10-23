using System.Numerics;

namespace Celeste.Simulation.Rendering.Lighting
{
    public interface ILightOwner
    {
        Vector2 OwnerPosition { get; }
        bool OwnerVisible { get; }
    }
}
