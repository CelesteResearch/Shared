using System;

namespace Celeste.Scene.Scheduling
{
    public readonly struct SceneModeKey : IEquatable<SceneModeKey>
    {
        public int Value { get; }

        public SceneModeKey(int value)
        {
            Value = value;
        }

        public static implicit operator SceneModeKey(int value)
        {
            return new(value);
        }

        public static explicit operator int(SceneModeKey mode)
        {
            return mode.Value;
        }

        public static bool operator ==(SceneModeKey a, SceneModeKey b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(SceneModeKey a, SceneModeKey b)
        {
            return a.Value != b.Value;
        }

        public bool Equals(SceneModeKey other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object other)
        {
            return other is SceneModeKey mode && Equals(mode);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
