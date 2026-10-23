using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public static class CarryableActorMotionSteps
    {
        public static void AdvanceGroundSpeed(SourceActorEntityState actor, ISourceEngineContext engine,
            ref Vector2 speed, ref Vector2 previousLiftSpeed, ref float gravityDelay)
        {
            float target = !actor.OnGround(actor.Position + Vector2.UnitX * 3f)
                ? 20f
                : actor.OnGround(actor.Position - Vector2.UnitX * 3f)
                    ? 0f
                    : -20f;
            speed.X = ScalarMath.Approach(speed.X, target, 800f * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            Vector2 liftSpeed = actor.LiftSpeed;
            if (liftSpeed == Vector2.Zero && previousLiftSpeed != Vector2.Zero)
            {
                speed = previousLiftSpeed;
                previousLiftSpeed = Vector2.Zero;
                speed.Y = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(speed.Y * .6f, 0);
                if (speed.X != 0 && speed.Y == 0) speed.Y = -60;
                if (speed.Y < 0)
                {
                    gravityDelay = .15f;
                }
            }
            else
            {
                previousLiftSpeed = liftSpeed;
                if (liftSpeed.Y < 0 && speed.Y < 0) speed.Y = 0;
            }
        }

        public static void AdvanceAirSpeed(Celeste.Core.Scheduling.ISourceEngineContext engine,
            ref Vector2 speed, ref float gravityDelay, float terminalVelocity = 200f,
            float gravityMultiplier = 1f)
        {
            float num = 800f;
            if (Math.Abs(speed.Y) <= 30f)
            {
                num *= 0.5f;
            }

            float num2 = 350f;
            if (speed.Y < 0f)
            {
                num2 *= 0.5f;
            }

            speed.X = ScalarMath.Approach(speed.X, 0f, num2 * engine.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (gravityDelay > 0f)
            {
                gravityDelay -= engine.DeltaTime;
            }
            else
            {
                speed.Y = ScalarMath.Approach(speed.Y, terminalVelocity, num * engine.DeltaTime * gravityMultiplier,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
        }
    }
}
