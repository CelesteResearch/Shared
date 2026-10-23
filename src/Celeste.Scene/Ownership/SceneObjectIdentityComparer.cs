using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Celeste.Scene.Ownership
{
    public sealed class SceneObjectIdentityComparer : IEqualityComparer<object>
    {
        public static SceneObjectIdentityComparer Instance { get; } = new SceneObjectIdentityComparer();

        private SceneObjectIdentityComparer()
        {
        }

        public new bool Equals(object left, object right) => ReferenceEquals(left, right);
        public int GetHashCode(object value) => value == null ? 0 : RuntimeHelpers.GetHashCode(value);
    }
}
