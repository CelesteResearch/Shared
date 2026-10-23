using System.Numerics;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public interface ISourceSolidWorldFactory
    {
        ISourceSolidWorld Create(Vector2 position, bool safe);
        ISourceSolidWorld CreateJumpThru(Vector2 position, bool safe);
    }
}
