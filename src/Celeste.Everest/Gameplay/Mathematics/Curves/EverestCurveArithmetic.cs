using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics;

namespace Celeste.Everest.Gameplay.Mathematics.Curves
{
    public sealed class EverestCurveArithmetic : ISourceCurveArithmetic
    {
        public Vector2 GetPoint(SimpleCurve curve, float percent)
        {
            var inverse = 1.0 - percent;
            var x = (float)(
                JITBarrier((float)(inverse * inverse)) * (double)curve.Begin.X
                + JITBarrier((float)(2.0 * inverse * percent)) * (double)curve.Control.X
                + JITBarrier((float)(percent * (double)percent)) * (double)curve.End.X);
            var y = (float)(
                JITBarrier((float)(inverse * inverse)) * (double)curve.Begin.Y
                + JITBarrier((float)(2.0 * inverse * percent)) * (double)curve.Control.Y
                + JITBarrier((float)(percent * (double)percent)) * (double)curve.End.Y);
            return new(x, y);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private float JITBarrier(float value)
        {
            return value;
        }
    }
}
