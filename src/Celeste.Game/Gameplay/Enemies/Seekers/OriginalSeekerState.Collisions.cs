using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Physics.Collision;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OnCollideH(PixelCollision data)
        {
            if (CurrentStateMachine.State == 3 && data.Hit != null)
            {
                var num = Math.Sign(Speed.X);
                if ((!CollideCheck("Celeste.Solid", Position + new Vector2(num, 4f)) && !MoveVExact(4)) ||
                    (!CollideCheck("Celeste.Solid", Position + new Vector2(num, -4f)) && !MoveVExact(-4)))
                    return;
            }

            if ((CurrentStateMachine.State == 3 || CurrentStateMachine.State == 5) && Math.Abs(Speed.X) >= 100f)
                SlammedIntoWall(data);
            else
                Speed.X *= -0.2f;
        }

        private void OnCollideV(PixelCollision data)
        {
            if (CurrentStateMachine.State == 3)
                Speed.Y *= -0.6f;
            else
                Speed.Y *= -0.2f;
        }
    }
}
