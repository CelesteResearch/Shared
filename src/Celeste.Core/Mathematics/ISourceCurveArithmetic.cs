using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public interface ISourceCurveArithmetic
    {
        Vector2 GetPoint(SimpleCurve curve, float percent);
    }
}
