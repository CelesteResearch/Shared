using System.Numerics;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public interface IOriginalFireBallPathPolicy
    {
        bool TryGetPastFinalPosition(Vector2[] nodes, int index, int lengthCount, out Vector2 position);
    }
}
