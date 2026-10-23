using System.Numerics;
using Celeste.Core.Mathematics;

namespace Celeste.Game.Gameplay.Mathematics.Curves
{
    public sealed class OriginalCurveArithmetic : ISourceCurveArithmetic
    {
        public Vector2 GetPoint(SimpleCurve curve, float percent)
        {
            var inverse = 1f - percent;
            var first = inverse * inverse * curve.Begin;
            var second = 2f * inverse * percent * curve.Control;
            var third = percent * percent * curve.End;
            return first + second + third;
        }
    }
}
