using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Holdables;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        private void OnAttackPlayer(RoomPlayerSession player)
        {
            if (State.State != 4)
            {
                player.Die(engine.VectorArithmetic.SafeNormalize(player.Center - Position));
                return;
            }

            ColliderGeometry collider = Collider;
            Collider = bounceHitbox;
            player.PointBounce(Center);
            Speed = engine.VectorArithmetic.SafeNormalize(Center - player.Center, 100f);
            scaleWiggler.Start();
            Collider = collider;
        }

        private void OnBouncePlayer(RoomPlayerSession player)
        {
            ColliderGeometry collider = Collider;
            Collider = attackHitbox;
            if (SourceEntityCollision.Check(this, player)) OnAttackPlayer(player);
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
            State.State = 6;
            sprite.Scale = new Vector2(1.4f, .6f);
            ((OriginalLevelSceneRoot)Scene).Particles.Emit(engine.SeekerParticles.P_Stomp,
                8, Center - Vector2.UnitY * 5f, new Vector2(6f, 3f));
        }

        public void HitSpring() => Speed.Y = -150f;

        private void OnHoldable(HoldableState holdable)
        {
            if (State.State != 6 && holdable.Dangerous(theo))
            {
                holdable.HitSeeker(this);
                State.State = 4;
                Speed = engine.VectorArithmetic.SafeNormalize(Center - ((ISourceEntityCenter)holdable.Entity).Center,
                    120f);
                scaleWiggler.Start();
            }
            else if ((State.State == 3 || State.State == 5) && holdable.IsHeld)
            {
                holdable.Swat(theo, System.Math.Sign(Speed.X));
                State.State = 4;
                Speed = engine.VectorArithmetic.SafeNormalize(Center - ((ISourceEntityCenter)holdable.Entity).Center,
                    120f);
                scaleWiggler.Start();
            }
        }
    }
}
