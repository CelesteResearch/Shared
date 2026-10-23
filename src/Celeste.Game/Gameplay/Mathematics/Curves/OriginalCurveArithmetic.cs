using System.Numerics;
using Celeste.Core.Mathematics;

namespace Celeste.Game.Gameplay.Mathematics.Curves
{
    public sealed class OriginalCurveArithmetic : ISourceCurveArithmetic
    {
        public Vector2 GetPoint(SimpleCurve curve, float percent)
        {
            float inverse = 1f - percent;
            Vector2 first = (inverse * inverse) * curve.Begin;
            Vector2 second = (2f * inverse * percent) * curve.Control;
            Vector2 third = (percent * percent) * curve.End;
            return (first + second) + third;
        }
    }
}
