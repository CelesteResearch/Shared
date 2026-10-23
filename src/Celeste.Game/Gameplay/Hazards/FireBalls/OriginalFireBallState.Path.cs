using System.Numerics;
using Celeste.Core.Mathematics;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState
    {
        protected Vector2 GetPercentPosition(float percent)
        {
            if (percent <= 0f) return nodes[0];

            if (percent >= 1f) return nodes[nodes.Length - 1];

            var num = lengths[lengths.Length - 1];
            var num2 = num * percent;
            int i;
            for (i = 0; i < lengths.Length - 1 && !(lengths[i + 1] > num2); i++)
            {
            }

            if (engine.FireBallPath.TryGetPastFinalPosition(nodes, i, lengths.Length, out var finalPosition))
                return finalPosition;
            var min = lengths[i] / num;
            var max = lengths[i + 1] / num;
            var num3 = ScalarMath.ClampedMap(percent, min, max);
            return Vector2Interpolation.Lerp(nodes[i], nodes[i + 1], num3, engine.ScalarArithmetic);
        }
    }
}
