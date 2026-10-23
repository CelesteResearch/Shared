using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Simulation.Gameplay.Holdables
{
    public static class GliderMotion
    {
        public static void AdvanceSpeed(SourceActorEntityState actor, ISourceEngineContext engine, HoldableState hold,
            ref Vector2 speed, ref Vector2 previousLiftSpeed, ref float gravityDelay, float highFrictionTimer,
            ref Vector2 wind)
        {
            if (actor.OnGround())
                CarryableActorMotionSteps.AdvanceGroundSpeed(actor, engine, ref speed, ref previousLiftSpeed,
                    ref gravityDelay);
            else if (hold.ShouldHaveGravity)
            {
                float gravity = 200;
                if (speed.Y >= -30) gravity *= .5f;
                float friction = speed.Y < 0 ? 40 : !(highFrictionTimer <= 0) ? 10 : 40;
                speed.X = ScalarMath.Approach(speed.X, 0, friction * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (gravityDelay > 0) gravityDelay -= engine.DeltaTime;
                else if (wind.Y < 0)
                    speed.Y = ScalarMath.Approach(speed.Y, 0, gravity * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                else
                    speed.Y = ScalarMath.Approach(speed.Y, 30, gravity * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
        }
    }
}
