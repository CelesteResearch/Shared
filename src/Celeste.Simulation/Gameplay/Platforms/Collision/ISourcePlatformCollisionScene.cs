using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.Collision
{
    public interface ISourcePlatformCollisionScene
    {
        PlatformCollisionWorld PlatformWorld { get; }
        ISourceSolidWorldFactory SolidWorldFactory { get; }
    }
}
