using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public struct SimpleCurve
    {
        public Vector2 Begin, End, Control;

        public SimpleCurve(Vector2 begin, Vector2 end, Vector2 control)
        {
            Begin = begin;
            End = end;
            Control = control;
        }

        public Vector2 GetPoint(float percent, ISourceCurveArithmetic arithmetic)
            => arithmetic.GetPoint(this, percent);

        public float GetLengthParametric(int resolution, ISourceCurveArithmetic curveArithmetic,
            ISourceVectorArithmetic vectorArithmetic)
        {
            Vector2 vector = Begin;
            float num = 0f;
            for (int i = 1; i <= resolution; i++)
            {
                Vector2 point = curveArithmetic.GetPoint(this, (float)i / (float)resolution);
                num += vectorArithmetic.Length(point - vector);
                vector = point;
            }

            return num;
        }
    }
}
