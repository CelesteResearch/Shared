using Celeste.Core.Randomness;

namespace Celeste.Simulation.Gameplay.Player.Scene
{
    public interface ISourceHiccupScene
    {
        ISourceRandom HiccupRandom { get; }
    }
}
