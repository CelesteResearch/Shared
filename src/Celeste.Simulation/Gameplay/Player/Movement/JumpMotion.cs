using System;
using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Movement
{
    public static class JumpMotion
    {
        public static Vector2 LiftBoost(Vector2 liftSpeed)
        {
            if (Math.Abs(liftSpeed.X) > 250f) liftSpeed.X = 250f * Math.Sign(liftSpeed.X);
            if (liftSpeed.Y > 0f) liftSpeed.Y = 0f;
            else if (liftSpeed.Y < -130f) liftSpeed.Y = -130f;
            return liftSpeed;
        }
    }
}
