using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public struct SimpleCurve(Vector2 begin, Vector2 end, Vector2 control)
    {
        public Vector2 Begin = begin, End = end, Control = control;

        public Vector2 GetPoint(float percent, ISourceCurveArithmetic arithmetic)
        {
            return arithmetic.GetPoint(this, percent);
        }

        public float GetLengthParametric(int resolution, ISourceCurveArithmetic curveArithmetic,
            ISourceVectorArithmetic vectorArithmetic)
        {
            var vector = Begin;
            var num = 0f;
            for (var i = 1; i <= resolution; i++)
            {
                var point = curveArithmetic.GetPoint(this, i / (float)resolution);
                num += vectorArithmetic.Length(point - vector);
                vector = point;
            }

            return num;
        }
    }
}
