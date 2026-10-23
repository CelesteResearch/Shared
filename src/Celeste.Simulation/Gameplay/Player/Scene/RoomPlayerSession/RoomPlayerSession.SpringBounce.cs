using System;
using System.Numerics;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Core.Mathematics;
using Celeste.Simulation.Presentation.ScreenEffects;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        public void SuperBounce(float fromY)
        {
            boostSequence.ReleaseCurrentBooster();
            var collider = Collider;
            Collider = World.Contacts.NormalHitbox;
            MoveV(fromY - Bottom);
            if (!World.NoRefills) World.RefillDash();
            RefillStamina();
            Machine.State = 0;
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.Normal.VariableJumpTimer = .2f;
            Data.Motion.AutoJump = true;
            Data.AutoJumpTimer = 0f;
            Data.Motion.DashAttackTimer = 0f;
            Data.Motion.GliderBoostTimer = 0f;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.WallBoostTimer = 0f;
            Data.Motion.Normal.Speed.X = 0f;
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y = -185f;
            Data.Motion.Launched = false;
            ((ISourceLevelShakeScene)Scene).DirectionalShake(-Vector2.UnitY, .1f);
            ((ISourceRumbleEnvironment)engineContext).RumbleSession.Rumble(1, 1);
            Sprite.Scale = new Vector2(.5f, 1.5f);
            Collider = collider;
        }

        public bool SideBounce(int direction, float fromX, float fromY)
        {
            if (Math.Abs(Data.Motion.Normal.Speed.X) > 240f && Math.Sign(Data.Motion.Normal.Speed.X) == direction)
                return false;
            var collider = Collider;
            Collider = World.Contacts.NormalHitbox;
            MoveV(ScalarMath.Clamp(fromY - Bottom, -4f, 4f));
            if (direction > 0) MoveH(fromX - Left);
            else if (direction < 0) MoveH(fromX - Right);
            if (!World.NoRefills) World.RefillDash();
            RefillStamina();
            Machine.State = 0;
            Data.Motion.JumpGraceTimer = 0f;
            Data.Motion.Normal.VariableJumpTimer = .2f;
            Data.Motion.AutoJump = true;
            Data.AutoJumpTimer = 0f;
            Data.Motion.DashAttackTimer = 0f;
            Data.Motion.GliderBoostTimer = 0f;
            Data.Motion.WallSlideTimer = 1.2f;
            Data.Motion.ForceMoveX = direction;
            Data.Motion.ForceMoveXTimer = .3f;
            Data.Motion.WallBoostTimer = 0f;
            Data.Motion.Launched = false;
            Data.Motion.Normal.Speed.X = 240f * direction;
            Data.Motion.Normal.VariableJumpSpeed = Data.Motion.Normal.Speed.Y = -140f;
            ((ISourceLevelShakeScene)Scene).DirectionalShake(Vector2.UnitX * direction, .1f);
            ((ISourceRumbleEnvironment)engineContext).RumbleSession.Rumble(1, 1);
            Sprite.Scale = new Vector2(1.5f, .5f);
            Collider = collider;
            return true;
        }
    }
}
