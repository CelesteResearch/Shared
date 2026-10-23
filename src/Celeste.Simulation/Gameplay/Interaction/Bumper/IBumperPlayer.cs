using System.Numerics;
using Celeste.Core.Geometry;

namespace Celeste.Simulation.Gameplay.Interaction.Bumper
{
    public interface IBumperPlayer
    {
        Vector2 Center { get; }
        Bounds? ColliderBounds { get; }
        void Die(Vector2 direction);
        Vector2 ExplodeLaunch(Vector2 from, bool snapUp);
    }
}
