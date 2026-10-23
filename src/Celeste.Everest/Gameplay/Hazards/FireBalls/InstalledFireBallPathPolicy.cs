using System.Numerics;
using Celeste.Game.Gameplay.Hazards.FireBalls;

namespace Celeste.Everest.Gameplay.Hazards.FireBalls
{
    public sealed class InstalledFireBallPathPolicy : IOriginalFireBallPathPolicy
    {
        public bool TryGetPastFinalPosition(Vector2[] nodes, int index, int lengthCount, out Vector2 position)
        {
            if (index == lengthCount - 1)
            {
                position = nodes[0];
                return true;
            }

            position = default;
            return false;
        }
    }
}
