using System;

namespace Celeste.Scene.Scheduling
{
    public readonly struct SceneModeKey : IEquatable<SceneModeKey>
    {
        public int Value { get; }
        public SceneModeKey(int value) => Value = value;
        public static implicit operator SceneModeKey(int value) => new SceneModeKey(value);
        public static explicit operator int(SceneModeKey mode) => mode.Value;
        public static bool operator ==(SceneModeKey a, SceneModeKey b) => a.Value == b.Value;
        public static bool operator !=(SceneModeKey a, SceneModeKey b) => a.Value != b.Value;
        public bool Equals(SceneModeKey other) => Value == other.Value;
        public override bool Equals(object other) => other is SceneModeKey mode && Equals(mode);
        public override int GetHashCode() => Value;
        public override string ToString() => Value.ToString();
    }
}
