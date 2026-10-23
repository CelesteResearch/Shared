using System;

namespace Celeste.Core.Mathematics.Curves
{
    [Serializable]
    public class SourceCurveKey : IEquatable<SourceCurveKey>, IComparable<SourceCurveKey>
    {
        public SourceCurveContinuity Continuity { get; set; }

        public float Position { get; private set; }

        public float TangentIn { get; set; }

        public float TangentOut { get; set; }

        public float Value { get; set; }

        public SourceCurveKey(float position, float value)
            : this(position, value, 0f, 0f, SourceCurveContinuity.Smooth)
        {
        }

        public SourceCurveKey(float position, float value, float tangentIn, float tangentOut)
            : this(position, value, tangentIn, tangentOut, SourceCurveContinuity.Smooth)
        {
        }

        public SourceCurveKey(float position, float value, float tangentIn, float tangentOut,
            SourceCurveContinuity continuity)
        {
            Position = position;
            Value = value;
            TangentIn = tangentIn;
            TangentOut = tangentOut;
            Continuity = continuity;
        }

        public SourceCurveKey Clone()
        {
            return new(Position, Value, TangentIn, TangentOut, Continuity);
        }

        public int CompareTo(SourceCurveKey other)
        {
            return Position.CompareTo(other.Position);
        }

        public bool Equals(SourceCurveKey other)
        {
            return this == other;
        }

        public static bool operator !=(SourceCurveKey a, SourceCurveKey b)
        {
            return !(a == b);
        }

        public static bool operator ==(SourceCurveKey a, SourceCurveKey b)
        {
            if (Equals(a, null)) return Equals(b, null);

            if (Equals(b, null)) return Equals(a, null);

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (a.Position == b.Position && /* ReSharper disable once CompareOfFloatsByEqualityOperator */ a.Value == b.Value && /* ReSharper disable once CompareOfFloatsByEqualityOperator */ a.TangentIn == b.TangentIn &&
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                a.TangentOut == b.TangentOut)
                return a.Continuity == b.Continuity;

            return false;
        }

        public override bool Equals(object obj)
        {
            return obj as SourceCurveKey == this;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode() ^ Value.GetHashCode() ^ TangentIn.GetHashCode() ^ TangentOut.GetHashCode() ^
                   Continuity.GetHashCode();
        }
    }
}
