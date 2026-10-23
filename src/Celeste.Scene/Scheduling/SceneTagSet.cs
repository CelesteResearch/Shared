using System;

namespace Celeste.Scene.Scheduling
{
    public readonly struct SceneTagSet : IEquatable<SceneTagSet>
    {
        public int Bits { get; }
        public SceneTagSet(int bits) => Bits = bits;
        public static implicit operator SceneTagSet(int bits) => new SceneTagSet(bits);
        public static explicit operator int(SceneTagSet tags) => tags.Bits;
        public static SceneTagSet operator |(SceneTagSet a, SceneTagSet b) => new SceneTagSet(a.Bits | b.Bits);
        public static SceneTagSet operator &(SceneTagSet a, SceneTagSet b) => new SceneTagSet(a.Bits & b.Bits);
        public static SceneTagSet operator ~(SceneTagSet a) => new SceneTagSet(~a.Bits);
        public static bool operator ==(SceneTagSet a, SceneTagSet b) => a.Bits == b.Bits;
        public static bool operator !=(SceneTagSet a, SceneTagSet b) => a.Bits != b.Bits;
        public bool Equals(SceneTagSet other) => Bits == other.Bits;
        public override bool Equals(object other) => other is SceneTagSet tags && Equals(tags);
        public override int GetHashCode() => Bits;
        public override string ToString() => Bits.ToString();
    }
}
