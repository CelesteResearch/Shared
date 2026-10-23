using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics;

namespace Celeste.Everest.Gameplay.Mathematics.Curves
{
    public sealed class EverestCurveArithmetic : ISourceCurveArithmetic
    {
        public Vector2 GetPoint(SimpleCurve curve, float percent)
        {
            double inverse = 1.0 - (double)percent;
            float x = (float)(
                (double)JITBarrier((float)(inverse * inverse)) * (double)curve.Begin.X
                + (double)JITBarrier((float)(2.0 * inverse * (double)percent)) * (double)curve.Control.X
                + (double)JITBarrier((float)((double)percent * (double)percent)) * (double)curve.End.X);
            float y = (float)(
                (double)JITBarrier((float)(inverse * inverse)) * (double)curve.Begin.Y
                + (double)JITBarrier((float)(2.0 * inverse * (double)percent)) * (double)curve.Control.Y
                + (double)JITBarrier((float)((double)percent * (double)percent)) * (double)curve.End.Y);
            return new Vector2(x, y);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private float JITBarrier(float value) => value;
    }
}
