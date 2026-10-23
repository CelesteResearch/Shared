using Celeste.Core.Display;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public sealed class HoldableState : global::Celeste.Core.Components.SourceComponentState
    {
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public global::Celeste.Core.Scheduling.ISourceEngineContext EngineContext => engine;

        private global::Celeste.Core.Components.ISourceMutableEntityState CurrentEntity =>
            (global::Celeste.Core.Components.ISourceMutableEntityState)Entity;

        private global::Celeste.Physics.Collision.ISourceEntityCollider CurrentColliderEntity =>
            (global::Celeste.Physics.Collision.ISourceEntityCollider)Entity;

        public global::Celeste.Physics.Collision.Shapes.ColliderGeometry PickupCollider;
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
        public void SetCannotHoldTimerForQuery(float value) => CannotHoldTimer = value;
        public float GravityTimer { get; private set; }
        public int IdleDepth { get; private set; }
        public Vector2 StartPosition { get; private set; }

        public HoldableState(global::Celeste.Core.Scheduling.ISourceEngineContext engine, float cannotHoldDelay = .1f) :
            base(true, false)
        {
            this.engine = engine;
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
            bool result = global::Celeste.Physics.Collision.SourceEntityCollision.Check(player, entity);
            entity.Collider = collider;
            return result;
        }

        public override void DebugRender(global::Celeste.Core.Rendering.ISourceRenderContext context, object camera)
        {
            base.DebugRender(context, camera);
            if (PickupCollider == null) return;
            var entity = CurrentColliderEntity;
            var collider = entity.Collider;
            entity.Collider = PickupCollider;
            entity.Collider.Render(camera, new global::Celeste.Core.Display.PackedColor(255, 192, 203, 255),
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
            bool SolidAt(Vector2 at) =>
                global::Celeste.Scene.Entities.SourceTrackedEntityCollision.CheckAt(
                    ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                    (global::Celeste.Physics.Collision.ISourceEntityCollider)Entity, at);

            if (global::Celeste.Scene.Entities.SourceTrackedEntityCollision.First<object>(
                    ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                    (global::Celeste.Physics.Collision.ISourceEntityCollider)Entity) != null)
            {
                if (force.X != 0)
                {
                    bool found = false;
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

                while (global::Celeste.Scene.Entities.SourceTrackedEntityCollision.First<object>(
                           ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Entities, "Celeste.Solid",
                           (global::Celeste.Physics.Collision.ISourceEntityCollider)Entity) != null)
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
            if (CannotHoldTimer > 0) CannotHoldTimer -= engine.DeltaTime;
            if (GravityTimer > 0) GravityTimer -= engine.DeltaTime;
        }

        public void CheckAgainstColliders()
        {
            foreach (var component in ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Components
                     .GetTrackedComponents("Celeste.HoldableCollider"))
            {
                var collider = (HoldableColliderState)component;
                if (collider.Check(this)) collider.OnCollide(this);
            }
        }

        public bool Dangerous(object collider) => DangerousCheck?.Invoke(collider) ?? false;
        public void HitSeeker(object seeker) => OnHitSeeker?.Invoke(seeker);
        public void Swat(object collider, int direction) => OnSwat?.Invoke(collider, direction);
        public bool HitSpring(object spring) => OnHitSpring?.Invoke(spring) ?? false;
        public void HitSpinner(object spinner) => OnHitSpinner?.Invoke(spinner);
        public Vector2 GetSpeed() => SpeedGetter?.Invoke() ?? Vector2.Zero;
        public void SetSpeed(Vector2 value) => SpeedSetter?.Invoke(value);
    }
}
