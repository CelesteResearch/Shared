using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Simulation.Gameplay.Hazards.Killbox
{
    public interface IKillboxPlayer
    {
        Bounds? ColliderBounds { get; }
        void Play(string name);
        void Bounce(float top);
        void Die(Vector2 direction);
    }
}
