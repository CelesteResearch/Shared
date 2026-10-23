using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public static class Vector2Selection
    {
        public static Vector2 ClosestTo(List<Vector2> list, Vector2 to, ISourceVectorArithmetic arithmetic)
        {
            Vector2 result = list[0];
            float distance = arithmetic.DistanceSquared(list[0], to);
            for (int index = 1; index < list.Count; index++)
            {
                float candidateDistance = arithmetic.DistanceSquared(list[index], to);
                if (candidateDistance < distance)
                {
                    distance = candidateDistance;
                    result = list[index];
                }
            }

            return result;
        }
    }
}
