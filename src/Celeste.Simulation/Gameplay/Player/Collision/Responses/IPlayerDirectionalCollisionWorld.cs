using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Collision.Responses
{
    public interface IPlayerDirectionalCollisionWorld
    {
        bool HorizontalSolidAt(Vector2 offset);
    }
}
