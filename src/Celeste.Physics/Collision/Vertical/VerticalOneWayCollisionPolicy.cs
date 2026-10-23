using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Celeste.Physics.Collision.Vertical
{
    public sealed class VerticalOneWayCollisionPolicy
    {
        private readonly IReadOnlyList<IVerticalOneWayCollider> colliders;

        private readonly HashSet<IVerticalOneWayCollider> registrations = new(ColliderIdentityComparer.Instance);

        public VerticalOneWayCollisionPolicy(IReadOnlyList<IVerticalOneWayCollider> colliders)
        {
            this.colliders = colliders;
            for (var index = 0; index < colliders.Count; index++)
                registrations.Add(colliders[index]);
        }

        public bool IsRegistered(IVerticalOneWayCollider collider)
        {
            return registrations.Contains(collider);
        }

        internal void AddRegistration(IVerticalOneWayCollider collider)
        {
            registrations.Add(collider);
        }

        internal void RemoveRegistration(IVerticalOneWayCollider collider)
        {
            for (var index = 0; index < colliders.Count; index++)
                if (ReferenceEquals(colliders[index], collider))
                    return;
            registrations.Remove(collider);
        }

        private sealed class ColliderIdentityComparer : IEqualityComparer<IVerticalOneWayCollider>
        {
            public static readonly ColliderIdentityComparer Instance = new();

            public bool Equals(IVerticalOneWayCollider left, IVerticalOneWayCollider right)
            {
                return ReferenceEquals(left, right);
            }

            public int GetHashCode(IVerticalOneWayCollider collider)
            {
                return RuntimeHelpers.GetHashCode(collider);
            }
        }

        public IVerticalOneWayCollider FirstOutside(ISourceEntityCollider mover, Vector2 at,
            bool allowPositiveVerticalMovement = true)
        {
            for (var index = 0; index < colliders.Count; index++)
            {
                var other = colliders[index];
                if (other.AllowPositiveVerticalMovement == allowPositiveVerticalMovement &&
                    !SourceEntityCollision.Check(mover, other) && SourceEntityCollision.CheckAt(mover, other, at))
                    return other;
            }

            return null;
        }

        public bool AnyCheck(ISourceEntityCollider mover, bool allowPositiveVerticalMovement = true)
        {
            for (var index = 0; index < colliders.Count; index++)
            {
                var other = colliders[index];
                if (other.AllowPositiveVerticalMovement == allowPositiveVerticalMovement &&
                    SourceEntityCollision.Check(mover, other))
                    return true;
            }

            return false;
        }

        public bool AnyAt(ISourceEntityCollider mover, Vector2 at, bool allowPositiveVerticalMovement = true)
        {
            for (var index = 0; index < colliders.Count; index++)
            {
                var other = colliders[index];
                if (other.AllowPositiveVerticalMovement == allowPositiveVerticalMovement &&
                    SourceEntityCollision.CheckAt(mover, other, at))
                    return true;
            }

            return false;
        }

        public bool AnyOutside(ISourceEntityCollider mover, Vector2 at,
            bool allowPositiveVerticalMovement = true)
        {
            return FirstOutside(mover, at, allowPositiveVerticalMovement) != null;
        }
    }
}
