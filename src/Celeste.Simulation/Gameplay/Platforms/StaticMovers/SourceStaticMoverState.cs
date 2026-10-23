using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Simulation.Gameplay.Platforms.StaticMovers
{
    public class SourceStaticMoverState : SourceComponentState
    {
        public Func<SourceSolidEntityState, bool> SolidChecker;

        public Func<ISourceJumpThruEntity, bool> JumpThruChecker;

        public Action<Vector2> OnMove;

        public Action<Vector2> OnShake;

        public Action<ISourcePlatformEntity> OnAttach;

        public Action OnDestroy;

        public Action OnDisable;

        public Action OnEnable;

        public ISourcePlatformEntity Platform;

        public SourceStaticMoverState() : base(false, false)
        {
        }

        private ISourceMutableEntityState CurrentEntity => (ISourceMutableEntityState)Entity;

        public void Destroy()
        {
            if (OnDestroy != null)
                OnDestroy();
            else
                CurrentEntity.RemoveSelf();
        }

        public void Shake(Vector2 amount)
        {
            if (OnShake != null) OnShake(amount);
        }

        public virtual void MoveWithLiftSpeed(Vector2 amount, Vector2 liftSpeed)
        {
            Move(amount);
        }

        public void Move(Vector2 amount)
        {
            if (OnMove != null)
                OnMove(amount);
            else
                CurrentEntity.Position =
                    SourceVector2Math.Add(CurrentEntity.Position,
                        amount);
        }

        public bool IsRiding(SourceSolidEntityState solid)
        {
            if (SolidChecker != null) return SolidChecker(solid);

            return false;
        }

        public bool IsRiding(ISourceJumpThruEntity jumpThru)
        {
            if (JumpThruChecker != null) return JumpThruChecker(jumpThru);

            return false;
        }

        protected void AttachToPlatform(SourcePlatformEntityState platform)
        {
            platform.AttachStaticMover(this);
        }

        public void TriggerPlatform()
        {
            if (Platform != null) Platform.OnStaticMoverTrigger(this);
        }

        public void Disable()
        {
            if (OnDisable != null)
                OnDisable();
            else
                CurrentEntity.Active = CurrentEntity.Visible = CurrentEntity.Collidable = false;
        }

        public void Enable()
        {
            if (OnEnable != null)
                OnEnable();
            else
                CurrentEntity.Active = CurrentEntity.Visible = CurrentEntity.Collidable = true;
        }
    }
}
