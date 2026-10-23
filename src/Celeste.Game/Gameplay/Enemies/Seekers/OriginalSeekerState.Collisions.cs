using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Enemies.Seeker;

namespace Celeste.Game.Gameplay.Enemies.Seekers
{
    public partial class OriginalSeekerState
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        private void OnCollideH(PixelCollision data)
        {
            if (State.State == 3 && data.Hit != null)
            {
                int num = Math.Sign(Speed.X);
                if ((!CollideCheck("Celeste.Solid", Position + new Vector2(num, 4f)) && !MoveVExact(4)) ||
                    (!CollideCheck("Celeste.Solid", Position + new Vector2(num, -4f)) && !MoveVExact(-4)))
                {
                    return;
                }
            }

            if ((State.State == 3 || State.State == 5) && Math.Abs(Speed.X) >= 100f)
            {
                SlammedIntoWall(data);
            }
            else
            {
                Speed.X *= -0.2f;
            }
        }

        private void OnCollideV(PixelCollision data)
        {
            if (State.State == 3)
            {
                Speed.Y *= -0.6f;
            }
            else
            {
                Speed.Y *= -0.2f;
            }
        }
    }
}
