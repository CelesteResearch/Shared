using System.Numerics;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public void Bounce(float fromY)
        {
            boostSequence.ReleaseCurrentBooster();
            var collider = Collider;
            Collider = World.Contacts.NormalHitbox;
            MoveVExact((int)(fromY - Bottom));
            if (!World.NoRefills) World.RefillDash();
            RefillStamina();
            Machine.State = 0;
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.Normal.VariableJumpTimer = .2f;
            Data.Motion.AutoJump = true;
            Data.AutoJumpTimer = .1f;
            Data.Motion.DashAttackTimer = 0f;
            Data.Motion.GliderBoostTimer = 0f;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.WallBoostTimer = 0f;
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y = -140f;
            Data.Motion.Launched = false;
            Rumble(0, 1);
            Sprite.Scale = new Vector2(.6f, 1.4f);
            Collider = collider;
        }
    }
}
