using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Celeste.Scene.Ownership
{
    public sealed class SceneObjectIdentityComparer : IEqualityComparer<object>
    {
        public static SceneObjectIdentityComparer Instance { get; } = new();

        private SceneObjectIdentityComparer()
        {
        }

        public new bool Equals(object left, object right)
        {
            return ReferenceEquals(left, right);
        }

        public int GetHashCode(object value)
        {
            return value == null ? 0 : RuntimeHelpers.GetHashCode(value);
        }
    }
}
