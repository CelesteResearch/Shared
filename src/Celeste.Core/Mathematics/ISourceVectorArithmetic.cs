using System.Numerics;

namespace Celeste.Core.Mathematics
{
    public interface ISourceVectorArithmetic
    {
        float Length(Vector3 value);
        float LengthSquared(Vector3 value);
        float Dot(Vector3 first, Vector3 second);
        float Distance(Vector3 first, Vector3 second);
        float DistanceSquared(Vector3 first, Vector3 second);
        Vector3 Normalize(Vector3 value);
        Vector3 Divide(Vector3 value, float divisor);

        float Length(Vector2 value);
        float LengthSquared(Vector2 value);
        float Dot(Vector2 first, Vector2 second);
        float Distance(Vector2 first, Vector2 second);
        float DistanceSquared(Vector2 first, Vector2 second);
        Vector2 Normalize(Vector2 value);
        Vector2 Divide(Vector2 value, float divisor);
        Vector2 SafeNormalize(Vector2 value);
        Vector2 SafeNormalize(Vector2 value, float length);
        Vector2 SafeNormalize(Vector2 value, Vector2 ifZero);
        Vector2 SafeNormalize(Vector2 value, Vector2 ifZero, float length);
        Vector2 Rotate(Vector2 value, float radians);
        Vector2 RotateTowards(Vector2 value, float targetAngle, float maxMove);
        Vector2 ClosestPointOnLine(Vector2 lineA, Vector2 lineB, Vector2 point);
        Vector2 Approach(Vector2 value, Vector2 target, float maxMove);
        Vector3 SafeNormalize(Vector3 value);
    }
}
