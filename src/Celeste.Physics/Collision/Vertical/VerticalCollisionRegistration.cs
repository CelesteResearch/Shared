using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Celeste.Physics.Collision.Vertical
{
    public static class VerticalCollisionRegistration
    {
        private static readonly ConditionalWeakTable<IVerticalOneWayCollisionWorld, RegistrationSet> Worlds = new();

        public static IDisposable Register(IVerticalOneWayCollisionWorld world, IVerticalOneWayCollider collider)
            => Worlds.GetValue(world, key => new RegistrationSet(key)).Add(collider);

        private sealed class RegistrationSet
        {
            private readonly IVerticalOneWayCollisionWorld world;
            private readonly List<IVerticalOneWayCollider> colliders = new();
            private readonly VerticalOneWayCollisionPolicy policy;

            public RegistrationSet(IVerticalOneWayCollisionWorld world)
            {
                this.world = world;
                policy = new VerticalOneWayCollisionPolicy(colliders);
            }

            public IDisposable Add(IVerticalOneWayCollider collider)
            {
                if (colliders.Count == 0)
                {
                    if (world.VerticalCollisionPolicy != null && world.VerticalCollisionPolicy != policy)
                        throw new InvalidOperationException(
                            "Vertical collision providers must share registrations.");
                    world.VerticalCollisionPolicy = policy;
                }

                colliders.Add(collider);
                policy.AddRegistration(collider);
                return new Registration(this, collider);
            }

            public void Remove(IVerticalOneWayCollider collider)
            {
                for (int index = 0; index < colliders.Count; index++)
                    if (ReferenceEquals(colliders[index], collider))
                    {
                        colliders.RemoveAt(index);
                        break;
                    }

                policy.RemoveRegistration(collider);
                if (colliders.Count == 0 && world.VerticalCollisionPolicy == policy)
                    world.VerticalCollisionPolicy = null;
            }
        }

        private sealed class Registration : IDisposable
        {
            private RegistrationSet owner;
            private readonly IVerticalOneWayCollider collider;

            public Registration(RegistrationSet owner, IVerticalOneWayCollider collider)
            {
                this.owner = owner;
                this.collider = collider;
            }

            public void Dispose()
            {
                var current = owner;
                if (current == null) return;
                owner = null;
                current.Remove(collider);
            }
        }
    }
}
