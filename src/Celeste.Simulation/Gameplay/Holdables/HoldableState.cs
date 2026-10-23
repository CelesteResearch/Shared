using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public sealed class HoldableState : SourceComponentState
    {
        public ISourceEngineContext EngineContext { get; }

        private ISourceMutableEntityState CurrentEntity =>
            (ISourceMutableEntityState)Entity;

        private ISourceEntityCollider CurrentColliderEntity =>
            (ISourceEntityCollider)Entity;

        public ColliderGeometry PickupCollider;
        public Action OnPickup;
        public Action<Vector2> OnCarry, OnRelease;
        public Func<object, bool> DangerousCheck;
        public Action<object> OnHitSeeker, OnHitSpinner;
        public Action<object, int> OnSwat;
        public Func<object, bool> OnHitSpring;
        public Func<Vector2> SpeedGetter;
        public Action<Vector2> SpeedSetter;
        public bool SlowRun = true, SlowFall;
        public bool ScenePresent => Scene != null;
        public RoomPlayerSession Holder { get; private set; }
        public bool IsHeld => Holder != null;
        public bool ShouldHaveGravity => GravityTimer <= 0;
        public float CannotHoldDelay { get; set; }

        public float CannotHoldTimer { get; private set; }

        // TargetQuery may write Holdable.cannotHoldTimer directly through reflection in the original.
        // This is an interop seam for that exact field write; it does not add gameplay behaviour.
        public void SetCannotHoldTimerForQuery(float value)
        {
            CannotHoldTimer = value;
        }

        public float GravityTimer { get; private set; }
        public int IdleDepth { get; private set; }
        public Vector2 StartPosition { get; private set; }

        public HoldableState(ISourceEngineContext engine, float cannotHoldDelay = .1f) :
            base(true, false)
        {
            EngineContext = engine;
            CannotHoldDelay = cannotHoldDelay;
        }

        public override void Added(object entity)
        {
            base.Added(entity);
            StartPosition = CurrentEntity.Position;
        }

        public override void EntityRemoved(object scene)
        {
            base.EntityRemoved(scene);
            if (Holder != null) Holder.Holding.SetHolding(null);
        }

        public bool Check(RoomPlayerSession player)
        {
            var entity = CurrentColliderEntity;
            var collider = entity.Collider;
            if (PickupCollider != null) entity.Collider = PickupCollider;
            var result = SourceEntityCollision.Check(player, entity);
            entity.Collider = collider;
            return result;
        }

        public override void DebugRender(ISourceRenderContext context, object camera)
        {
            base.DebugRender(context, camera);
            if (PickupCollider == null) return;
            var entity = CurrentColliderEntity;
            var collider = entity.Collider;
            entity.Collider = PickupCollider;
            entity.Collider.Render(camera, new(255, 192, 203, 255),
                context);
            entity.Collider = collider;
        }

        public bool Pickup(RoomPlayerSession player)
        {
            if (CannotHoldTimer > 0 || Scene == null) return false;
            IdleDepth = CurrentEntity.Depth;
            CurrentEntity.Depth = player.Depth - 1;
            CurrentEntity.Visible = true;
            Holder = player;
            OnPickup?.Invoke();
            return true;
        }

        public void Carry(Vector2 position)
        {
            if (OnCarry != null) OnCarry(position);
            else CurrentEntity.Position = position;
        }

        public void Release(Vector2 force)
        {
            bool SolidAt(Vector2 at)
            {
                return SourceTrackedEntityCollision.CheckAt(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                    (ISourceEntityCollider)Entity, at);
            }

            if (SourceTrackedEntityCollision.First<object>(
                    ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                    (ISourceEntityCollider)Entity) != null)
            {
                if (force.X != 0)
                {
                    var found = false;
                    int sign = Math.Sign(force.X), distance = 0;
                    while (!found && distance++ < 10)
                        if (!SolidAt(CurrentEntity.Position + sign * distance * Vector2.UnitX))
                            found = true;
                    if (found)
                    {
                        var position = CurrentEntity.Position;
                        position.X += sign * distance;
                        CurrentEntity.Position = position;
                    }
                }

                while (SourceTrackedEntityCollision.First<object>(
                           ((ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                           (ISourceEntityCollider)Entity) != null)
                    CurrentEntity.Position += Vector2.UnitY;
            }

            CurrentEntity.Depth = IdleDepth;
            Holder = null;
            GravityTimer = .1f;
            CannotHoldTimer = CannotHoldDelay;
            OnRelease?.Invoke(force);
        }

        public override void Update()
        {
            base.Update();
            if (CannotHoldTimer > 0) CannotHoldTimer -= EngineContext.DeltaTime;
            if (GravityTimer > 0) GravityTimer -= EngineContext.DeltaTime;
        }

        public void CheckAgainstColliders()
        {
            foreach (var component in ((ISourceScene)Scene).SourceScene.Components
                     .GetTrackedComponents("Celeste.HoldableCollider"))
            {
                var collider = (HoldableColliderState)component;
                if (collider.Check(this)) collider.OnCollide(this);
            }
        }

        public bool Dangerous(object collider)
        {
            return DangerousCheck?.Invoke(collider) ?? false;
        }

        public void HitSeeker(object seeker)
        {
            OnHitSeeker?.Invoke(seeker);
        }

        public void Swat(object collider, int direction)
        {
            OnSwat?.Invoke(collider, direction);
        }

        public bool HitSpring(object spring)
        {
            return OnHitSpring?.Invoke(spring) ?? false;
        }

        public void HitSpinner(object spinner)
        {
            OnHitSpinner?.Invoke(spinner);
        }

        public Vector2 GetSpeed()
        {
            return SpeedGetter?.Invoke() ?? Vector2.Zero;
        }

        public void SetSpeed(Vector2 value)
        {
            SpeedSetter?.Invoke(value);
        }
    }
}
