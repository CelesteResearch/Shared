using System.Numerics;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public sealed class OriginalFireBallPathPolicy : IOriginalFireBallPathPolicy
    {
        public bool TryGetPastFinalPosition(Vector2[] nodes, int index, int lengthCount, out Vector2 position)
        {
            position = default;
            return false;
        }
    }
}
