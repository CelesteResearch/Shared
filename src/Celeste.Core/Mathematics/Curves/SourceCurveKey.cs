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
            return new SourceCurveKey(Position, Value, TangentIn, TangentOut, Continuity);
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
            if (object.Equals(a, null))
            {
                return object.Equals(b, null);
            }

            if (object.Equals(b, null))
            {
                return object.Equals(a, null);
            }

            if (a.Position == b.Position && a.Value == b.Value && a.TangentIn == b.TangentIn &&
                a.TangentOut == b.TangentOut)
            {
                return a.Continuity == b.Continuity;
            }

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
