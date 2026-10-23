using System;

namespace Celeste.Scene.Scheduling
{
    public readonly struct SceneTagSet : IEquatable<SceneTagSet>
    {
        public int Bits { get; }

        public SceneTagSet(int bits)
        {
            Bits = bits;
        }

        public static implicit operator SceneTagSet(int bits)
        {
            return new(bits);
        }

        public static explicit operator int(SceneTagSet tags)
        {
            return tags.Bits;
        }

        public static SceneTagSet operator |(SceneTagSet a, SceneTagSet b)
        {
            return new(a.Bits | b.Bits);
        }

        public static SceneTagSet operator &(SceneTagSet a, SceneTagSet b)
        {
            return new(a.Bits & b.Bits);
        }

        public static SceneTagSet operator ~(SceneTagSet a)
        {
            return new(~a.Bits);
        }

        public static bool operator ==(SceneTagSet a, SceneTagSet b)
        {
            return a.Bits == b.Bits;
        }

        public static bool operator !=(SceneTagSet a, SceneTagSet b)
        {
            return a.Bits != b.Bits;
        }

        public bool Equals(SceneTagSet other)
        {
            return Bits == other.Bits;
        }

        public override bool Equals(object other)
        {
            return other is SceneTagSet tags && Equals(tags);
        }

        public override int GetHashCode()
        {
            return Bits;
        }

        public override string ToString()
        {
            return Bits.ToString();
        }
    }
}
