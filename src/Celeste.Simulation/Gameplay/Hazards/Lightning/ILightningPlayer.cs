using System.Numerics;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public interface ILightningPlayer
    {
        float X { get; }
        void Die(Vector2 direction);
    }
}
