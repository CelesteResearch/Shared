using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Game.Execution.Levels;
using Celeste.Physics.Collision;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Holdables;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private void OnAttackPlayer(RoomPlayerSession player)
        {
            if (CurrentStateMachine.State != 4)
            {
                player.Die(engine.VectorArithmetic.SafeNormalize(player.Center - Position));
                return;
            }

            var collider = Collider;
            Collider = BounceHitbox;
            player.PointBounce(Center);
            Speed = engine.VectorArithmetic.SafeNormalize(Center - player.Center, 100f);
            scaleWiggler.Start();
            Collider = collider;
        }

        private void OnBouncePlayer(RoomPlayerSession player)
        {
            var collider = Collider;
            Collider = AttackHitbox;
            if (SourceEntityCollision.Check(this, player))
            {
                OnAttackPlayer(player);
            }
            else
            {
                player.Bounce(Top);
                GotBouncedOn(player);
            }

            Collider = collider;
        }

        private void GotBouncedOn(ISourceEntityCenter entity)
        {
            engine.Freeze(.15f);
            Speed = engine.VectorArithmetic.SafeNormalize(Center - entity.Center, 200f);
            CurrentStateMachine.State = 6;
            sprite.Scale = new(1.4f, .6f);
            ((OriginalLevelSceneRoot)Scene).Particles.Emit(engine.SeekerParticles.P_Stomp,
                8, Center - Vector2.UnitY * 5f, new(6f, 3f));
        }

        public void HitSpring()
        {
            Speed.Y = -150f;
        }

        private void OnHoldable(HoldableState holdable)
        {
            if (CurrentStateMachine.State != 6 && holdable.Dangerous(theo))
            {
                holdable.HitSeeker(this);
                CurrentStateMachine.State = 4;
                Speed = engine.VectorArithmetic.SafeNormalize(Center - ((ISourceEntityCenter)holdable.Entity).Center,
                    120f);
                scaleWiggler.Start();
            }
            else if ((CurrentStateMachine.State == 3 || CurrentStateMachine.State == 5) && holdable.IsHeld)
            {
                holdable.Swat(theo, Math.Sign(Speed.X));
                CurrentStateMachine.State = 4;
                Speed = engine.VectorArithmetic.SafeNormalize(Center - ((ISourceEntityCenter)holdable.Entity).Center,
                    120f);
                scaleWiggler.Start();
            }
        }
    }
}
