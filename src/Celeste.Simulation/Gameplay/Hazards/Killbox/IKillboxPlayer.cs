using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Hazards.Killbox
{
    public interface IKillboxPlayer
    {
        global::Celeste.Core.Geometry.Bounds? ColliderBounds { get; }
        void Play(string name);
        void Bounce(float top);
        void Die(Vector2 direction);
    }
}
