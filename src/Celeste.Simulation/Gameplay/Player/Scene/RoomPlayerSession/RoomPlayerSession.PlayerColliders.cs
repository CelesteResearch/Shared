using System.Numerics;
using Celeste.Core.Diagnostics.Collision;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public Bounds PlayerColliderBounds =>
            World.Contacts.HurtboxBoundsAt(Vector2.Zero);

        private void CheckPlayerColliders()
        {
            if (Dead || Machine.State == 21) return;
            var saved = World.Contacts.BeginPlayerColliderPass();
            var trackedComponents =
                ((ISourceScene)Scene).SourceScene.Components.GetTrackedComponents("Celeste.PlayerCollider");
            var collisionObserver =
                SourceRuntimeExtensions
                    .Get<ISourcePlayerCollisionObserver>(EngineContext);
            collisionObserver?.RecordCollider(this);
            foreach (var tracked in trackedComponents)
            {
                var component = (PlayerColliderComponentState)tracked;
                collisionObserver?.RecordCollider(component.Entity);
                collisionObserver?.RecordOtherPlayerColliders(this);
                if (component.Check(this) && Dead)
                {
                    World.Contacts.EndPlayerColliderPass(saved, true);
                    return;
                }
            }

            World.Contacts.EndPlayerColliderPass(saved, false);
        }
    }
}
